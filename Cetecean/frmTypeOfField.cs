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
    public partial class frmTypeOfField : Form
    {

        DataTable _data;
        DataTable listData;
        Dictionary<string, string> listOut;
        Dictionary<string, string> listLatLon = new Dictionary<string,string>();
        Dictionary<string, string> listFormDate= new Dictionary<string,string>();
        string type = "";

        public Dictionary<string, string> List
        {
            set { listOut = value; }
            get { return listOut; }

        }


        public Dictionary<string, string> FormatDate
        {
            get { return listFormDate; }
        }

        public Dictionary<string, string> ListLatLon
        {
            get
            {
                if (type == "point")
                {
                    listLatLon.Add("Latitude", cbxLatitude1.Text);
                    listLatLon.Add("Longitude", cbxLongitude1.Text);
                    return listLatLon;
                }else
                {
                    listLatLon.Add("StartLat", cbxLatitude1.Text);
                    listLatLon.Add("StartLon", cbxLongitude1.Text);
                    listLatLon.Add("EndLat", cbxLatitude2.Text);
                    listLatLon.Add("EndLon", cbxLongitude2.Text);
                    return listLatLon;
                }
  
            }

        }


        public DataTable Data 
        {
            set { _data = value; }
            get { return _data; }
        
        }


        public frmTypeOfField()
        {
            InitializeComponent();
        }


        public frmTypeOfField(string type, Dictionary<string,string> list)
        {
            InitializeComponent();
            this.type = type;
            if (type == "line")
            {
                label4.Text = "Start Latitude";
                label5.Text = "Start Longitude";
                label7.Visible = true;
                label6.Visible = true;
                cbxLatitude2.Visible = true;
                cbxLongitude2.Visible = true;
            }

            listData = new DataTable();
            listData.Columns.Add("Name", typeof(string));
            listData.Columns.Add("Type", typeof(string));

            listOut = list;
            int i = 0;
            foreach(string v in list.Keys)
            {
                listData.Rows.Add(v, list[v]);
                AddData(v,i);
                i++;
            }
            dgvListfields.DataSource = listData;

            if (IsDifferentValues())
            {
              btnAccept.Enabled=true;
            }

            this.cbxLatitude1.SelectedIndexChanged += new System.EventHandler(this.cbxLatitude1_SelectedIndexChanged);
            this.cbxLongitude1.SelectedIndexChanged += new System.EventHandler(this.cbxLongitude1_SelectedIndexChanged);
            this.cbxLatitude2.SelectedIndexChanged += new System.EventHandler(this.cbxLatitude2_SelectedIndexChanged);
            this.cbxLongitude2.SelectedIndexChanged += new System.EventHandler(this.cbxLongitude2_SelectedIndexChanged);
   


        }

        private void AddData(string value, int i)
        {
            cbxLatitude1.Items.Add(value);
            cbxLatitude2.Items.Add(value);
            cbxLongitude1.Items.Add(value);
            cbxLongitude2.Items.Add(value);

            if (value.ToUpper() == "LATITUDE" || value.ToUpper() == "STARTLAT")
            {

                cbxLatitude1.SelectedIndex = i;
            }

            if (value.ToUpper() == "LONGITUDE" || value.ToUpper() == "STARTLON")
            {

                cbxLongitude1.SelectedIndex = i;
            }

            if (value.ToUpper() == "ENDLAT")
            {

                cbxLatitude2.SelectedIndex = i;
            }

            if ( value.ToUpper() == "ENDLON")
            {

                cbxLongitude2.SelectedIndex = i;
            }

        }





        private void frmTypeOfField_Load(object sender, EventArgs e)
        {
           
            cbxTypeOfField.Items.Add("string");
            cbxTypeOfField.Items.Add("double");
            cbxTypeOfField.Items.Add("int");
            cbxTypeOfField.Items.Add("date");
            cbxTypeOfField.Items.Add("time");
            cbxDateFormat.Items.Add("dd/MM/yyyy");
            cbxDateFormat.Items.Add("MM/dd/yyyy");
            cbxDateFormat.SelectedIndex= 0;

        }

        private void dgvListfields_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            grpChange.Enabled = true;
            int i = dgvListfields.CurrentCell.RowIndex;
            txtNameField.Text = dgvListfields.Rows[i].Cells[0].Value.ToString();
            cbxTypeOfField.Text = dgvListfields.Rows[i].Cells[1].Value.ToString();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
             
        }

        private void cbxLatitude1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsDifferent(cbxLatitude1))
            {
                btnAccept.Enabled = true;
            }
            else 
            {

                btnAccept.Enabled = false;
            
            }
            
        }

        private bool IsDifferent(ComboBox combo) {


            if (IsDifferentValues())
                   return true;
            else
            {
                MessageBox.Show("It is not possible to use twice a field");
                return false;
            }
        }

        private bool IsDifferentValues()
        {
            if (this.type == "point" )
            {
              
                return cbxLatitude1.Text != cbxLongitude1.Text;
            }
            else {
                return
                    cbxLatitude1.Text != cbxLongitude1.Text && 
                    cbxLatitude1.Text != cbxLatitude2.Text &&
                    cbxLatitude1.Text != cbxLongitude2.Text &&
                    cbxLongitude1.Text != cbxLatitude2.Text &&
                    cbxLongitude1.Text != cbxLongitude2.Text &&
                    cbxLatitude2.Text != cbxLongitude2.Text;
                    }
        }

        private void cbxLongitude1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsDifferent(cbxLongitude1))
            {
                btnAccept.Enabled = true;
            }
            else
            {

                btnAccept.Enabled = false;

            }
        }

        private void cbxLatitude2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsDifferent(cbxLatitude2))
            {
                btnAccept.Enabled = true;
            }
            else
            {

                btnAccept.Enabled = false;

            }
        }

        private void cbxLongitude2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsDifferent(cbxLongitude2))
            {
                btnAccept.Enabled = true;
            }
            else
            {

                btnAccept.Enabled = false;

            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            listOut[txtNameField.Text] = cbxTypeOfField.Text;
            int i = dgvListfields.CurrentCell.RowIndex;
            dgvListfields.Rows[i].Cells[1].Value = cbxTypeOfField.Text;
            if (cbxTypeOfField.Text == "date")
            {
                if (!listFormDate.ContainsKey(txtNameField.Text))
                {
                    listFormDate.Add(txtNameField.Text, cbxDateFormat.Text);
                }
                else {

                    listFormDate.Remove(txtNameField.Text);
                    listFormDate.Add(txtNameField.Text, cbxDateFormat.Text);
                }

            }


        }

        private void cbxTypeOfField_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTypeOfField.Text == "date")
            {
                cbxDateFormat.Visible = true;
            }
            else {
                cbxDateFormat.Visible = false;
            }
        }
    }
}
