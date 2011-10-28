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
        List<string> layerList1 = new List<string>();
        List<string> layerList2 = new List<string>();
        int gridSelectIndex;
        int swatheSelectIndex;
        string columnHead1Select;
        string columnHead2Select;
        IFeatureSet inputSwathe = null;
        IFeatureSet inputGrid = null;
        FeatureSet output = new FeatureSet();


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
            cmbGrid.Items.Clear();
            cmbGridID.Items.Clear();
            cmbSwathe.Items.Clear();
            cmbSwatheID.Items.Clear();

            //Get the layers from the map
            getLayers(layerList1);
            cmbGrid.DataSource = layerList1;
            getLayers(layerList2);
            cmbSwathe.DataSource = layerList2;

        }

        #region Methods

        //Method to get user selected variables from Split Tracks form
        private void getLayers(List<string> layerList)
        {
            //clears layerLists
            layerList.Clear();

            //loops through the map layers and adds them to the layerLists.
            //These lists will be used to populate the combo boxes.
            if (_map.Layers.Count > 0 )
            {
                for (int i = 0; i < _map.Layers.Count; i++)
                {
                    string title = _map.Layers[i].LegendText;
                    layerList.Insert(i, title);                   
                }
            }
            else
            {
                MessageBox.Show("Please add another layer to the map for this operation", "Not enough layers present.");
                return;
            }
        }

//Getting user selections-----------------------------------------
        //Select the polygon grid layer index
        private void cmbGrid_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //Clear out the ID combobox to match the next selection
            cmbGridID.Items.Clear();
            //gets the user selected index from the combobox populated with layers
            gridSelectIndex = cmbGrid.SelectedIndex;
            //selects the input layer based on the index
            inputGrid = (IFeatureSet)_map.Layers[gridSelectIndex].DataSet;
            //Add all column headers of the selected layer to the ID combobox
            foreach (DataColumn col in inputGrid.DataTable.Columns)
            {
                string colHead = col.ColumnName;
                cmbGridID.Items.Add(colHead);
            }
        }
            
        //Takes the user selected ID string for use later in the join
        private void cmbGridID_SelectedIndexChanged(object sender, EventArgs e)
        {
            columnHead1Select = Convert.ToString(cmbGridID.SelectedItem);    //The selected text from the combobox
        }
      
        //Same functionality as above
        private void cmbSwathe_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSwatheID.Items.Clear();
            swatheSelectIndex = cmbSwathe.SelectedIndex;
            inputSwathe = (IFeatureSet)_map.Layers[swatheSelectIndex].DataSet;
            foreach (DataColumn col in inputSwathe.DataTable.Columns)
            {
                string colHead = col.ColumnName;
                cmbSwatheID.Items.Add(colHead);
            }
        }
           
        
        private void cmbSwatheID_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            columnHead2Select = Convert.ToString(cmbSwatheID.SelectedItem);
             
        }


        #endregion

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //Requirement #10 Functionality-------------------------------------------------------------
            if (gridSelectIndex != swatheSelectIndex)
            {   
                //Create and add new column to the swathe attribute table to hold the swathe effort value
                System.Data.DataColumn swatheEffort = new System.Data.DataColumn("Swathe Effort", typeof(double));
                inputSwathe.DataTable.Columns.Add(swatheEffort);

                //initializes a new list to hold polygonID's
                //Uses string so ID can hold letters and numbers
                List<string> polygonIDList = new List<string>();

                //loops through the Swathe DataTable and populates the polygonIDList with unique polygonID's.
                //This functionality comes from requirement #8 - split survey swathes by polygons.  
                foreach (DataRow row in inputSwathe.DataTable.Rows)
                {
                    //Gets the selected column from the user for the polygon ID
                   string polygonID = Convert.ToString(row[columnHead2Select]);
                    
                    if (!polygonIDList.Contains(polygonID))
                    {
                        polygonIDList.Add(polygonID);
                    }
                }

                //loops through the list to find matches
                foreach (string ID in polygonIDList) 
                {
                    //initializes a new list called swatheAreas
                    List<double> swatheAreas = new List<double>();

                    //loops through each inputSwathe feature and if the polygonID in the feature matches the ID in the 
                    //polygonIDList, it collects the Survey Line Length for the feature and adds it to the LineLengths list.
                    foreach (Feature fe in inputSwathe.Features)
                    {
                        string feID = Convert.ToString(fe.DataRow[columnHead2Select]);

                        if (String.ReferenceEquals(ID, feID))
                        {
                            double polygonSwatheArea = Convert.ToDouble(fe.DataRow["Swathe_Area"]);
                            swatheAreas.Add(polygonSwatheArea);
                        }
                    }

                    //calculates the sum of all the swathes
                    double swatheAreaSum = Math.Round(swatheAreas.Sum(), 3);

                    //loops through the inputPolygon DataTable and if the "polygonID" matches the polygonID from the 
                    //polygonSwatheArea feature, the swathe area sum is added to the swathe area sum
                    foreach (DataRow row in inputGrid.DataTable.Rows)
                    {
                        string feSwatheID = Convert.ToString(row[columnHead1Select]);

                        if (String.ReferenceEquals(feSwatheID, ID))
                        {
                            row["Swathe_area_sum"] = swatheAreaSum;
                        }

                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

       

     }
}
