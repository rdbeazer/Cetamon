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
    public partial class frmJoinPointsToPolygons : Form
    {
        #region "Class Variables"
        Map _map = null;
        List<string> layerList = new List<string>();
        int input1SelectIndex = 0;
        int input2SelectIndex = 0;
        string polygonIDField = null;

        #endregion

        public frmJoinPointsToPolygons()
        {
            InitializeComponent();
        }

        public frmJoinPointsToPolygons(Map map)
        {
            _map = map;
            InitializeComponent();
        }

        private void frmJoinPointsToPolygons_Load(object sender, EventArgs e)
        {
            cmbInput1.Items.Clear();
            cmbInput2.Items.Clear();
            getLayers();
        }

    #region Methods

        //Method to get the map layers and populate the user selection controls in the form.
        private void getLayers()
        {
            layerList.Clear();  //clears layerList

            //  Gets the collection of polygon and point layers from the map.
            IMapPolygonLayer[] polygonLayers = _map.GetPolygonLayers();
            IMapPointLayer[] pointLayers = _map.GetPointLayers();

            //  Gets a count for each type of layer.
            int polygonCount = polygonLayers.Count();
            int pointCount = pointLayers.Count();

            //  Checks to make sure at least one polygon and one point layer are added to the map.
            if (polygonCount > 0 && pointCount > 0)
            {
                for (int i = 0; i < _map.Layers.Count; i++)  //  loops through each map layer.
                {
                    IMapLayer layer = _map.Layers[i];

                    if (polygonLayers.Contains(layer))  //  if layer is in the polygon layers collection (the layer is type polygon)
                    {
                        cmbInput1.Items.Add(layer.LegendText);  //  adds the legendText of the layer to the combobox for user polygon selection.

                        //  Checks to make sure there is a polygonID associated with each feature.  If not, assigns "polygonID"
                        IFeatureSet inputPolygon = (IFeatureSet)_map.Layers[i].DataSet;
                        if (!inputPolygon.DataTable.Columns.Contains("polygonID") && !inputPolygon.DataTable.Columns.Contains("POLYGONID"))
                        {
                            inputPolygon.AddFid();  //  Adds FID
                            inputPolygon.DataTable.Columns["FID"].ColumnName = "polygonID"; //  Changes FID column name.
                        }
                    }

                    if (pointLayers.Contains(layer))  //  if layer is in the point layers collection (the layer is type point)
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
                MessageBox.Show("For the join operation, make sure that you have a polygon and point shapefile loaded in the map.");
                this.Close();
            }
        }

        private void cmbInput1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Creates a new string to hold the value of the selected item.
            string selectedItem = cmbInput1.SelectedItem.ToString();
            //The input1SelectIndex is assigned as the index of the selected item in the LayerList.
            input1SelectIndex = layerList.IndexOf(selectedItem);

            //  input1SelectIndex is used to get the correct dataset from the map layers (the one selected by the user).
            cmbField.Items.Clear();
            IFeatureSet polygonFS = (IFeatureSet)_map.Layers[input1SelectIndex].DataSet;
            foreach (DataColumn col in polygonFS.DataTable.Columns)  //loops through each of the columns in the IFeatureSet
            {
                cmbField.Items.Add(col.ColumnName);  //  adds the column name to the cmbField combobox.
            }
        }

        private void cmbInput2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  Same methodology as for cmbInput1 above.  However, this populates a checked list box instead of a combobox.
            string selectedItem2 = cmbInput2.SelectedItem.ToString(); 
            input2SelectIndex = layerList.IndexOf(selectedItem2);
            clsFields.Items.Clear();
            IFeatureSet pointFS = (IFeatureSet)_map.Layers[input2SelectIndex].DataSet;
            foreach (DataColumn col in pointFS.DataTable.Columns)
            {
                clsFields.Items.Add(col.ColumnName);
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                //  Initializes new List to hold the selectedFields from clsFields.
                List<string> selectedFields = new List<string>();
                foreach (string field in clsFields.CheckedItems)  //  loops through the checked fields
                {
                    selectedFields.Add(field);  //  adds the checked fields to the selectedFields list.
                }

                //  Creates two new input FeatureSets.
                //  The FeatureSets are populated with the data sets from the specified map layer index.
                //  The map layer index is set using the layerList and the user selected layers.
                IFeatureSet inputPolygon = (IFeatureSet)_map.Layers[input1SelectIndex].DataSet;
                IFeatureSet inputPoint = (IFeatureSet)_map.Layers[input2SelectIndex].DataSet;

                //  Temporary IFeatureSet created to hold the intersection of the inputPoint and inputPolygon FeatureSets
                IFeatureSet tempOutput = inputPoint.Intersection(inputPolygon, FieldJoinType.All, null);

                //Create new datacolumns with the selected join fields
                foreach (DataColumn column in tempOutput.DataTable.Columns)
                {
                    if (selectedFields.Contains(column.ColumnName))
                    {
                        //  Checks to make sure there is not already a DataColumn in the table with that name.
                        if (inputPolygon.DataTable.Columns.Contains(column.ColumnName))
                        {
                            //  Alerts the user if the column name already exists
                            MessageBox.Show("The data table already contains a column with the name" + " '" + column.ColumnName +
                                "'.\n\nThe column will not be added to the data table.", "Input Error");
                            return;
                        }
                        else
                        {
                            //  if the column does not exist in the data table, it is added.
                            inputPolygon.DataTable.Columns.Add(new DataColumn(column.ColumnName, column.DataType));
                        }
                    }
                }

                //initializes a new list to hold polygonID's
                List<int> polygonIDList = new List<int>();

                //loops through the inputPolygon DataTable and populates the polygonIDList with unique polygonID's.
                foreach (DataRow row in inputPolygon.DataTable.Rows)
                {
                    int polygonID = Convert.ToInt32(row[polygonIDField]);
                    if (!polygonIDList.Contains(polygonID)) //  if the list doesn't contain the ID.
                    {
                        polygonIDList.Add(polygonID);
                    }
                }

                //  variable to hold the value
                double fieldValue = 0;

                foreach (int ID in polygonIDList)  //  loops through each ID in the polygonID list.
                {
                    foreach (Feature feature in tempOutput.Features)  //  loops through each feature in the joined FeatureSet
                    {
                        //  sets the featureID as the int value found in the polygonIDField column of the joined featureSet.
                        //  the polygonIDField was set from the selection by the user in the cmbField combobox in the GUI.
                        int featureID = Convert.ToInt32(feature.DataRow[polygonIDField]);
                        if (featureID == ID)  //  if the featureID matches the ID from the polygon list the values from each of the 
                        //  fields specified by the user need to be collected.
                        {
                            //  loops through each field in the selectedFields (list generated from the selected items)
                            foreach (string field in selectedFields)
                            {
                                //  assigns the variable the value for that field
                                fieldValue = Convert.ToDouble(feature.DataRow[field]);

                                //  loops back through the inputPolygon data table and if the IDs match up, the field value is 
                                //  placed in the same field.
                                foreach (DataRow row in inputPolygon.DataTable.Rows)
                                {
                                    int polyID = Convert.ToInt32(row[polygonIDField]);
                                    if (polyID == ID)
                                    {
                                        row[field] = fieldValue;
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
                        inputPolygon.Save();  //  Saves to the original file directory

                        MessageBox.Show("The updated attributes have been saved to the original shapefile: " +  //  Alerts the user that the file has been saved.
                        inputPolygon.Filename + ".", "File Saved");
                    }
                    if (result == DialogResult.No)
                    {
                        MessageBox.Show("The updated attributes were not saved to a file and will remain in memory.", "File Not Saved");
                    }
                }
                if (radNewShape.Checked)  // If user checks the box to save the attributes to a new shapefile.
                {
                    FeatureSet output = new FeatureSet(FeatureType.Polygon);  // output FeatureSet is declared.
                    output = (FeatureSet)inputPolygon;  // output is equal to the inputPolygon

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

                        //  If the user clicks "Yes", the saved file is added as a new polygon layer on the map.
                        if (result == DialogResult.Yes)
                        {
                            MapPolygonLayer newPolygonLayer = new MapPolygonLayer(output);
                            string filename = output.Filename;
                            //  The new polygon layer receives the name it was saved as.
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
                MessageBox.Show("Please check the values entered and try again", "Entry Error");
            }

        }

        private void cmbField_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  polygonIDField holds the string for the field selected by the user as holding the unique polygonID.
            polygonIDField = cmbField.SelectedItem.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();  // closes the form
        }

        private void chbSelectAll_CheckedChanged(object sender, EventArgs e)
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
        
    #endregion

    }
}
