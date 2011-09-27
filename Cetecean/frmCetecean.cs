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
    public partial class frmCetecean : Form
    {
        public frmCetecean()
        {
            InitializeComponent();
        }

        private void frmCetecean_Load(object sender, EventArgs e)
        {

            ExcelData convert = new ExcelData(@"C:\ISU\AdvGIS_P\Cetamon\Data_test\xls\points.xls");
            convert.Import();
            DataTable data = convert.GetData("point");
        }
    }
}
