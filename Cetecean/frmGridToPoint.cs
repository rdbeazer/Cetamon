using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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
    public partial class frmGridToPoint : Form
    {
        #region Class Level Variables
        Map _map = null;
        List<string> layerList = new List<string>();
        int gridSelectIndex = 0;
        FeatureSet outputPoint = new FeatureSet(FeatureType.Point);
        Boolean cbChecked = true;
        #endregion

        public frmGridToPoint()
        {
            InitializeComponent();
        }

        public frmGridToPoint(Map map)
        {
            _map = map;
            InitializeComponent();
        }
       

        private void frmGridToPoint_Load(object sender, EventArgs e)
        {
            cmbGrid.Items.Clear();
            getLayers();

        }

        #region Methods
        //Method to get user selected variables from Split Tracks form
        private void getLayers()
        {
            //clears layerLists
            layerList.Clear();

            //loops through the map layers and adds them to the layerLists.
            //These lists will be used to populate the combo boxes.
            if (_map.Layers.Count > 0)
            {
                for (int i = 0; i < _map.Layers.Count; i++)
                {
                    string title = _map.Layers[i].LegendText;
                    //Checking file types-------------------------
                    IFeatureSet checkType = (IFeatureSet)_map.Layers[i].DataSet;

                    //If the Feature type is polygon, adds to cmbInput1
                    if (checkType.FeatureType == FeatureType.Polygon)
                    {
                        cmbGrid.Items.Add(title);
                    }

                    //Adds each layer and its index to LayerList.  **Used later to reference the layers by index.
                    layerList.Insert(i, title);
                }
            }
            else
            {
                MessageBox.Show("Please add another layer to the map for this operation", "Not enough layers present.");
                return;
            }
        }

        private void cmbGridLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGridItem = cmbGrid.SelectedItem.ToString();
            clsFields.Items.Clear();
            //Clear out the ID combobox to match the next selection
            gridSelectIndex = layerList.IndexOf(selectedGridItem);
            IFeatureSet gridFS = (IFeatureSet)_map.Layers[gridSelectIndex].DataSet;

            foreach (DataColumn col in gridFS.DataTable.Columns)
            {
                clsFields.Items.Add(col.ColumnName);
            }
            chbSelectAll.Visible = true;
            lblSelect.Visible = true;
            clsFields.Visible = true;
        }

        //Select All
        private void chbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if(chbSelectAll.Checked)
            {
                for (int i = 0; i < clsFields.Items.Count; i++)
                {
                    clsFields.SetItemChecked(i, true);
                }
            }
            else
            {
                 for (int i = 0; i < clsFields.Items.Count; i++)
                    {
                clsFields.SetItemChecked(i, false);
                    }
            
            }
        }

        private void btnCreatePoints_Click(object sender, EventArgs e)
        {
            IFeatureSet inputGrid = (IFeatureSet)_map.Layers[gridSelectIndex].DataSet;
            List<string> columnList = new List<string>();
            outputPoint.DataTable.Clear();
            outputPoint.Projection = inputGrid.Projection; //Set projection

            //Create new Columns in the point attribute table
            outputPoint.DataTable.Columns.Add(new DataColumn("Point_ID", typeof(int)));
            outputPoint.DataTable.Columns.Add(new DataColumn("Lat", typeof(double)));
            outputPoint.DataTable.Columns.Add(new DataColumn("Long", typeof(double)));

            //Check the status of the selected all checkbox
            foreach (int ind in clsFields.CheckedIndices)
            {
                
                string name = null;
                if (clsFields.GetItemChecked(ind) == true)
                {
                    name = Convert.ToString(clsFields.GetItemText(clsFields.Items[ind]));
                    //get the data type of the selected item, add the column to the outputPoint DataTable

                    foreach (DataColumn col in inputGrid.DataTable.Columns)
                        if (name == col.ColumnName.ToString())
                        {
                            outputPoint.DataTable.Columns.Add(new DataColumn(name, col.DataType));
                            columnList.Add(name); 
                        }
                }
            }
             int id = 0;
          
            //Parse each polygon feature, get centroid, add to the outputPoint FS
            foreach (Feature fi in inputGrid.Features)
            {
                //Get a placeholder for the centroid coordinates
                IFeature placeHolder;
                //Set to the polygon centroid
                placeHolder = fi.Centroid();
                //Extract X and Y coordinates
                double coordx = placeHolder.Coordinates[0].X;
                double coordy = placeHolder.Coordinates[0].Y;
                //Create a new point with the coordinates
                DotSpatial.Topology.Point pt = new DotSpatial.Topology.Point(coordx,coordy);
                //Create a feature which contains the point coordinates, add to the Featureset
                IFeature pointAdd = outputPoint.AddFeature(pt);
                //Edit the feature datarow
                pointAdd.DataRow.BeginEdit();
                //Adds amplifying information about the point
                pointAdd.DataRow["Point_ID"] = id;
                pointAdd.DataRow["Lat"] = placeHolder.Coordinates[0].X;
                pointAdd.DataRow["Long"] = placeHolder.Coordinates[0].Y;
                //Takes the user selected columns from the grid featureset and adds them to the point
                foreach (string name in columnList)             //Add the selected point attributes
                {
                    pointAdd.DataRow[name] = fi.DataRow[name];  //Compares the columns, moves matching values to the output point
                }
                pointAdd.DataRow.EndEdit();     //Stop editing
                id++;
            }
            //Adding to the Map
                string text = txtInput.Text;
                MapPointLayer gridToPointLayer = new MapPointLayer(outputPoint);
                gridToPointLayer.LegendText = text;
                gridToPointLayer.Symbolizer.SetFillColor(Color.Red);
                _map.Layers.Add(gridToPointLayer);
                _map.ResetBuffer();
                  if (cbChecked == true)
                {
                    saveFile(outputPoint);
                    return;
                }
                this.Close();
            
        }       

//Gets the value from the Save checkbox
      private void cbxSave_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSave.Checked == true)
            {
                cbChecked = true;
            }
            else
            {
                cbChecked = false;
            }
        }
           
        //Save file dialog
        private void saveFile(FeatureSet output)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "shapefile files (*.shp)|*.shp";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Save Point Shapefile";
            string strFileName = txtInput.Text;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                strFileName = dialog.FileName;
            }

            if (strFileName == String.Empty)
            {
                // MessageBox.Show("The Split Tracks file won't be saved");
                return;
            }
            else
            {
                output.SaveAs(strFileName, true);
            }
            this.Close();
        }

        #endregion

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        
       
        

        
       

       
    }

}
