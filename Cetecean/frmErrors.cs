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
    public partial class frmErrors : Form
    {
        public frmErrors(string data)
        {
            InitializeComponent();
            txtOutput.Text = data;
        }

        private void frmErrors_Load(object sender, EventArgs e)
        {

        }
    }
}
