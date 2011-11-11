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
    public partial class frmCountSpecies : Form
    {

        #region "Class Variables"

        Map _map = null;
        List<string> layerList = new List<string>();
        int input1SelectIndex = 0;
        int input2SelectIndex = 0;
        bool speciesCount = true;
        string polygonIDField = null;
        string speciesCountField = null;
        string addedFields = null;
        string newField1 = null;
        string newField2 = null;

        #endregion

        public frmCountSpecies(Map map)
        {
            _map = map;
            InitializeComponent();
        }

        public frmCountSpecies()
        {
            InitializeComponent();
        }

        private void frmCountSpecies_Load(object sender, EventArgs e)
        {
            cmbInput1.Items.Clear();
            cmbInput2.Items.Clear();
            getLayers();
        }

        #region Methods

        //Method to get user selected layers from CountSpecies form.
        private void getLayers()
        {
            layerList.Clear();  //clears layerList

            //  Gets the collection of polygon and point layers from the map
            IMapPolygonLayer[] polygonLayers = _map.GetPolygonLayers();
            IMapPointLayer[] pointLayers = _map.GetPointLayers();

            //  Gets a count for each type of layer
            int polygonCount = polygonLayers.Count();
            int pointCount = pointLayers.Count();

            //  Checks to make sure at least one polygon and one point layer are added to the map.
            if (polygonCount > 0 && pointCount > 0)
            {
                for (int i = 0; i < _map.Layers.Count; i++)  //  Loops through each map layer
                {
                    IMapLayer layer = _map.Layers[i];

                    if (polygonLayers.Contains(layer))  //  If layer is a polygon layer
                    {
                        cmbInput1.Items.Add(layer.LegendText);  //  adds the legendText of the layer to the combobox for user polygon selection

                        //  Checks to make sure there is a polygonID associated with each feature.  If not, assigns "polygonID"
                        IFeatureSet inputPolygon = (IFeatureSet)_map.Layers[i].DataSet;

                        if (!inputPolygon.DataTable.Columns.Contains("polygonID") && !inputPolygon.DataTable.Columns.Contains("POLYGONID"))
                        {
                            inputPolygon.AddFid();  //  Adds FID
                            inputPolygon.DataTable.Columns["FID"].ColumnName = "polygonID"; //  Changes FID column name.
                        }
                    }

                    if (pointLayers.Contains(layer))  //  If layer is a point layer
                    {
                        cmbInput2.Items.Add(layer.LegendText);  //  adds the legendText of the layer to the combobox for user point selection

                        //  Checks to make sure there is a pointID associated with each feature.  If not, assigns "pointID".
                        IFeatureSet inputPoint = (IFeatureSet)_map.Layers[i].DataSet;

                        if (!inputPoint.DataTable.Columns.Contains("pointID") && !inputPoint.DataTable.Columns.Contains("POINTID"))
                        {
                            inputPoint.AddFid();  //  Adds FID
                            inputPoint.DataTable.Columns["FID"].ColumnName = "pointID"; //  Changes FID column name.
                        }
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
                MessageBox.Show("For the join operation, make sure that you have a polygon shapefile and a point shapefile loaded in the map.");
                this.Close();
            }
        }
        
        private void cmbInput1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //Creates a new string to hold the value of the selected item.
            //The input1SelectIndex is assigned as the index of the selected item in the LayerList.
            string selectedItem = cmbInput1.SelectedItem.ToString();
            input1SelectIndex = layerList.IndexOf(selectedItem);

            cmbField.Items.Clear();

            //New IFeatureSet using the map layer at the specified index.
            IFeatureSet polyFS = (IFeatureSet)_map.Layers[input1SelectIndex].DataSet;

            //Loops through each of the columns and adds the ColumnName to the cmbField combo box.
            foreach (DataColumn col in polyFS.DataTable.Columns)
            {
                cmbField.Items.Add(col.ColumnName);
            }
        }

        //Same methodology as cmbInput1
        private void cmbInput2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedItem2 = cmbInput2.SelectedItem.ToString();
            input2SelectIndex = layerList.IndexOf(selectedItem2);
            cmbSpecies.Items.Clear();
            IFeatureSet inputPoint = (IFeatureSet)_map.Layers[input2SelectIndex].DataSet;
            foreach (DataColumn col in inputPoint.DataTable.Columns)
            {
                cmbSpecies.Items.Add(col.ColumnName);
            }
        }

        private void cmbField_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //Sets the polygonIDField as the string value of the selected item in cmbField.
            polygonIDField = cmbField.SelectedItem.ToString();
        }

        private void cmbSpecies_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //Sets the speciesCountField as the string value of the selected item in cmbSpecies
            speciesCountField = cmbSpecies.SelectedItem.ToString();
        }

        private void btnCalculate_Click_1(object sender, EventArgs e)
        {
            //Check to make sure layers are different
            if (input1SelectIndex != input2SelectIndex)
            {
                try
                {
                    IFeatureSet inputPolygon = (IFeatureSet)_map.Layers[input1SelectIndex].DataSet;
                    IFeatureSet inputPoint = (IFeatureSet)_map.Layers[input2SelectIndex].DataSet;

                    //Creates a new field using the user input from the textbox and adds it to the polygon DataTable
                    newField1 = txtSightings.Text;
                    System.Data.DataColumn sightingsCol = new System.Data.DataColumn(newField1, typeof(int));

                    //  Checks to make sure the Data table does not already contain the name.
                    if (inputPolygon.DataTable.Columns.Contains(sightingsCol.ColumnName))
                    {
                        MessageBox.Show("The field name " + "'" + sightingsCol.ColumnName +
                            "' already exists in the data table.\n\nPlease enter a different field name for the Number of Sightings.",
                            "Input Error");
                        return;
                    }
                    else
                    {
                        inputPolygon.DataTable.Columns.Add(sightingsCol);
                        addedFields += "\n\n\t" + newField1;
                    }


                    //If the checkbox remains checked, the speciesCount variable is true.
                    //The new field for species per polygon is added to the datatable.
                    if (ckbIncludeTotalSpecis.Checked)
                    {
                        newField2 = txtSpeciesCount.Text;
                        System.Data.DataColumn speciesCountCol = new System.Data.DataColumn(newField2, typeof(int));
                        if (inputPolygon.DataTable.Columns.Contains(speciesCountCol.ColumnName))
                        {
                            MessageBox.Show("The field name " + "'" + speciesCountCol.ColumnName +
                                "' already exists in the data table.\n\nPlease enter a different field name for the Species Count.",
                                "Input Error");
                            return;
                        }
                        else
                        {
                            inputPolygon.DataTable.Columns.Add(speciesCountCol);
                            addedFields += "\n\n\t" + newField2;
                        }
                    }

                    //A temporary IFeatureSet is created to hold the interesection data between the point and polygon files.
                    IFeatureSet tempOutput = inputPoint.Intersection(inputPolygon, FieldJoinType.All, null);

                    //initializes a new list to hold polygonID's
                    List<int> polygonIDList = new List<int>();

                    //loops through the tempOutput DataTable and populates the polygonIDList with unique polygonID's.
                    foreach (DataRow row in tempOutput.DataTable.Rows)
                    {
                        int polygonID = Convert.ToInt32(row[polygonIDField]);
                        if (!polygonIDList.Contains(polygonID))
                        {
                            polygonIDList.Add(polygonID);
                        }
                    }

                    //loops through each ID in the polygonIDList
                    foreach (int ID in polygonIDList)
                    {
                        //initializes a new list called sightingsList
                        List<int> sightingsList = new List<int>();

                        //loops through each tempOutput feature.
                        foreach (Feature fe in tempOutput.Features)
                        {
                            //assigns feID the value in "polygonID" column of tempOutput.
                            int feID = Convert.ToInt32(fe.DataRow[polygonIDField]);

                            //if the polygonID matches the ID from the polygonIDList, the value 
                            //  in speciesCountField is added to the sightingsList
                            if (feID == ID)
                            {
                                int sighting = Convert.ToInt32(fe.DataRow[speciesCountField]);
                                sightingsList.Add(sighting);
                            }
                        }

                        //totalSpecies count if speciesCount is true.
                        int sightingCount = sightingsList.Count;
                        int totalSpeciesCount = 0;
                        if (ckbIncludeTotalSpecis.Checked)
                        {
                            totalSpeciesCount = sightingsList.Sum();
                        }

                        //loops through the inputPolygon DataTable 
                        foreach (DataRow row in inputPolygon.DataTable.Rows)
                        {
                            int feLineID = Convert.ToInt32(row[polygonIDField]);

                            //If the polygonID in the feature matches the polygonID in the tempOutput
                            if (feLineID == ID)
                            {
                                //Number of sightings are added to the inputPolygon table for the associated polygonID
                                row[newField1] = sightingCount;

                                //If speciesCount is true, the totalSpeciesCount is also added to the table.
                                if (ckbIncludeTotalSpecis.Checked)
                                {
                                    row[newField2] = totalSpeciesCount;
                                }
                            }
                        }
                    }


                    this.Close(); //  Closes the form

                    if (radOriginal.Checked)  //  If user checks the box to save the attributes to the original shapefile.
                    {
                        DialogResult result = MessageBox.Show("The polygon grid attributes have been updated.\n\nNew Fields:" + addedFields
                        + "\n\nAre you sure you want to save the changes to the original shapefile?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                        if (result == DialogResult.Yes)
                        {
                            FeatureSet savePolygon = (FeatureSet)inputPolygon;
                            inputPolygon.Save();

                            MessageBox.Show("The updated attributes have been saved to the original shapefile:\n\n" +
                            inputPolygon.Filename, "File Saved");
                        }
                        if (result == DialogResult.No)
                        {
                            MessageBox.Show("The updated attributes have not been saved.", "File Not Saved");
                            return;
                        }
                    }

                    if (radNewShape.Checked)  // If user checks the box to save the attributes to a new shapefile.
                    {
                        //  output FeatureSet is declared
                        FeatureSet output = new FeatureSet(FeatureType.Polygon);
                        //  output is equal to the pointInput
                        output = (FeatureSet)inputPolygon;

                        //  Calls the saveFile method
                        Functions saveObj = new Functions();
                        saveObj.saveFile(output);

                        if (saveObj.saved)
                        {
                            //  Alerts the user that the file has been saved.
                            //  Asks the user if they would like to add the saved file to the map.
                            DialogResult result = MessageBox.Show("The updated attributes have been saved to the new file " +
                                output.Filename + ".\n\nWould you like to add the new file to the map?", "File Saved",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                            //  If the user clicks "Yes", the saved file is added as a new point layer on the map.
                            if (result == DialogResult.Yes)
                            {
                                MapPolygonLayer newPolygonLayer = new MapPolygonLayer(output);
                                string filename = output.Filename;
                                //  the new point layer receives the name it was saved as.
                                int index = filename.LastIndexOf("\\");
                                string legendText = filename.Substring(index + 1);
                                newPolygonLayer.LegendText = legendText;
                                newPolygonLayer.Projection = _map.Projection;
                                _map.Layers.Add(newPolygonLayer);
                                _map.ResetBuffer();
                            }
                        }
                    }  
                }
                catch
                {
                    MessageBox.Show("Please check the values entered and try again.", "Entry Error");
                }

            }
            else
            {
                //Check to make sure selection is different
                MessageBox.Show("The selected layers must be different", "Selection Error");
                cmbInput1.Focus();
                return;
            }
        }
        #endregion
    }
}