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
    public partial class frmJoinPolygonsToPoints : Form
    {
        #region "Class Variables"
        Map _map = null;
        List<string> layerList = new List<string>();
        int input1SelectIndex = 0;
        int input2SelectIndex = 0;
        string pointIDField = "pointID";
        bool Input1Selected = false;
        bool Input2Selected = false;
        #endregion

        public frmJoinPolygonsToPoints()
        {
            InitializeComponent();
        }

        public frmJoinPolygonsToPoints(Map map)
        {
            _map = map;
            InitializeComponent();
        }

        private void frmJoinPolygonsToPoints_Load(object sender, EventArgs e)
        {
            try
            {
                cmbInput2.Items.Clear();
                cmbInput1.Items.Clear();
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
        //  Method to get the map layers and populate the user selection controls in the form
        private void getLayers()
        {
            try
            {
                layerList.Clear();  //  clears layerList

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
                            cmbInput2.Items.Add(layer.LegendText);  //  adds the legendText of the layer to the combobox for user polygon selection

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
                            cmbInput1.Items.Add(layer.LegendText);  //  adds the legendText of the layer to the combobox for user point selection

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

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                //  Initializes a new list to hold the selectedFields from clsFields.
                List<string> selectedFields = new List<string>();
                foreach (string field in clsFields.CheckedItems)  //  Loops through each of the checked fields
                {
                    selectedFields.Add(field);  //  Adds the checked fields to the selectedFields list.
                }

                if (selectedFields.Count < 1)
                {
                    MessageBox.Show("No fields were selected to join.\n\nPlease select at least one field to join and try again.", "Input Error");
                    clsFields.Focus();
                    return;
                }

                //  Creates two new input FeatureSets.
                //  The FeatureSets are populated with the data sets from the specified map layer index.
                //  The map layer index is set using the layerList and the user selected layers.
                IFeatureSet inputPoint = (IFeatureSet)_map.Layers[input1SelectIndex].DataSet;
                IFeatureSet inputPolygon = (IFeatureSet)_map.Layers[input2SelectIndex].DataSet;

                //  Temporary IFeatureSet created to hold the intersection of the inputPoint and inputPolygon FeatureSets
                IFeatureSet tempOutput = inputPoint.Intersection(inputPolygon, FieldJoinType.All, null);


                //  Create new DataColumns in tempOutput with the selected join fields
                foreach (DataColumn column in tempOutput.DataTable.Columns)  //  Loops through each of the columns
                {
                    if (selectedFields.Contains(column.ColumnName))  // if the selectedFields list contains the column name
                    {
                        // Checks to see if the field name already exists in the data table.
                        if (inputPoint.DataTable.Columns.Contains(column.ColumnName))
                        {
                            // Alerts the user that the field name already exists and gives the option of overwriting the data.
                            DialogResult result = MessageBox.Show("The field name " + "'" + column.ColumnName +
                                "' already exists in the " + inputPoint.Name + " data table.\n\nWould you like to overwrite the existing data?", "Input Error",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                continue;
                            }

                            if (result == DialogResult.No)
                            {
                                MessageBox.Show("The field " + "'" + column.ColumnName + "' will not be joined.\n\nIf you want to join the attributes from the field, " +
                                    "please rename the field within the shapefile.");
                                selectedFields.Remove(column.ColumnName);
                                continue;
                            }
                        }


                        else
                        {
                            //  If the column name doesn't already exist in the inputPoint dataTable, it is added.
                            inputPoint.DataTable.Columns.Add(new DataColumn(column.ColumnName, column.DataType));
                        }
                    }
                }


                //initializes a new list to hold pointID's
                List<int> pointIDList = new List<int>();

                //loops through the inputPoint DataTable and populates the pointIDList with unique pointID's.
                foreach (DataRow row in inputPoint.DataTable.Rows)
                {
                    int pointID = Convert.ToInt32(row[pointIDField]);
                    if (!pointIDList.Contains(pointID))  //  If the list doesn't contain the ID
                    {
                        pointIDList.Add(pointID);
                    }
                }

                foreach (int ID in pointIDList)  //  Loops through each ID in the pointIDList.
                {
                    foreach (Feature feature in tempOutput.Features)  //  Loops through each of the features in the tempOutput (joined FeatureSet)
                    {
                        //  Sets the featureID as the int value found in the pointIDField column of the joined FeatureSet
                        //  The pointIDField was set from the selection by the user in the cmbField combobox.
                        int featureID = Convert.ToInt32(feature.DataRow[pointIDField]);
                        //  If the featureID matches the ID from the pointIDList, the values for each of the fields specified by the user need to be collected.
                        if (featureID == ID)
                        {
                            foreach (string field in selectedFields) //  Loops through each field in selectedFields
                            {
                                if (feature.DataRow[field] is DBNull)  // Checks to see if the cell is empty.
                                {
                                    continue;
                                }
                                else
                                {
                                    var fieldValue = feature.DataRow[field]; //  Assigns the fieldValue as the value in the joined FeatureSet (tempOutput)
                                    //  at the specified field column.

                                    //  Loops back through the inputPoint data table and if the IDs match up, the field value is assigned to the 
                                    //  specific field column in the inputPoint data table.
                                    foreach (DataRow row in inputPoint.DataTable.Rows)
                                    {
                                        int pointID = Convert.ToInt32(row[pointIDField]);
                                        if (pointID == ID)
                                        {
                                            row[field] = fieldValue;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                this.Close();  //  Closes the form

                if (radOriginal.Checked)  //  If user checks the box to save the attributes to the original shapefile.
                {
                    //  Checks to make sure the user wants to update the original shapefile.
                    DialogResult result = MessageBox.Show("The attributes have been updated.\n\nAre you sure you want to save to the original shapefile?",
                        "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        inputPoint.Save();  //  Saves to the original file directory

                        MessageBox.Show("The updated attributes have been saved to the original shapefile: " +  //  Alerts the user that the file has been saved.
                        inputPoint.Filename + ".", "File Saved");
                    }
                    if (result == DialogResult.No)
                    {
                        MessageBox.Show("The updated attributes were not saved to a file and will remain in memory.", "File Not Saved");
                    }
                }


                if (radNewShape.Checked) // If user checks the box to save the attributes to a new shapefile.
                {
                    FeatureSet output = new FeatureSet(FeatureType.Point); // output FeatureSet is declared.
                    output = (FeatureSet)inputPoint; // output is equal to the inputPoint

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
                            MapPointLayer newPointLayer = new MapPointLayer(output);
                            string file = Path.GetFileNameWithoutExtension(output.Filename);
                            newPointLayer.LegendText = file;
                            newPointLayer.Projection = _map.Projection;
                            _map.Layers.Add(newPointLayer);
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
           
        private void cmbInput1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Creates a new string to hold the value of the selected item.
                string selectedItem = cmbInput1.SelectedItem.ToString();
                //The input1SelectIndex is assigned as the index of the selected item in the LayerList.
                input1SelectIndex = layerList.IndexOf(selectedItem);

                Input1Selected = true;

                if (Input1Selected && Input2Selected)
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

        private void cmbInput2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Same methodology as for cmbInput1 above.  
                string selectedItem2 = cmbInput2.SelectedItem.ToString();
                input2SelectIndex = layerList.IndexOf(selectedItem2);

                Input2Selected = true;

                if (Input1Selected && Input2Selected)
                {
                    btnCalculate.Enabled = true;
                }

                clsFields.Items.Clear();
                IFeatureSet pointFS = (IFeatureSet)_map.Layers[input2SelectIndex].DataSet;
                foreach (DataColumn col in pointFS.DataTable.Columns) // Loops through each of the columns in the IFeatureSet
                {
                    clsFields.Items.Add(col.ColumnName); // Adds the column name to the checked list box.
                }

                chbSelectAll.Enabled = true;
                lblSelect.Enabled = true;
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

        private void chbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //  If the Select All checkbox is checked, loops through each item in the checked list box
                //  and checks each item.
                if (chbSelectAll.Checked)
                {
                    for (int i = 0; i < clsFields.Items.Count; i++)
                    {
                        clsFields.SetItemChecked(i, true);
                    }
                }
                //  If the Select All checkbox is unchecked, loops through each item in the checked list box
                //  and unchecks each item.
                else
                {
                    for (int i = 0; i < clsFields.Items.Count; i++)
                    {
                        clsFields.SetItemChecked(i, false);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
    #endregion

    }
}
