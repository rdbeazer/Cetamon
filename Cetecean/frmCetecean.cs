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





        private void AddPointLayer(DataTable table,string name)
        {
            MapPointLayer pointLayer = new MapPointLayer();
            FeatureSet pointFs = new FeatureSet(FeatureType.Point);

            System.Data.DataColumn  latField = new System.Data.DataColumn("Latitude",typeof(double));
            System.Data.DataColumn  longField = new System.Data.DataColumn("Longitude", typeof(double));


            pointFs.DataTable.Columns.Add(latField);
            pointFs.DataTable.Columns.Add(longField);

            pointFs.Projection = map1.Projection;
            pointLayer = new MapPointLayer(pointFs);
            pointLayer.LegendText = name;
            pointLayer.Symbolizer.SetFillColor(Color.Green);
            map1.Layers.Add(pointLayer);
                foreach (DataRow row in table.Rows)
                {
                   double latitude=0;
                   double longitude=0;
                       longitude = Convert.ToDouble(row["Longitude"]);
                       latitude = Convert.ToDouble(row["Latitude"]);
                       double[] xy = new double[] { longitude, latitude };
                       ProjectionInfo wgs84 = KnownCoordinateSystems.Geographic.World.WGS1984;
                       Reproject.ReprojectPoints(xy, new double[] { 0 }, wgs84, map1.Projection, 0, 1);
                       DotSpatial.Topology.Point point = new DotSpatial.Topology.Point(xy[0], xy[1]);
                       IFeature newF = pointLayer.DataSet.AddFeature(point);
                       newF.DataRow["Latitude"] = latitude;
                       newF.DataRow["Longitude"] = longitude;
                       ProjectionInfo ip = map1.Projection;

                }
                map1.ResetBuffer();
          }

        private void AddLineLayer(DataTable table,string name)
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
            lineLayer.LegendText = name;
            lineLayer.Symbolizer.SetFillColor(Color.Red);
            map1.Layers.Add(lineLayer);

 
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
            map1.ResetBuffer();

        }

        //Adding the polygon layer data----------------------------------------------------------------------------------------------------
        private void AddPolygonLayer(DataTable table, string name)
        {


            //Create and add the polygon Layer
            MapPolygonLayer polygonLayer = new MapPolygonLayer();
            polygonLayer.LegendText = name;
            polygonLayer.Symbolizer.SetFillColor(Color.Blue);

            //creating the polygon feature set
            FeatureSet polygonFS = new FeatureSet(FeatureType.Polygon);

            //set the projection 
            polygonFS.Projection = map1.Projection;


            Polygon polygon1 = null;
            IFeature feature1 = null;

            //Add to the map
            map1.Layers.Add(polygonLayer);

            int i = 0;
            double latitude = 0;
            double longitude = 0;
            double startLat = 0;
            double startLong = 0;


            //Create coordinate list to hold coors
            List<Coordinate> coordList = new List<Coordinate>();

            LinearRing objRing;



            foreach (DataRow row in table.Rows)
            {

               if (i == 1)
                {
                    startLat = Convert.ToDouble(row["Latitude"]);
                    startLong = Convert.ToDouble(row["Longitude"]);
                    coordList.Add(new Coordinate(startLat, startLong));

                }

                else
                {
                    //Add the rest of the coordinates
                    latitude = Convert.ToDouble(row["Latitude"]);
                    longitude = Convert.ToDouble(row["Longitude"]);
                    coordList.Add(new Coordinate(latitude, longitude));

                }
                i++;

            }

            //Add start point to close the polygon when the loop finishes
            coordList.Add(new Coordinate(startLat, startLong));


            //create polygon feature here to be updated with foreach loop
            objRing = new LinearRing(coordList);
            polygon1 = new Polygon(objRing);
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
             OpenFileDialog dialog = new OpenFileDialog();
             dialog.Filter="Shapefile (*.shp)|*.shp";
            dialog.InitialDirectory=@"c:\\";  
            dialog.Title="Select a shapefile";
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
                try
                {
                    map1.AddLayer(strFileName);
                }
                catch (NullReferenceException)
                { 
                }
            }

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
                        AddPointLayer(data,Validator.GetNameFile(@strFileName));
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
                AddLineLayer(data,Validator.GetNameFile(@strFileName));
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
                AddPolygonLayer(data,Validator.GetNameFile(@strFileName));

            }


        }

        private void createGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCreatePolygonGrid f = new frmCreatePolygonGrid(map1);
            f.Show();
        }
        


    }
}
