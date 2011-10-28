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
    public partial class frmPolyEffortByGrid : Form
    {
        #region Class Level Variables
        Map _map = null;
        List<string> layerList1 = new List<string>();
        List<string> layerList2 = new List<string>();
        string columnHead1Select;
        string columnHead2Select;
        int gridSelectIndex = 0;
        int trackSelectIndex = 0;
        IFeatureSet inputGrid = null;
        IFeatureSet inputTrack = null;
        FeatureSet output = new FeatureSet();
        #endregion

        public frmPolyEffortByGrid()
        {
            InitializeComponent();
        }

        public frmPolyEffortByGrid(Map map)
        {
            _map = map;
            InitializeComponent();
        }

        private void frmPolyEffortByGrid_Load(object sender, EventArgs e)
        {
            //Clear the combobox items from any previous runs
            cmbGrid.Items.Clear();
            cmbGridID.Items.Clear();
            cmbTrack.Items.Clear();
            cmbTrackID.Items.Clear();

            //Populate the comboboxes with lists from the cetacean form
            getLayers(layerList1);
            cmbGrid.DataSource = layerList1;
            getLayers(layerList2);
            cmbTrack.DataSource = layerList2;

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
           

        //Select the polygon grid layer index
        private void cmbGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Clear out the ID combobox to match the next selection
            cmbGridID.Items.Clear();
            gridSelectIndex = cmbGrid.SelectedIndex;
            inputGrid = (IFeatureSet)_map.Layers[gridSelectIndex].DataSet;
            //Add all column headers of the selected layer to the ID combobox
            foreach (DataColumn col in inputGrid.DataTable.Columns)
            {
                string colHead = col.ColumnName;
                cmbGridID.Items.Add(colHead);
            }
        }

        private void cmbGridID_SelectedIndexChanged(object sender, EventArgs e)
        {
            columnHead1Select = Convert.ToString(cmbGridID.SelectedItem);    //The selected text from the combobox
        }


        //Select the track line layer index
        private void cmbLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTrackID.Items.Clear();
            trackSelectIndex = cmbTrack.SelectedIndex;
            inputTrack = (IFeatureSet)_map.Layers[trackSelectIndex].DataSet;
            foreach (DataColumn col in inputTrack.DataTable.Columns)
            {
                string colHead = col.ColumnName;
                cmbTrackID.Items.Add(colHead);
            }
        }

        private void cmbTrackID_SelectedIndexChanged(object sender, EventArgs e)
        {
            columnHead2Select = Convert.ToString(cmbTrackID.SelectedItem);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (gridSelectIndex != trackSelectIndex)
            {
                //Uses selected layers for functionality
                IFeatureSet inputTrack = (IFeatureSet)_map.Layers[trackSelectIndex].DataSet;
                IFeatureSet inputGrid = (IFeatureSet)_map.Layers[gridSelectIndex].DataSet;

                //creates new DataColumn "lineLengthCol" and
                //adds the column to the inputPolygon DataTable
                System.Data.DataColumn trackLengthCol = new System.Data.DataColumn("Sum_Tracks", typeof(double));
                inputGrid.DataTable.Columns.Add(trackLengthCol);

                //initializes a new list to hold polygonID's
                List<string> polygonIDList = new List<string>();

                //loops through the inputLine DataTable and populates the polygonIDList with unique polygonID's.
                foreach (DataRow row in inputTrack.DataTable.Rows)
                {
                    string polygonID = Convert.ToString(row[columnHead2Select]);
                    if (!polygonIDList.Contains(polygonID))
                    {
                        polygonIDList.Add(polygonID);
                    }
                }

                //loops through each ID in the polygonIDList
                foreach (string ID in polygonIDList)
                {
                    //initializes a new list called lineLengths
                    List<double> trackLengths = new List<double>();

                    //loops through each inputLine feature and if the polygonID in the feature matches the ID in the 
                    //polygonIDList, it collects the Survey Line Length for the feature and adds it to the LineLengths list.
                    foreach (Feature fe in inputTrack.Features)
                    {
                        string feID = Convert.ToString(fe.DataRow[columnHead2Select]);

                        if (String.ReferenceEquals(feID,ID))
                        {
                            double trackLength = Convert.ToDouble(fe.DataRow["TrackLength"]);
                            trackLengths.Add(trackLength);
                        }
                    }

                    //calculates the sum of all the lines in the lineLengths list and rounds to three decimal places.
                    double trackLengthSum = Math.Round(trackLengths.Sum(), 3);

                    //loops through the inputPolygon DataTable and if the "polygonID" matches the polygonID from the 
                    //inputLine feature, the lineLength Sum is added to the "Sum_Tracks" column in the inputPolygon DataTable.
                    foreach (DataRow row in inputGrid.DataTable.Rows)
                    {
                        string fetrackID = Convert.ToString(row[columnHead1Select]);

                        if (string.ReferenceEquals(fetrackID,ID))
                        {
                            row["Sum_Tracks"] = trackLengthSum;
                        }
                        else
                        {
                            row["Sum_Tracks"] = 0;
                        }
                    }


                }
                //Alerts the user that the attributes have been updated.
                MessageBox.Show("The polygon grid attributes have been updated.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            else
            {
                //Check to make sure selection is different
                MessageBox.Show("The selected layers must be different", "Selection Error");
                cmbGrid.Focus();
                return;
            }
        }
        #endregion

        

    }
}
