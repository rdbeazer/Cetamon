using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using DotSpatial.Controls;
using DotSpatial.Topology;
using DotSpatial.Data;
using DotSpatial.Symbology;
using DotSpatial.Projections;
using DotSpatial.Symbology.Forms;

namespace Cetecean
{
    class VectorGrid
    {
        private Map _mainMap;
        private AreaInterest _area = new AreaInterest();
        private AreaInterest _orgArea;
        private MapPolygonLayer _GridLayer = null;
        private FeatureSet rectangleFs;
        private ProgressBar pro = null;

        public void Progress(ProgressBar bar)
        {
            pro = bar;
        }

        public VectorGrid(double xmin, double ymin, double xmax, double ymax, int numColums, int numRows, double cellSizeX, double cellSizeY, double azimut, IMap map)
        {
            _orgArea.MinX = xmin;
            _orgArea.MinY = ymin;
            _orgArea.MaxX = xmax;
            _orgArea.MaxY = ymax;
            _orgArea.NumColumns = numColums;
            _orgArea.NumRows = numRows;
            _orgArea.CellSizeX = cellSizeX;
            _orgArea.CellSizeY = cellSizeY;
            _orgArea.Azimut = azimut;

            _mainMap = map as Map;
            UpdateAreaInterest(_orgArea);

        }

        public VectorGrid(string typecoor, double xmin, double ymin, int numColums, int numRows, double cellSizeX, double cellSizeY, double azimut, IMap map)
        {
            _orgArea = new AreaInterest();
            _orgArea.TypeCoor = typecoor;
            _orgArea.MinX = xmin;
            _orgArea.MinY = ymin;
            _orgArea.NumColumns = numColums;
            _orgArea.NumRows = numRows;
            _orgArea.CellSizeX = cellSizeX;
            _orgArea.CellSizeY = cellSizeY;
            _orgArea.Azimut = azimut;
            _mainMap = map as Map;
            UpdateAreaInterestByOrigin(_orgArea);

        }


        public AreaInterest Get_area()
        {
            return _area;
        }

        public MapPolygonLayer GetLayer()
        {
            return _GridLayer;
        }

        public VectorGrid(AreaInterest p, IMap map)
        {
            _orgArea = p;
            _mainMap = map as Map;
            UpdateAreaInterest(p);
        }



        public void UpdateRowColsByCellSize(double cellSizeX, double cellSizeY)
        {
            _orgArea.CellSizeX = cellSizeX;
            _orgArea.CellSizeY = cellSizeY;
            UpdateAreaInterestByCellSize(_orgArea);
        }

        public void UpdateCellSizeByColRows(int col, int row)
        {
            _orgArea.NumColumns = col;
            _orgArea.NumRows = row;
            UpdateAreaInterestByColumnsRows(_orgArea);

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
            double[] xy = new double[2];
            xy[0] = x;
            xy[1] = y;
            double[] z = new double[1];
            ProjectionInfo wgs84 = KnownCoordinateSystems.Geographic.World.WGS1984;
            Reproject.ReprojectPoints(xy, z, wgs84, _mainMap.Projection, 0, 1);
            return new Coordinate(xy[0], xy[1]);
        }

        public Coordinate ReprojectPointToWgs84(double x, double y)
        {
            double[] xy = new double[2];
            xy[0] = x;
            xy[1] = y;
            double[] z = new double[1];

            ProjectionInfo wgs84 = KnownCoordinateSystems.Geographic.World.WGS1984;
         

            Reproject.ReprojectPoints(xy, z, _mainMap.Projection, wgs84, 0, 1);
            return new Coordinate(xy[0], xy[1]);
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


            if (_area.Azimut == 0) return c;
            double angle = DegToRad(_area.Azimut);
            double azi = GetAzimut(c);
            double v = (angle + azi) * 180.0 / Math.PI;
            double dist = Math.Sqrt((_area.MinX - c.X) * (_area.MinX - c.X) + (_area.MinY - c.Y) * (_area.MinY - c.Y));
            return new Coordinate((Math.Sin(angle + azi) * dist) + _area.MinX, (Math.Cos(angle + azi) * dist) + _area.MinY);


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
            return GetAzimut(new Coordinate(_area.MinX, _area.MinY), target);

        }


        public void AddGrid(IList<IFeature> selected)
        {
            if (pro != null)
            {
                pro.Value = 0;
                pro.Maximum = 1000;
                pro.Visible = true;
            }

            _GridLayer.DataSet.Features.Clear();

            Int32 id = 0;

            for (int i = 0; i < _area.NumColumns; i++)
            {
                for (int j = 0; j < _area.NumRows; j++)
                {

                    int val = 1000 * id / (_area.NumColumns * _area.NumRows);

                    if (pro != null)
                    {
                        pro.Value = val;
                      //  pro.Increment(val);
                    }
                    Coordinate[] array = new Coordinate[5];

                    array[0] = ProjectPointAzimut(new Coordinate(_area.MinX + (i * _area.CellSizeX), _area.MinY + (j * _area.CellSizeY)));
                    array[1] = ProjectPointAzimut(new Coordinate(_area.MinX + (i * _area.CellSizeX), _area.MinY + ((j + 1) * _area.CellSizeY)));
                    array[2] = ProjectPointAzimut(new Coordinate(_area.MinX + ((i + 1) * _area.CellSizeX), _area.MinY + ((j + 1) * _area.CellSizeY)));
                    array[3] = ProjectPointAzimut(new Coordinate(_area.MinX + ((i + 1) * _area.CellSizeX), _area.MinY + (j * _area.CellSizeY)));
                    array[4] = ProjectPointAzimut(new Coordinate(_area.MinX + (i * _area.CellSizeX), _area.MinY + (j * _area.CellSizeY)));
                    LinearRing shell = new LinearRing(array);
                    Polygon poly = new Polygon(shell);

                    if (selected != null && selected.Count > 0)
                    {
                        foreach (IFeature fea in selected)
                        {
                            if (!fea.Intersects((IGeometry)poly))
                            {
                                IFeature newF = _GridLayer.DataSet.AddFeature(poly);
                                newF.DataRow["polygonID"] = id;
                                newF.DataRow["row"] = j + 1;
                                newF.DataRow["col"] = i + 1;

                            }
                        }
                        id++;
                    }
                    else
                    {
                        IFeature newF = _GridLayer.DataSet.AddFeature(poly);
                        newF.DataRow["polygonID"] = id;
                        newF.DataRow["row"] = j + 1;
                        newF.DataRow["col"] = i + 1;
                        id++;
                    
                    }
                   
                }
            }
            rectangleFs = (FeatureSet)_GridLayer.DataSet;
            _mainMap.ResetBuffer();
            if (pro != null)  pro.Visible = false;

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

            for (int i = 0; i < _area.NumColumns; i++)
            {
                for (int j = 0; j < _area.NumRows; j++)
                {

                    int val = 100 * id / (_area.NumColumns * _area.NumRows);

                    if (pro != null)
                    {
                        pro.Increment(val);
                    }
                    Coordinate[] array = new Coordinate[5];

                    array[0] = ProjectPointAzimut(new Coordinate(_area.MinX + (i * _area.CellSizeX), _area.MinY + (j * _area.CellSizeY)));
                    array[1] = ProjectPointAzimut(new Coordinate(_area.MinX + (i * _area.CellSizeX), _area.MinY + ((j + 1) * _area.CellSizeY)));
                    array[2] = ProjectPointAzimut(new Coordinate(_area.MinX + ((i + 1) * _area.CellSizeX), _area.MinY + ((j + 1) * _area.CellSizeY)));
                    array[3] = ProjectPointAzimut(new Coordinate(_area.MinX + ((i + 1) * _area.CellSizeX), _area.MinY + (j * _area.CellSizeY)));
                    array[4] = ProjectPointAzimut(new Coordinate(_area.MinX + (i * _area.CellSizeX), _area.MinY + (j * _area.CellSizeY)));
                    LinearRing shell = new LinearRing(array);
                    Polygon poly = new Polygon(shell);
                    IFeature newF = _GridLayer.DataSet.AddFeature(poly);
                    newF.DataRow["polygonID"] = id;
                    newF.DataRow["row"] = j + 1;
                    newF.DataRow["col"] = i + 1;
                    id++;
                }
            }
            rectangleFs = (FeatureSet)_GridLayer.DataSet;
            _mainMap.ResetBuffer();
            if (pro != null) if (pro.Value == pro.Maximum) pro.Visible = false;

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
            rectangleFs.SaveAs(name, true);
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
                rectangleFs.DataTable.Columns.Add("polygonID");
                rectangleFs.DataTable.Columns.Add("row");
                rectangleFs.DataTable.Columns.Add("col");

                rectangleFs.Projection = _mainMap.Projection;

                _GridLayer = new MapPolygonLayer(rectangleFs);
                _GridLayer.LegendText = "Grid";

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
                if (lay.LegendText == "Grid")
                {
                    _GridLayer = (MapPolygonLayer)lay;
                    return true;
                }
            }
            return false;
        }

        public void UpdateAreaInterestByOrigin(AreaInterest p)
        {
            _area.Name = p.Name;
            _area.Description = p.Description;
            _area.TypeCoor = p.TypeCoor;
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

        public bool UpdateAreaInterest(AreaInterest p)
        {
            if ((Math.Abs(p.MinX - (p.MaxX - (p.NumColumns * p.CellSizeX))) < 0.001) &&
                (Math.Abs(p.MinY - (p.MaxY - (p.NumRows * p.CellSizeY))) < 0.001))
            {
                _area = p;
                return false;
            }
            else
            {
                double dx = p.MaxX - p.MinX;
                double dy = p.MaxY - p.MinY;
                _area.Name = p.Name;
                _area.Description = p.Description;
                _area.TypeCoor = p.TypeCoor;
                _area.MinX = p.MinX;
                _area.MinY = p.MinY;
                _area.MaxY = p.MinY + (p.CellSizeY * p.NumRows);
                _area.MaxX = p.MinX + (p.CellSizeX * p.NumColumns);
                _area.NumColumns = p.NumColumns;
                _area.NumRows = p.NumRows;
                _area.CellSizeX = p.CellSizeX;
                _area.CellSizeY = p.CellSizeY;
                _area.Azimut = p.Azimut;
                return true;
            }


        }

        public int[] GetCell(double xo, double yo)
        {
            double x = this.UnProjectPointAzimut(xo, yo).X;
            double y = this.UnProjectPointAzimut(xo, yo).Y;

            if ((x < _area.MinX) || (x > _area.MaxX) || (y < _area.MinY) || (y > _area.MaxY))
            {
                return new int[2] { -1, -1 };
            }
            else
            {
                int[] val = new int[2] { (int)(Math.Floor(((x - _area.MinX) / _area.CellSizeX)) + 1), (int)(Math.Floor(((_area.MaxY - y) / _area.CellSizeY)) + 1) };
                return GetCellOrigenXY(val[0], val[1]);
            }
        }

        public int[] GetCellOrigenXY(int col, int row)
        {
            return new int[2] { col, _area.NumRows - row + 1 };
        }

        public double[] GetCoordenatesByCell(int col, int row)
        {
            if ((col < 1) || (col > _area.NumColumns) || (row < 1) || (row > _area.NumRows))
            {
                return new double[2] { 0d, 0d };
            }
            else
            {
                // return new double[2] { _area.minX + (_area.cellSize * col) - (_area.cellSize / 2), _area.maxY - (_area.cellSize * row) + (_area.cellSize / 2) };

                Coordinate pointProj = new Coordinate(_area.MinX + (_area.CellSizeX * col) - (_area.CellSizeX / 2), _area.MinY + (_area.CellSizeY * row) - (_area.CellSizeY / 2));
                return new double[2] { ProjectPointAzimut(pointProj).X, ProjectPointAzimut(pointProj).Y };

            }



        }


    }
}
