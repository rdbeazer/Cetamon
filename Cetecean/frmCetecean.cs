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

        #region "Class Level Variables

        List<string> layerList1 = new List<string>();
        List<string> layerList2 = new List<string>();
        int polygonIndex = 0;
        int lineIndex = 0;

        //Create output FS to hold the joined tables
        FeatureSet output = new FeatureSet();

        #endregion

        private void AddPointLayer(DataTable table, string name)
        {

            MapPointLayer pointLayer = new MapPointLayer();
            FeatureSet pointFs = new FeatureSet(FeatureType.Point);

            System.Data.DataColumn latField = new System.Data.DataColumn("Latitude", typeof(double));
            System.Data.DataColumn longField = new System.Data.DataColumn("Longitude", typeof(double));


            pointFs.DataTable.Columns.Add(latField);
            pointFs.DataTable.Columns.Add(longField);

            pointFs.Projection = map1.Projection;
            pointLayer = new MapPointLayer(pointFs);
            pointLayer.LegendText = name;
            pointLayer.Symbolizer.SetFillColor(Color.Green);
            map1.Layers.Add(pointLayer);
            foreach (DataRow row in table.Rows)
            {
                double latitude = 0;
                double longitude = 0;
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
          
        //method converts the excel data table to a line shapefile and adds a field for track length.
        private void AddLineLayer(DataTable table,string name)
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
                    longitude = Convert.ToDouble(row["StartLon"]);
                    latitude = Convert.ToDouble(row["StartLat"]);
                    longitude1 = Convert.ToDouble(row["EndLon"]);
                    latitude1 = Convert.ToDouble(row["EndLat"]);

                    //Creates new array and adds coordinate values.
                    double[] xy = new double[] { longitude, latitude, longitude1, latitude1 };
                    string esri = Properties.Resources.Wgs84_String;
                    ProjectionInfo wgs84 = new ProjectionInfo();
                    wgs84.ReadEsriString(esri);
                    Reproject.ReprojectPoints(xy, new double[] { 0, 0 }, wgs84, map1.Projection, 0, 2);

                    //stores coordinates from the array in a coordinate list.
                    List<Coordinate> lista = new List<Coordinate>() { new Coordinate(xy[0], xy[1]), new Coordinate(xy[2], xy[3]) };
                    //creates a line string from the coordinates.
                    LineString li = new LineString(lista);
                    //adds the linestring to a new IFeature newF
                    IFeature newF = lineLayer.DataSet.AddFeature(li);

                    //Calculates line length using GetDistance method.
                    double lineLength = GetDistance(latitude, latitude1, longitude, longitude1);
                    //Sets the value in column "Survey Line Length" to the returned lineLength.
                    newF.DataRow["TrackLength"] = lineLength;

                    foreach (DataColumn col in table.Columns)
                    {
                        newF.DataRow[col.ColumnName] = row[col.ColumnName];
                    }

                }
                catch (InvalidCastException)
                {
                    map1.ResetBuffer();
                    return;
                }
                catch (FormatException)
                {

                }

                i++;
            }

            map1.ResetBuffer();

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
 
        //REMOVE
        //    MapLineLayer lineLayer = new MapLineLayer();
        //    DotSpatial.Data.FeatureSet lineFs = new DotSpatial.Data.FeatureSet(FeatureType.Line);

        //    System.Data.DataColumn startLatField = new System.Data.DataColumn("StartLat", typeof(double));
        //    System.Data.DataColumn startLongField = new System.Data.DataColumn("StartLong", typeof(double));
        //    System.Data.DataColumn endLatField = new System.Data.DataColumn("EndLat", typeof(double));
        //    System.Data.DataColumn endLongField = new System.Data.DataColumn("EndLong", typeof(double));

        //    lineFs.DataTable.Columns.Add(startLatField);
        //    lineFs.DataTable.Columns.Add(startLongField);
        //    lineFs.DataTable.Columns.Add(endLatField);
        //    lineFs.DataTable.Columns.Add(endLongField);

        //    lineFs.Projection = KnownCoordinateSystems.Geographic.World.WGS1984;
        //    lineLayer = new MapLineLayer(lineFs);
        //    lineLayer.LegendText = name;
        //    lineLayer.Symbolizer.SetFillColor(Color.Red);
        //    map1.Layers.Add(lineLayer);

 
        //    int indexStartLat = 0;
        //    int indexStartLong = 0;
        //    int indexEndLat = 0;
        //    int indexEndLong = 0;

        //    foreach (DataRow row in table.Rows)
        //    {
        //        double startLat = 0;
        //        double startLong = 0;
        //        double endLat = 0;
        //        double endLong = 0;

        //            List<Coordinate> coordList = new List<Coordinate>();
        //            startLat = Convert.ToDouble(row[indexStartLat]);
        //            startLong = Convert.ToDouble(row[indexStartLong]);
        //            coordList.Add(new Coordinate(startLat, startLong));

        //            endLat = Convert.ToDouble(row[indexEndLat]);
        //            endLong = Convert.ToDouble(row[indexEndLong]);
        //            coordList.Add(new Coordinate(endLat, endLong));

        //            DotSpatial.Topology.LineString line = new DotSpatial.Topology.LineString(coordList);
        //            IFeature feature = lineLayer.DataSet.AddFeature(line);

        //            feature.DataRow["StartLat"] = startLat;
        //            feature.DataRow["StartLong"] = startLong;
        //            feature.DataRow["EndLat"] = endLat;
        //            feature.DataRow["EndLong"] = endLong;
        //    }
        //    map1.ResetBuffer();

        //}

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

        //Method to get user selected variables from Split Tracks form
        private void getLayers()
        {
            //clears layerLists
            layerList1.Clear();
            layerList2.Clear();

            //loops through the map layers and adds them to the layerLists.
            //These lists will be used to populate the combo boxes.
            if (map1.Layers.Count > 1)
            {
                for (int i = 0; i < map1.Layers.Count; i++)
                {
                    string title = map1.Layers[i].LegendText;
                    layerList1.Insert(i, title);
                    layerList2.Insert(i, title);
                }
            }

            else
            {
                MessageBox.Show("Please add a layer to the map");
                return;
            }
           
        }
            
        //Split Tracks by Grid Functionality
        private void splitTracksByGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Gets user input on grid and track layers
            getLayers();
            //initializes a new frmSplitTrack
             frmSplitTrack splitTrack = new frmSplitTrack();
            //passes the lists to the splitTrack form
            splitTrack.passList1(this.layerList1);
            splitTrack.passList2(this.layerList2);
            //opens the dialog to select the layers.
            splitTrack.ShowDialog();
            //assigns indexes to the selected layers using getPolygonIndex and getLineIndex methods.
            this.polygonIndex = splitTrack.getPolygonIndex();
            this.lineIndex = splitTrack.getLineIndex();
        

            //Uses selected layers for functionality
            IFeatureSet inputLine = (IFeatureSet)map1.Layers[lineIndex].DataSet;
            IFeatureSet inputPolygon = (IFeatureSet)map1.Layers[polygonIndex].DataSet;

            //Set output feature to a line
            output.FeatureType = inputLine.FeatureType;

            //Create a temporary file to hold the intersection of 
            IFeatureSet tempOutput = inputLine.Intersection(inputPolygon, FieldJoinType.All, null);

            //Create new datacolumns from the merging file to the output file 
            foreach (DataColumn inputLineColumn in tempOutput.DataTable.Columns)
            {
                output.DataTable.Columns.Add(new DataColumn(inputLineColumn.ColumnName, inputLineColumn.DataType));
            }

            //Calculate each track distance and add to the table
            calculateTrackDistance(tempOutput, output);

            //Saves the output as a shapefile in designated directory.
            //TODO:  Change this so that the user can select the directory.
            output.SaveAs("C:\\DotSpatial\\testclip.shp", true);

            //Creates a new MapLineLayer using the output featureset
            MapLineLayer lineIntersectLayer = new MapLineLayer(output);

            //Sets Legend and Symbolizer properties.
            lineIntersectLayer.LegendText = "Split survey tracks";
            lineIntersectLayer.Symbolizer.SetFillColor(Color.Red);

            map1.Layers.Add(lineIntersectLayer);
            map1.ResetBuffer();

            //Alerts the user that the attributes have been updated.
            MessageBox.Show("The selected track layer has been segmented by the selected grid layer", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

    //Calculate the survey effort by grid-------------------------------------
        private void calculateSurveyEffortByGridToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //method gets user input on grid and track layers
            getLayers();

            //initializes a new polyEffortbyGrid form
            frmPolyEffortByGrid polyEffort = new frmPolyEffortByGrid();
            //passes the lists to the Polygon Effort Select form
            polyEffort.passList1(this.layerList1);
            polyEffort.passList2(this.layerList2);
            //opens the dialog to select the layers.
            polyEffort.ShowDialog();
            //assigns indexes to the selected layers using getPolygonIndex and getLineIndex methods.
            this.polygonIndex = polyEffort.getPolygonIndex();
            this.lineIndex = polyEffort.getLineIndex();
            //Uses selected layers for functionality
            IFeatureSet inputLine = (IFeatureSet)map1.Layers[lineIndex].DataSet;
            IFeatureSet inputPolygon = (IFeatureSet)map1.Layers[polygonIndex].DataSet;

            //creates new DataColumn "lineLengthCol" and
            //adds the column to the inputPolygon DataTable
            System.Data.DataColumn lineLengthCol = new System.Data.DataColumn("Sum_Tracks", typeof(double));
            inputPolygon.DataTable.Columns.Add(lineLengthCol);

            //initializes a new list to hold polygonID's
            List<int> polygonIDList = new List<int>();

            //loops through the inputLine DataTable and populates the polygonIDList with unique polygonID's.
            foreach (DataRow row in inputLine.DataTable.Rows)
            {
                int polygonID = Convert.ToInt32(row["polygonID"]);
                if (!polygonIDList.Contains(polygonID))
                {
                    polygonIDList.Add(polygonID);
                }
            }


            //loops through each ID in the polygonIDList
            foreach (int ID in polygonIDList)
            {
                //initializes a new list called lineLengths
                List<double> lineLengths = new List<double>();

                //loops through each inputLine feature and if the polygonID in the feature matches the ID in the 
                //polygonIDList, it collects the Survey Line Length for the feature and adds it to the LineLengths list.
                foreach (Feature fe in inputLine.Features)
                {
                    int feID = Convert.ToInt32(fe.DataRow["polygonID"]);

                    if (feID == ID)
                    {
                        double lineLength = Convert.ToDouble(fe.DataRow["TrackLength"]);
                        lineLengths.Add(lineLength);
                    }
                }

                //calculates the sum of all the lines in the lineLengths list and rounds to three decimal places.
                double lineLengthSum = Math.Round(lineLengths.Sum(), 3);

                //loops through the inputPolygon DataTable and if the "polygonID" matches the polygonID from the 
                //inputLine feature, the lineLength Sum is added to the "Sum_Tracks" column in the inputPolygon DataTable.
                foreach (DataRow row in inputPolygon.DataTable.Rows)
                {
                      int feLineID = Convert.ToInt32(row["polygonID"]);

                    if (feLineID == ID)
                    {
                        row["Sum_Tracks"] = lineLengthSum;
                    }
                    else
                    {
                        row["Sum_Tracks"] = 0;
                    }
                }

               
            }
            //Alerts the user that the attributes have been updated.
            MessageBox.Show("The polygon grid attributes have been updated.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
