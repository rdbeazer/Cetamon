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
        bool Input1Selected = false;
        bool Input2Selected = false;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.GetType().ToString() + "\n" + ex.StackTrace, "Exception");
            }     
        }
           
        //Select the polygon grid layer index
        private void cmbGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGridItem = cmbInputGrid.SelectedItem.ToString();
            gridSelectIndex = layerList.IndexOf(selectedGridItem);
            inputGrid = (IFeatureSet)_map.Layers[gridSelectIndex].DataSet;
            Input2Selected = true;
            if (Input1Selected && Input2Selected)
            {
                btnCalculate.Enabled = true;
            }
        }

        //Select the track line layer index
        private void cmbLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTrackID.Items.Clear();
            cmbTrackLength.Items.Clear();
            string selectedLineItem = cmbTrack.SelectedItem.ToString();
            trackSelectIndex = layerList.IndexOf(selectedLineItem);
            

            inputTrack = (IFeatureSet)_map.Layers[trackSelectIndex].DataSet;
            foreach (DataColumn col in inputTrack.DataTable.Columns)
            {
                cmbTrackID.Items.Add(col.ColumnName);
                cmbTrackLength.Items.Add(col.ColumnName);
            }
            string idName = "PolygonID";
            if (cmbTrackID.Items.Contains(idName))
            {
                cmbTrackID.Text = "";
                cmbTrackID.SelectedText = idName;
                polygonIDSelect = idName;
            }
            string lengthName = "TrackLength";
            if (cmbTrackLength.Items.Contains(lengthName))
            {
                cmbTrackLength.Text = "";
                cmbTrackLength.SelectedText = lengthName;
                trackLengthSelect = lengthName;
            }
            Input1Selected = true;
            if (Input1Selected && Input2Selected)
            {
                btnCalculate.Enabled = true;
            }

        }

        private void cmbTrackID_SelectedIndexChanged(object sender, EventArgs e)
        {
            polygonIDSelect = Convert.ToString(cmbTrackID.SelectedItem);
        }

         private void cmbTrackArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            trackLengthSelect = Convert.ToString(cmbTrackLength.SelectedItem);
        }

         private void btnCalculate_Click(object sender, EventArgs e)
         {
             try
             {
                 //Requirement #6 Functionality-------------------------------------------------------------
                 //Create and add new column to the track attribute table to hold the track effort value
                 System.Data.DataColumn trackEffort = new System.Data.DataColumn(txtTrack.Text, typeof(decimal));
                 

                 if (inputGrid.DataTable.Columns.Contains(trackEffort.ColumnName))
                 {
                     //  Alerts the user that the field name already exists and gives the option of changing the 
                     //  field name or overwriting the data in the field.
                     DialogResult result = MessageBox.Show("The field name " + "'" + trackEffort.ColumnName +
                         "' already exists in the data table.\n\nWould you like to over-write the existing field?",
                         "Input Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                     if (result == DialogResult.Yes) { }
                     if (result == DialogResult.No)
                     {
                         MessageBox.Show("Please rename the length field", "Rename Field");

                         txtTrack.Focus();
                         return;
                     }
                 }

                 else
                 {
                     inputGrid.DataTable.Columns.Add(trackEffort);
                 }

                 //initializes a new list to hold polygonID's
                 //Uses string so ID can hold letters and numbers
                 List<string> polygonIDList = new List<string>();

                 //loops through the track DataTable and populates the polygonIDList with unique polygonID's.  
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
                     //Look in the inputTrack DataTable
                     foreach (Feature fe in inputTrack.Features)
                     {
                         string feID = Convert.ToString(fe.DataRow[polygonIDSelect]);
                         //If the inputTrack polygon ID and the inputGrid polygon ID match, add the lengths to the sum for that polygon
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
                 //Update the data to show a zero value instead of a blank
                 foreach (DataRow row in inputGrid.DataTable.Rows)
                 {
                     if (row[txtTrack.Text].ToString() == "")
                     {
                         row[txtTrack.Text] = 0;
                     }
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

             this.Close();
             
             //Saving Options

            if(radOriginal.Checked)
            {
                try
                {
                    inputGrid.Save();
                    MessageBox.Show("The input grid attributes have been updated with the track area data and saved." +
                    "\n|n File Location: " + inputGrid.Filename, "Update Successful");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.GetType().ToString() + "\n" + ex.StackTrace, "Exception");
                    return;
                }
            }

            else if (radNewShape.Checked)
            {
                try
                {
                    FeatureSet output = new FeatureSet(FeatureType.Polygon);
                    output = (FeatureSet)inputGrid;
                    Functions saveObject = new Functions();
                    saveObject.saveFile(output);
                    //  Alerts the user that the file has been saved.
                    //  Asks the user if they would like to add the saved file to the map.  
                    DialogResult result = MessageBox.Show("The updated attributes have been saved to the new file " +
                        output.Filename + ".\n\n Would you like to add the new file to the map?", "File Saved",
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.GetType().ToString() + "\n" + ex.StackTrace, "Exception");
                    return;
                }
            }

            else
            {
                MessageBox.Show("The input grid attributes have been updated with the track area data.", "Update Successful");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

         private void btnInputTrack_Click(object sender, EventArgs e)
         {
             MessageBox.Show("This tool allows the user to take track lengths and add them to the \n" +
             "attribute table of a polygon grid layer for survey effort calculations.  \n\n" +
             "Please select the track layer to input into this function here. \n" +
             "Other selections for the track input are based on fields in the attribute table. \n\n" +
             "The grid shapefile required is the same polygon shapefile that has been used to segment the survey tracks.","Tool Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 
         }
        #endregion
    }
}
