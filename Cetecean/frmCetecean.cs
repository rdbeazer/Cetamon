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
            System.Data.DataColumn  longField = new System.Data.DataColumn("Longitude", typeof(double));


            pointFs.DataTable.Columns.Add(latField);
            pointFs.DataTable.Columns.Add(longField);

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

        private void AddLineLayer(DataTable table)
        {
            MapLineLayer lineLayer = new MapLineLayer();
            DotSpatial.Data.FeatureSet lineFs = new DotSpatial.Data.FeatureSet(FeatureType.Line);

            System.Data.DataColumn startLatField = new System.Data.DataColumn("StartLat", typeof(double));
            System.Data.DataColumn startLongField = new System.Data.DataColumn("StartLong", typeof(double));
            System.Data.DataColumn endLatField = new System.Data.DataColumn("EndLat", typeof(double));
            System.Data.DataColumn endLongField = new System.Data.DataColumn("EndLong", typeof(double));

            lineFs.DataTable.Columns.Add(startLatField);
            lineFs.DataTable.Columns.Add(startLongField);
            lineFs.DataTable.Columns.Add(endLatField);
            lineFs.DataTable.Columns.Add(endLongField);

            lineFs.Projection = KnownCoordinateSystems.Geographic.World.WGS1984;
            lineLayer = new MapLineLayer(lineFs);
            lineLayer.LegendText = "line";
            lineLayer.Symbolizer.SetFillColor(Color.Red);
            map1.Layers.Add(lineLayer);

            int i = 0;

            int indexStartLat = 0;
            int indexStartLong = 0;
            int indexEndLat = 0;
            int indexEndLong = 0;

            foreach (DataRow row in table.Rows)
            {
                double startLat = 0;
                double startLong = 0;
                double endLat = 0;
                double endLong = 0;

                if (i == 0)
                {
                    int searchIndex = 0;
                    foreach (DataColumn column in table.Columns)
                    {
                        if (Convert.ToString(row[searchIndex]) == "StartLat" || Convert.ToString(row[searchIndex]) == "STARTLAT")
                        {
                            indexStartLat = searchIndex;
                        }
                        if (Convert.ToString(row[searchIndex]) == "StartLong" || Convert.ToString(row[searchIndex]) == "STARTLONG")
                        {
                            indexStartLong = searchIndex;
                        }
                        if (Convert.ToString(row[searchIndex]) == "EndLat" || Convert.ToString(row[searchIndex]) == "ENDLAT")
                        {
                            indexEndLat = searchIndex;
                        }
                        if (Convert.ToString(row[searchIndex]) == "EndLong" || Convert.ToString(row[searchIndex]) == "ENDLONG")
                        {
                            indexEndLong = searchIndex;
                        }
                        searchIndex++;
                    }
                }

                else
                {

                    List<Coordinate> coordList = new List<Coordinate>();
                    startLat = Convert.ToDouble(row[indexStartLat]);
                    startLong = Convert.ToDouble(row[indexStartLong]);
                    coordList.Add(new Coordinate(startLat, startLong));

                    endLat = Convert.ToDouble(row[indexEndLat]);
                    endLong = Convert.ToDouble(row[indexEndLong]);
                    coordList.Add(new Coordinate(endLat, endLong));

                    DotSpatial.Topology.LineString line = new DotSpatial.Topology.LineString(coordList);
                    IFeature feature = lineLayer.DataSet.AddFeature(line);

                    feature.DataRow["StartLat"] = startLat;
                    feature.DataRow["StartLong"] = startLong;
                    feature.DataRow["EndLat"] = endLat;
                    feature.DataRow["EndLong"] = endLong;
                }
                i++;
            }
            map1.ResetBuffer();

        }

        //Adding the polygon layer data----------------------------------------------------------------------------------------------------
        private void AddPolygonLayer(DataTable table)
        {


            //Create and add the polygon Layer
            MapPolygonLayer polygonLayer = new MapPolygonLayer();
            polygonLayer.LegendText = "polygon";
            polygonLayer.Symbolizer.SetFillColor(Color.Blue);

            //creating the polygon feature set
            FeatureSet polygonFS = new FeatureSet(FeatureType.Polygon);

            //set the projection 
            polygonFS.Projection = map1.Projection;

            ////Set data columns
            //System.Data.DataColumn latField = new System.Data.DataColumn("Latitude", typeof(double));
            //System.Data.DataColumn longField = new System.Data.DataColumn("Longitude", typeof(double));

            ////Add data from excel table
            //polygonFS.DataTable.Columns.Add(latField);
            //polygonFS.DataTable.Columns.Add(longField);

            Polygon polygon1 = null;
            IFeature feature1 = null;

            //Add to the map
            map1.Layers.Add(polygonLayer);

            int i = 0;
            double latitude = 0;
            double longitude = 0;
            double startLat = 0;
            double startLong = 0;
            int indexLat = 0;
            int indexLon = 0;

            //Create coordinate list to hold coors
            List<Coordinate> coordList = new List<Coordinate>();

            LinearRing objRing = new LinearRing(coordList);



            foreach (DataRow row in table.Rows)
            {
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
                //Fill first set of coordinates with a startX and startY
                else if (i == 1)
                {
                    startLat = Convert.ToDouble(row[indexLat]);
                    startLong = Convert.ToDouble(row[indexLon]);
                    coordList.Add(new Coordinate(startLat, startLong));
                    //update the featureset
                    //feature1.DataRow["Latitude"] = startLat;
                    //feature1.DataRow["Longitude"] = startLong;

                }

                else
                {
                    //Add the rest of the coordinates
                    latitude = Convert.ToDouble(row[indexLat]);
                    longitude = Convert.ToDouble(row[indexLon]);
                    coordList.Add(new Coordinate(latitude, longitude));
                    //feature1.DataRow["Latitude"] = latitude;
                    //feature1.DataRow["Longitude"] = longitude;
                }
                i++;

            }

            //Add start point to close the polygon when the loop finishes
            coordList.Add(new Coordinate(startLat, startLong));
            //feature1.DataRow["Latitude"] = startLat;
            //feature1.DataRow["Longitude"] = startLong;

            //create polygon feature here to be updated with foreach loop
            polygon1 = new Polygon(coordList);
            polygonFS.InitializeVertices();
            feature1 = polygonFS.AddFeature(objRing);
            map1.ResetBuffer();
            map1.ZoomToMaxExtent();
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

        private void ExcelToLine_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter="xls files (*.xls)|*.xls";
            //dialog.InitialDirectory=@"..\..\..\Data_set\";  
            dialog.Title = "Select a Excel File";
            string strFileName = String.Empty;
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
                DataTable data = convert.GetData("line");
                AddLineLayer(data);
            }
        }

        private void convertExceltoPolygon_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "xls files (*.xls)|*.xls";
            dialog.InitialDirectory = @"..\..\..\Data_set\";
            dialog.Title = "Select a Excel File";
            string strFileName = String.Empty;
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
                AddPolygonLayer(data);

            }


        }

        private void createGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCreatePolygonGrid f = new frmCreatePolygonGrid(map1);
            f.Show();
        }
        


    }
}
