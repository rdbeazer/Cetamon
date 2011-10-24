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
    public partial class frmCalculateBuffer : Form
    {

        Map _map = null;

        public frmCalculateBuffer()
        {
            InitializeComponent();
        }

        public frmCalculateBuffer(Map map)
        {
            _map = map;
            InitializeComponent();
        }

        private void rbtOne_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "Field :";
            label3.Visible = false;
            cbxField2.Visible = false;
            
        }

        private void rbtTwo_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "Field 1 (Right side)";
            label3.Visible = true;
            cbxField2.Visible = true;

        }

        private void frmCalculateBuffer_Load(object sender, EventArgs e)
        {
            GetLayers();
        }

        /// <summary>
        /// Get the layers
        /// </summary>
        private void GetLayers()
        {
            if (_map.Layers.Count > 0)
            {
                foreach (IMapLayer iLa in _map.Layers)
                {
                    IFeatureSet fT = (IFeatureSet)iLa.DataSet;
                    if (fT.FeatureType == FeatureType.Line)
                        cbxLayer.Items.Add(iLa.LegendText);
                }
            }
            else
            {
                MessageBox.Show("Please add a layer to the map");
                return;
            }
        }


        private void FillFields(string layer)
        {
            if (layer == "") return;
            cbxField1.Items.Clear();
            cbxField2.Items.Clear();
            cbxDissolve.Items.Clear();

            IFeatureSet fT=null;
            foreach (IMapLayer iLa in _map.Layers)
            {
                 fT = (IFeatureSet)iLa.DataSet;
                 if (fT.Name == layer)
                     break;
            }
            if (fT == null) return;
            foreach (DataColumn col in fT.DataTable.Columns)
            {
                if (col.DataType == typeof(double) || col.DataType == typeof(int))
                {
                    cbxField1.Items.Add(col.ColumnName);
                    cbxField2.Items.Add(col.ColumnName);
                }
                if (col.DataType == typeof(int) || col.DataType == typeof(string))
                    cbxDissolve.Items.Add(col.ColumnName);
            }
        
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            IFeatureSet fT = null;
            IFeatureSet outp = null;
            foreach (IMapLayer iLa in _map.Layers)
            {
                fT = (IFeatureSet)iLa.DataSet;
                if (fT.Name == cbxLayer.Text)
                    break;
            }

            if (rbtOne.Checked)
            {
                if (cbxField1.Text == "")
                {
                    MessageBox.Show("Please select a field");
                    return;
                }
                outp=CalculateBuffer(fT, cbxField1.Text);
            }

            if (rbtTwo.Checked)
            { 
            
            }

            if (chkDissolve.Checked)
            { 
            
            
            }
            IMapPolygonLayer Ipo = new MapPolygonLayer(outp);

            Ipo.LegendText = "Buffer";
            Ipo.Symbolizer.SetFillColor(Color.Green);

            _map.Layers.Add(Ipo);
        }


        private IFeatureSet CalculateBuffer(IFeatureSet feaS, string field)
        {
            IFeatureSet outp = new FeatureSet() ;
            outp.FeatureType = FeatureType.Polygon;

            outp.Projection = _map.Projection;

            foreach (DataColumn col in feaS.DataTable.Columns) { 
                   outp.DataTable.Columns.Add(new DataColumn(col.ColumnName, col.DataType));
                }

            int i = 0;
            foreach (DataRow row in feaS.DataTable.Rows)
            {
                double v = Convert.ToDouble(row[field])/100000;
                IFeature fea = outp.AddFeature(feaS.Features[i].Buffer(v));
                foreach (DataColumn col in feaS.DataTable.Columns)
                {
                    fea.DataRow[col.ColumnName] = row[col.ColumnName];
                }
                i++;
            }

            return outp;

        }


        private IFeatureSet CalculateBuffer(IFeatureSet feaS, string field, string field2)
        {
            return null;
        }

        private void cbxLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillFields(cbxLayer.Text);
        }

    }
}
