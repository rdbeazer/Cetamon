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
        FeatureSet output = new FeatureSet();
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

        private void cmbInput1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Creates a new string to hold the value of the selected item.
            //The input1SelectIndex is assigned as the index of the selected item in the LayerList.
            string selectedItem = cmbInput1.SelectedItem.ToString();
            input1SelectIndex = layerList.IndexOf(selectedItem);

            cmbField.Items.Clear();
            IFeatureSet polygonFS = (IFeatureSet)_map.Layers[input1SelectIndex].DataSet;
            foreach (DataColumn col in polygonFS.DataTable.Columns)
            {
                cmbField.Items.Add(col.ColumnName);
            }
        }

        private void cmbInput2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem2 = cmbInput2.SelectedItem.ToString();
            input2SelectIndex = layerList.IndexOf(selectedItem2);
            lstFields.Items.Clear();
            IFeatureSet pointFS = (IFeatureSet)_map.Layers[input2SelectIndex].DataSet;
            foreach (DataColumn col in pointFS.DataTable.Columns)
            {
                lstFields.Items.Add(col.ColumnName);
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            List<string> selectedFields = new List<string>();

            foreach (string item in lstFields.SelectedItems)
            {
                selectedFields.Add(item);
            }
            
            IFeatureSet inputPolygon = (IFeatureSet)_map.Layers[input1SelectIndex].DataSet;
            IFeatureSet inputPoint = (IFeatureSet)_map.Layers[input2SelectIndex].DataSet;

            output.FeatureType = inputPolygon.FeatureType;

            foreach (DataColumn column in inputPolygon.DataTable.Columns)
            {
                output.DataTable.Columns.Add(new DataColumn(column.ColumnName, column.DataType));
            }

            foreach (Feature fe in inputPolygon.Features)
            {
                output.Features.Add(fe);
            }

            //Create a temporary file to hold the intersection of 
            IFeatureSet tempOutput = inputPoint.Intersection(inputPolygon, FieldJoinType.All, null);

            //Create new datacolumns with the selected join fields
            foreach (DataColumn column in tempOutput.DataTable.Columns)
            {
                if (selectedFields.Contains(column.ColumnName))
                {
                    output.DataTable.Columns.Add(new DataColumn(column.ColumnName, column.DataType)); 
                }
            }



            //initializes a new list to hold polygonID's
            List<int> polygonIDList = new List<int>();

            //loops through the inputLine DataTable and populates the polygonIDList with unique polygonID's.
            foreach (DataRow row in output.DataTable.Rows)
            {
                int polygonID = Convert.ToInt32(row[polygonIDField]);
                if (!polygonIDList.Contains(polygonID))
                {
                    polygonIDList.Add(polygonID);
                }
            }

            double fieldValue = 0;

            foreach (int ID in polygonIDList)
            {
                foreach (Feature feature in tempOutput.Features)
                {
                    int featureID = Convert.ToInt32(feature.DataRow[polygonIDField]);
                    if (featureID == ID)
                    {
                        foreach (string field in selectedFields)
                        {
                            fieldValue = Convert.ToDouble(feature.DataRow[field]);
                            foreach (DataRow row in output.DataTable.Rows)
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

            saveFile(output);

            //Creates a new MapPolygonLayer using the output featureset
            MapPolygonLayer IntersectLayer = new MapPolygonLayer(output);



            //Sets Legend and Symbolizer properties.
            IntersectLayer.LegendText = txtOutput.Text;
            IntersectLayer.Symbolizer.SetFillColor(Color.Blue);
            IntersectLayer.Projection = _map.Projection;
            IntersectLayer.DataSet.FillAttributes();


            _map.Layers.Add(IntersectLayer);
            _map.ResetBuffer();
            //Alerts the user that the attributes have been updated.
            //MessageBox.Show("The selected track layer has been segmented by the selected grid layer", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Close();
        }

        

        //Save file dialog
        private void saveFile(FeatureSet output)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "shapefile files (*.shp)|*.shp";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Save" + txtOutput.Text;
            string strFileName = "";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                strFileName = dialog.FileName;
            }

            if (strFileName == String.Empty)
            {
                //MessageBox.Show("The Split Tracks file won't be saved");
                return;
            }
            else
            {
                output.SaveAs(strFileName, true);
            }
        }

        private void cmbField_SelectedIndexChanged(object sender, EventArgs e)
        {
            polygonIDField = cmbField.SelectedItem.ToString();
        }

        #endregion

    }
}
