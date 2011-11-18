using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotSpatial.Projections;
using DotSpatial.Topology;

namespace Cetecean
{
    public class GeoCal
    {
        ProjectionInfo _proj;
        public GeoCal(ProjectionInfo proj)
        {
            _proj = proj;
        
        }

        ProjectionInfo Proj 
        {
            get { return this._proj; } 
            set{ _proj=value;}
        }

        public double toRad(double v)
        {
            return v * _proj.GeographicInfo.Unit.Radians;

        }

        public double toDeg(double v)
        {
            return v / _proj.GeographicInfo.Unit.Radians;

        }

        public double Cos_deg(double v) { 
            return  Math.Cos(this.toRad(v));
        }

        public double Sin_deg(double v)
        {
            return Math.Sin(this.toRad(v));
        } 


       

        public double GetAzimuth(Coordinate origin, Coordinate target) 
        {
            if (_proj.Transform.Proj4Name == "longlat" || (origin.X > 180.0 && origin.X < 180.0) || (origin.Y < 90 && origin.X > 90))
            {

                double dlon = toRad(target.X - origin.X);
                double dlat = toRad(target.Y - origin.Y);

                double y=Math.Sin(dlon) * Cos_deg(target.Y);
                double x=Cos_deg(origin.Y) *Sin_deg(target.Y) - Sin_deg(origin.Y) * Cos_deg(target.Y)*Math.Cos(dlon);
                return toRad((toDeg(Math.Atan2(y, x)) + 360.0) % 360.0);
            }
            else
            {
            double dx = target.X - origin.X;
            double dy = target.Y - origin.Y;
            if (dx == 0 && dy > 0) return 0;
            if (dx == 0 && dy < 0) return (Math.PI);
            if (dx > 0 && dy == 0) return (Math.PI / 2);
            if (dx < 0 && dy == 0) return (3 * Math.PI / 2);
            if (dx > 0 && dy > 0) return (Math.Atan(dx / dy));
            if (dx > 0 && dy < 0) return (Math.PI + Math.Atan(dx / dy));
            if (dx < 0 && dy < 0) return ((Math.PI) + Math.Atan(dx / dy));
            if (dx < 0 && dy > 0) return ((2 * Math.PI) + Math.Atan(dx / dy));
            return 0;
            }

        }

        public double Distance(Coordinate pto1, Coordinate pto2)
        {
            if (_proj.Transform.Proj4Name == "longlat" || (pto1.X > 180.0 && pto1.X < 180.0) || (pto1.Y < 90 && pto1.X > 90))
            {
                  double r=_proj.GeographicInfo.Datum.Spheroid.EquatorialRadius;
                  double dlon = toRad(pto2.X - pto1.X);
                  double dlat = toRad(pto2.Y - pto1.Y);

                 return  Math.Acos(Sin_deg(pto1.Y) * Sin_deg(pto2.Y) +
                    Cos_deg(pto1.Y) * Cos_deg(pto2.Y) *
                    Math.Cos(dlon)) * r ;
            }
            else
            {
                return Math.Sqrt(((pto2.X - pto1.X) * (pto2.X - pto1.X)) + ((pto2.Y - pto1.Y) * (pto2.Y - pto1.Y)));
            
            }

        
        
        }


        public  Coordinate AzimuthDist(Coordinate ptoI, double azi, double dist) 
        {
            if (_proj.Transform.Proj4Name == "longlat" || (ptoI.X > 180.0 && ptoI.X < 180.0) || (ptoI.Y < 90 && ptoI.X > 90))
            {
             double r=_proj.GeographicInfo.Datum.Spheroid.EquatorialRadius;

             double lat2= Math.Asin(Sin_deg(ptoI.Y)*Math.Cos(dist/r) +   Cos_deg(ptoI.Y)*Math.Sin(dist/r)*Math.Cos(azi));
             double lon2 = toRad(ptoI.X) + Math.Atan2(Math.Sin(azi)*Math.Sin(dist/r)*Cos_deg(ptoI.Y), Math.Cos(dist/r) - (Sin_deg(ptoI.Y) * Math.Sin(lat2)));
             
             return new Coordinate(toDeg(lon2),toDeg(lat2));
 	        
         }
         else
         {
             return new Coordinate(ptoI.X + Math.Sin(azi) * dist, ptoI.Y + Math.Cos(azi) * dist);
         }
        
        }
    }
}
