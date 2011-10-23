using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotSpatial.Controls;
using DotSpatial.Topology;
using DotSpatial.Data;
using DotSpatial.Symbology;
using DotSpatial.Projections;

namespace Cetecean
{
  
    public partial class frmSplitTrack : Form
    {
#region Class Level Variables
        Map _map = null;
        List<string> layerList1 = new List<string>();
        List<string> layerList2 = new List<string>();
        int polygonSelectIndex = 0;
        int lineSelectIndex = 0;

        //Create output FS to hold the joined tables
        FeatureSet output = new FeatureSet();

#endregion


        public frmSplitTrack()
        {
            InitializeComponent();
        }

        public frmSplitTrack(Map map)
        {
            _map = map;
            InitializeComponent();
        }

        private void frmSplitTrack_Load_1(object sender, EventArgs e)
        {
            //Clear the combobox items from any previous runs
            cmbGrid.Items.Clear();
            cmbLine.Items.Clear();

            getLayers();

            //Populate the comboboxes with lists from the cetacean form
            cmbGrid.DataSource = layerList1; //Polygon
            cmbLine.DataSource = layerList2; //Line
        }

        #region Methods

        //Method to get user selected variables from Split Tracks form
        private void getLayers()
        {
            //clears layerLists
            layerList1.Clear();
            layerList2.Clear();

            //loops through the map layers and adds them to the layerLists.
            //These lists will be used to populate the combo boxes.
            if (_map.Layers.Count > 1)
            {
                for (int i = 0; i < _map.Layers.Count; i++)
                {
                    string title = _map.Layers[i].LegendText;

                    //Checking file types-------------------------
                    IFeatureSet checkType = (IFeatureSet)_map.Layers[i].DataSet;

                    if (checkType.FeatureType == FeatureType.Polygon)
                    {
                        layerList1.Insert(i, title);
                    }
                    //Note - for some unknown reason, this else if statement ruins the functionality
                    //else if (checkType.FeatureType == FeatureType.Line)
                    //{
                        layerList2.Insert(i, title);
                    //}
                }
            }
            else
            {
                MessageBox.Show("Please add a layer to the map");
                return;
            }
        }      
 
        //Get the polygon grid layer index based on the user selection
        private void cmbGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            polygonSelectIndex = cmbGrid.SelectedIndex;
        }

        //Get the track line layer index based on user selection
        private void cmbLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            lineSelectIndex = cmbLine.SelectedIndex;
        }

        //Split the form
        private void btnSplit_Click_1(object sender, EventArgs e)
        {
            try
            {
                //check to make sure selections are different
                if (polygonSelectIndex != lineSelectIndex)
                {
                    //Get the input line and polygon based on the index of the user selection from the combo box
                    IFeatureSet inputLine = (IFeatureSet)_map.Layers[lineSelectIndex].DataSet;
                    IFeatureSet inputPolygon = (IFeatureSet)_map.Layers[polygonSelectIndex].DataSet;
                    
                        //Set output feature to a line
                        output.FeatureType = inputLine.FeatureType;

                        //Create a temporary file to hold the intersection of 
                        IFeatureSet tempOutput = inputLine.Intersection(inputPolygon, FieldJoinType.All, null);

                        //Create new datacolumns from the merging file to the output file 
                        foreach (DataColumn inputLineColumn in tempOutput.DataTable.Columns)
                        {
                            output.DataTable.Columns.Add(new DataColumn(inputLineColumn.ColumnName, inputLineColumn.DataType));
                        }

                        ////Calculate each track distance and add to the table
                        calculateTrackDistance(tempOutput, output);

                        saveFile(output);

                        //Creates a new MapLineLayer using the output featureset
                        MapLineLayer lineIntersectLayer = new MapLineLayer(output);

                        //Sets Legend and Symbolizer properties.
                        lineIntersectLayer.LegendText = "Split survey tracks";
                        lineIntersectLayer.Symbolizer.SetFillColor(Color.Red);

                        _map.Layers.Add(lineIntersectLayer);
                        _map.ResetBuffer();
                        //Alerts the user that the attributes have been updated.
                        MessageBox.Show("The selected track layer has been segmented by the selected grid layer", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    
                }
                else
                {
                    //Check to make sure selection is different
                    MessageBox.Show("The selected layers must be different", "Selection Error");
                    cmbGrid.Focus();
                    return;
                }
            }
            catch
            {
                //Catch calculation errors
                MessageBox.Show("Make sure the grid selection is a polygon shapefile and the track selection is a line shapefile.", "Execution Error");
            }
        }


        public int getPolygonIndex()
        {
            return polygonSelectIndex;
        }

        public int getLineIndex()
        {
            return lineSelectIndex;
        }

        //Save file dialog
        private void saveFile(FeatureSet output)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "shapefile files (*.shp)|*.shp";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Save Split Tracks";
            string strFileName = "";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                strFileName = dialog.FileName;
            }

            if (strFileName == String.Empty)
            {
                // MessageBox.Show("The Split Tracks file won't be saved");
                return;
            }
            else
            {
                output.SaveAs(strFileName, true);
            }
           
         }
        //Calculates the track distance for each line feature within a featureset
        public void calculateTrackDistance(IFeatureSet inputFeatureSet, FeatureSet outputFeatureSet)
        {

            foreach (Feature fe in inputFeatureSet.Features)
            {
                double trackDistance = 0;
                //declares a coordinate array and populates it with the coordinates from each feature fe.
                Coordinate[] coord = (Coordinate[])fe.Coordinates;

                //fills each data row with the appropriate lat or lon coordinate.
                fe.DataRow["StartLat"] = coord[0].Y;
                fe.DataRow["StartLon"] = coord[0].X;
                fe.DataRow["EndLat"] = coord[1].Y;
                fe.DataRow["EndLon"] = coord[1].X;

                //re-calculates the survey line length using the coordinates from above and the GetDistance method.
                trackDistance = GetDistance(coord[0].Y, coord[1].Y, coord[0].X, coord[1].X);
                fe.DataRow["TrackLength"] = trackDistance;

                //adds feature fe to FeatureSet output.
                outputFeatureSet.Features.Add(fe);
            }

        }

        //Method calculates the distance between two coordinate locations.
        public double GetDistance(double Lat1, double Lat2, double long1, double long2)
        {
            double distance = Double.MinValue;
            //converts decimal degrees to radians
            double Lat1InRad = Lat1 * (Math.PI / 180.0);
            double Long1InRad = long1 * (Math.PI / 180.0);
            double Lat2InRad = Lat2 * (Math.PI / 180.0);
            double Long2InRad = long2 * (Math.PI / 180.0);

            double Longitude = Long2InRad - Long1InRad;
            double Latitude = Lat2InRad - Lat1InRad;

            double a = Math.Pow(Math.Sin(Latitude / 2.0), 2.0) + Math.Cos(Lat1InRad) * Math.Cos(Lat2InRad) * Math.Pow(Math.Sin(Longitude / 2.0), 2.0);
            double c = 2.0 * Math.Asin(Math.Sqrt(a));

            const Double kEarthRadiusKms = 6376.5;
            distance = kEarthRadiusKms * c;
            double roundDist = Math.Round(distance, 2);
            return roundDist;
        }

        #endregion

    }
}
