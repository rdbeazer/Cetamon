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
                    }

                    if (pointLayers.Contains(layer))  //  if layer is in the point layers collection (the layer is type point)
                    {
                        cmbInput2.Items.Add(layer.LegendText);  //  adds the legendText of the layer to the combobox for user point selection
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

      #region Old getLayers()
        //}
        ////Method to get user selected layers from CountSpecies form.
        //private void getLayers()
        //{
        //    //clears layerList
        //    layerList.Clear();

        //    //loops through the map layers
        //    if (_map.Layers.Count > 1)
        //    {
        //        for (int i = 0; i < _map.Layers.Count; i++)
        //        {
        //            string title = _map.Layers[i].LegendText;

        //            //Checking file types-------------------------
        //            IFeatureSet checkType = (IFeatureSet)_map.Layers[i].DataSet;

        //            //If the Feature type is polygon, adds to cmbInput1
        //            if (checkType.FeatureType == FeatureType.Polygon)
        //            {
        //                cmbInput1.Items.Add(title);
        //            }
        //            //If the FeatureType is point, adds to cmbInput2
        //            else if (checkType.FeatureType == FeatureType.Point)
        //            {
        //                cmbInput2.Items.Add(title);
        //            }

        //            //Adds each layer and its index to LayerList.  **Used later to reference the layers by index.
        //            layerList.Insert(i, title);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please add a layer to the map");
        //        return;
        //    }
        //} 
            #endregion

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
            List<string> selectedFields = new List<string>();

            foreach (string field in clsFields.CheckedItems)
            {
                selectedFields.Add(field);
            }
            
            IFeatureSet inputPolygon = (IFeatureSet)_map.Layers[input1SelectIndex].DataSet;
            IFeatureSet inputPoint = (IFeatureSet)_map.Layers[input2SelectIndex].DataSet;

      #region Old Code  
            //  I found that it was easier to just update the input polygon and then create an output at the 
            //  end if the user wants to save it as a different shapefile.


            //output.FeatureType = inputPolygon.FeatureType;

            //foreach (DataColumn column in inputPolygon.DataTable.Columns)
            //{
            //    output.DataTable.Columns.Add(new DataColumn(column.ColumnName, column.DataType));
            //}

            //foreach (Feature fe in inputPolygon.Features)
            //{
            //    output.Features.Add(fe);
            //} 
            #endregion

            //Create a temporary file to hold the intersection of 
            IFeatureSet tempOutput = inputPoint.Intersection(inputPolygon, FieldJoinType.All, null);

            //Create new datacolumns with the selected join fields
            foreach (DataColumn column in tempOutput.DataTable.Columns)
            {
                if (selectedFields.Contains(column.ColumnName))
                {
                    //  Checks to make sure there is not already a DataColumn in the table with that name.
                    if (inputPolygon.DataTable.Columns.Contains(column.ColumnName))
                    {
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

            if (chkSave.Checked)  //  If user checks the box to save the attributes to the original shapefile.
            {
                inputPolygon.Save();  //  Saves to the original file directory
                MessageBox.Show("The updated attributes have been saved to " +  //  Alerts the user that the file has been saved.
                    inputPoint.Filename + ".", "File Saved");
            }

            if (chkSaveAs.Checked)  // If user checks the box to save the attributes to a new shapefile.
            {
                FeatureSet output = new FeatureSet(FeatureType.Polygon);  // output FeatureSet is declared.
                output = (FeatureSet)inputPolygon;  // output is equal to the inputPolygon
                
                //  Calls the saveFile method
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
            #region Old code
            
            //saveFile(output);

            ////Creates a new MapPolygonLayer using the output featureset
            //MapPolygonLayer IntersectLayer = new MapPolygonLayer(output);



            ////Sets Legend and Symbolizer properties.
            //IntersectLayer.LegendText = txtOutput.Text;
            //IntersectLayer.Symbolizer.SetFillColor(Color.Blue);
            //IntersectLayer.Projection = _map.Projection;
            //IntersectLayer.DataSet.FillAttributes();


            //_map.Layers.Add(IntersectLayer);
            //_map.ResetBuffer();
            ////Alerts the user that the attributes have been updated.
            ////MessageBox.Show("The selected track layer has been segmented by the selected grid layer", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //this.Close(); 
            #endregion
        }

        //Save file dialog
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
                MessageBox.Show("The polygon file will not be saved");
                return;
            }
            else
            {
                output.SaveAs(strFileName, true);
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
