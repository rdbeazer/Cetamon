using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Topology;

namespace Cetecean
{
    public partial class frmDissolve : Form
    {
        Map _map = null;
        public frmDissolve(Map map)
        {
            this._map = map;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetLayers();
        }

        private void GetLayers()
        {
            if (_map.Layers.Count > 0)
            {
                foreach (IMapLayer iLa in _map.GetFeatureLayers())
                {
                    FeatureSet fT = (FeatureSet)iLa.DataSet;
                    //It is added only the line layers
                    if (fT.FeatureType == FeatureType.Polygon)
                        cbxLayer.Items.Add(iLa.LegendText);
                }
            }
            else
            {
                MessageBox.Show("Please add a layer to the map");
                Close();
                return;
            }
        }

        private void cbxLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillFields(cbxLayer.Text);
        }


        private void FillFields(string layer)
        {
            if (layer == "") return;
            // clear the comboBox
            cbxDissolve.Items.Clear();

            //it is obtained the featureset of the layer selected
            IFeatureSet fT = null;
            foreach (IMapLayer iLa in _map.GetFeatureLayers())
            {
                fT = (IFeatureSet)iLa.DataSet;
                if (fT.Name == layer)
                    break;
            }


            if (fT == null) return;


            foreach (DataColumn col in fT.DataTable.Columns)
            {
                if (col.DataType == typeof(int) || col.DataType == typeof(Double) || col.DataType == typeof(Int32) || col.DataType == typeof(Int64) || col.DataType == typeof(string))
                    cbxDissolve.Items.Add(col.ColumnName);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
           if ( cbxDissolve.Text =="" || cbxLayer.Text=="")
           {
               MessageBox.Show("Please complete the information");
           }
            
            IFeatureSet fT = null;
            foreach (IMapLayer iLa in _map.GetFeatureLayers())
            {
                fT = (IFeatureSet)iLa.DataSet;
                if (fT.Name == cbxLayer.Text)
                    break;
            }

            try
            {
                IFeatureSet fea = fT.Dissolve(cbxDissolve.Text);
                string file=Validator.SaveShapefileString("dissolve", (FeatureSet)fea);
                if (file != "")
                {
                    _map.AddLayer(@file);
                }
                this.Cursor = Cursors.Default;
                Close();
            }
            catch
            {
                MessageBox.Show("Problem dissolving the polygon layer");
                this.Cursor = Cursors.Default;
                Close();
            }
            this.Cursor = Cursors.Default;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
