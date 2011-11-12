using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotSpatial.Controls;
using DotSpatial.Topology;
using DotSpatial.Data;
using DotSpatial.Symbology;
using DotSpatial.Projections;

namespace Cetecean
{
    public partial class frmCreatePolygonGrid : Form
    {
        Map _map = null;
        VectorGrid _vector = null;
        Coordinate _startPoint = null;
        Coordinate _startPointe = null;
        MapPointLayer _pointLayer = null;
        MapPolygonLayer _polygonLayer = null;
        AreaInterest _area = null;

        bool _activePoint = false;
        bool _activeBox = false;
        int _numClicks = 0;

        public frmCreatePolygonGrid()
        {
            InitializeComponent();
        }

        public frmCreatePolygonGrid(Map map)
        {
            _map = map;
            InitializeComponent();
        }

        private void rbtPointOrigin_Click(object sender, EventArgs e)
        {
            label8.Text = "Please pick an origin:";
            label3.Visible = false;
            label4.Visible = false;
            txtXmax.Visible = false;
            txtYmax.Visible = false;
            txtNumColumns.Enabled = true;
            txtNumRows.Enabled = true;
            ClearAll();

            setPointLayer();
            removeLayer("Area selected");
            _polygonLayer = null;

        }

        private void rbtBox_Click(object sender, EventArgs e)
        {
            label8.Text = "Please select a region:";
            label3.Visible = true;
            label4.Visible = true;
            txtXmax.Visible = true;
            txtYmax.Visible = true;
            
            txtNumColumns.Enabled = false;
            txtNumRows.Enabled = false;
            ClearAll();
            setPolygonLayer();
            removeLayer("Origin Point");
            _pointLayer = null;
        }

        private void btnCaptureArea_Click(object sender, EventArgs e)
        {
            if (rbtBox.Checked)
            {

                if (_activePoint)
                {
                    _map.MouseDown -= getPointMap_MouseDown;
                    _activePoint = false;
                }

                if (!_activeBox)
                {
                   
                    _map.MouseDown += new System.Windows.Forms.MouseEventHandler(mapSelect_MouseDown);
                    _map.MouseUp += new System.Windows.Forms.MouseEventHandler(mapSelect_MouseUp);
                    _map.FunctionMode = FunctionMode.Select;
                    _activeBox = true;
                }




            }

            if (rbtPointOrigin.Checked)
            {
                if (_activeBox)
                {
                    _map.MouseDown -= mapSelect_MouseDown;
                    _map.MouseUp -= mapSelect_MouseUp;
                    _activeBox = false;
                }

                if (!_activePoint)
                {
                    _map.FunctionMode = FunctionMode.None;
                    _map.Cursor = Cursors.Cross;
                    _activePoint = true;
                    _map.MouseDown += new System.Windows.Forms.MouseEventHandler(getPointMap_MouseDown);
                }


            }
            grbParameters.Enabled = true;
            this.Hide();
        }

        public bool CheckValue()
        {
            if (txtGridSize.Text != "")
            {
                try
                {

                    Convert.ToDouble(txtGridSize.Text);
                }
                catch (FormatException)
                {
                    return false;
                }
                
                return true;
            } 
            return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_activeBox)
            {
                _map.MouseDown -= mapSelect_MouseDown;
                _map.MouseUp -= mapSelect_MouseUp;
            }

            if (_activePoint)
            {
                _map.MouseDown -= getPointMap_MouseDown;
            }

            removeLayer("Area selected");
            removeLayer("Origin Point");
         //   removeLayer("Grid");
            _startPoint = null;
            this.Close();

        }

        void mapSelect_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //only modify rectangle drawing if function mode is Select
            if (_map.FunctionMode != FunctionMode.Select) return;

            if (_numClicks == 0)
            {
                //todo: draw point...

                _startPoint = new Coordinate(_map.PixelToProj(e.Location));
                _startPointe = new Coordinate(e.Location.X, e.Location.Y);
                _numClicks = 1;

            }
            else if (_numClicks == 1)
            {
                _numClicks = 2;
            }

        }

        void mapSelect_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //only modify rectangle drawing if function mode is Select
            if (_map.FunctionMode != FunctionMode.Select) return;

            foreach (IMapLayer lay in _map.GetAllLayers())
            {
                if (lay.LegendText == "Area selected")
                {
                    MapPolygonLayer pol = (MapPolygonLayer)lay;
                    pol.DataSet.Features.Clear();
                }
            }



            if (_numClicks == 1)
            {
                Coordinate endPoint = new Coordinate(_map.PixelToProj(e.Location));
                Coordinate eendPoint = new Coordinate(e.Location.X, e.Location.Y);

                setPolygonLayer();
                if (_polygonLayer.DataSet.Features == null) return;
                _polygonLayer.DataSet.Features.Clear();
                Coordinate[] array = new Coordinate[5];
                array[0] = _startPoint;
                array[1] = new Coordinate(_startPoint.X, endPoint.Y);
                array[2] = endPoint;
                array[3] = new Coordinate(endPoint.X, _startPoint.Y);
                array[4] = _startPoint;
                LinearRing shell = new LinearRing(array);
                Polygon poly = new Polygon(shell);

                IFeature newF = _polygonLayer.DataSet.AddFeature(poly);
                newF.DataRow["ID"] = 1;
                _numClicks = 0;
                _map.ResetBuffer();
                Extent ext = poly.Envelope.ToExtent();
                fillData(ext);
                this.Visible = true;

            }
        }

        void fillData(Extent ext)
        {
            txtXmax.Text = ext.MaxX.ToString();
            txtXmin.Text = ext.MinX.ToString();
            txtYmax.Text = ext.MaxY.ToString();
            txtYmin.Text = ext.MinY.ToString();
            _area = new AreaInterest();
            _area.MaxX = ext.MaxX;
            _area.MaxY = ext.MaxY;
            _area.MinX = ext.MinX;
            _area.MinY = ext.MinY;

        }

        void ClearAll()
        {
            txtXmax.Text = "";
            txtXmin.Text = "";
            txtYmax.Text = "";
            txtYmin.Text = "";
            txtNumRows.Text = "";
            txtNumColumns.Text = "";
            txtGridSize.Text = "";
            _area = null;
            _vector = null;

        }

        void getPointMap_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            Coordinate startPoint;
            startPoint = new Coordinate(_map.PixelToProj(e.Location));
            if (_pointLayer.DataSet.Features != null)
                _pointLayer.DataSet.Features.Clear();
            else
                return;
            DotSpatial.Topology.Point point = new DotSpatial.Topology.Point(startPoint.X, startPoint.Y);
            IFeature newF = _pointLayer.DataSet.AddFeature(point);
            newF.DataRow["ID"] = 1;
            _map.ResetBuffer();


           // double[] xy = new double[] { startPoint.X, startPoint.Y };
           // string esri = Properties.Resources.wgs_84_esri_string;
           // ProjectionInfo wgs84 = KnownCoordinateSystems.Geographic.World.WGS1984;//new ProjectionInfo();
           // wgs84.ReadEsriString(esri);
            //Reproject.ReprojectPoints(xy, new double[] { 0 }, _map.Projection, wgs84, 0, 1);

            txtXmin.Text = startPoint.X.ToString();
            txtYmin.Text = startPoint.Y.ToString();
            txtXmax.Text = "";
            txtYmax.Text = "";

            _area = new AreaInterest();

            _area.MinX = startPoint.X;
            _area.MinY = startPoint.Y;
            this.Visible = true;
         //   _map.MouseDown -= getPointMap_MouseDown;
           // Clean_selection();
        }

        void setPolygonLayer()
        {
            if (_polygonLayer == null)
            {

                FeatureSet rectangleFs = new FeatureSet(FeatureType.Polygon);
                rectangleFs.DataTable.Columns.Add("ID");
                rectangleFs.Projection = _map.Projection;
                _polygonLayer = new MapPolygonLayer(rectangleFs);
                _polygonLayer.LegendText = "Area selected";
                Color redColor = Color.Red.ToTransparent(0.8f);
                _polygonLayer.Symbolizer = new PolygonSymbolizer();
                _polygonLayer.Symbolizer.SetFillColor(Color.WhiteSmoke);
                _polygonLayer.Symbolizer.SetOutline(Color.Green, 1.0);
                _polygonLayer.SelectionSymbolizer = _polygonLayer.Symbolizer;
                Extent ext = _map.ViewExtents;
                _map.Layers.Add(_polygonLayer);
                _map.ViewExtents = ext;
            }

        }
        void setPointLayer() 
        {
            if (_pointLayer == null)
            {
                FeatureSet _pointFs = new FeatureSet(FeatureType.Point);
                _pointFs.DataTable.Columns.Add("ID");
                _pointFs.Projection = _map.Projection;
                _pointLayer = new MapPointLayer(_pointFs);
                _pointLayer.LegendText = "Origin Point";
                _pointLayer.Symbolizer.SetFillColor(Color.Green);
                Extent ext = _map.ViewExtents;
                _map.Layers.Add(_pointLayer);
                _map.ViewExtents = ext;
            }
        }
        void removeLayer(string name)
        {
            _map.FunctionMode = FunctionMode.None;
            foreach (IMapLayer lay in _map.GetLayers())
            {
                if (lay.LegendText == name)
                {
                    _map.Layers.Remove(lay);
                    break;
                }
            }
        }

        private void btnCreateGrid_Click(object sender, EventArgs e)
        {
            
            if (_area == null) {

                MessageBox.Show("Please select an area or origin point and fill all parameters");
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            if (rbtBox.Checked && (_vector != null))
            {
                _vector.AddLayer();
                _vector.Progress(progressBar1);
                _vector.AddGrid();

            }

            if (rbtPointOrigin.Checked && Validator.IsInt32(txtNumColumns) && Validator.IsInt32(txtNumRows) && Validator.IsDouble(txtGridSize))
            {
                _area.NumColumns = Convert.ToInt32(txtNumColumns.Text);
                _area.NumRows = Convert.ToInt32(txtNumRows.Text);
                _area.CellSize = Convert.ToDouble(txtGridSize.Text);
                _vector = new VectorGrid(_area,_map);
                _vector.AddLayer();
                _vector.Progress(progressBar1);
                _vector.AddGrid();
            }

            removeLayer("Area selected");
            removeLayer("Origin Point");
            this.Cursor = Cursors.Default;
        }

        private void txtNumColumns_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumRows_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGridSize_TextChanged(object sender, EventArgs e)
        {
            if (rbtBox.Checked)
            {
                if (CheckValue())
                {
                    if (_area != null)
                    {
                        _area.NumColumns = 0;
                        _area.NumRows = 0;
                        _area.CellSize = Convert.ToDouble(txtGridSize.Text);
                        _vector = new VectorGrid(_area, _map);
                        txtNumRows.Text = _vector.Get_area().NumRows.ToString();
                        txtNumColumns.Text = _vector.Get_area().NumColumns.ToString();
                    }
                }
                else
                {
                    txtNumColumns.Text = "";
                    txtNumRows.Text = "";
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "shapefile files (*.shp)|*.shp";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Save Polygon Grid";
            string strFileName = "";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                strFileName = dialog.FileName;
            }


            if (strFileName == String.Empty)
            {
              // MessageBox.Show("The polygon Grid won't be saved");
                return;
            }
            else
            {
                label9.Text = strFileName;
                _vector.Save(strFileName);

                foreach (ILayer l in _map.GetAllLayers())
                { 
                   if (l.LegendText== "Grid")
                   {
                       MapPolygonLayer p = (MapPolygonLayer)l;
                       p.LegendText=Validator.GetNameFile(strFileName);
                       Close();
                       return;
                   }
                
                }


            }
        }

        private void frmCreatePolygonGrid_Load(object sender, EventArgs e)
        {

        }

        private void rbtPointOrigin_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtBox_CheckedChanged(object sender, EventArgs e)
        {

        }

    
    }
}
