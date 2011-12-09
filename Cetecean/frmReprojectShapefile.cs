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
using DotSpatial.Projections;
using DotSpatial.Data;

namespace Cetecean
{
    public partial class frmReprojectShapefile : Form
    {
        Map _map = null;
        List<string> layerList = new List<string>();
        public ProjectionInfo _selectedCoordinateSystem;
        IFeatureSet selectedFS;
        int shapefileSelectIndex;
            
        public frmReprojectShapefile()
        {
            InitializeComponent();
        }

        public frmReprojectShapefile(Map map)
        {
            _map = map;
            InitializeComponent();
        }

        

        private void frmReprojectShapefile_Load(object sender, EventArgs e)
        {
            LoadMajorCategories();
            getLayers();
        }

        private void radProjected_CheckedChanged(object sender, EventArgs e)
        {
            LoadMajorCategories();
        }

        private void LoadMajorCategories()
        {
            if (radProjected.Checked) // If the Projected radio button is checked, the MajorCategory combobox is populated.
            {
                cmbMajorCategory.SuspendLayout();
                cmbMajorCategory.Items.Clear();
                string[] names = KnownCoordinateSystems.Projected.Names; //creates a string array of the projected names.
                foreach (string name in names) // loops through the array and adds each string name to the combobox.
                {
                    cmbMajorCategory.Items.Add(name);
                }
                cmbMajorCategory.SelectedIndex = 0;
                cmbMajorCategory.ResumeLayout();
            }
            else // if the Geographic radio button is checked.
            {
                cmbMajorCategory.SuspendLayout();
                cmbMajorCategory.Items.Clear();
                string[] names = KnownCoordinateSystems.Geographic.Names;  // creates a string array of the geographic names.
                foreach (string name in names) // loops through the array and addes each string name to the combobox.
                {
                    cmbMajorCategory.Items.Add(name);
                }
                cmbMajorCategory.SelectedIndex = 0;
                cmbMajorCategory.ResumeLayout();
            }
        }

        private void LoadMinorCategories()
        {
            if (radProjected.Checked)
            {
                // assigns the CoordinateSystemCategory as the string selected in the MajorCategory combobox.
                CoordinateSystemCategory c = KnownCoordinateSystems.Projected.GetCategory((string)cmbMajorCategory.SelectedItem);
                if (c == null) return;
                cmbMinorCategory.SuspendLayout();
                cmbMinorCategory.Items.Clear();
                string[] names = c.Names;  // creates an array of the category names within the CoordinateSystemCategory
                foreach (string name in names)
                {
                    cmbMinorCategory.Items.Add(name);
                }
                cmbMinorCategory.SelectedIndex = 0;
                _selectedCoordinateSystem = c.GetProjection(names[0]);
                cmbMinorCategory.ResumeLayout();
            }
            else // does the same as above for the geographic systems if the Geographic radio button is selected.
            {
                CoordinateSystemCategory c = KnownCoordinateSystems.Geographic.GetCategory((string)cmbMajorCategory.SelectedItem);
                cmbMinorCategory.SuspendLayout();
                cmbMinorCategory.Items.Clear();
                string[] names = c.Names;
                foreach (string name in names)
                {
                    cmbMinorCategory.Items.Add(name);
                }
                cmbMinorCategory.SelectedIndex = 0;
                _selectedCoordinateSystem = c.GetProjection(names[0]);
                cmbMinorCategory.ResumeLayout();
            }
        }

        private void cmbMajorCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMinorCategories();
        }

        private void cmbMinorCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // assigns the _selectedCoordinateSystem variable.
            if (radProjected.Checked)
            {
                CoordinateSystemCategory c = KnownCoordinateSystems.Projected.GetCategory((string)cmbMajorCategory.SelectedItem);
                _selectedCoordinateSystem = c.GetProjection((string)cmbMinorCategory.SelectedItem);
                cmbMinorCategory.ResumeLayout();
            }
            else
            {
                CoordinateSystemCategory c = KnownCoordinateSystems.Geographic.GetCategory((string)cmbMajorCategory.SelectedItem);
                _selectedCoordinateSystem = c.GetProjection((string)cmbMinorCategory.SelectedItem);
                cmbMinorCategory.ResumeLayout();
            }
        }

        private void getLayers()
        {
            try
            {
                layerList.Clear();  //clears layerList

                IMapFeatureLayer[] featureLayers = _map.GetFeatureLayers();

                int featureCount = featureLayers.Count();

                //  Checks to make sure at least one feature is loaded in the map.
                if (featureCount > 0)
                {
                    cmbShapefile.SuspendLayout();
                    cmbShapefile.Items.Clear();

                    for (int i = 0; i < _map.Layers.Count; i++)  //  Loops through each map layer
                    {
                        IMapLayer layer = _map.Layers[i];

                        if (featureLayers.Contains(layer))  //  If layer is a featurelayer
                        {
                            cmbShapefile.Items.Add(layer.LegendText);  //  adds the legendText of the layer to the combobox for user shapefile selection
                            
                        }

                        //*********IMPORTANT**********
                        //  It is imporant to add each map layer to the layerList.  The layer list holds the map index and legend text for each of the 
                        //  map layers.  This is how the user selected items in the comboboxes (referred to by their legendText) can be associated with the 
                        //  correct map layer (by index)
                        layerList.Insert(i, layer.LegendText);
                    }
                    cmbShapefile.SelectedIndex = 0;
                    cmbShapefile.ResumeLayout();
                }
                else
                {
                    //  Alerts the user and closes the form if there are no features loaded in the map.
                    MessageBox.Show("A shapefile must be loaded in the map.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            selectedFS = (IFeatureSet)_map.Layers[shapefileSelectIndex].DataSet;
            string feType = selectedFS.FeatureType.ToString();
            FeatureSet output = new FeatureSet();
            output = (FeatureSet)selectedFS;
            output.Projection = _selectedCoordinateSystem;
            Functions saveObj = new Functions();
            saveObj.saveFile(output);

            if (saveObj.saved)
            {
                //  Alerts the user that the file has been saved.
                //  Asks the user if they would like to add the saved file to the map.
                DialogResult result = MessageBox.Show(Path.GetFileNameWithoutExtension(output.Filename) + " has been reprojected to " + output.Projection.Name.ToString() +
                    "\nand saved to: " + output.Filename + 
                    "\n\nWould you like to add the new file to the map?", "File Saved",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                //  If the user clicks "Yes", the saved file is added as a new point layer on the map.
                if (result == DialogResult.Yes)
                {
                    if (feType == "Polygon")
                    {
                        MapPolygonLayer newPolygonLayer = new MapPolygonLayer(output);
                        string file = Path.GetFileNameWithoutExtension(output.Filename);
                        newPolygonLayer.LegendText = file;
                        newPolygonLayer.Projection = _selectedCoordinateSystem;
                        _map.Layers.Add(newPolygonLayer);
                        _map.ResetBuffer();
                    }
                    if (feType == "Line")
                    {
                        MapLineLayer newLineLayer = new MapLineLayer(output);
                        string file = Path.GetFileNameWithoutExtension(output.Filename);
                        newLineLayer.LegendText = file;
                        newLineLayer.Projection = _selectedCoordinateSystem;
                        _map.Layers.Add(newLineLayer);
                        _map.ResetBuffer();
                    }
                    if (feType == "Point")
                    {
                        MapPointLayer newPointLayer = new MapPointLayer(output);
                        string file = Path.GetFileNameWithoutExtension(output.Filename);
                        newPointLayer.LegendText = file;
                        newPointLayer.Projection = _selectedCoordinateSystem;
                        _map.Layers.Add(newPointLayer);
                        _map.ResetBuffer();
                    }
                }
            }

        }

        private void cmbShapefile_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = cmbShapefile.SelectedItem.ToString();
            shapefileSelectIndex = layerList.IndexOf(selectedItem);
        }  
    }
}
