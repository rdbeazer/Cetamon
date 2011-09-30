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
using DotSpatial.Projections;
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

            //DataTable table = new DataTable();
            //table.Columns.Add("Latitude", typeof(double));
            //table.Columns.Add("Longitude", typeof(double));
            //table.Rows.Add(45.253, -112.43);
            //table.Rows.Add(45.509, -112.46091);
        }


        private void AddPointLayer(DataTable table)
        {
            MapPointLayer pointLayer = new MapPointLayer();
            FeatureSet pointFs = new FeatureSet(FeatureType.Point);

            System.Data.DataColumn  latField = new System.Data.DataColumn("Latitude",typeof(double));
            System.Data.DataColumn  lonField = new System.Data.DataColumn("Longitude", typeof(double));


            pointFs.DataTable.Columns.Add(latField);
            pointFs.DataTable.Columns.Add(lonField);

            pointFs.Projection = map1.Projection;
            pointLayer = new MapPointLayer(pointFs);
            pointLayer.LegendText = "point";
            pointLayer.Symbolizer.SetFillColor(Color.Green);
            map1.Layers.Add(pointLayer);
            int i = 0;
                foreach (DataRow row in table.Rows)
                {
                   double latitude=0;
                   double longitude=0;
                   int indexLat=0;
                   int indexLon=1;

                    
                   if (i == 0)
                   {
                       int searchIndex = 0;
                       foreach (DataColumn col in table.Columns)
                       {
                           if (Convert.ToString(row[searchIndex]) == "Latitude" || Convert.ToString(row[searchIndex]) == "LATITUDE")
                           {
                               indexLat = searchIndex;
                           }
                           if (Convert.ToString(row[searchIndex]) == "Longitude" || Convert.ToString(row[searchIndex]) == "LONGITUDE")
                           {
                               indexLon = searchIndex;
                           }
                           searchIndex++;
                       }
                   }
                   else

                   {
                       longitude = Convert.ToDouble(row[indexLon]);
                       latitude = Convert.ToDouble(row[indexLat]);
                       double[] xy = new double[] { longitude, latitude };
                       string esri = Properties.Resources.Wgs84_String;
                       ProjectionInfo wgs84 = new ProjectionInfo();
                       wgs84.ReadEsriString(esri);
                       Reproject.ReprojectPoints(xy, new double[] { 0 }, wgs84, map1.Projection, 0, 1);
                       DotSpatial.Topology.Point point = new DotSpatial.Topology.Point(xy[0], xy[1]);
                       IFeature newF = pointLayer.DataSet.AddFeature(point);
                       newF.DataRow["Latitude"] = latitude;
                       newF.DataRow["Longitude"] = longitude;
                       ProjectionInfo ip = map1.Projection;


                   }
                   i++;

                }

                map1.ResetBuffer();
          }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map1.ZoomIn();
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map1.ZoomOut();
        }

        private void openShapefileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map1.AddLayer();
        }

        private void importFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
             dialog.Filter="xls files (*.xls)|*.xls";
            dialog.InitialDirectory=@"..\..\..\Data_set\";  
            dialog.Title="Select a Excel File";
            string strFileName=String.Empty;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                strFileName = dialog.FileName;
            }

            if (strFileName == String.Empty)
            {
                return;
            }
            else
            {
                ExcelData convert = new ExcelData(@strFileName);
                convert.Import();
                DataTable data = convert.GetData("point");
                        AddPointLayer(data);
        
            }
               
        }

        private void panToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map1.FunctionMode = FunctionMode.Pan;

        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map1.FunctionMode = FunctionMode.Info;
        }
        


    }
}
