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
         List<string> layerList1 = new List<string>(20);
         List<string> layerList2 = new List<string>(20);
         int input1SelectIndex = 0;
         int input2SelectIndex = 0;
         bool speciesCount = false;

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

            cmbInput1.DataSource = layerList1;
            cmbInput2.DataSource = layerList2;

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

                    //if (checkType.FeatureType == FeatureType.Polygon)
                    //{
                        
                        layerList1.Insert(i, title);
                        
                    //}
                    ////Note - for some unknown reason, this else if statement ruins the functionality
                    //if (checkType.FeatureType == FeatureType.Point)
                    //{
                        layerList2.Insert(i, title);
                       
                        //layerList2.Add(title);
                    //}
                }
            }
            else
            {
                MessageBox.Show("Please add a layer to the map");
                return;
            }
        }

        private void cmbInput1_SelectedIndexChanged(object sender, EventArgs e)
        {
            input1SelectIndex = cmbInput1.SelectedIndex;
        }

        private void cmbInput2_SelectedIndexChanged(object sender, EventArgs e)
        {
            input2SelectIndex = cmbInput2.SelectedIndex;
        }

        private void ckbIncludeTotalSpecis_CheckedChanged(object sender, EventArgs e)
        {
            speciesCount = true;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (input1SelectIndex != input2SelectIndex)
            {
                //Uses selected layers for functionality
                IFeatureSet inputPolygon = (IFeatureSet)_map.Layers[input1SelectIndex].DataSet;
                IFeatureSet inputPoint = (IFeatureSet)_map.Layers[input2SelectIndex].DataSet;

                //Creates a new column "Sightings" and adds it to the polygon grid DataTable
                System.Data.DataColumn sightingsCol = new System.Data.DataColumn("Sightings", typeof(int));
                inputPolygon.DataTable.Columns.Add(sightingsCol);

                ////Sets the speciesCount variable from the boolean value assigned in the speciesCount Form.
                //this.speciesCount = speciesCountForm.getCheckedValue();
                //if the checkbox was checked, the "true" value is passed and a another new column for SpeciesCount
                //is created and added to the polygon grid DataTable.
                if (speciesCount == true)
                {
                    System.Data.DataColumn speciesCountCol = new System.Data.DataColumn("SpeciesCount", typeof(int));
                    inputPolygon.DataTable.Columns.Add(speciesCountCol);
                }

                //A temporary IFeatureSet is created to hold the interesection data between the point and polygon files.
                IFeatureSet tempOutput = inputPoint.Intersection(inputPolygon, FieldJoinType.All, null);

                //initializes a new list to hold polygonID's
                List<int> polygonIDList = new List<int>();

                //loops through the tempOutput DataTable and populates the polygonIDList with unique polygonID's.
                foreach (DataRow row in tempOutput.DataTable.Rows)
                {
                    int polygonID = Convert.ToInt32(row["polygonID"]);
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
                        int feID = Convert.ToInt32(fe.DataRow["polygonID"]);

                        //if the polygonID matches the ID from the polygonIDList, the value in the "Number" column is added 
                        //to the sightingsList
                        if (feID == ID)
                        {
                            int sighting = Convert.ToInt32(fe.DataRow["Number"]);
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

                    //loops through the inputPolygon DataTable and if the "polygonID" matches the polygonID from the 
                    //tempOutput DataTable, the number of sightings are added to the polygon grid file for the associated
                    //polygonID.  totalSpeciesCount is also added if the value is set to true.
                    foreach (DataRow row in inputPolygon.DataTable.Rows)
                    {
                        int feLineID = Convert.ToInt32(row["polygonID"]);

                        if (feLineID == ID)
                        {
                            row["Sightings"] = sightingCount;
                            if (speciesCount == true)
                            {
                                row["SpeciesCount"] = totalSpeciesCount;
                            }
                        }
                    }
                }

                //Alerts the user that the attributes have been updated.
                MessageBox.Show("The polygon grid attributes have been updated.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
