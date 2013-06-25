using System;
 
namespace T2.CheckPointVsTriangle
{
    class Vector3D
    {
        private double x;
        private double y;
        private double z;
 
        public double X
        {
            get
            {
                return this.x;
            }
        }
 
        public double Y
        {
            get
            {
                return this.y;
            }
        }
 
        public double Z
        {
            get
            {
                return this.z;
            }
        }
 
        public double Length
        {
            get
            {
                double result = Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);
                return result;
            }
        }
 
        public Vector3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
 
        public static Vector3D operator +(Vector3D first, Vector3D second)
        {
            double resultX = first.X + second.X;
            double resultY = first.Y + second.Y;
            double resultZ = first.Z + second.Z;
            Vector3D result = new Vector3D(resultX, resultY, resultZ);
 
            return result;
        }
 
        public static Vector3D operator -(Vector3D first, Vector3D second)
        {
            double resultX = first.X - second.X;
            double resultY = first.Y - second.Y;
            double resultZ = first.Z - second.Z;
            Vector3D result = new Vector3D(resultX, resultY, resultZ);
 
            return result;
        }
 
        public static double DotProduct(Vector3D first, Vector3D second)
        {
            double result = first.X * second.X + first.Y * second.Y + first.Z * second.Z;
 
            return result;
        }
 
        public static Vector3D CrossProduct(Vector3D first, Vector3D second)
        {
            double resultX = first.Y * second.Z - first.Z * second.Y;
            double resultY = first.Z * second.X - first.X * second.Z;
            double resultZ = first.X * second.Y - first.Y * second.X;
            Vector3D result = new Vector3D(resultX, resultY, resultZ);
 
            return result;
        }
 
        public static bool SameSide(Vector3D p, Vector3D v1, Vector3D v2, Vector3D v3)
        {
            Vector3D cp1 = CrossProduct(v2-v1, p-v1);
            Vector3D cp2 = CrossProduct(v2-v1, v3-v1);
            bool result=DotProduct(cp1, cp2) >= 0;
 
            return result;
        }
 
        public static bool PointTriangle(Vector3D p, Vector3D a, Vector3D b, Vector3D c)
        {
            bool result= SameSide(p, a, b, c) && SameSide(p, b, c, a) && SameSide(p, c, a, b);
            return result;
        }
 
        public override string ToString()
        {
            string result = string.Format("({0}, {1}, {2})", this.X, this.Y, this.Z);
            return result;
        }
    }
}