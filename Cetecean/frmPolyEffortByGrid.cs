using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cetecean
{
    public partial class frmPolyEffortByGrid : Form
    {
        public frmPolyEffortByGrid()
        {
            InitializeComponent();
        }

        List<string> layerList1 = new List<string>();
        List<string> layerList2 = new List<string>();
        int polygonSelectIndex = 0;
        int lineSelectIndex = 0;

        private void frmSplitTrack_Load_1(object sender, EventArgs e)
        {
            //Clear the combobox items from any previous runs
            cmbGrid.Items.Clear();
            cmbLine.Items.Clear();

            //Populate the comboboxes with lists from the cetacean form
            cmbGrid.DataSource = layerList1;
            cmbLine.DataSource = layerList2;
        }

        //Methods to import layer list from Map1---------------------
        public void passList1(List<string> layerList)
        {
            this.layerList1 = layerList;

        }

        public void passList2(List<string> layerList)
        {
            this.layerList2 = layerList;

        }
        //---------------------------------------------------------

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

        //Set and pass the indices to the main form, close this form
        private void btnSplit_Click_1(object sender, EventArgs e)
        {
            //check to make sure selections are different
            if (polygonSelectIndex != lineSelectIndex)
            {
                getPolygonIndex();
                getLineIndex();
                this.Close();
            }
            else
            {
                MessageBox.Show("The selected layers must be different");
                cmbGrid.Focus();
                return;
            }
        }

        public int getPolygonIndex()
        {
            return polygonSelectIndex;
        }

        public int getLineIndex()
        {
            return lineSelectIndex;
        }

       

        
        


    }
}
