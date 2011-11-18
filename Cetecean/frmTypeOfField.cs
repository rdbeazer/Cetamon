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
        string type = "";

        public Dictionary<string, string> List
        {
            set { listOut = value; }
            get { return listOut; }

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
                    listLatLon.Add("StartLong", cbxLongitude1.Text);
                    listLatLon.Add("EndLat", cbxLatitude2.Text);
                    listLatLon.Add("EndLong", cbxLongitude2.Text);
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

        public frmTypeOfField(string type, DataTable data)
        {
            InitializeComponent();

            if (type == "line")
            {
                label4.Text = "Start Latitude";
                label5.Text = "Start Longitude";
                cbxLatitude2.Visible = true;
                cbxLongitude2.Visible = true;
            }

            listData = new DataTable();
            listData.Columns.Add("Name", typeof(string));
            listData.Columns.Add("Type", typeof(string));
            _data = CopyMemory(data);

     
            
        }

        public frmTypeOfField(string type, Dictionary<string,string> list)
        {
            InitializeComponent();
            this.type = type;
            if (type == "line")
            {
                label4.Text = "Start Latitude";
                label5.Text = "Start Longitude";
                cbxLatitude2.Visible = true;
                cbxLongitude2.Visible = true;
            }

            listData = new DataTable();
            listData.Columns.Add("Name", typeof(string));
            listData.Columns.Add("Type", typeof(string));

            listOut = list;

            foreach(string v in list.Keys)
            {
                listData.Rows.Add(v, list[v]);
                AddData(v);
            }
            dgvListfields.DataSource = listData;



        }

        private void AddData(string value)
        {
            cbxLatitude1.Items.Add(value);
            cbxLatitude2.Items.Add(value);
            cbxLongitude1.Items.Add(value);
            cbxLongitude2.Items.Add(value);
        }



        private DataTable CopyMemory(DataTable table)
        {
            DataTable newTable = new DataTable();

            foreach (DataColumn col in table.Columns)
            {
                newTable.Columns.Add(col.ColumnName, col.DataType);

                DataRow row = listData.NewRow();
                row["Name"] = col.ColumnName;
                row["Type"] = col.DataType.Name;
                

            }
            dgvListfields.DataSource = listData;
            

            foreach (DataRow row in table.Rows)
            {
                DataRow newRow = newTable.NewRow();
                newRow.ItemArray = row.ItemArray;
            }
            return newTable;
        }


        private Type FieldType(string name)
        {

            switch (name)
            {
                case "STARTLAT":
                case "ENDLAT":
                case "STARTLON":
                case "ENDLON":
                case "LATITUDE":
                case "LONGITUDE":
                    return typeof(double);
                case "UNIQUE ROW NUMBER":
                case "TRANSECTID":
                case "SEGMENT ID":
                case "LEFT":
                case "RIGHT":
                case "COURSE":
                case "NUMBER":
                case "SIGHTING ID":
                    return typeof(int);
                default:
                    return typeof(string);
            }


        }


        private void frmTypeOfField_Load(object sender, EventArgs e)
        {
            cbxTypeOfField.Items.Add("string");
            cbxTypeOfField.Items.Add("double");
            cbxTypeOfField.Items.Add("int");


            

        }

        private void dgvListfields_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvListfields.CurrentCell.RowIndex;
            txtNameField.Text = dgvListfields.Rows[i].Cells[0].Value.ToString();
            cbxTypeOfField.Text = dgvListfields.Rows[i].Cells[1].Value.ToString();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
             
        }

        private void cbxLatitude1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsDifferent())
            {
                btnAccept.Enabled = true;
            }
            else {

                btnAccept.Enabled = false;
            
            }
            
        }

        private bool IsDifferent()
        {
            if (this.type == "point" )
            {
                return cbxLatitude1.Text != "" && cbxLongitude1.Text != "" && cbxLatitude1.Text != cbxLongitude1.Text;
            }
            else {
                return cbxLatitude1.Text != "" && cbxLongitude1.Text != "" &&
                    cbxLatitude2.Text != "" && cbxLongitude2.Text != "" &&
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
            if (IsDifferent())
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
            if (IsDifferent())
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
            if (IsDifferent())
            {
                btnAccept.Enabled = true;
            }
            else
            {

                btnAccept.Enabled = false;

            }
        }
    }
}
