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
            //clears layerList
            layerList.Clear();

            //loops through the map layers
            if (_map.Layers.Count > 1)
            {
                for (int i = 0; i < _map.Layers.Count; i++)
                {
                    string title = _map.Layers[i].LegendText;

                    //Checking file types-------------------------
                    IFeatureSet checkType = (IFeatureSet)_map.Layers[i].DataSet;

                    //If the Feature type is polygon, adds to cmbInput1
                    if (checkType.FeatureType == FeatureType.Polygon)
                    {
                        cmbInput1.Items.Add(title);
                    }
                    //If the FeatureType is point, adds to cmbInput2
                    else if (checkType.FeatureType == FeatureType.Point)
                    {
                        cmbInput2.Items.Add(title);
                    }

                    //Adds each layer and its index to LayerList.  **Used later to reference the layers by index.
                    layerList.Insert(i, title);
                }
            }
            else
            {
                MessageBox.Show("Please add a layer to the map");
                return;
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

        //Changes speciesCount to false if the box is unchecked.  The field for species count will not be added to the layer.
        private void ckbIncludeTotalSpecis_CheckedChanged_1(object sender, EventArgs e)
        {
            speciesCount = false;
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

                IFeatureSet inputPolygon = (IFeatureSet)_map.Layers[input1SelectIndex].DataSet;
                IFeatureSet inputPoint = (IFeatureSet)_map.Layers[input2SelectIndex].DataSet;

                //Creates a new field using the user input from the textbox and adds it to the polygon DataTable
                newField1 = txtSightings.Text;
                System.Data.DataColumn sightingsCol = new System.Data.DataColumn(newField1, typeof(int));
                inputPolygon.DataTable.Columns.Add(sightingsCol);
                addedFields = "\n\n\t" + newField1;

                //If the checkbox remains checked, the speciesCount variable is true.
                //The new field for species per polygon is added to the datatable.
                if (speciesCount == true)
                {
                    newField2 = txtSpeciesCount.Text;
                    System.Data.DataColumn speciesCountCol = new System.Data.DataColumn(newField2, typeof(int));
                    inputPolygon.DataTable.Columns.Add(speciesCountCol);
                    addedFields += "\n\n\t" + newField2;
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
                    if (speciesCount == true)
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
                            if (speciesCount == true)
                            {
                                row[newField2] = totalSpeciesCount;
                            }
                        }
                    }
                }

                //Alerts the user that the attributes have been updated and asks for approval to save the feature.
                MessageBox.Show("The polygon grid attributes have been updated.\n\nNew Fields:" + addedFields
                    + "\n\nWould you like to save the shapefile?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (DialogResult == DialogResult.Yes)
                {
                    inputPolygon.Save();
                }
                this.Close();
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