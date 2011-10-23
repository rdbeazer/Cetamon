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
        List<string> gridAttributeList = new List<string>();
        List<string> trackAttributeList = new List<string>();
        int polygonSelectIndex = 0;
        int lineSelectIndex = 0;
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

        private void frmSplitTrack_Load_1(object sender, EventArgs e)
        {
            //Clear the combobox items from any previous runs
            cmbGrid.Items.Clear();
            cmbLine.Items.Clear();

            getLayers();

            //Populate the comboboxes with lists from the cetacean form
            cmbGrid.DataSource = layerList1;
            cmbLine.DataSource = layerList2;
        }

        #region Methods
        //Method to get user selected variables from Split Tracks form
        private void getLayers()
        {
            //clears layerLists
            layerList1.Clear();
            layerList2.Clear();

            //loops through the map layers and adds them to the layerLists.
            //These lists will be used to populate the combo boxes.
            if (_map.Layers.Count > 1)
            {
                for (int i = 0; i < _map.Layers.Count; i++)
                {
                    string title = _map.Layers[i].LegendText;

                    //Checking file types-------------------------
                    IFeatureSet checkType = (IFeatureSet)_map.Layers[i].DataSet;

                    if (checkType.FeatureType == FeatureType.Polygon)
                    {
                        layerList1.Insert(i, title);
                    }
                    //Note - for some unknown reason, this else if statement ruins the functionality
                    //else if (checkType.FeatureType == FeatureType.Line)
                    //{
                    layerList2.Insert(i, title);
                    //}
                }
            }
            else
            {
                MessageBox.Show("Please add a layer to the map");
                return;
            }
        }


        //Select the polygon grid layer index
        private void cmbGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            polygonSelectIndex = cmbGrid.SelectedIndex;
        }

        //Select the track line layer index
        private void cmbLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            lineSelectIndex = cmbLine.SelectedIndex;
        }


        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (polygonSelectIndex != lineSelectIndex)
            {
                //Uses selected layers for functionality
                IFeatureSet inputLine = (IFeatureSet)_map.Layers[lineSelectIndex].DataSet;
                IFeatureSet inputPolygon = (IFeatureSet)_map.Layers[polygonSelectIndex].DataSet;

                //creates new DataColumn "lineLengthCol" and
                //adds the column to the inputPolygon DataTable
                System.Data.DataColumn lineLengthCol = new System.Data.DataColumn("Sum_Tracks", typeof(double));
                inputPolygon.DataTable.Columns.Add(lineLengthCol);

                //initializes a new list to hold polygonID's
                List<int> polygonIDList = new List<int>();

                //loops through the inputLine DataTable and populates the polygonIDList with unique polygonID's.
                foreach (DataRow row in inputLine.DataTable.Rows)
                {
                    int polygonID = Convert.ToInt32(row["polygonID"]);
                    if (!polygonIDList.Contains(polygonID))
                    {
                        polygonIDList.Add(polygonID);
                    }
                }


                //loops through each ID in the polygonIDList
                foreach (int ID in polygonIDList)
                {
                    //initializes a new list called lineLengths
                    List<double> lineLengths = new List<double>();

                    //loops through each inputLine feature and if the polygonID in the feature matches the ID in the 
                    //polygonIDList, it collects the Survey Line Length for the feature and adds it to the LineLengths list.
                    foreach (Feature fe in inputLine.Features)
                    {
                        int feID = Convert.ToInt32(fe.DataRow["polygonID"]);

                        if (feID == ID)
                        {
                            double lineLength = Convert.ToDouble(fe.DataRow["TrackLength"]);
                            lineLengths.Add(lineLength);
                        }
                    }

                    //calculates the sum of all the lines in the lineLengths list and rounds to three decimal places.
                    double lineLengthSum = Math.Round(lineLengths.Sum(), 3);

                    //loops through the inputPolygon DataTable and if the "polygonID" matches the polygonID from the 
                    //inputLine feature, the lineLength Sum is added to the "Sum_Tracks" column in the inputPolygon DataTable.
                    foreach (DataRow row in inputPolygon.DataTable.Rows)
                    {
                        int feLineID = Convert.ToInt32(row["polygonID"]);

                        if (feLineID == ID)
                        {
                            row["Sum_Tracks"] = lineLengthSum;
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
