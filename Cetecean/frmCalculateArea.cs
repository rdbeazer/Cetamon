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
    public partial class frmCalculateArea : Form
    {
        Map _map = null;

        public frmCalculateArea(Map map)
        {
            _map = map;
            InitializeComponent();
        }


        private void frmCalculateArea_Load(object sender, EventArgs e)
        {
            GetLayers();
        }

        /// <summary>
        /// Get the layers
        /// </summary>
        private void GetLayers()
        {

            if (_map.GetPolygonLayers().Length > 0)
            {
                for (int i = 0; i < _map.GetPolygonLayers().Length; i++)
                {
                    string title = _map.GetPolygonLayers()[i].LegendText;
                    cbxPolygon1.Items.Add(title);
                }
            }

            else
            {
                MessageBox.Show("Please add a polygon layer ");
                Close();
                return;
            }


        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (cbxPolygon1.Text == "") return;
            IFeatureSet polyg1 = null;
            
            //it is selected layer
            foreach (IMapLayer iLa in _map.Layers)
                if (iLa.LegendText == cbxPolygon1.Text)
                    polyg1 = (IFeatureSet)iLa.DataSet;

            //it is verify if the area field exists.
            DataColumn area = polyg1.DataTable.Columns["Area"];

            //if the area field doesn't exist, it is created and added in datatable 
            if (area==null)
            {
              area= new DataColumn("Area",typeof(double));
              polyg1.DataTable.Columns.Add(area);

            }

            //It is calculated the area of each feature
            foreach (IFeature fea in polyg1.Features)
            {
                fea.DataRow["Area"] = fea.Area();
            }
            MessageBox.Show("The area was calculated sucessfully");
            try
            {
                polyg1.Save();
            }
            catch(Exception) {
                Validator.SaveShapefile("layer", (FeatureSet)polyg1);
            }
            
            Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
