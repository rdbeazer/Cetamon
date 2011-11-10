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
    public partial class frmPolyEffortBySwathe : Form
    {

#region Class Level Variables
        Map _map = null;
        List<string> layerList = new List<string>();
        int swatheSelectIndex;
        int gridSelectIndex;
        string polygonIDSelect;
        string swatheAreaSelect;
        IFeatureSet inputSwathe = null;
        IFeatureSet inputGrid = null;
        FeatureSet output = new FeatureSet();
        decimal swatheAreaSum;
               


#endregion
        public frmPolyEffortBySwathe()
        {
            InitializeComponent();
        }

        public frmPolyEffortBySwathe(Map map)
        {
            _map = map;
            InitializeComponent();
        }

        private void polyEffortBySwathe_Load(object sender, EventArgs e)
        {
            //Clear the combobox items from any previous runs
            cmbSwathe.Items.Clear();
            cmbInputGrid.Items.Clear();
            cmbSwatheArea.Items.Clear();

            //Get the layers from the map
            getLayers();
         }

        #region Methods

        //Method to get user selected variables from Split Tracks form
        private void getLayers()
        {
            layerList.Clear();  //  clears layerList

            //  Gets the collection of polygon and point layers from the map
            IMapPolygonLayer[] polygonLayers = _map.GetPolygonLayers();   

            //  Gets a count for each type of layer
            int polygonCount = polygonLayers.Count();

            //  Checks to make sure at least 2 polygon layers have been added.
            if (polygonCount > 1)
            {
                for (int i = 0; i < _map.Layers.Count; i++)  //  Loops through each map layer
                {
                    IMapLayer layer = _map.Layers[i];

                    if (polygonLayers.Contains(layer))  //  If layer is a polygon layer
                    {
                        cmbSwathe.Items.Add(layer.LegendText);
                        cmbInputGrid.Items.Add(layer.LegendText);//  adds the legendText of the layer to the combobox for user polygon selection
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
                MessageBox.Show("An Input Swathe layer and an Input Grid layer must be selected.");
                this.Close();
            }
        }

//Getting user selections-----------------------------------------
     
        //Same functionality as above
        private void cmbSwathe_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSwatheID.Items.Clear();
            swatheSelectIndex = cmbSwathe.SelectedIndex;
            inputSwathe = (IFeatureSet)_map.Layers[swatheSelectIndex].DataSet;
            foreach (DataColumn col in inputSwathe.DataTable.Columns)
            {
                cmbSwatheID.Items.Add(col.ColumnName);
                cmbSwatheArea.Items.Add(col.ColumnName);

            }
        }

        private void cmbInputGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridSelectIndex = cmbInputGrid.SelectedIndex;
            inputGrid = (IFeatureSet)_map.Layers[gridSelectIndex].DataSet;
        }     
        private void cmbSwatheID_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            polygonIDSelect = Convert.ToString(cmbSwatheID.SelectedItem);
             
        }

        private void cmbSwatheArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            swatheAreaSelect = Convert.ToString(cmbSwatheArea.SelectedItem);
        }

       
        

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                //Requirement #10 Functionality-------------------------------------------------------------
                //Create and add new column to the swathe attribute table to hold the swathe effort value
                System.Data.DataColumn swatheEffort = new System.Data.DataColumn(txtSwathe.Text, typeof(decimal));
                inputGrid.DataTable.Columns.Add(swatheEffort);

                //initializes a new list to hold polygonID's
                //Uses string so ID can hold letters and numbers
                List<string> polygonIDList = new List<string>();

                //loops through the Swathe DataTable and populates the polygonIDList with unique polygonID's.  
                foreach (DataRow row in inputSwathe.DataTable.Rows)
                {
                    //Gets the selected column from the user for the polygon ID
                    string polygonID = Convert.ToString(row[polygonIDSelect]);
                    //If the polygonIDList doesn't have the ID loaded, add it now
                    if (!polygonIDList.Contains(polygonID))
                    {
                        polygonIDList.Add(polygonID);
                    }
                }

                //loops through the list to find matches
                foreach (string ID in polygonIDList)
                {
                    //Look in the inputSwathe DataTable
                    foreach (Feature fe in inputSwathe.Features)
                    {
                        string feID = Convert.ToString(fe.DataRow[polygonIDSelect]);

                        if (ID == feID)
                        {
                            decimal polygonSwatheArea = Convert.ToDecimal(fe.DataRow[swatheAreaSelect]);
                            swatheAreaSum += polygonSwatheArea;
                        }

                    }

                    foreach (Feature grid in inputGrid.Features)
                    {
                        string polygonID = Convert.ToString(grid.DataRow[polygonIDSelect]);

                        if (polygonID == ID)
                        {
                            grid.DataRow[txtSwathe.Text] = swatheAreaSum;
                        }

                    }
                    swatheAreaSum = 0;
                }
            }
            catch
            {
                MessageBox.Show("Entry Error.  Please check the values entered and try again.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
                   
            this.Close();
            

            //Saving Options

            if(radOriginal.Checked)
            {
                inputGrid.Save();
                MessageBox.Show("The input grid attributes have been updated with the swathe area data and saved." +
                "\n|n File Location: " + inputGrid.Filename, "Update Successful");
            }

            else if (radNewShape.Checked)
            {
                FeatureSet output = new FeatureSet(FeatureType.Polygon);
                output = (FeatureSet)inputGrid;
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

            else
            {
                MessageBox.Show("The input grid attributes have been updated with the swathe area data.", "Update Successful");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
                MessageBox.Show("The file will not be saved");
                return;
            }
            else
            {
                output.SaveAs(strFileName, true);
            }
        }

        private void btnInputSwathe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the input swathe that has been segmented by a grid layer and the area of all swathes calculated."  , "Input Swathe Help");
        }

        #endregion


    }
}
