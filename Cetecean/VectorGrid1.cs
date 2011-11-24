using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using DotSpatial.Controls;
using DotSpatial.Topology;
using DotSpatial.Data;
using DotSpatial.Symbology;
using DotSpatial.Projections;
namespace Cetecean
{
    class VectorGrid1
    {
        private Map _mainMap;
        private AreaInterest _area = new AreaInterest();
        private AreaInterest _orgArea;
        private MapPolygonLayer _GridLayer = null;
        private FeatureSet rectangleFs = new FeatureSet();
        private string _name="Grid";
        private GeoCal geo = null;
        private ProgressBar pro = null;
        public string Name
        {
            get { return _name;}
            set {this._name=value;}
        }

         public VectorGrid1(double xmin, double ymin, double xmax, double ymax, int numColums, int numRows, double cellSize, IMap map)
        {
            geo = new GeoCal(map.Projection);
             _orgArea = new AreaInterest();
            _orgArea.MinX = xmin;
            _orgArea.MinY = ymin;
            _orgArea.MaxX = xmax;
            _orgArea.MaxY = ymax;
            _orgArea.NumColumns = numColums;
            _orgArea.NumRows = numRows;
            _orgArea.CellSize = cellSize;
            _mainMap = map as Map;
            UpdateAreaInterest(_orgArea);

        }


        public VectorGrid1(double xmin, double ymin, int numColums, int numRows, double cellSize, IMap map)
        {
            geo = new GeoCal(map.Projection);
            _orgArea = new AreaInterest();
            _orgArea.MinX = xmin;
            _orgArea.MinY = ymin;
            _orgArea.NumColumns = numColums;
            _orgArea.NumRows = numRows;
            _orgArea.CellSize = cellSize;
            _mainMap = map as Map;
            UpdateAreaInterestByOrigin(_orgArea);

        }

        public void Progress(ProgressBar bar)
        {
            pro = bar;
        }


        public AreaInterest Get_area()
        {
            return _area;
        }

        public MapPolygonLayer GetLayer()
        {
            return _GridLayer;
        }

        public VectorGrid1(AreaInterest p, IMap map)
        {
            geo = new GeoCal(map.Projection);
            _orgArea = p;
            _mainMap = map as Map;
            UpdateAreaInterest(p);
        }


        #region previuos


        //public void UpdateCellSizeByCol(int colums)
        //{
        //    _orgArea.NumColumns = colums;

        //    double dx = _orgArea.maxX - _orgArea.minX;

        //    _orgArea.cellSize = dx / _orgArea.numColums;

        //    double dy = _orgArea.maxY - _orgArea.minY;

        //    double nrow = Math.Floor(dy / _orgArea.cellSize);

        //    if ((dy / _orgArea.cellSize) > Math.Floor(dy / _orgArea.cellSize)) nrow = Math.Floor(dy / _orgArea.cellSize) + 1;



        //    _area.minX = _orgArea.minX;
        //    _area.maxY = _orgArea.maxY;
        //    _area.maxX = _orgArea.minX + (_orgArea.cellSize * _orgArea.numColums);
        //    _area.minY = _orgArea.maxY - (_orgArea.cellSize * nrow);
        //    _area.numRows = (int)nrow;
        //    _area.numColums = colums;
        //    _area.cellSize = _orgArea.cellSize;


        //}

        //public void UpdateCellSizeByRow(int rows)
        //{
        //    _orgArea.numRows = rows;

        //    double dy = _orgArea.maxY - _orgArea.minY;

        //    _orgArea.cellSize = dy / _orgArea.numRows;

        //    double dx = _orgArea.maxX - _orgArea.minX;

        //    double ncol = Math.Floor(dx / _orgArea.cellSize);

        //    if ((dx / _orgArea.cellSize) > Math.Floor(dx / _orgArea.cellSize)) ncol = Math.Floor(dx / _orgArea.cellSize) + 1;


        //    _area.minX = _orgArea.minX;
        //    _area.maxY = _orgArea.maxY;
        //    _area.maxX = _orgArea.minX + (_orgArea.cellSize * ncol);
        //    _area.minY = _orgArea.maxY - (_orgArea.cellSize * _orgArea.numRows);
        //    _area.numColums = (int)ncol;
        //    _area.numRows = rows;
        //    _area.cellSize = _orgArea.cellSize;

        //}
        #endregion



        public Coordinate ReprojectPoint(double x, double y)
        {
            ProjectionInfo wgs84 = KnownCoordinateSystems.Geographic.World.WGS1984;
            if (wgs84 == _mainMap.Projection)
            {
                return new Coordinate(x, y);

            }
            else
            {

                double[] xy = new double[2];
                xy[0] = x;
                xy[1] = y;
                double[] z = new double[1];

                Reproject.ReprojectPoints(xy, z, wgs84, _mainMap.Projection, 0, 1);
                return new Coordinate(xy[0], xy[1]);
            }
        }

        public Coordinate ReprojectPointToWgs84(double x, double y)
        {
            ProjectionInfo wgs84 = KnownCoordinateSystems.Geographic.World.WGS1984;
            if (wgs84 == _mainMap.Projection)
            {
                return new Coordinate(x, y);

            }
            else
            {
                double[] xy = new double[2];
                xy[0] = x;
                xy[1] = y;
                double[] z = new double[1];

                Reproject.ReprojectPoints(xy, z, _mainMap.Projection, wgs84, 0, 1);
                return new Coordinate(xy[0], xy[1]);
            }
        }


        private double DegToRad(double ang)
        {
            return Math.PI * ang / 180.0;

        }


        public Coordinate ProjectPointAzimut(double x, double y)
        {
            return ProjectPointAzimut(new Coordinate(x, y));
        }


        public Coordinate ProjectPointAzimut(Coordinate c)
        {
            try
            {

                if (_area.Azimut == 0) return c;
                double angle = DegToRad(_area.Azimut);
                double azi = GetAzimut(c);
                double v = (angle + azi) * 180.0 / Math.PI;
                double dist = Math.Sqrt((_area.MinX - c.X) * (_area.MinX - c.X) + (_area.MinY - c.Y) * (_area.MinY - c.Y));
                return new Coordinate((Math.Sin(angle + azi) * dist) + _area.MinX, (Math.Cos(angle + azi) * dist) + _area.MinY);
            }
            catch (Exception)
            {
                MessageBox.Show("Problem in the function point Azimuth");
                return null;
            }

        }

        public Coordinate UnProjectPointAzimut(double x, double y)
        {
            return UnProjectPointAzimut(new Coordinate(x, y));
        }

        public Coordinate UnProjectPointAzimut(Coordinate c)
        {
            if (_area.Azimut == 0) return c;
            double azi = DegToRad(_area.Azimut);
            double angleP = GetAzimut(c);
            double angle = angleP - azi;
            double dist = Math.Sqrt(((_area.MinX - c.X) * (_area.MinX - c.X)) + ((_area.MinY - c.Y) * (_area.MinY - c.Y)));
            return new Coordinate((Math.Sin(angle) * dist) + _area.MinX, (Math.Cos(angle) * dist) + _area.MinY);
        }

        private double GetAzimut(Coordinate origin, Coordinate target)
        {
            double dx = target.X - origin.X;
            double dy = target.Y - origin.Y;

            // if (dx == 0 && dy == 0) return 0;
            if (dx == 0 && dy > 0) return 0;
            if (dx == 0 && dy < 0) return Math.PI;
            if (dx > 0 && dy == 0) return Math.PI / 2;
            if (dx < 0 && dy == 0) return 3 * Math.PI / 2;
            if (dx > 0 && dy > 0) return Math.Atan(dx / dy);
            if (dx > 0 && dy < 0) return Math.PI + Math.Atan(dx / dy);
            if (dx < 0 && dy < 0) return (Math.PI) + Math.Atan(dx / dy);
            if (dx < 0 && dy > 0) return (2 * Math.PI) + Math.Atan(dx / dy);
            return 0;
            //  return Math.Atan(dx / dy);

        }

        private double GetAzimut(Coordinate target)
        {
            return geo.GetAzimuth(new Coordinate(_area.MinX, _area.MinY), target);
            //return GetAzimut(new Coordinate(_area.MinX, _area.MinY), target);

        }


        public void AddGrid()
        {
            if (pro != null)
            {
                pro.Value = 0;
                pro.Maximum = 100;
                pro.Visible = true;
            }

            _GridLayer.DataSet.Features.Clear();

            Int32 id = 0;

            double xini = _area.MinX;
            double yini = _area.MinY;

            rectangleFs = (FeatureSet)_GridLayer.DataSet;
            for (int i = 0; i < _area.NumColumns; i++)
            {
               // xini = geo.AzimuthDist(new Coordinate(_area.MinX, _area.MinY), Math.PI / 2, _area.CellSize * i).X;
                for (int j = 0; j < _area.NumRows; j++)
                {
                    int val =100 *id /( _area.NumColumns * _area.NumRows );

                    if (pro != null) {
                        pro.Increment(val);
                    }

                //    yini = geo.AzimuthDist(new Coordinate(_area.MinX, _area.MinY), 0, _area.CellSize * j).Y;
                    Coordinate[] array = new Coordinate[5];

                    //array[0] = new Coordinate(xini + i * _area.NumColumns, yini + j * _area.NumRows);
                    //array[1] = new Coordinate(xini + i * _area.NumColumns, yini + (j+1) * _area.NumRows);
                    //array[2] = new Coordinate(xini + (i + 1) * _area.NumColumns, yini + (j + 1) * _area.NumRows);
                    //array[3] = new Coordinate(xini + (i + 1) * _area.NumColumns, yini + j * _area.NumRows);
                    //array[4] = array[0];

                    array[0] = (new Coordinate(_area.MinX + (i * _area.CellSizeX), _area.MinY + (j * _area.CellSizeY)));
                    array[1] = (new Coordinate(_area.MinX + (i * _area.CellSizeX), _area.MinY + ((j + 1) * _area.CellSizeY)));
                    array[2] = (new Coordinate(_area.MinX + ((i + 1) * _area.CellSizeX), _area.MinY + ((j + 1) * _area.CellSizeY)));
                    array[3] = (new Coordinate(_area.MinX + ((i + 1) * _area.CellSizeX), _area.MinY + (j * _area.CellSizeY)));
                    array[4] = (new Coordinate(_area.MinX + (i * _area.CellSizeX), _area.MinY + (j * _area.CellSizeY)));
                    LinearRing shell = new LinearRing(array);
                    Polygon poly = new Polygon(shell);
                    IFeature newF = _GridLayer.DataSet.AddFeature(poly);
                    newF.DataRow["PolygonID"] = id;
                    newF.DataRow["row"] = j + 1;
                    newF.DataRow["col"] = i + 1;
                    id++;
                }
            }
           

           
            _mainMap.ResetBuffer();
            if (pro != null) if (pro.Value == pro.Maximum) pro.Visible = false;
            //   OnRectangleCreated();
        }

        public Extent GetExtent(double offset)
        {

            double[] xValues = new double[4]
                               {
                                 ProjectPointAzimut(new Coordinate(_area.MinX,_area.MinY)).X,
                                 ProjectPointAzimut(new Coordinate(_area.MinX,_area.MaxY)).X,
                                 ProjectPointAzimut(new Coordinate(_area.MaxX,_area.MaxY)).X,
                                 ProjectPointAzimut(new Coordinate(_area.MaxX,_area.MinY)).X,
                               };
            double[] yValues = new double[4]
                               {
                                 ProjectPointAzimut(new Coordinate(_area.MinX,_area.MinY)).Y,
                                 ProjectPointAzimut(new Coordinate(_area.MinX,_area.MaxY)).Y,
                                 ProjectPointAzimut(new Coordinate(_area.MaxX,_area.MaxY)).Y,
                                 ProjectPointAzimut(new Coordinate(_area.MaxX,_area.MinY)).Y,
                               };


            double percX = (xValues.Max() - xValues.Min()) * offset;
            double percY = (yValues.Max() - yValues.Min()) * offset;

            return new Extent(xValues.Min() - percX, yValues.Min() - percY, xValues.Max() + percX, yValues.Max() + percX);

        }
        public Extent GetExtent()
        {
            return GetExtent(0);
        }

        public void Save(string name)
        {

            try
            {
                rectangleFs.SaveAs(@name,true);
            }
            catch (NullReferenceException )
            {
               
            }
        }

        public void AddLayer()
        {
            if (GridLayerIsInMap())
            {
                _GridLayer.DataSet.Features.Clear();
            }
            else
            {
                rectangleFs = new FeatureSet(FeatureType.Polygon);
                rectangleFs.DataTable.Columns.Add("PolygonID");
                rectangleFs.DataTable.Columns.Add("row");
                rectangleFs.DataTable.Columns.Add("col");

                rectangleFs.Projection = _mainMap.Projection;

                _GridLayer = new MapPolygonLayer(rectangleFs);
                _GridLayer.LegendText = _name;

                //_rectangleLayer.LegendItemVisible = false;
                Color redColor = Color.Red.ToTransparent(0.8f);
                _GridLayer.Symbolizer = new PolygonSymbolizer();
                // 
                _GridLayer.Symbolizer.SetOutline(Color.Red, 1.0);
                _GridLayer.Symbolizer.SetFillColor(Color.Transparent);
                _GridLayer.SelectionSymbolizer = _GridLayer.Symbolizer;
                _GridLayer.Symbolizer.SetOutline(Color.Red, 1.0);
                // Extent ext = this.GetExtent(0.15);
                _mainMap.Layers.Add(_GridLayer);
                // _mainMap.ViewExtents = ext;

            }

            if (!GridLayerIsInMap())
            {
                //    Extent ext = this.GetExtent(0.15);
                _mainMap.Layers.Add(_GridLayer);
                //   _mainMap.ViewExtents = ext;
            }
        }

        public bool GridLayerIsInMap()
        {
            foreach (IMapLayer lay in _mainMap.GetAllLayers())
            {
                if (lay.LegendText == _name)
                {
                    _GridLayer = (MapPolygonLayer)lay;
                    return true;
                }
            }
            return false;
        }

        public void UpdateAreaInterestByOrigin(AreaInterest p)
        {
            _area.MinX = p.MinX;
            _area.MinY = p.MinY;
            _area.MaxX = p.MinX + (p.CellSizeX * p.NumColumns);
            _area.MaxY = p.MinY + (p.CellSizeY * p.NumRows);
            _area.NumColumns = p.NumColumns;
            _area.NumRows = p.NumRows;
            _area.CellSizeY = p.CellSizeY;
            _area.CellSizeX = p.CellSizeX;
            _area.Azimut = p.Azimut;
        }

        public void UpdateAreaInterestByColumnsRows(AreaInterest p)
        {
            try
            {
                double dx = p.MaxX - p.MinX;
                double dy = p.MaxY - p.MinY;
                double cellSizeX = dx / p.NumColumns;
                double cellSizeY = dy / p.NumRows;

                _area.MinX = p.MinX;
                _area.MinY = p.MinY;
                _area.MaxY = p.MinY + (p.NumRows * cellSizeY);
                _area.MaxX = p.MinX + (p.NumColumns * cellSizeX);

                _area.NumColumns = p.NumColumns;
                _area.NumRows = p.NumRows;
                _area.CellSizeX = cellSizeX;
                _area.CellSizeY = cellSizeY;
                _area.Azimut = p.Azimut;
            }
            catch (Exception)
            {
                MessageBox.Show("Problem in the UpdateAreaInterest");
            }
        }

        public void UpdateAreaInterestByCellSize(AreaInterest p)
        {
            double dx = p.MaxX - p.MinX;
            double dy = p.MaxY - p.MinY;
            double ncol = Math.Floor(dx / p.CellSizeX);
            double nrow = Math.Floor(dy / p.CellSizeY);

            _area.MinX = p.MinX;
            _area.MinY = p.MinY;
            _area.MaxY = p.MinY + (p.CellSizeY * nrow);
            _area.MaxX = p.MinX + (p.CellSizeX * ncol);

            _area.NumColumns = Convert.ToInt16(ncol);
            _area.NumRows = Convert.ToInt16(nrow);
            _area.CellSizeX = p.CellSizeX;
            _area.CellSizeY = p.CellSizeY;
            _area.Azimut = p.Azimut;

        }

        public bool    UpdateAreaInterest(AreaInterest p)
        {

                if (p.NumColumns != 0 && p.NumRows != 0)
                {
                    _area.MinX = p.MinX;
                    _area.MinY = p.MinY;
                   
                   _area.MaxX = geo.AzimuthDist(new Coordinate(p.MinX, p.MinY), Math.PI/2.0, p.CellSize * p.NumColumns).X;

                   double dis = Math.Abs(_area.MaxX - _area.MinX) / p.NumColumns;
                   _area.MaxY = _area.MinY+ dis * p.NumRows;

                   _orgArea.CellSize = p.CellSize;

                   _area.NumColumns = p.NumColumns;
                   _area.NumRows = p.NumRows;
                   _area.CellSize = dis;
                   _area.Azimut = p.Azimut;
                    
                    return true;
                }
                else 
                {
                    Coordinate p1 = new Coordinate(p.MinX, p.MinY);
                    Coordinate p2 = new Coordinate(p.MaxX, p.MinY);
                    Coordinate p3 = new Coordinate(p.MinX, p.MinY);
                    Coordinate p4 = new Coordinate(p.MinX, p.MaxY);

                    double dx = geo.Distance(p1,p2);
                    
                    double dy = geo.Distance(p3,p4);

                    

                    if ((dy / p.CellSize) > Math.Floor(dy / p.CellSize))
                        p.NumRows = Convert.ToInt32(Math.Floor(dy / p.CellSize));

                    if ((dx / p.CellSize) > Math.Floor(dx / p.CellSize))
                        p.NumColumns = Convert.ToInt32(Math.Floor(dx / p.CellSize));

                    double dyy = Math.Abs(p.MaxY-p.MinY) / p.NumRows;
                    double dxx = Math.Abs(p.MaxX- p.MinX) / p.NumColumns;

                    double va = 0;
                    if (dxx > dyy) va = dxx; else va = dyy;

                    _area.CellSize = va;
                    _area.MinX = p.MinX;
                    _area.MinY = p.MinY;

                    //_area.MaxY=geo.AzimuthDist(new Coordinate(_area.MinX, _area.MinY), 0, p.CellSize * p.NumRows).Y;
                   //_area.MaxX = geo.AzimuthDist(new Coordinate(_area.MinX, _area.MinY), Math.PI/2.0, p.CellSize * p.NumColumns).X;

                    _area.MaxX = _area.MinX + va * p.NumColumns;
                    _area.MaxY = _area.MinY + va * p.NumRows;
                    
                    _area.NumColumns = p.NumColumns;
                    _area.NumRows = p.NumRows;
                   // _area.CellSize = p.CellSize;
                    _area.Azimut = p.Azimut;



                    return true;
                }


            }
            

                //if (p.NumColumns != 0 && p.NumRows != 0)
                //{
                //    _area.MinX = p.MinX;
                //    _area.MinY = p.MinY;
                //    _area.MaxY = p.MinY + (p.CellSize * p.NumRows);
                //    _area.MaxX = p.MinX + (p.CellSize * p.NumColumns);
                //    _area.NumColumns = p.NumColumns;
                //    _area.NumRows = p.NumRows;
                //    _area.CellSize = p.CellSize;
                //    _area.Azimut = p.Azimut;
                //    return true;

                //}
                //else
                //{
                //    double dx = p.MaxX - p.MinX;
                //    double dy = p.MaxY - p.MinY;
                //    if ((dy / p.CellSize) > Math.Floor(dy / p.CellSize))
                //        p.NumRows = Convert.ToInt32(Math.Floor(dy / p.CellSize));

                //    if ((dx / p.CellSize) > Math.Floor(dx / p.CellSize))
                //        p.NumColumns = Convert.ToInt32(Math.Floor(dx / p.CellSize));

                //    _area.MinX = p.MinX;
                //    _area.MinY = p.MinY;
                //    _area.MaxY = p.MinY + (p.CellSize * p.NumRows);
                //    _area.MaxX = p.MinX + (p.CellSize * p.NumColumns);
                //    _area.NumColumns = p.NumColumns;
                //    _area.NumRows = p.NumRows;
                //    _area.CellSize = p.CellSize;
                //    _area.Azimut = p.Azimut;
                //    return true;

                //}

           
     





        }
}
