﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using DotSpatial.Controls;
using DotSpatial.Topology;
using DotSpatial.Data;
using DotSpatial.Symbology;
using DotSpatial.Projections;

namespace Cetecean
{
    public partial class frmCalculateLineLength : Form
    {
        Map _map = null;
        List<string> layerList = new List<string>();
        int selectedIndex = 0;
        public frmCalculateLineLength()

        {
            InitializeComponent();
        }

        public frmCalculateLineLength(Map map)
        {
            _map = map;
            InitializeComponent();
        }

        private void frmCalculateLineLength_Load(object sender, EventArgs e)
        {
            cmbLine.Items.Clear();
            getLayers();
        }

        private void getLayers()
        {
            try
            {
                layerList.Clear();

                IMapLineLayer[] lineLayers = _map.GetLineLayers(); // Gets the collection of line layers from the map.
                int lineCount = lineLayers.Count();  // Gets a count of line layers

                if (lineCount > 0)  // Checks to make sure a line layer is loaded in the map
                {
                    for (int i = 0; i < _map.Layers.Count; i++)  // Loops through each map layer.
                    {
                        IMapLayer layer = _map.Layers[i];

                        if (lineLayers.Contains(layer))  // If layer is a Line layer.
                        {
                            cmbLine.Items.Add(layer.LegendText);  // Adds line layer to the combo box.
                        }

                        layerList.Insert(i, layer.LegendText);  // Inserts the index and legend text in the layerList.
                    }
                }
                else
                {
                    MessageBox.Show("Please add a point layer to the map");
                    return;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Entry Error.  Please check the values entered and try again.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.GetType().ToString() + "\n" + ex.StackTrace, "Exception");
                return;
            }

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Creates IFeatureSet using the selectedIndex from the map layers.
                IFeatureSet lineInput = (IFeatureSet)_map.Layers[selectedIndex].DataSet;

                //  Assigns string value of textbox.
                string lineLengthString = txtAttributeField.Text;
                //  Creates a new DataColumn with the heading as the string.
                DataColumn lineLengthCol = new DataColumn(lineLengthString, typeof(double));
                //Check to make sure the attribute table doesn't already contain this column name
                if (lineInput.DataTable.Columns.Contains(lineLengthCol.ColumnName))
                {
                    MessageBox.Show("The attribute table already contains a column with the name " + "'" + lineLengthCol.ColumnName +
                        "'. \nPlease rename the column.", "Input Error");
                        txtAttributeField.Focus();
                        return;
                }
                //  Adds the new DataColumn if there isn't already a column with that name.
                else
                {
                    lineInput.DataTable.Columns.Add(lineLengthCol);
                }

                    //  Loops through each feature and assigns the variables with the appropriate coordinates of each feature.
                    foreach (Feature lineF in lineInput.Features)
                    {
                        double startLat = lineF.Coordinates[0].Y;
                        double startLon = lineF.Coordinates[0].X;
                        double endLat = lineF.Coordinates[1].Y;
                        double endLon = lineF.Coordinates[1].X;

                        // Calls the GetDistance method
                        Functions getDist = new Functions();
                        double lineLength = getDist.GetDistance(startLat, endLat, startLon, endLon);

                        //  Assigns the value retrieved from the GetDistance method to the specified location.
                        lineF.DataRow[lineLengthCol] = lineLength;
                    }

                    this.Close(); //  Closes the form

                    if (radOriginal.Checked)  //  If user checks the box to save the attributes to the original shapefile.
                    {
                        DialogResult dResult = MessageBox.Show("The polygon grid attributes have been updated.\n\nNew Field(s):" + lineLengthCol.ColumnName
                        + "\n\nAre you sure you want to save the changes to the original shapefile?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                        if (dResult == DialogResult.Yes)
                        {
                            lineInput.Save();

                            MessageBox.Show("The updated attributes have been saved to the original shapefile:\n\n" +
                            lineInput.Filename, "File Saved");
                        }
                        if (dResult == DialogResult.No)
                        {
                            MessageBox.Show("The updated attributes have not been saved.", "File Not Saved");
                            return;
                        }
                    }

                    else if (radNewShape.Checked)  // If user checks the box to save the attributes to a new shapefile.
                    {
                        //  output FeatureSet is declared
                        FeatureSet output = new FeatureSet(FeatureType.Polygon);
                        //  output is equal to the pointInput
                        output = (FeatureSet)lineInput;

                        //  Calls the saveFile method
                        Functions saveObj = new Functions();
                        saveObj.saveFile(output);

                        if (saveObj.saved)
                        {
                            //  Alerts the user that the file has been saved.
                            //  Asks the user if they would like to add the saved file to the map.
                            DialogResult diaResult = MessageBox.Show("The updated attributes have been saved to the new file " +
                                output.Filename + ".\n\nWould you like to add the new file to the map?", "File Saved",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                            //  If the user clicks "Yes", the saved file is added as a new point layer on the map.
                            if (diaResult == DialogResult.Yes)
                            {
                                MapLineLayer newLineLayer = new MapLineLayer(output);
                                string file = Path.GetFileNameWithoutExtension(output.Filename);
                                newLineLayer.LegendText = file;
                                newLineLayer.Projection = _map.Projection;
                                _map.Layers.Add(newLineLayer);
                                _map.ResetBuffer();
                            }
                        }
                    }
                    else if(radSession.Checked)
                    {
                        MessageBox.Show("The input line lengths have been calculated, but the file has not been saved.", "Update Successful");
                    }
                }
            
            catch (FormatException)
            {
                MessageBox.Show("Entry Error.  Please check the values entered and try again.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            catch (DuplicateNameException dup)
            {
                MessageBox.Show(dup.Message + "\n\n" + dup.GetType().ToString() + "\n\nIt appears that this operation has already been performed using the same input.", "Exception");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.GetType().ToString() + "\n" + ex.StackTrace, "Exception");
                return;
            }
        }

        private void cmbLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedLine = cmbLine.SelectedItem.ToString();
            selectedIndex = layerList.IndexOf(selectedLine);
            btnCalculate.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
