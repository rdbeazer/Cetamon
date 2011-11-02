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
    public partial class frmExtractRasterValues : Form
    {

        #region Class Variables
        Map _map = null;
        List<string> layerList = new List<string>();
        int input2SelectIndex = 0;
        #endregion

        public frmExtractRasterValues()
        {
            InitializeComponent();
        }

        public frmExtractRasterValues(Map map)
        {
            _map = map;
            InitializeComponent();
        }

        private void frmExtractRasterValues_Load(object sender, EventArgs e)
        {
            //Clears combo box and checked list box when form is loaded.
            cmbPoint.Items.Clear();
            clsFields.Items.Clear();

            //Calls getLayers method
            getLayers();
        }

    #region Methods
        private void getLayers()
        //Method to get the map layers and populate the user selection controls in the form.
        {
            layerList.Clear();  //clears layerList

            //Gets the collection of RasterLayers from the map.
            IMapRasterLayer[] rasterLayers = _map.GetRasterLayers();
            //Gets the collection of PointLayers from the map.
            IMapPointLayer[] pointLayers = _map.GetPointLayers();

            //Gets a count for each type of layer.
            int rasterCount = rasterLayers.Count();
            int pointCount = pointLayers.Count();

            //Check to make sure a raster and point layer are loaded in the map.
            if (rasterCount > 0 && pointCount > 0)
            {
                for (int i = 0; i < _map.Layers.Count; i++) //loops through each map layer
                {
                    IMapLayer layer = _map.Layers[i];

                    if (rasterLayers.Contains(layer)) //if layer is in the rasterLayers collection
                    {
                        if (!clsFields.Items.Contains(layer.LegendText))  //and it's not already added to the checked list box.
                        {
                            clsFields.Items.Add(layer.LegendText);  //adds the LegendText of the layer to the checked list box.
                        }
                        else
                        {
                            MessageBox.Show("Raster layers have the same name.\n\nPlease change the raster names in the legend.", "Input Error");
                            this.Close();
                        }
                    }
                    if (pointLayers.Contains(layer)) //if layer is in the pointLayers collection
                    {
                        cmbPoint.Items.Add(layer.LegendText);  //adds the LegendText of the layer to the checked list box.
                    }

                    //** -----------------------------------------------------**
                    //  The next piece of code is important.  Each map layer needs to be added to the layerList.  The layer list is used to index the 
                    //  map layers with their legendText.  This way, user selected items in the combobox or checked list box (referred to by
                    // their legendText) can be associated with the correct map layer (by index).

                    layerList.Insert(i, layer.LegendText); // inserts the index and LegendText regardless of which type.
                }
            }
            else
            {
                MessageBox.Show("Please make sure you have at least one raster layer and one point layer loaded into the map.");
                this.Close();
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //  IFeatureSet pointInput is declared and assigned by the map layer index that the user selected in
            //  the pointInput combobox.
            IFeatureSet pointInput = (IFeatureSet)_map.Layers[input2SelectIndex].DataSet;

            //  A loop for each checked item in the checked list box.
            //  These items are the available rasters from the map layers.
            foreach (string raster in clsFields.CheckedItems)
            {
                //  selectedIndex holds the index of the raster in the map. 
                int selectedIndex = layerList.IndexOf(raster);
                //  Declares a new raster using the DataSet at the specified map.Layers index.
                IRaster rasterInput = (IRaster)_map.Layers[selectedIndex].DataSet;
                //  Sets the NoDataValue of the raster to the int value of the NoDataValue textbox.
                rasterInput.NoDataValue = Convert.ToInt32(txtNoDataValue.Text);
                //  Creates a new DataColumn named the same as the LegendText of the raster.
                //      The type is double because it holds raster values.
                DataColumn rasValCol = new DataColumn(_map.Layers[selectedIndex].LegendText, typeof(double));
                //  Checks to make sure there is not already a DataColumn in the table with that name
                if (pointInput.DataTable.Columns.Contains(rasValCol.ColumnName))
                {
                    //  If the column already exists, the user is alerted.
                    MessageBox.Show("The data table already contains a column with the name" + " '" + rasValCol.ColumnName +
                        "'.  \nThe column will not be added to the data table.", "Input Error");
                    return;
                }
                else
                {
                    //  If the column does not exist in the data table, it is added.
                    pointInput.DataTable.Columns.Add(rasValCol);
                }

                foreach (IFeature ptFeature in pointInput.Features)  //  Loops through each feature
                {
                    //  assigns the coordinates of the point to variable coord.
                    Coordinate coord = ptFeature.Coordinates[0];
                    //  gets the rowColumn index for the raster based on the coordinate coord.
                    RcIndex rowColumn = rasterInput.Bounds.ProjToCell(coord);
                    //  declares variable rasValue which holds the value of the raster cell at the rowColumn index.
                    double rasValue = rasterInput.Value[rowColumn.Row, rowColumn.Column];
                    //  adds the raster value to the specified column in the feature.
                    ptFeature.DataRow[rasValCol] = rasValue;
                }
            }

            this.Close(); //  Closes the form

            if (chkSave.Checked)  //  If user checks the box to save the attributes to the original shapefile.
            {
                pointInput.Save();
                MessageBox.Show("The updated attributes have been saved to " +
                    pointInput.Filename + ".", "File Saved");
            }

            if (chkSaveAs.Checked)  // If user checks the box to save the attributes to a new shapefile.
            {
                //  output FeatureSet is declared
                FeatureSet output = new FeatureSet(FeatureType.Point);
                //  output is equal to the pointInput
                output = (FeatureSet)pointInput;

                //  Calls the saveFile method
                saveFile(output);

                //  Alerts the user that the file has been saved.
                //  Asks the user if they would like to add the saved file to the map.
                DialogResult result = MessageBox.Show("The updated attributes have been saved to the new file " +
                    output.Filename + ".\n\nWould you like to add the new file to the map?", "File Saved",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                //  If the user clicks "Yes", the saved file is added as a new point layer on the map.
                if (result == DialogResult.Yes)
                {
                    MapPointLayer newPointLayer = new MapPointLayer(output);
                    string filename = output.Filename;
                    //  the new point layer receives the name it was saved as.
                    int index = filename.LastIndexOf("\\");
                    string legendText = filename.Substring(index + 1);
                    newPointLayer.LegendText = legendText;
                    _map.Layers.Add(newPointLayer);
                    _map.ResetBuffer();
                }
            }
        }

        private void cmbPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  Input2SelectIndex holds the map layer index of the item selected in the combobox.
            string selectedPoint = cmbPoint.SelectedItem.ToString();
            input2SelectIndex = layerList.IndexOf(selectedPoint);
        }

        private void chbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            //  If the selectAll checkbox is checked, loops through each item in the checked list box
            //  and checks each item.
            if (chbSelectAll.Checked)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
                //MessageBox.Show("The Split Tracks file won't be saved");
                return;
            }
            else
            {
                output.SaveAs(strFileName, true);
            }
        } 
    #endregion

    }
}
