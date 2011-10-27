using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using  DotSpatial.Data;
using DotSpatial.Topology;
using DotSpatial.Projections;
namespace Cetecean
{
    public static class Validator
    {

        private static string title = "Entry Error";

        public static string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public static bool IsPresent(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(textBox.Tag + " is a required field.", Title);
                textBox.Focus();
                return false;
            }
            return true;
        }

        public static string GetNameFile(string file)
        {
            char[] v = file.ToCharArray();
            for (int i = v.Length - 1; i > 0; i--)
            {
                if (v[i] == '/' || v[i] == '\\')
                {
                    return file.Substring(i + 1, file.Length - i - 5);
                }
            }
            return "default";
        }

        public static bool IsDecimal(TextBox textBox)
        {
            try
            {
                Convert.ToDecimal(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag + " must be a decimal number.", Title);
                textBox.Focus();
                return false;
            }
        }

        public static bool IsDouble(TextBox textBox)
        {
            try
            {
                Convert.ToDouble(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag + " must be a double number.", Title);
                textBox.Focus();
                return false;
            }
        }

        public static bool IsDoublePositive(TextBox textBox)
        {
            try
            {
                if (Convert.ToDouble(textBox.Text) > 0)
                    return true;
                else
                {
                    MessageBox.Show(textBox.Tag + " must be > 0", Title);
                    textBox.Focus();
                    return false;

                }
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag + " must be a double number.", Title);
                textBox.Focus();
                return false;
            }
        }

        public static bool SaveShapefile(string name, FeatureSet feaS)
        {

            DialogResult result = MessageBox.Show("Do you want to save " + name + " as shapefile?", "Save option", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Shapefile files (*.shp)|*.shp";
                dialog.InitialDirectory = @"C:\";
                dialog.Title = "Save shapefile";
                string strFileName = "";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    strFileName = dialog.FileName;
                    feaS.SaveAs(@strFileName, true);
                    return true;
                }



            }
            return false;

        }

        public static bool IsInt32(TextBox textBox)
        {
            try
            {
                Convert.ToInt32(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag + " must be an integer.", Title);
                textBox.Focus();
                return false;
            }
        }

        public static bool IsWithinRange(TextBox textBox, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(textBox.Tag + " must be between " + min
                    + " and " + max + ".", Title);
                textBox.Focus();
                return false;
            }
            return true;
        }


        public Coordinate TranslateTo(Coordinate point, double bearing, double distance)
        {
            #region info
            // Taken from: http://www.koders.com/java/fid72A4E7D3DA8195D118CF926431263DDB8C45C5A1.aspx
            /*
             * Vincenty's Inverse Algorythm.
             *
             * notice: MATLAB had no formula which took the ellipsoid into accout -- only a
             * formula which used Earth's average radius.  This is why the formulae have
             * two separate sources.  -- Jon
             *
             *
             *
             * // Flattening
                    f  = (semiMajorAxis-semiMinorAxis) / semiMajorAxis;
             *
             * // 1 - flattening
                    fo = 1.0 - f;
             *
             * // Flattening squared
                    f2 = f*f;
             * // Flattening cubed
                    f3 = f*f2;
             * // Flattening ^ 4
                    f4 = f*f3;
                    eccentricitySquared = f * (2.0-f);

             *          * Solution of the geodetic direct problem after T.Vincenty.
                     * Modified Rainsford's method with Helmert's elliptical terms.
                     * Effective in any azimuth and at any distance short of antipodal.
                     *
                     * Latitudes and longitudes in radians positive North and East.
                     * Forward azimuths at both points returned in radians from North.
                     *
                     * Programmed for CDC-6600 by LCDR L.Pfeifer NGS ROCKVILLE MD 18FEB75
                     * Modified for IBM SYSTEM 360 by John G.Gergen NGS ROCKVILLE MD 7507
                     * Ported from Fortran to Java by Daniele Franzoni.
                     *
                     * Source: ftp://ftp.ngs.noaa.gov/pub/pcsoft/for_inv.3d/source/forward.for
                     *         subroutine DIRECT1
            // Protect internal variables from changes
                    final double lat1     = this.lat1;
                    final double long1    = this.long1;
                    final double azimuth  = this.azimuth;
                    final double distance = this.distance;
                    double TU  = fo*Math.sin(lat1) / Math.cos(lat1);
                    double SF  = Math.sin(azimuth);
                    double CF  = Math.cos(azimuth);
                    double BAZ = (CF!=0) ? Math.atan2(TU, CF)*2.0 : 0;
                    double CU  = 1/Math.sqrt(TU*TU + 1.0);
                    double SU  = TU*CU;
                    double SA  = CU*SF;
                    double C2A = 1.0 - SA*SA;
                    double X   = Math.sqrt((1.0/fo/fo-1)*C2A+1.0) + 1.0;
                    X   = (X-2.0)/X;
                    double C   = 1.0-X;
                    C   = (X*X/4.0+1.0)/C;
                    double D   = (0.375*X*X-1.0)*X;
                    TU   = distance / fo / semiMajorAxis / C;
                    double Y   = TU;
                    double SY, CY, CZ, E;
                    do {
                        SY = Math.sin(Y);
                        CY = Math.cos(Y);
                        CZ = Math.cos(BAZ+Y);
                        E  = CZ*CZ*2.0-1.0;
                        C  = Y;
                        X  = E*CY;
                        Y  = E+E-1.0;
                        Y  = (((SY*SY*4.0-3.0)*Y*CZ*D/6.0+X)*D/4.0-CZ)*SY*D+TU;
                    } while (Math.abs(Y-C) > TOLERANCE_1);
                    BAZ  = CU*CY*CF - SU*SY;
                    C    = fo*Math.sqrt(SA*SA+BAZ*BAZ);
                    D    = SU*CY + CU*SY*CF;
                    lat2 = Math.atan2(D, C);
                    C    = CU*CY-SU*SY*CF;
                    X    = Math.atan2(SY*SF, C);
                    C    = ((-3.0*C2A+4.0)*f+4.0)*C2A*f/16.0;
                    D    = ((E*CY*C+CZ)*SY*C+Y)*SA;
                    long2 = long1+X - (1.0-C)*D*f;
                    long2 = castToAngleRange(long2);
                    destinationValid = true;

             */
            #endregion

            //ProjectionInfo p = KnownCoordinateSystems.Geographic.World.WGS1984;
            //Proj4Datum pd = Proj4Datum.WGS84;
            Proj4Ellipsoid pe = Proj4Ellipsoid.WGS_1984;
            Spheroid s = new Spheroid(pe);
            double TARGET_ACCURACY = 1.0E-12;
            double f = s.FlatteningFactor(); //ellipsoid.Flattening; 
            double fo = 1.0 - f;
            double semiMajorAxis = s.EquatorialRadius;// ellipsoid.SemiMajorAxisMeters;

            //final double lat1     = this.lat1;
            double lat1 = point.Y * Math.PI / 180.0;

            //final double long1    = this.long1;
            double long1 = point.X * Math.PI / 180.0;

            //final double azimuth  = this.azimuth;
            double azimuth = bearing / 180.0 * Math.PI;

            //final double distance = this.distance;
            double dist = distance;

            //double TU  = fo*Math.sin(lat1) / Math.cos(lat1);
            double tu = fo * Math.Sin(lat1) / Math.Cos(lat1);

            //double SF  = Math.sin(azimuth);
            double sf = Math.Sin(azimuth);

            //double CF  = Math.cos(azimuth);
            double cf = Math.Cos(azimuth);

            //double BAZ = (CF!=0) ? Math.atan2(TU, CF)*2.0 : 0;
            double baz = (cf != 0) ? Math.Atan2(tu, cf) * 2.0 : 0;

            //double CU  = 1/Math.sqrt(TU*TU + 1.0);
            double cu = 1.0 / Math.Sqrt(tu * tu + 1.0);

            //double SU  = TU*CU;
            double su = tu * cu;

            //double SA  = CU*SF;
            double sa = cu * sf;

            //double C2A = 1.0 - SA*SA;
            double c2A = 1.0 - sa * sa;

            //double X   = Math.sqrt((1.0/fo/fo-1)*C2A+1.0) + 1.0;
            double x = Math.Sqrt((1.0 / fo / fo - 1) * c2A + 1.0) + 1.0;

            //X   = (X-2.0)/X;
            x = (x - 2.0) / x;

            //double C   = 1.0-X;
            double c = 1.0 - x;

            //C   = (X*X/4.0+1.0)/C;
            c = (x * x / 4.0 + 1.0) / c;

            //double D   = (0.375*X*X-1.0)*X;
            double d = (0.375 * x * x - 1.0) * x;

            //TU   = distance / fo / semiMajorAxis / C;
            tu = dist / fo / semiMajorAxis / c;

            //double Y   = TU;
            double y = tu;

            //double SY, CY, CZ, E;
            double sy, cy, cz, e;
            int iterations = 0;

            //do {
            do
            {
                //    SY = Math.sin(Y);
                sy = Math.Sin(y);
                //    CY = Math.cos(Y);
                cy = Math.Cos(y);
                //    CZ = Math.cos(BAZ+Y);
                cz = Math.Cos(baz + y);
                //    E  = CZ*CZ*2.0-1.0;
                e = cz * cz * 2.0 - 1.0;
                //    C  = Y;
                c = y;
                //    X  = E*CY;
                x = e * cy;
                //    Y  = E+E-1.0;
                y = e + e - 1.0;
                //    Y  = (((SY*SY*4.0-3.0)*Y*CZ*D/6.0+X)*D/4.0-CZ)*SY*D+TU;
                y = (((sy * sy * 4.0 - 3.0) * y * cz * d / 6.0 + x) * d / 4.0 - cz) * sy * d + tu;
                //} while (Math.abs(Y-C) > TOLERANCE_1);
                iterations++;
            } while (iterations < 30 && Math.Abs(y - c) > TARGET_ACCURACY);

            //BAZ  = CU*CY*CF - SU*SY;
            baz = cu * cy * cf - su * sy;

            //C    = fo*Math.sqrt(SA*SA+BAZ*BAZ);
            c = fo * Math.Sqrt(sa * sa + baz * baz);

            //D    = SU*CY + CU*SY*CF;
            d = su * cy + cu * sy * cf;

            //lat2 = Math.atan2(D, C);
            double lat2 = Math.Atan2(d, c);

            //C    = CU*CY-SU*SY*CF;
            c = cu * cy - su * sy * cf;

            //X    = Math.atan2(SY*SF, C);
            x = Math.Atan2(sy * sf, c);

            //C    = ((-3.0*C2A+4.0)*f+4.0)*C2A*f/16.0;
            c = ((-3.0 * c2A + 4.0) * f + 4.0) * c2A * f / 16.0;

            //D    = ((E*CY*C+CZ)*SY*C+Y)*SA;
            d = ((e * cy * c + cz) * sy * c + y) * sa;

            //long2 = long1+X - (1.0-C)*D*f;
            double long2 = long1 + x - (1.0 - c) * d * f;

            //long2 = castToAngleRange(long2);
            long2 = long2 - (2 * Math.PI) * Math.Floor(long2 / (2 * Math.PI) + 0.5);

            //destinationValid = true;

            // Return a new position, rounded to 10 digits of accuracy

            return new Coordinate(long2 * 180.0 / Math.PI, lat2 * 180.0 / Math.PI);
        }

    }
}