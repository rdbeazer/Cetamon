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
    public partial class frmCalculateBuffer : Form
    {

        Map _map = null;

        public frmCalculateBuffer()
        {
            InitializeComponent();
        }

        public frmCalculateBuffer(Map map)
        {
            _map = map;
            InitializeComponent();
        }

        private void rbtBuffer_CheckedChanged(object sender, EventArgs e)
        {

            label2.Visible = false;
            cbxField1.Visible = false;
            label3.Visible = false;
            cbxField2.Visible = false;
            txtBuffer.Visible = true;

            cbxSideType.Enabled = true;
            label4.Enabled = true;
        }

        private void rbtOne_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "Field :";
            label2.Visible = true;
            cbxField1.Visible = true;
            label3.Visible = false;
            cbxField2.Visible = false;
            txtBuffer.Visible = false;
            cbxSideType.Enabled = true;
            label4.Enabled = true;
            
        }

        private void rbtTwo_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "Field 1 (Right side)";
            label3.Visible = true;
            cbxField2.Visible = true;
            label2.Visible = true;
            cbxField1.Visible = true;
            txtBuffer.Visible = false;
            cbxSideType.Enabled = false;
            label4.Enabled = false;
        }

        private void frmCalculateBuffer_Load(object sender, EventArgs e)
        {
            GetLayers();
            cbxSideType.Items.Add("Full");
            cbxSideType.Items.Add("Left");
            cbxSideType.Items.Add("Right");


        }

        /// <summary>
        /// Get the layers
        /// </summary>
        private void GetLayers()
        {
            if (_map.Layers.Count > 0)
            {
                foreach (IMapLayer iLa in _map.Layers)
                {
                    FeatureSet fT = (FeatureSet)iLa.DataSet;
                    if (fT.FeatureType == FeatureType.Line)
                        cbxLayer.Items.Add(iLa.LegendText);
                }
            }
            else
            {
                MessageBox.Show("Please add a layer to the map");
                Close();
                return;
            }
        }


        private void FillFields(string layer)
        {
            if (layer == "") return;
            cbxField1.Items.Clear();
            cbxField2.Items.Clear();
            cbxDissolve.Items.Clear();

            IFeatureSet fT=null;
            foreach (IMapLayer iLa in _map.Layers)
            {
                 fT = (IFeatureSet)iLa.DataSet;
                 if (fT.Name == layer)
                     break;
            }
            if (fT == null) return;
            foreach (DataColumn col in fT.DataTable.Columns)
            {
                if (col.DataType == typeof(double) || col.DataType == typeof(int))
                {
                    cbxField1.Items.Add(col.ColumnName);
                    cbxField2.Items.Add(col.ColumnName);
                }
                if (col.DataType == typeof(int) || col.DataType == typeof(string))
                    cbxDissolve.Items.Add(col.ColumnName);
            }
        
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            FeatureSet fT = null;
            FeatureSet outp = null;
            foreach (IMapLayer iLa in _map.Layers)
            {
                fT = (FeatureSet)iLa.DataSet;
                if (fT.Name == cbxLayer.Text)
                    break;
            }

            if (rbtBuffer.Checked)
            {
                if (Validator.IsPresent(txtBuffer) && Validator.IsDoublePositive(txtBuffer))
                {

                    outp = (FeatureSet)CalculateBuffer(fT,Convert.ToDouble(txtBuffer.Text),cbxSideType.Text);
                }
            }



            if (rbtOne.Checked)
            {
                if (cbxField1.Text == "")
                {
                    MessageBox.Show("Please select a field");
                    return;
                }
                outp = CalculateBuffer(fT, cbxField1.Text, cbxSideType.Text);
            }

            if (rbtTwo.Checked)
            {
                if (cbxField1.Text == "" || cbxField2.Text == "")
                {
                    MessageBox.Show("Please select a field");
                    return;
                }
                outp = CalculateBuffer(fT, cbxField1, cbxField2);

            }

            if (chkDissolve.Checked)
            { 
                 if (cbxDissolve.Text == "")
                 {
                     MessageBox.Show("Please select a field");
                    return;
                 }

                 outp = (FeatureSet)outp.Dissolve(cbxDissolve.Text);
            }

            Validator.SaveShapefile("Buffer", outp);
            IMapPolygonLayer Ipo = new MapPolygonLayer(outp);
            Ipo.LegendText = "Buffer";
            Ipo.Symbolizer.SetFillColor(Color.Green);

            _map.Layers.Add(Ipo);
            fT = null;
            Close();
        }


        private FeatureSet CalculateBuffer(FeatureSet feaS, string field, string side)
        {
            FeatureSet outp = new FeatureSet() ;
            outp.FeatureType = FeatureType.Polygon;

            outp.Projection = _map.Projection;

            foreach (DataColumn col in feaS.DataTable.Columns) { 
                   outp.DataTable.Columns.Add(new DataColumn(col.ColumnName, col.DataType));
                }

            int i = 0;
            foreach (DataRow row in feaS.DataTable.Rows)
            {

                double v = Convert.ToDouble(row[field]);

                IFeature fea1;
                IFeature fea ;

                if (side == "Full")
                {
                    fea1 = (TransfGeometry(feaS.Features[i], true));
                    fea1 = fea1.Buffer(v);
                    fea = outp.AddFeature((TransfGeometry(fea1, false)));
                }
                else if (side == "Left")
                {
                    IFeature l = TransfGeometry((Feature)feaS.Features[i], true);
                    LinearRing linL = new LinearRing(BufferBySide(l, v, "L"));
                    fea = outp.AddFeature(TransfGeometry(new Feature(new Polygon(linL)), false));
                }
                else 
                {
                    IFeature l = TransfGeometry((Feature)feaS.Features[i], true);
                    LinearRing linL = new LinearRing(BufferBySide(l, v, "R"));
                    fea = outp.AddFeature(TransfGeometry(new Feature(new Polygon(linL)), false));
                
                }


              
                foreach (DataColumn col in feaS.DataTable.Columns)
                {
                    fea.DataRow[col.ColumnName] = row[col.ColumnName];
                }
                i++;
            }

            feaS.Projection = _map.Projection;
            return outp;

        }

        private FeatureSet CalculateBuffer(FeatureSet feaS, double buffer, string side)
        {
            FeatureSet outp = new FeatureSet();
            outp.FeatureType = FeatureType.Polygon;

            outp.Projection = _map.Projection;

            foreach (DataColumn col in feaS.DataTable.Columns)
            {
                outp.DataTable.Columns.Add(new DataColumn(col.ColumnName, col.DataType));
            }

            int i = 0;
            foreach (DataRow row in feaS.DataTable.Rows)
            {

                IFeature fea;

                if (side == "Full")
                {
                    fea = outp.AddFeature(TransfGeometry(TransfGeometry(feaS.Features[i], true).Buffer(buffer), false));
                }
                else if (side == "Left")
                {
                    IFeature l = TransfGeometry((Feature)feaS.Features[i], true);
                    LinearRing linL = new LinearRing(BufferBySide(l, buffer, "L"));
                    fea = outp.AddFeature(TransfGeometry(new Feature(new Polygon(linL)), false));
                }
                else
                {
                    IFeature l = TransfGeometry((Feature)feaS.Features[i], true);
                    LinearRing linL = new LinearRing(BufferBySide(l, buffer, "R"));
                    fea = outp.AddFeature(TransfGeometry(new Feature(new Polygon(linL)), false));

                }
                
               
                foreach (DataColumn col in feaS.DataTable.Columns)
                {
                    fea.DataRow[col.ColumnName] = row[col.ColumnName];
                }
                i++;
            }

            feaS.Projection = _map.Projection;
            return (FeatureSet)outp;

        }


        private IFeature TransfGeometry(IFeature C, bool t)
        {
            IFeature B = (IFeature)C.Clone();

            if (_map.Projection != KnownCoordinateSystems.Geographic.World.WGS1984)
            {
                return B;
            }

            MessageBox.Show(_map.Projection.Unit.Name);

            double[] xy = new double[B.Coordinates.Count * 2];
            double[] z = new double[B.Coordinates.Count * 2];
             for (int i = 0; i < B.Coordinates.Count; i++)
            {
                xy[2 * i] =  B.Coordinates[i].X;
                xy[2 * i + 1] = B.Coordinates[i].Y;
            }


            if (t)
            DotSpatial.Projections.Reproject.ReprojectPoints(xy, z, _map.Projection,
                KnownCoordinateSystems.Projected.World.WebMercator, 0, B.Coordinates.Count);
             else
                DotSpatial.Projections.Reproject.ReprojectPoints(xy, z, KnownCoordinateSystems.Projected.World.WebMercator,
                  _map.Projection, 0, B.Coordinates.Count);

            Coordinate[] c1 = new Coordinate[B.Coordinates.Count];

            for (int i = 0; i < B.Coordinates.Count; i++)
            {
               c1[i]= new Coordinate(xy[2*i],xy[2*i+1]);
            }

            B.Coordinates = c1;
            return B;
        }

        private FeatureSet CalculateBuffer(FeatureSet feaS, ComboBox cfieldR, ComboBox cfieldL)
        {
            string fieldR = cfieldR.Text;
            string fieldL = cfieldL.Text;

            IFeatureSet outp = new FeatureSet();
            outp.FeatureType = FeatureType.Polygon;

            outp.Projection = _map.Projection;

            foreach (DataColumn col in feaS.DataTable.Columns)
            {
                outp.DataTable.Columns.Add(new DataColumn(col.ColumnName, col.DataType));
            }

            int i = 0;
            foreach (DataRow row in feaS.DataTable.Rows)
            {
                double vR = Convert.ToDouble(row[fieldR]) ;
                double vL = Convert.ToDouble(row[fieldL]);
                IFeature l = TransfGeometry((Feature)feaS.Features[i], true);

                //IFeature fea = outp.AddFeature(TransfGeometry(TransfGeometry(feaS.Features[i], true).Buffer(v), false));
                LinearRing linR= new LinearRing(BufferBySide(l,vR,"R"));
                LinearRing linL= new LinearRing(BufferBySide(l,vL,"L"));
                IFeature feaR = outp.AddFeature(TransfGeometry(new Feature(new Polygon(linR)), false));
                IFeature feaL = outp.AddFeature(TransfGeometry(new Feature(new Polygon(linL)), false));


                foreach (DataColumn col in feaS.DataTable.Columns)
                {
                    feaR.DataRow[col.ColumnName] = row[col.ColumnName];
                    feaL.DataRow[col.ColumnName] = row[col.ColumnName];
                }
                i++;
            }

            return (FeatureSet)outp;
        
        }



        private Coordinate AzimutDist(Coordinate ptoI, double azi, double dist)
        {

            return new Coordinate(ptoI.X + Math.Sin(azi) * dist , ptoI.Y + Math.Cos(azi) * dist);
        }

        private List<Coordinate> Curv(Coordinate ptoi, double azi, double dis, double parts, string side)
        {

            List<Coordinate> list = new List<Coordinate>();
            double dAz =Math.PI /(2.0*parts);

                if (side == "R")
                {
                    for (int i = 0; i <= parts; i++)
                    {
                        list.Add(new Coordinate(AzimutDist(ptoi, azi + dAz * i, dis)));
                    }
                }
                if (side == "L")
                {
                    for (int i = 0; i <= parts; i++)
                    {
                        list.Add(new Coordinate(AzimutDist(ptoi, azi - dAz * i, dis)));
                    }
                }
            


            

        return list;
    
        }
        
        private double Distance (Coordinate ptoI, Coordinate ptoF)
        {
         return Math.Sqrt(((ptoF.X - ptoI.X) * (ptoF.X - ptoI.X)) + ((ptoF.Y - ptoI.Y)*(ptoF.Y - ptoI.Y)));
        }

        private List<Coordinate> Offset(Coordinate ptoI, Coordinate ptoF, double disB, string side)
        {
            List<Coordinate> list = new List<Coordinate>();
            double azi=GetAzimut(ptoI, ptoF);
            double conAzi=azi+Math.PI;
            double aziS;
            double dis = Distance(ptoI, ptoF);
            if (side == "R")
            {
               aziS= azi + (Math.PI / 2);
               list.Add(new Coordinate(AzimutDist(ptoF, aziS, disB)));
               list.Add(new Coordinate(AzimutDist(ptoF, conAzi, dis)));
            }
            else
            {
              aziS = azi - (Math.PI / 2);
              list.Add(new Coordinate(AzimutDist(ptoF, aziS, disB)));
              list.Add(new Coordinate(AzimutDist(ptoF, conAzi, dis)));
            }
            return list;
           
           
        }

        private double GetAzimut(Coordinate origin, Coordinate target)
        {
            double dx = target.X - origin.X;
            double dy = target.Y - origin.Y;
            if (dx == 0 && dy > 0) return 0;
            if (dx == 0 && dy < 0) return Math.PI;
            if (dx > 0 && dy == 0) return Math.PI / 2;
            if (dx < 0 && dy == 0) return 3 * Math.PI / 2;
            if (dx > 0 && dy > 0) return Math.Atan(dx / dy);
            if (dx > 0 && dy < 0) return Math.PI + Math.Atan(dx / dy);
            if (dx < 0 && dy < 0) return (Math.PI) + Math.Atan(dx / dy);
            if (dx < 0 && dy > 0) return (2 * Math.PI) + Math.Atan(dx / dy);
            return 0;


        }

        private Coordinate[] BufferBySide(IFeature feaS, double buffer, string side)
        {
            
            List<Coordinate> list = new List<Coordinate>();
            Coordinate ini = feaS.Coordinates[0];
            Coordinate end = feaS.Coordinates[1];
            
            list.Add(ini);
            list.Add(end);

            double az= GetAzimut(ini,end);

            foreach(Coordinate c in Curv(end,az,buffer,10,side))
               list.Add(c);
           
            if (side == "R")
                az=az+Math.PI/2.0;
              else
                az=az-Math.PI/2.0;
            
            foreach(Coordinate c in Curv(ini, az ,buffer,10,side))
               list.Add(c);
            

            list.Add(ini);
            return list.ToArray();

        }

        private void cbxLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillFields(cbxLayer.Text);
        }

        private void cbxDissolve_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cbxSideType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkDissolve_CheckedChanged(object sender, EventArgs e)
        {
            cbxDissolve.Visible = true;
        }



    }
}
