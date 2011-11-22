using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using  DotSpatial.Data;
using DotSpatial.Topology;
using DotSpatial.Projections;
namespace Cetecean
{
    public static class Validator
    {

        private static string title = "Entry Error";

        public static string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }


        public static bool IsSelected(ComboBox combo)
        {
            if (combo.Text == "")
            {
                MessageBox.Show(combo.Tag + " is a required field.", Title);
                combo.Focus();
                return false;
            }
            return true;
        }

        public static bool IsPresent(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(textBox.Tag + " is a required field.", Title);
                textBox.Focus();
                return false;
            }
            return true;
        }

        public static string GetNameFile(string file)
        {
            char[] v = file.ToCharArray();
            string temp = "";
            for (int i = v.Length - 1; i > 0; i--)
            {
                if (v[i] == '/' || v[i] == '\\')
                {

                    return temp.Split('.')[0]; //file.Substring(i + 1, file.Length - i - 5);
                }
                temp = v[i].ToString()+ temp;
            }
            return "default";
        }

        public static bool IsDecimal(TextBox textBox)
        {
            try
            {
                Convert.ToDecimal(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag + " must be a decimal number.", Title);
                textBox.Focus();
                return false;
            }
        }

        public static bool IsDouble(TextBox textBox)
        {
            try
            {
                Convert.ToDouble(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag + " must be a double number.", Title);
                textBox.Focus();
                return false;
            }
        }

        public static bool IsDoublePositive(TextBox textBox)
        {
            try
            {
                if (Convert.ToDouble(textBox.Text) > 0)
                    return true;
                else
                {
                    MessageBox.Show(textBox.Tag + " must be > 0", Title);
                    textBox.Focus();
                    return false;

                }
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag + " must be a double number.", Title);
                textBox.Focus();
                return false;
            }
        }

        public static bool SaveShapefile(string name, FeatureSet feaS)
        {

            DialogResult result = MessageBox.Show("Do you want to save " + name + " as shapefile?", "Save option", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Shapefile files (*.shp)|*.shp";
                dialog.InitialDirectory = @"C:\";
                dialog.Title = "Save shapefile";
                string strFileName = "";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    strFileName = dialog.FileName;
                    feaS.SaveAs(@strFileName, true);
                    return true;
                }



            }
            return false;

        }

        public static bool IsInt32(TextBox textBox)
        {
            try
            {
                Convert.ToInt32(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag + " must be an integer.", Title);
                textBox.Focus();
                return false;
            }
        }

        public static bool IsWithinRange(TextBox textBox, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(textBox.Tag + " must be between " + min
                    + " and " + max + ".", Title);
                textBox.Focus();
                return false;
            }
            return true;
        }

    }
}