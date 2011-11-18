using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
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
        bool input1Selected = false;
        bool input2Selected = false;
        bool fieldSelected = false;

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
            try
            {
                cmbInput1.Items.Clear();
                cmbInput2.Items.Clear();
                getLayers();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please check the values entered and try again.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.GetType().ToString() + "\n\n" + ex.StackTrace, "Exception");
                return;
            }
        }

        #region Methods

        //Method to get user selected layers from CountSpecies form.
        private void getLayers()
        {
            try
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
            catch (FormatException)
            {
                MessageBox.Show("Please check the values entered and try again.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.GetType().ToString() + "\n\n" + ex.StackTrace, "Exception");
                return;
            }
        }
        
        private void cmbInput1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                //Creates a new string to hold the value of the selected item.
                //The input1SelectIndex is assigned as the index of the selected item in the LayerList.
                string selectedItem = cmbInput1.SelectedItem.ToString();
                input1SelectIndex = layerList.IndexOf(selectedItem);

                input1Selected = true;
                if (input1Selected && input2Selected && fieldSelected)  // Enables Calculate button if all selections have been made.
                {
                    btnCalculate.Enabled = true;
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Please check the values entered and try again.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.GetType().ToString() + "\n\n" + ex.StackTrace, "Exception");
                return;
            }
        }

        //Same methodology as cmbInput1
        private void cmbInput2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                string selectedItem2 = cmbInput2.SelectedItem.ToString();
                input2SelectIndex = layerList.IndexOf(selectedItem2);
                cmbSpecies.Items.Clear();
                IFeatureSet inputPoint = (IFeatureSet)_map.Layers[input2SelectIndex].DataSet;
                foreach (DataColumn col in inputPoint.DataTable.Columns)
                {
                    cmbSpecies.Items.Add(col.ColumnName);
                }

                cmbSpecies.SelectedItem = "Number";

                input2Selected = true;

                if (input1Selected && input2Selected && fieldSelected)
                {
                    btnCalculate.Enabled = true;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please check the values entered and try again.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.GetType().ToString() + "\n\n" + ex.StackTrace, "Exception");
                return;
            }
        }

        private void cmbSpecies_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                //Sets the speciesCountField as the string value of the selected item in cmbSpecies
                speciesCountField = cmbSpecies.SelectedItem.ToString();
                fieldSelected = true;

                if (input1Selected && input2Selected && fieldSelected)
                {
                    btnCalculate.Enabled = true;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please check the values entered and try again.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.GetType().ToString() + "\n\n" + ex.StackTrace, "Exception");
                return;
            }
        }

        private void btnCalculate_Click_1(object sender, EventArgs e)
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
                    //  Alerts the user that the field name already exists and gives the option of changing the 
                    //  field name or overwriting the data in the field.
                    DialogResult result = MessageBox.Show("The field name " + "'" + sightingsCol.ColumnName +
                        "' already exists in the " + inputPolygon.Name + " data table.\n\nWould you like to over-write the existing field?",
                        "Input Error", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes) { }
                    if (result == DialogResult.No)
                    {
                        MessageBox.Show("Please rename the sightings field and try again.");
                        txtSightings.Focus();
                        return;
                    }
                }
                else
                {
                    inputPolygon.DataTable.Columns.Add(sightingsCol);
                    addedFields += "\n\n\t" + "'" + newField1 + "'";
                }

                if (ckbIncludeTotalSpecis.Checked) // Total species count checkbox is checked.
                {
                    newField2 = txtSpeciesCount.Text;
                    System.Data.DataColumn speciesCountCol = new System.Data.DataColumn(newField2, typeof(int));

                    //  Checks to see if the field name already exists in the table.
                    if (inputPolygon.DataTable.Columns.Contains(speciesCountCol.ColumnName))
                    {
                        //  Alerts the user that the field name already exists and gives the option of changing the 
                        //  field name or overwriting the data in the field.
                        DialogResult result = MessageBox.Show("The field name " + "'" + speciesCountCol.ColumnName +
                            "' already exists in the data table.\n\nWould you like to over-write the existing field?",
                            "Input Error", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (result == DialogResult.Yes) { }
                        if (result == DialogResult.No)
                        {
                            MessageBox.Show("Please rename the species count field and try again.");
                            txtSpeciesCount.Focus();
                            return;
                        }
                    }
                    //  If the field name doesn't already exist, it adds the field to the datatable.
                    else
                    {
                        inputPolygon.DataTable.Columns.Add(speciesCountCol);
                        addedFields += "\n\n\t" + "'" + newField2 + "'";
                    }
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

                        //if the polygonID matches the ID from the polygonIDList, the value 
                        //  in speciesCountField is added to the sightingsList
                        if (feID == ID)
                        {
                            int sighting = Convert.ToInt32(fe.DataRow[speciesCountField]);
                            sightingsList.Add(sighting);
                        }
                    }

                    // Gets sighting count from sightings list.
                    int sightingCount = sightingsList.Count;
                    // Initializes variable total species count.
                    int totalSpeciesCount = 0;
                    // If total species checked, returns sum as total species count.
                    if (ckbIncludeTotalSpecis.Checked)
                    {
                        totalSpeciesCount = sightingsList.Sum();
                    }

                    //loops through the inputPolygon DataTable 
                    foreach (DataRow row in inputPolygon.DataTable.Rows)
                    {
                        int feLineID = Convert.ToInt32(row["polygonID"]);

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

                    foreach (Feature feature in inputPolygon.Features)
                    {
                        if (feature.DataRow[newField1] is DBNull)
                        {
                            feature.DataRow[newField1] = 0;
                            feature.DataRow[newField2] = 0;
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
                            string file = Path.GetFileNameWithoutExtension(output.Filename);
                            newPolygonLayer.LegendText = file;
                            newPolygonLayer.Projection = _map.Projection;
                            _map.Layers.Add(newPolygonLayer);
                            _map.ResetBuffer();
                        }
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please check the values entered and try again.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.GetType().ToString() + "\n\n" + ex.StackTrace, "Exception");
                return;
            }
        }
        #endregion

        private void ckbIncludeTotalSpecis_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ckbIncludeTotalSpecis.Checked == false)
                {
                    lblSpeciesCount.Visible = false;
                    txtSpeciesCount.Visible = false;
                }
                else
                {
                    lblSpeciesCount.Visible = true;
                    txtSpeciesCount.Visible = true;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please check the values entered and try again.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.GetType().ToString() + "\n\n" + ex.StackTrace, "Exception");
                return;
            }
        }
    }
}