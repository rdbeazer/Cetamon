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

            ExcelData convert = new ExcelData(@"G:\caroso\class\Advanced GIS\data.xls");
            convert.Import();

           // LoadExcelFiles Load = new LoadExcelFiles(@"G:\caroso\class\Advanced GIS\data.xls");
         //   MessageBox.Show(Convert.ToChar(65) + "1");
        }
    }
}
