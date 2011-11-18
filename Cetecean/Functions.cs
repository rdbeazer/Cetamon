using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DotSpatial.Controls;
using DotSpatial.Topology;
using DotSpatial.Data;
using DotSpatial.Symbology;
using DotSpatial.Projections;

namespace Cetecean
{
    class Functions
    {
        public bool saved = false;

        public void saveFile(FeatureSet output)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "shapefile files (*.shp)|*.shp";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Save";
            string strFileName = "";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                strFileName = dialog.FileName;
            }

            if (strFileName == String.Empty)
            {
                MessageBox.Show("The file was not saved, a valid filename must be entered.");
                return;
            }
            else
            {
                output.SaveAs(strFileName, true);
                saved = true;
            }
        } 

        public double GetDistance(double Lat1, double Lat2, double long1, double long2)
        {
            double distance = Double.MinValue;
            //converts decimal degrees to radians
            double Lat1InRad = Lat1 * (Math.PI / 180.0);
            double Long1InRad = long1 * (Math.PI / 180.0);
            double Lat2InRad = Lat2 * (Math.PI / 180.0);
            double Long2InRad = long2 * (Math.PI / 180.0);

            double Longitude = Long2InRad - Long1InRad;
            double Latitude = Lat2InRad - Lat1InRad;

            double a = Math.Pow(Math.Sin(Latitude / 2.0), 2.0) + Math.Cos(Lat1InRad) * Math.Cos(Lat2InRad) * Math.Pow(Math.Sin(Longitude / 2.0), 2.0);
            double c = 2.0 * Math.Asin(Math.Sqrt(a));

            const Double kEarthRadiusKms = 6376.5;
            distance = kEarthRadiusKms * c;
            double roundDist = Math.Round(distance, 2);
            return roundDist;
        }
    }
}

