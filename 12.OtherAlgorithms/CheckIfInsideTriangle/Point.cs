using System;

namespace T2.CheckPointVsTriangle
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            string result = string.Format("({0}, {1})", this.X, this.Y, this.Z);
            return result;
        }
    }
}