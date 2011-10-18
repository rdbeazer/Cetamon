using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cetecean
{
    public class AreaInterest
    {
        private double minX;
        private double minY;
        private double maxX;
        private double maxY;
        private int numRows = 0;
        private int numColumns = 0;
        private double cellSize=1;
        private double cellSizeX = 1;
        private double cellSizeY = 1;
        private double azimut = 0;
        public AreaInterest()
        {
        }

        public double MinX
        {
            get { return this.minX; }
            set { this.minX = value; }
        }
        public double MinY
        {
            get { return this.minY; }
            set { this.minY = value; }
        }
        public double MaxX
        {
            get { return this.maxX; }
            set { this.maxX = value; }
        }

        public double MaxY
        {
            get { return this.maxY; }
            set { this.maxY = value; }
        }
        public int NumRows
        {
            get { return this.numRows; }
            set { this.numRows = value; }
        }

        public int NumColumns
        {
            get { return this.numColumns; }
            set { this.numColumns = value; }
        }

        public double Azimut
        {
            get { return this.azimut; }
            set { this.azimut = value; }
        }

        public double CellSize
        {
            get
            {
                if (this.cellSizeX != this.cellSizeY)
                {
                    return 0;
                }
                else
                {
                    return this.cellSize;
                }

            }
            set
            {
                this.cellSize = value;
                this.cellSizeX = value;
                this.cellSizeY = value;
            }
        }

        public double CellSizeX
        {
            get { return this.cellSizeX; }
            set { this.cellSizeX = value; }
        }

        public double CellSizeY
        {
            get { return this.cellSizeY; }
            set { this.cellSizeY = value; }
        }

    }
}
