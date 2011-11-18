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
        Map _map = null;
        List<string> layerList = new List<string>();
        int polygonSelectIndex;
        int lineSelectIndex;
        IFeatureSet inputPolygon = null;
        IFeatureSet inputLine = null;
        FeatureSet output = new FeatureSet();
        bool cbChecked = true;
        bool input1Selected = false;
        bool input2Selected = false;

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

            //Populate the comboboxes with lists from the cetacean form
            getLayers();
        }

        #region Methods

        //Method to get user selected variables from Split Tracks form
       private void getLayers()
        {
            try
            {
                layerList.Clear();  //  clears layerList

                //  Gets the collection of polygon and line layers from the map
                IMapPolygonLayer[] polygonLayers = _map.GetPolygonLayers();
                IMapLineLayer[] lineLayers = _map.GetLineLayers();

                //  Gets a count for each type of layer
                int polygonCount = polygonLayers.Count();
                int lineCount = lineLayers.Count();


                if (polygonCount > 0 && lineCount > 0)
                {
                    for (int i = 0; i < _map.Layers.Count; i++)  //  Loops through each map layer
                    {
                        IMapLayer layer = _map.Layers[i];

                        if (polygonLayers.Contains(layer))  //  If layer is a polygon layer
                        {
                            cmbGrid.Items.Add(layer.LegendText);//  adds the legendText of the layer to the combobox for user polygon selection
                        }

                        if (lineLayers.Contains(layer))
                        {
                            cmbLine.Items.Add(layer.LegendText);
                        }

                        //*********IMPORTANT**********
                        //  It is imporant to add each map layer to the layerList.  The layer list holds the map index and legend text for each of the 
                        //  map layers.  This is how the user selected items in the comboboxes (referred to by their legendText) can be associated with the 
                        //  correct map layer (by index)
                        layerList.Insert(i, layer.LegendText);
                    }
                }
                else
                {
                    //  Alerts the user and closes the form if there are no polygon or point layers in the map.
                    MessageBox.Show("For this operation, a track and a grid shapefile must be loaded into the map.", "Entry Error");
                    this.Close();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Entry Error.  Please check the values entered and try again.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.GetType().ToString() + "\n" + ex.StackTrace, "Exception");
                return;
            }

        }

        //Get the polygon grid layer index based on the user selection
        private void cmbGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPolygonItem = cmbGrid.SelectedItem.ToString();
            polygonSelectIndex = layerList.IndexOf(selectedPolygonItem);
            inputPolygon = (IFeatureSet)_map.Layers[polygonSelectIndex].DataSet;
            input1Selected = true;
            if (input1Selected && input2Selected)
            {
                btnSplit.Enabled = true;
            }
        }

        //Get the track line layer index based on user selection
        private void cmbLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedLineItem = cmbLine.SelectedItem.ToString();
            lineSelectIndex = layerList.IndexOf(selectedLineItem);
            inputLine = (IFeatureSet)_map.Layers[lineSelectIndex].DataSet;
            input2Selected = true;
            if (input1Selected && input2Selected)
            {
                btnSplit.Enabled = true;
            }
        }

        //Split the form
        private void btnSplit_Click_1(object sender, EventArgs e)
        {
            try
            {
                    //Create a temporary file to hold the intersection of 
                    IFeatureSet tempOutput = inputLine.Intersection(inputPolygon, FieldJoinType.All, null);
                    tempOutput.Projection = inputLine.Projection;

                    if (tempOutput == null)
                    {
                        return;
                    }
                    tempOutput.DataTable.Columns.Add(new DataColumn("TrackLength", typeof(double)));
                    calculateTrackDistance(tempOutput);
                    output = (FeatureSet)tempOutput;
                   
                    //Adding to the Map

                    if (cbChecked == true)
                    {
                        Functions saveObject = new Functions();
                        saveObject.saveFile(output);
                        if (saveObject.saved)
                        {
                            DialogResult result = MessageBox.Show("Split track operation successful.  A new shapefile has been created." +
                            tempOutput.Filename + ".\n\nWould you like to add the file to the map?", "Operation Successful - File Saved",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                            //  If the user clicks "Yes", the saved file is added as a new polygon layer on the map.
                            if (result == DialogResult.Yes)
                            {
                                 string text = txtInput.Text;
                                 MapLineLayer lineIntersectLayer = new MapLineLayer(tempOutput);
                                 lineIntersectLayer.LegendText = text;
                                 lineIntersectLayer.Symbolizer.SetFillColor(Color.Blue);
                                 _map.Layers.Add(lineIntersectLayer);
                                 _map.ResetBuffer();
                            }
                        }
                    }

                    else 
                    {
                        DialogResult result = MessageBox.Show("Split track operation successful, however the file has not been saved.", "Operation Successful");
                        string text = txtInput.Text;
                        MapLineLayer lineIntersectLayer = new MapLineLayer(tempOutput);
                        lineIntersectLayer.LegendText = text;
                        lineIntersectLayer.Symbolizer.SetFillColor(Color.Blue);
                        _map.Layers.Add(lineIntersectLayer);
                        _map.ResetBuffer();               
                    }

                    this.Close();
                }
          
            catch (FormatException)
            {
                MessageBox.Show("Entry Error.  Please check the values entered and try again.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            catch (DuplicateNameException dup)
            {
                MessageBox.Show(dup.Message + "\n\n" + dup.GetType().ToString() + "\n\nIt appears that this operation has already been performed using the same input.", "Exception");
                        return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.GetType().ToString() + "\n" + ex.StackTrace, "Exception");
                return;
            }
        }

        #endregion
        #region distance methods
        //Calculates the track distance for each line feature within a featureset
        public void calculateTrackDistance(IFeatureSet inputFeatureSet)
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

        private void cbxSave_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSave.Checked == true)
            {
                cbChecked = true;
            }
            else
            {
                cbChecked = false;
            }
        }

    }
}

