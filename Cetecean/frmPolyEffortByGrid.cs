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
    public partial class frmPolyEffortByGrid : Form
    {
        #region Class Level Variables
        Map _map = null;
        List<string> layerList = new List<string>();
        string polygonIDSelect;
        string trackLengthSelect;
        int gridSelectIndex = 0;
        int trackSelectIndex = 0;
        IFeatureSet inputGrid = null;
        IFeatureSet inputTrack = null;
        FeatureSet output = new FeatureSet();
        decimal trackLengthSum;
        #endregion

        public frmPolyEffortByGrid()
        {
            InitializeComponent();
        }

        public frmPolyEffortByGrid(Map map)
        {
            _map = map;
            InitializeComponent();
        }

        private void frmPolyEffortByGrid_Load(object sender, EventArgs e)
        {
            //Clear the combobox items from any previous runs
            cmbInputGrid.Items.Clear();
            cmbTrack.Items.Clear();
            cmbTrackID.Items.Clear();

            //Populate the comboboxes with lists from the cetacean form
           getLayers();

        }

        #region Methods
        //Method to get user selected variables from Split Tracks form
        private void getLayers()
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
                        cmbInputGrid.Items.Add(layer.LegendText);//  adds the legendText of the layer to the combobox for user polygon selection
                    }

                    if (lineLayers.Contains(layer))  
                    {
                        cmbTrack.Items.Add(layer.LegendText);  
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
           
        //Select the polygon grid layer index
        private void cmbGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGridItem = cmbInputGrid.SelectedItem.ToString();
            gridSelectIndex = layerList.IndexOf(selectedGridItem);
            inputGrid = (IFeatureSet)_map.Layers[gridSelectIndex].DataSet;
        }

        //Select the track line layer index
        private void cmbLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedLineItem = cmbTrack.SelectedItem.ToString();
            trackSelectIndex = layerList.IndexOf(selectedLineItem);
            cmbTrackID.Items.Clear();
            inputTrack = (IFeatureSet)_map.Layers[trackSelectIndex].DataSet;
            foreach (DataColumn col in inputTrack.DataTable.Columns)
            {
                cmbTrackID.Items.Add(col.ColumnName);
                cmbTrackArea.Items.Add(col.ColumnName);
            }
        }

        private void cmbTrackID_SelectedIndexChanged(object sender, EventArgs e)
        {
            polygonIDSelect = Convert.ToString(cmbTrackID.SelectedItem);
        }

         private void cmbTrackArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            trackLengthSelect = Convert.ToString(cmbTrackArea.SelectedItem);
        }

         private void btnCalculate_Click(object sender, EventArgs e)
         {
             try
             {
                 //Requirement #10 Functionality-------------------------------------------------------------
                 //Create and add new column to the swathe attribute table to hold the swathe effort value
                 System.Data.DataColumn trackEffort = new System.Data.DataColumn(txtTrack.Text, typeof(decimal));
                 inputGrid.DataTable.Columns.Add(trackEffort);

                 //initializes a new list to hold polygonID's
                 //Uses string so ID can hold letters and numbers
                 List<string> polygonIDList = new List<string>();

                 //loops through the Swathe DataTable and populates the polygonIDList with unique polygonID's.  
                 foreach (DataRow row in inputTrack.DataTable.Rows)
                 {
                     //Gets the selected column from the user for the polygon ID
                     string polygonID = Convert.ToString(row[polygonIDSelect]);
                     //If the polygonIDList doesn't have the ID loaded, add it now
                     if (!polygonIDList.Contains(polygonID))
                     {
                         polygonIDList.Add(polygonID);
                     }
                 }

                 //loops through the list to find matches
                 foreach (string ID in polygonIDList)
                 {
                     //Look in the inputSwathe DataTable
                     foreach (Feature fe in inputTrack.Features)
                     {
                         string feID = Convert.ToString(fe.DataRow[polygonIDSelect]);

                         if (ID == feID)
                         {
                             decimal polygonTrackLength = Convert.ToDecimal(fe.DataRow[trackLengthSelect]);
                             trackLengthSum += polygonTrackLength;
                         }

                     }

                     foreach (Feature grid in inputGrid.Features)
                     {
                         string polygonID = Convert.ToString(grid.DataRow[polygonIDSelect]);

                         if (polygonID == ID)
                         {
                             grid.DataRow[txtTrack.Text] = trackLengthSum;
                         }

                     }
                     trackLengthSum = 0;
                }
             }
             catch
             {
                 MessageBox.Show("Entry Error.  Please check the values entered and try again.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 return;
             }

             this.Close();
             
             //Saving Options

            if(radOriginal.Checked)
            {
                inputGrid.Save();
                MessageBox.Show("The input grid attributes have been updated with the swathe area data and saved." +
                "\n|n File Location: " + inputGrid.Filename, "Update Successful");
            }

            else if (radNewShape.Checked)
            {
                FeatureSet output = new FeatureSet(FeatureType.Polygon);
                output = (FeatureSet)inputGrid;
                saveFile(output);
                //  Alerts the user that the file has been saved.
                //  Asks the user if they would like to add the saved file to the map.  
                DialogResult result = MessageBox.Show("The updated attributes have been saved to the new file " +
                    output.Filename + ".\n\nWould you like to add the new file to the map?", "File Saved",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                //  If the user clicks "Yes", the saved file is added as a new polygon layer on the map.
                if (result == DialogResult.Yes)
                {
                    MapPolygonLayer newPolygonLayer = new MapPolygonLayer(output);
                    string filename = output.Filename;
                    //  The new polygon layer receives the name it was saved as.
                    int index = filename.LastIndexOf("\\");
                    string legendText = filename.Substring(index + 1);
                    newPolygonLayer.LegendText = legendText;
                    _map.Layers.Add(newPolygonLayer);
                    _map.ResetBuffer();
                }
            }

            else
            {
                MessageBox.Show("The input grid attributes have been updated with the swathe area data.", "Update Successful");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveFile(FeatureSet output)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "shapefile files (*.shp)|*.shp";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Save";
            string strFileName = "";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                strFileName = dialog.FileName;
            }

            if (strFileName == String.Empty)
            {
                MessageBox.Show("The file will not be saved");
                return;
            }
            else
            {
                output.SaveAs(strFileName, true);
            }
        }
               

         private void btnInputTrack_Click(object sender, EventArgs e)
         {
             MessageBox.Show("This tool allows the user to take track lengths and add them to the \n" +
             "attribute table of a polygon grid layer for survey effort calculations.  \n\n" +
             "Please select the track layer to input into this function here.","Tool Help");
                 
         }
         #region oldCalculate
        // private void btnCalculate_Click(object sender, EventArgs e)
        //{
        //    if (gridSelectIndex != trackSelectIndex)
        //    {
        //        //Uses selected layers for functionality
        //        IFeatureSet inputTrack = (IFeatureSet)_map.Layers[trackSelectIndex].DataSet;
        //        IFeatureSet inputGrid = (IFeatureSet)_map.Layers[gridSelectIndex].DataSet;

        //        //creates new DataColumn "lineLengthCol" and
        //        //adds the column to the inputPolygon DataTable
        //        System.Data.DataColumn trackLengthCol = new System.Data.DataColumn("Sum_Tracks", typeof(double));
        //        inputGrid.DataTable.Columns.Add(trackLengthCol);

        //        //initializes a new list to hold polygonID's
        //        List<string> polygonIDList = new List<string>();

        //        //loops through the inputLine DataTable and populates the polygonIDList with unique polygonID's.
        //        foreach (DataRow row in inputTrack.DataTable.Rows)
        //        {
        //            string polygonID = Convert.ToString(row[trackIDSelect]);
        //            if (!polygonIDList.Contains(polygonID))
        //            {
        //                polygonIDList.Add(polygonID);
        //            }
        //        }

        //        //loops through each ID in the polygonIDList
        //        foreach (string ID in polygonIDList)
        //        {
        //            //initializes a new list called lineLengths
        //            List<double> trackLengths = new List<double>();

        //            //loops through each inputLine feature and if the polygonID in the feature matches the ID in the 
        //            //polygonIDList, it collects the Survey Line Length for the feature and adds it to the LineLengths list.
        //            foreach (Feature fe in inputTrack.Features)
        //            {
        //                string feID = Convert.ToString(fe.DataRow[trackIDSelect]);

        //                if (String.ReferenceEquals(feID,ID))
        //                {
        //                    double trackLength = Convert.ToDouble(fe.DataRow["TrackLength"]);
        //                    trackLengths.Add(trackLength);
        //                }
        //            }

        //            //calculates the sum of all the lines in the lineLengths list and rounds to three decimal places.
        //            double trackLengthSum = Math.Round(trackLengths.Sum(), 3);

        //            //loops through the inputPolygon DataTable and if the "polygonID" matches the polygonID from the 
        //            //inputLine feature, the lineLength Sum is added to the "Sum_Tracks" column in the inputPolygon DataTable.
        //            foreach (DataRow row in inputGrid.DataTable.Rows)
        //            {
        //                string fetrackID = Convert.ToString(row[polygonIDSelect]);

        //                if (string.ReferenceEquals(fetrackID,ID))
        //                {
        //                    row["Sum_Tracks"] = trackLengthSum;
        //                }
        //                else
        //                {
        //                    row["Sum_Tracks"] = 0;
        //                }
        //            }


        //        }
        //        //Alerts the user that the attributes have been updated.
        //        MessageBox.Show("The polygon grid attributes have been updated.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        this.Close();
        //    }
        //    else
        //    {
        //        //Check to make sure selection is different
        //        MessageBox.Show("The selected layers must be different", "Selection Error");
        //        cmbInputGrid.Focus();
        //        return;
        //    }
        //}
#endregion
        #endregion







    }
}
