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
    public partial class frmSplitPolygons : Form
    {
        Map _map = null;

        public frmSplitPolygons()
        {
            InitializeComponent();
        }

        public frmSplitPolygons(Map map)
        {
            _map = map;
            InitializeComponent();
        }

        private void frmSplitPolygons_Load(object sender, EventArgs e)
        {
            GetLayers();
        }

        /// <summary>
        /// Get the layers
        /// </summary>
        private void GetLayers()
        {
            int i = 0;
            if (_map.Layers.Count > 0)
            { 
                foreach (IMapLayer iLa in _map.Layers)
                {
                    FeatureSet fT = (FeatureSet)iLa.DataSet;
                    if (fT.FeatureType == FeatureType.Polygon)
                    {
                        cbxPolygon1.Items.Add(iLa.LegendText);
                        cbxPolygon2.Items.Add(iLa.LegendText);

                        i++;
                    }

                }
            }
            else
            {
                MessageBox.Show("Please add two polygon layers ");
                Close();
                return;
            }

            if (i < 2)
            {
                MessageBox.Show("Please add two polygon layers ");
                Close();
                return;
            
            }
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //verify if the layers selected are different
            if (cbxPolygon1.Text != "" && cbxPolygon2.Text == cbxPolygon1.Text)
            {
                MessageBox.Show("Please select two different polygon layers");
                return;
            }

            //The layers selected should be assigned to IFeatureSet
             IFeatureSet polyg2=null;
             IFeatureSet polyg1=null;
            foreach (IMapLayer iLa in _map.Layers)
            {
                if (iLa.LegendText == cbxPolygon1.Text)
                    polyg1 = (IFeatureSet)iLa.DataSet;
                if (iLa.LegendText == cbxPolygon2.Text)
                {
                    polyg2 = (IFeatureSet)iLa.DataSet;
                    if (!polyg2.DataTable.Columns.Contains("polygonID") && !polyg2.DataTable.Columns.Contains("POLYGONID"))
                    {
                        polyg2.AddFid();  //  Adds FID
                        polyg2.DataTable.Columns["FID"].ColumnName = "polygonID"; //  Changes FID column name.
                    }
                }

            }

            //It is executed the intersection.. copying all fields
            IFeatureSet tempOutput = polyg1.Intersection(polyg2, FieldJoinType.All, null);
            
            //It is assigned the same projection to the output layer
            tempOutput.Projection = polyg1.Projection;
            if (tempOutput == null) return;
            tempOutput.AddFid();
            tempOutput.DataTable.Columns["FID"].ColumnName = "split_swatheID";

            //it is saved the intersection file
            Validator.SaveShapefile(" intersection between " + cbxPolygon1.Text + " and " + cbxPolygon2.Text, (FeatureSet)tempOutput);

            MapPolygonLayer PolIntersectLayer = new MapPolygonLayer(tempOutput);

            //Name of the intersect layer in the legend
            PolIntersectLayer.LegendText = "Split_"+ cbxPolygon1.Text + "_" + cbxPolygon2.Text;
            PolIntersectLayer.Symbolizer.SetFillColor(Color.Red);

            //the layer is added
            _map.Layers.Add(PolIntersectLayer);
            _map.ResetBuffer();
            MessageBox.Show("The intersection was executed sucessfully");
            this.Cursor = Cursors.Default;
            Close();
        }

        private void cbxPolygon1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbxPolygon2.Text != "" && cbxPolygon2.Text == cbxPolygon1.Text)
                MessageBox.Show("Please select two different polygon layers");

        }

        private void cbxPolygon2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPolygon1.Text != "" && cbxPolygon2.Text == cbxPolygon1.Text)
                MessageBox.Show("Please select two different polygon layers");
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
