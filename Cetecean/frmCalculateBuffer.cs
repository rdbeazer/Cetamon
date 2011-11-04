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
//using DotSpatial.Positioning;
namespace Cetecean
{
    public partial class frmCalculateBuffer : Form
    {
        //Global variable
        Map _map = null;
        GeoCal _geo = null;

        public frmCalculateBuffer()
        {
            InitializeComponent();
        }

        public frmCalculateBuffer(Map map)
        {
            //set the current map
            _map = map;
            InitializeComponent();
        }

        private void rbtBuffer_CheckedChanged(object sender, EventArgs e)
        {

            //Disable some times when the buffer radiobutton is selected
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
            //Disable some times when it is selected one field
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
            //Disable some times when it is are selected two field.. 
            // In this option the user has to select two field with the width of each side
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
            ///Load the current line layer in the form
            GetLayers();
            //Update the combox SideType
            cbxSideType.Items.Add("Full");
            cbxSideType.Items.Add("Left");
            cbxSideType.Items.Add("Right");
            cbxSideType.SelectedIndex = 0;

        }

        /// <summary>
        /// Get the layers
        /// </summary>
        private void GetLayers()
        {
            //Verify the number of layers
            if (_map.Layers.Count > 0)
            {
                foreach (IMapLayer iLa in _map.Layers)
                {
                    FeatureSet fT = (FeatureSet)iLa.DataSet;
                    //It is added only the line layers
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
            // clear the comboBox
            cbxField1.Items.Clear();
            cbxField2.Items.Clear();
            cbxDissolve.Items.Clear();

            //it is obtained the featureset of the layer selected
            IFeatureSet fT = null;
            foreach (IMapLayer iLa in _map.Layers)
            {
                fT = (IFeatureSet)iLa.DataSet;
                if (fT.Name == layer)
                    break;
            }


            if (fT == null) return;


            foreach (DataColumn col in fT.DataTable.Columns)
            {
                //In the cbxField1 and cbxField2 are added the fields with type numeric
                if (col.DataType == typeof(double) || col.DataType == typeof(int))
                {
                    cbxField1.Items.Add(col.ColumnName);
                    cbxField2.Items.Add(col.ColumnName);
                }
                //In the cbxField1 and cbxField2 are added the fields with type integer and alphanumeric
                if (col.DataType == typeof(int) || col.DataType == typeof(string))
                    cbxDissolve.Items.Add(col.ColumnName);
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _geo=new GeoCal(_map.Projection);


            //Initialization of two featureSet
            // fT => it will have the information of the current line layer
            FeatureSet fT = null;
            // outp => it will have the information of the polygon layer generated
            FeatureSet outp = null;

            //it is obtained the current line layer
            foreach (IMapLayer iLa in _map.Layers)
            {
                fT = (FeatureSet)iLa.DataSet;
                if (fT.Name == cbxLayer.Text)
                    break;
            }

            //This option calculates the buffer using only the information of distance
            if (rbtBuffer.Checked)
            {
                //Verify the values introduced by the user
                if (Validator.IsPresent(txtBuffer) && Validator.IsDoublePositive(txtBuffer))
                {
                    //outp will get the featureset 
                    //the function CalculateBuffer takes into account the side (Full=> both sides, left, right)
                    outp = (FeatureSet)CalculateBuffer(fT, Convert.ToDouble(txtBuffer.Text), cbxSideType.Text);
                }
            }


            //This option calculates the buffer using only the information of a field selected
            if (rbtOne.Checked)
            {
                // if there is not any field selected
                if (cbxField1.Text == "")
                {
                    MessageBox.Show("Please select a field");
                    return;
                }
                //outp will get the featureset 
                //the function CalculateBuffer takes into account the side (Full=> both sides, left, right)
                outp = CalculateBuffer(fT, cbxField1.Text, cbxSideType.Text);
            }

            if (rbtTwo.Checked)
            {
                if (cbxField1.Text == "" || cbxField2.Text == "")
                {
                    MessageBox.Show("Please select a field");
                    return;
                }

                //outp will get the featureset 
                //the function CalculateBuffer takes into account the side the field1 and field2
                //this function will generate two polygos per each line.
                outp = CalculateBuffer(fT, cbxField1, cbxField2);

            }

            if (chkDissolve.Checked)
            {
                if (cbxDissolve.Text == "")
                {
                    MessageBox.Show("Please select a field");
                    return;
                }

                // If the user wants to dissolve the polygon, the outp will be overwritten with the dissolved polygons
                outp = (FeatureSet)outp.Dissolve(cbxDissolve.Text);
            }

            //Save the output
            Validator.SaveShapefile("Buffer", outp);
            IMapPolygonLayer Ipo = new MapPolygonLayer(outp);
            Ipo.LegendText = "Buffer";
            Ipo.Symbolizer.SetFillColor(Color.Green);
            //it is added in the map
            _map.Layers.Add(Ipo);
            fT = null;
            Close();
        }


        private FeatureSet CalculateBuffer(FeatureSet feaS, string field, string side)
        {
            //temporal outp
            FeatureSet outp = new FeatureSet();
            outp.FeatureType = FeatureType.Polygon;

            // it is assigned the current projection in the map
            outp.Projection = _map.Projection;

            //The columns of the line layer are introduced in the buffer layer
            foreach (DataColumn col in feaS.DataTable.Columns)
            {
                outp.DataTable.Columns.Add(new DataColumn(col.ColumnName, col.DataType));
            }

            // getting all features of the line layer
            int i = 0;
            foreach (DataRow row in feaS.DataTable.Rows)
            {
                //it is used the field selected to get the buffer distance
                double v = Convert.ToDouble(row[field]);

                IFeature fea1;
                IFeature fea;

                if (side == "Full")
                {
                    //The features are transformed in a projected coordinate system
                    fea1 = (TransfGeometry(feaS.Features[i], true));
                    // Calculation of the buffer
                    fea1 = fea1.Buffer(v);
                    //The features are transformed  again to original coordinate system
                    fea = outp.AddFeature((TransfGeometry(fea1, false)));
                }
                else if (side == "Left")
                {
                    //The features are transformed in a projected coordinate system
                    IFeature l = TransfGeometry((Feature)feaS.Features[i], true);
                    //It is calculated the polygon of the left side 
                    LinearRing linL = new LinearRing(BufferBySide(l, v, "L"));
                    //The features are transformed  again to original coordinate system
                    fea = outp.AddFeature(TransfGeometry(new Feature(new Polygon(linL)), false));
                }
                else
                {
                    //The features are transformed in a projected coordinate system
                    IFeature l = TransfGeometry((Feature)feaS.Features[i], true);
                    //It is calculated the polygon of the left side 
                    LinearRing linL = new LinearRing(BufferBySide(l, v, "R"));
                    //The features are transformed  again to original coordinate system
                    fea = outp.AddFeature(TransfGeometry(new Feature(new Polygon(linL)), false));

                }


                // The information is added in the buffer layer
                foreach (DataColumn col in feaS.DataTable.Columns)
                {
                    fea.DataRow[col.ColumnName] = row[col.ColumnName];
                }
                i++;
            }

            feaS.Projection = _map.Projection;
            return outp;

        }

        /// <summary>
        /// This function repeat the procedure of previous function,
        /// but, it uses the buffer value for all features in the line layer
        /// </summary>
        /// <param name="feaS"></param>
        /// <param name="buffer"></param>
        /// <param name="side"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Transform the coordinates of a Feature  to projected coordinated
        /// </summary>
        /// <param name="C"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        private IFeature TransfGeometry(IFeature C, bool t)
        {
            //If the current projection is different of WGS84 the transformation is not executed
            //if (_map.Projection != KnownCoordinateSystems.Geographic.World.WGS1984)
            //{
            //    return C;
            //}
            return C;


            IFeature B = (IFeature)C.Clone();


            //Generate an array with all coordinates
            double[] xy = new double[B.Coordinates.Count * 2];
            double[] z = new double[B.Coordinates.Count * 2];
            //Filling the array
            for (int i = 0; i < B.Coordinates.Count; i++)
            {
                xy[2 * i] = B.Coordinates[i].X;
                xy[2 * i + 1] = B.Coordinates[i].Y;
            }

            //Executing the transformantion true=> WGS84 to WebMercator  false=> WebMercator to WGS84
            if (t)
                DotSpatial.Projections.Reproject.ReprojectPoints(xy, z, _map.Projection,
                    KnownCoordinateSystems.Projected.World.WebMercator, 0, B.Coordinates.Count);
            else
                DotSpatial.Projections.Reproject.ReprojectPoints(xy, z, KnownCoordinateSystems.Projected.World.WebMercator,
                  _map.Projection, 0, B.Coordinates.Count);

            Coordinate[] c1 = new Coordinate[B.Coordinates.Count];

            for (int i = 0; i < B.Coordinates.Count; i++)
            {
                c1[i] = new Coordinate(xy[2 * i], xy[2 * i + 1]);
            }

            //Assigning the new coordinates.
            B.Coordinates = c1;
            return B;
        }

        /// <summary>
        /// Calculate the buffer of both sides taking into account the field 1 and field 2
        /// </summary>
        /// <param name="feaS"></param>
        /// <param name="cfieldR"></param>
        /// <param name="cfieldL"></param>
        /// <returns></returns>
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
                double vR = Convert.ToDouble(row[fieldR]);
                double vL = Convert.ToDouble(row[fieldL]);
                IFeature l = TransfGeometry((Feature)feaS.Features[i], true);

                //Calculating the buffer of both sides
                LinearRing linR = new LinearRing(BufferBySide(l, vR, "R"));
                LinearRing linL = new LinearRing(BufferBySide(l, vL, "L"));
                IFeature feaR = outp.AddFeature(TransfGeometry(new Feature(new Polygon(linR)), false));
                IFeature feaL = outp.AddFeature(TransfGeometry(new Feature(new Polygon(linL)), false));

                //Copying the data of each column
                //One line will generate two features. Right and Left
                foreach (DataColumn col in feaS.DataTable.Columns)
                {
                    feaR.DataRow[col.ColumnName] = row[col.ColumnName];
                    feaL.DataRow[col.ColumnName] = row[col.ColumnName];
                }
                i++;
            }

            return (FeatureSet)outp;

        }


        /// <summary>
        /// Calculate the cooridnate of a point when it is obtained from of translation
        /// </summary>
        /// <param name="ptoI">point initial</param>
        /// <param name="azi">Azimuth</param>
        /// <param name="dist">distance</param>
        /// <returns></returns>
        //private Coordinate AzimutDist(Coordinate ptoI, double azi, double dist)
        //{
        //    //generate a new point
        //    return new Coordinate(ptoI.X + Math.Sin(azi) * dist, ptoI.Y + Math.Cos(azi) * dist);
        //}

        private List<Coordinate> Curv(Coordinate ptoi, double azi, double dis, double parts, string side)
        {

            List<Coordinate> list = new List<Coordinate>();
            double dAz = Math.PI / (2.0 * parts);

            if (side == "R")
            {
                for (int i = 0; i <= parts; i++)
                {
                    list.Add(new Coordinate(_geo.AzimuthDist(ptoi, azi + dAz * i, dis)));
                }
            }
            if (side == "L")
            {
                for (int i = 0; i <= parts; i++)
                {
                    list.Add(new Coordinate(_geo.AzimuthDist(ptoi, azi - dAz * i, dis)));
                }
            }





            return list;

        }

        //private double Distance(Coordinate ptoI, Coordinate ptoF)
        //{
        //    return Math.Sqrt(((ptoF.X - ptoI.X) * (ptoF.X - ptoI.X)) + ((ptoF.Y - ptoI.Y) * (ptoF.Y - ptoI.Y)));
        //}

        /// <summary>
        /// Generate the offset line according with the direction and the side selected
        /// </summary>
        /// <param name="ptoI"> initial Point of the line</param>
        /// <param name="ptoF">End point of the line</param>
        /// <param name="disB">Buffer</param>
        /// <param name="side">Side to be created the curve</param>
        /// <returns></returns>
        private List<Coordinate> Offset(Coordinate ptoI, Coordinate ptoF, double disB, string side)
        {
            List<Coordinate> list = new List<Coordinate>();
            double azi = _geo.GetAzimuth(ptoI, ptoF);
            double conAzi = azi + Math.PI;
            double aziS;
            double dis = _geo.Distance(ptoI, ptoF);
            if (side == "R")
            {
                aziS = azi + (Math.PI / 2);
                list.Add(new Coordinate(_geo.AzimuthDist(ptoF, aziS, disB)));
                list.Add(new Coordinate(_geo.AzimuthDist(ptoF, conAzi, dis)));
            }
            else
            {
                aziS = azi - (Math.PI / 2);
                list.Add(new Coordinate(_geo.AzimuthDist(ptoF, aziS, disB)));
                list.Add(new Coordinate(_geo.AzimuthDist(ptoF, conAzi, dis)));
            }
            return list;


        }

        /// <summary>
        /// Calculate the Azimuth
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        //private double GetAzimut(Coordinate origin, Coordinate target)
        //{
        //    double dx = target.X - origin.X;
        //    double dy = target.Y - origin.Y;
        //    if (dx == 0 && dy > 0) return 0;
        //    if (dx == 0 && dy < 0) return Math.PI;
        //    if (dx > 0 && dy == 0) return Math.PI / 2;
        //    if (dx < 0 && dy == 0) return 3 * Math.PI / 2;
        //    if (dx > 0 && dy > 0) return Math.Atan(dx / dy);
        //    if (dx > 0 && dy < 0) return Math.PI + Math.Atan(dx / dy);
        //    if (dx < 0 && dy < 0) return (Math.PI) + Math.Atan(dx / dy);
        //    if (dx < 0 && dy > 0) return (2 * Math.PI) + Math.Atan(dx / dy);
        //    return 0;

        //}

        /// <summary>
        /// Generate the list of point of a buffer according with the side
        /// </summary>
        /// <param name="feaS"></param>
        /// <param name="buffer"></param>
        /// <param name="side"></param>
        /// <returns></returns>
        private Coordinate[] BufferBySide(IFeature feaS, double buffer, string side)
        {
            //Get the initial point and the end point of a line
            List<Coordinate> list = new List<Coordinate>();
            Coordinate ini = feaS.Coordinates[0];
            Coordinate end = feaS.Coordinates[1];

            //add both points
            list.Add(ini);
            list.Add(end);
            //get azimuth
            double az = _geo.GetAzimuth(ini, end);

            //Calculate the point in the initial curve of the buffer.. 
            // the number of point using to create the curve is 10..
            // the points are added in the list of points
            foreach (Coordinate c in Curv(end, az, buffer, 10, side))
                list.Add(c);

            //the second curve should start according with the side selected
            if (side == "R")
                az = az + Math.PI / 2.0;
            else
                az = az - Math.PI / 2.0;

            //calculation of the second curve
            //Add valued in the list
            foreach (Coordinate c in Curv(ini, az, buffer, 10, side))
                list.Add(c);

            //the first point should be the same that the last point
            list.Add(ini);

            //covert the list in an array
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
