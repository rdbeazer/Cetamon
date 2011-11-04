using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotSpatial.Data;
using DotSpatial.Controls;
using DotSpatial.Symbology.Forms;
namespace Cetecean
{
    public partial class frmCalculateField : Form
    {
        Map _map;
        IFeatureSet _featureset;
        public frmCalculateField(Map map)
        {
            _map = map;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFieldCal_Click(object sender, EventArgs e)
        {
            IMapLayer  la=null;
            //Loop maps
            for (int i = 0; i < _map.Layers.Count; i++)
            {
                string title = _map.Layers[i].LegendText;
                if (title == cbxList.Text) 
                {
                    la = _map.Layers[i];
                }
            }
            //verify if layer is not null
            if (la == null) return;
            //load featureset

             _featureset = (IFeatureSet)la.DataSet;

            //Open Dialog AttributeCalculator of DotSpatial
            AttributeCalculator attributeCal = new AttributeCalculator();
            //Show the dialog
            attributeCal.Show();
            //Set the featureset selected
            attributeCal.FeatureSet = _featureset; 
            //Define list fields
            List<string> fieldList = new List<string>();
            
            //populate the list of fields
            foreach (DataColumn dataCol in _featureset.DataTable.Columns)
                fieldList.Add(dataCol.ToString());

            //load the list of fields in the dialog
            attributeCal.LoadTableField(fieldList); //Load all fields
            
            //assign an event when a new field is created
            attributeCal.NewFieldAdded += AttributeCalNewFieldAdded; //when user
        }

        private void frmCalculateField_Load(object sender, EventArgs e)
        {
            //load the list of layers
            getLayers();
        }

        void AttributeCalNewFieldAdded(object sender, EventArgs e)
        {
            //obaint the dialog object
            AttributeCalculator attributeCal = sender as AttributeCalculator;
            //update the featureset

            if (attributeCal != null) _featureset = attributeCal.FeatureSet;

            Close();
        }

        private void getLayers()
        {
            //clears layerLists
            cbxList.Items.Clear();

            //loops through the map layers and adds them to the layerLists.

            if (_map.Layers.Count > 0)
            {
                for (int i = 0; i < _map.Layers.Count; i++)
                {
                    string title = _map.Layers[i].LegendText;
                    cbxList.Items.Add(title);
                }
            }
            else
            {
                btnFieldCal.Enabled = false;
            }
        }

    }
}
