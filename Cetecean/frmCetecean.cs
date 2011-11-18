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
using System.Reflection;
namespace Cetecean
{
    public partial class frmCetecean : Form
    {
        GeoCal geo;

        public frmCetecean()
        {
            InitializeComponent();
            this.Text = "Cetacean Monitoring System " + Assembly.GetCallingAssembly().GetName().Version.ToString(); 
        }

        private void frmCetecean_Load(object sender, EventArgs e)
        {
             geo = new GeoCal(map1.Projection);
            //double lat = 50.06639;
            //double lon = -5.71472;
            //double lat1 = 58.64389;
            //double lon1 = -3.07000;

            //double distance =geo.Distance(new Coordinate(lon, lat), new Coordinate(lon1, lat1));
            //double Azimuth = geo.GetAzimuth(new Coordinate(lon, lat), new Coordinate(lon1, lat1));

            map1.Projection = KnownCoordinateSystems.Projected.World.WebMercator;

            //Coordinate n = geo.AzimuthDist(new Coordinate(lon, lat), Azimuth, distance);


            //double r = 0;
            //DataTable table = new DataTable();
            //table.Columns.Add("Latitude", typeof(double));
            //table.Columns.Add("Longitude", typeof(double));
            //table.Rows.Add(45.253, -112.43);
            //table.Rows.Add(45.509, -112.46091);
        }

        #region "Class Level Variables

        List<string> layerList1 = new List<string>();
        List<string> layerList2 = new List<string>();

        //Create output FS to hold the joined tables
        FeatureSet output = new FeatureSet();

        #endregion

        #region Excel Conversions

        private void ExcelToLine_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter="xls files (*.xls)|*.xls";
            //dialog.InitialDirectory=@"..\..\..\Data_set\";  
            dialog.Title = "Select an Excel File";
            string strFileName = String.Empty;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                strFileName = dialog.FileName;
            }

            if (strFileName == String.Empty)
            {
                this.Cursor = Cursors.Default;
                return;
            }
            else
            {
                ExcelData convert = new ExcelData(@strFileName);
                convert.Import();
                DataTable data = convert.GetData("line");

                if (data == null)
                {
                    MessageBox.Show("The file has not been imported");
                    this.Cursor = Cursors.Default;
                    return;
                }
                if (convert.Problems != "")
                {
                    frmErrors error = new frmErrors(convert.Problems);
                    error.Show();
                }

                AddLineLayer(data,convert.listUsed, Validator.GetNameFile(@strFileName));
            }
            this.Cursor = Cursors.Default;
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
                AddPolygonLayer(data, Validator.GetNameFile(@strFileName));

            }


        }

        private void AddPointLayer(DataTable table,Dictionary<string,string> list, string name)
        {

            try
            {

                MapPointLayer pointLayer = new MapPointLayer();
                FeatureSet pointFs = new FeatureSet(FeatureType.Point);
                
                //loops through each DataColumn in the data table (from excel sheet) and adds the column name and data type.
                //to the FeatureSet lineFs.
                foreach (DataColumn col in table.Columns)
                {
                    pointFs.DataTable.Columns.Add(new DataColumn(col.ColumnName, col.DataType));
                }

                //pointFs.DataTable.Columns.Add(latField);
                //pointFs.DataTable.Columns.Add(longField);

                pointFs.Projection = map1.Projection;
                pointLayer = new MapPointLayer(pointFs);
                pointLayer.LegendText = name;
                pointLayer.Symbolizer.SetFillColor(Color.Green);
                map1.Layers.Add(pointLayer);
                foreach (DataRow row in table.Rows)
                {
                    double latitude = 0;
                    double longitude = 0;
                    longitude = Convert.ToDouble(row[list["Longitude"]]);
                    latitude = Convert.ToDouble(row[list["Latitude"]]);
                    double[] xy = new double[] { longitude, latitude };
                    ProjectionInfo wgs84 = KnownCoordinateSystems.Geographic.World.WGS1984;
                    Reproject.ReprojectPoints(xy, new double[] { 0 }, wgs84, map1.Projection, 0, 1);
                    DotSpatial.Topology.Point point = new DotSpatial.Topology.Point(xy[0], xy[1]);
                    IFeature newF = pointLayer.DataSet.AddFeature(point);
                   
                    ProjectionInfo ip = map1.Projection;


                    foreach (DataColumn col in table.Columns)
                    {
                        newF.DataRow[col.ColumnName] = row[col.ColumnName];
                    }
                }
                map1.ResetBuffer();
                Validator.SaveShapefile(name + ".xls", pointFs);
            }

            catch (Exception) 
            {
                MessageBox.Show("Problem in the creation of Shapefile");
            }
        }
          
        private void AddLineLayer(DataTable table, Dictionary<string, string> list,string name)
        {
            //Initialize new MapLineLayer "lineLayer"
            MapLineLayer lineLayer = new MapLineLayer();
            //New FeatureSet of type Line
            FeatureSet lineFs = new FeatureSet(FeatureType.Line);

            //loops through each DataColumn in the data table (from excel sheet) and adds the column name and data type.
            //to the FeatureSet lineFs.
            foreach (DataColumn col in table.Columns)
            {
                lineFs.DataTable.Columns.Add(new DataColumn(col.ColumnName, col.DataType));
            }

            //Creates new DataColumn "Survey Line Length" and adds it to the lineFs DataTable
            System.Data.DataColumn lineLengthCol = new System.Data.DataColumn("TrackLength", typeof(double));
            lineFs.DataTable.Columns.Add(lineLengthCol);

            lineFs.Projection = map1.Projection;
            lineLayer = new MapLineLayer(lineFs);
            lineLayer.LegendText = name;
            lineLayer.Symbolizer.SetFillColor(Color.Green);
            map1.Layers.Add(lineLayer);
            int i = 0;
            IEnvelope max= null;
            //loops through each row in the data table (from excel)
            foreach (DataRow row in table.Rows)
            {
                double latitude = 0;
                double longitude = 0;
                double latitude1 = 0;
                double longitude1 = 0;
                try
                {
                    //Gets values from specified columns and assigns to variables
                    longitude = Convert.ToDouble(row[list["StartLon"]]);
                    latitude = Convert.ToDouble(row[list["StartLat"]]);
                    longitude1 = Convert.ToDouble(row[list["EndLon"]]);
                    latitude1 = Convert.ToDouble(row[list["EndLat"]]);

                    //Creates new array and adds coordinate values.
                    double[] xy = new double[] { longitude, latitude, longitude1, latitude1 };

                    ProjectionInfo wgs84 = KnownCoordinateSystems.Geographic.World.WGS1984;
                    Reproject.ReprojectPoints(xy, new double[] { 0, 0 }, wgs84, map1.Projection, 0, 2);

                    //stores coordinates from the array in a coordinate list.
                    List<Coordinate> lista = new List<Coordinate>() { new Coordinate(xy[0], xy[1]), new Coordinate(xy[2], xy[3]) };
                    //creates a line string from the coordinates.
                    LineString li = new LineString(lista);
                    //adds the linestring to a new IFeature newF

                    if (i == 0)
                        max = li.Envelope;
                    else
                      max= max.Union(li.Envelope);


                    IFeature newF = lineLayer.DataSet.AddFeature(li);

                    //Calculates line length using GetDistance method.
                    double lineLength = geo.Distance(new Coordinate(latitude, longitude),new Coordinate(latitude1, longitude1));
                    //Sets the value in column "Survey Line Length" to the returned lineLength.
                    newF.DataRow["TrackLength"] = lineLength;

                    

                    foreach (DataColumn col in table.Columns)
                    {
                        newF.DataRow[col.ColumnName] = row[col.ColumnName];
                    }
                    i++;
                }
                catch (InvalidCastException)
                {
                    map1.ViewExtents = max.ToExtent();
                    map1.ResetBuffer();
                    Validator.SaveShapefile(name + ".xls", lineFs);
                    return;
                }
                catch (FormatException)
                {

                }

                i++;
            }

            map1.ViewExtents = max.ToExtent();
            map1.ResetBuffer();
            Validator.SaveShapefile(name+".xls",lineFs);

        }




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

#endregion
       
        #region MapWindow Functions
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
            dialog.Filter = "Shapefile (*.shp)|*.shp";
            dialog.InitialDirectory = @"c:\\";
            dialog.Title = "Select a shapefile";
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
            this.Cursor = Cursors.WaitCursor;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "xls files (*.xls)|*.xls";
            dialog.InitialDirectory = @"..\..\..\Data_set\";
            dialog.Title = "Select an Excel File";
            string strFileName = String.Empty;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                strFileName = dialog.FileName;
            }

            if (strFileName == String.Empty)
            {
                this.Cursor = Cursors.Default;
                return;
            }
            else
            {
                ExcelData convert = new ExcelData(@strFileName);
                convert.Import();
                DataTable data = convert.GetData("point");
                if (data == null)
                {
                    MessageBox.Show("The file has not been imported");
                    this.Cursor = Cursors.Default;
                    return;
                }
                if (convert.Problems != "")
                {
                    frmErrors error = new frmErrors(convert.Problems);
                    error.Show();
                }

                AddPointLayer(data, convert.listUsed, Validator.GetNameFile(@strFileName));
            }
            this.Cursor = Cursors.Default;
        }

        private void panToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map1.FunctionMode = FunctionMode.Pan;

        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map1.FunctionMode = FunctionMode.Info;
        }

#endregion

        #region Cetecean Functionality

        private void createGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCreatePolygonGrid f = new frmCreatePolygonGrid(map1);
            f.Show();
        }

        private void splitTracksByGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSplitTrack split = new frmSplitTrack(map1);
            split.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCalculateBuffer fr = new frmCalculateBuffer(map1);
            fr.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmCountSpecies countSpecies = new frmCountSpecies(map1);
            countSpecies.ShowDialog();
        }

        private void surveyTracksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPolyEffortByGrid effort = new frmPolyEffortByGrid(map1);
            effort.ShowDialog();
        }

        private void surveySwathesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPolyEffortBySwathe swatheEffort = new frmPolyEffortBySwathe(map1);
            swatheEffort.ShowDialog();
        }
        

        #endregion

        //Calculates the track distance for each line feature within a featureset

        private void calculateTrackDistance(IFeatureSet inputFeatureSet, FeatureSet outputFeatureSet)
        {
            foreach (Feature fe in inputFeatureSet.Features)
            {
                //declares a coordinate array and populates it with the coordinates from each feature fe.
                Coordinate[] coord = (Coordinate[])fe.Coordinates;

                //fills each data row with the appropriate lat or lon coordinate.
                fe.DataRow["StartLat"] = coord[0].Y;
                fe.DataRow["StartLon"] = coord[0].X;
                fe.DataRow["EndLat"] = coord[1].Y;
                fe.DataRow["EndLon"] = coord[1].X;

                //re-calculates the survey line length using the coordinates from above and the GetDistance method.
                fe.DataRow["TrackLength"] = GetDistance(coord[0].Y, coord[1].Y, coord[0].X, coord[1].X);

                //adds feature fe to FeatureSet output.
                outputFeatureSet.Features.Add(fe);
            }
        }

        //Method calculates the distance between two coordinate locations.
        private double GetDistance(double Lat1, double Lat2, double long1, double long2)
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

        private void splitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSplitPolygons po = new frmSplitPolygons(map1);
            po.Show();
        }

        private void calculateAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCalculateArea ar = new frmCalculateArea(map1);
            ar.Show();
        }

        private void pointsToPolygonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmJoinPointsToPolygons joinPtToPolygon = new frmJoinPointsToPolygons(map1);
            joinPtToPolygon.Show();
        }

        private void polygonsToPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmJoinPolygonsToPoints joinPolygonsToPoints = new frmJoinPolygonsToPoints(map1);
            joinPolygonsToPoints.Show();
        }

        private void extractRasterValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExtractRasterValues extractRasterValues = new frmExtractRasterValues(map1);
            extractRasterValues.Show();
        }

        private void convertGridToPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGridToPoint gtp = new frmGridToPoint(map1);
            gtp.Show();
        }

        private void calculatorFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCalculateField cal = new frmCalculateField(map1);
            cal.Show();
        }

        private void tsmAbout_Click(object sender, EventArgs e)
        {
            frmAbout1 frmAbout = new frmAbout1();
            frmAbout.ShowDialog();
        }

        private void tsmExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmCalculateLineLength calcLine = new frmCalculateLineLength(map1);
            calcLine.Show();
        }

        


        
     
    }
}
