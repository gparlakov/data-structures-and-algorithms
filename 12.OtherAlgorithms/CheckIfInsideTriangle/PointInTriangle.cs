using System;
using System.Collections.Generic;
using System.Linq;
 
namespace T2.CheckPointVsTriangle
{
    public class PointInTriangle
    {
        static void Main()
        {
            Console.WriteLine("Given 3 points A, B and C, forming triangle, and a point P");
            Console.WriteLine("Check if the point P is in the triangle or not\n");
 
            //  triangle points
            Point a = new Point(-3.45, -2.12, 0);
            Point b = new Point(6.82, 1.9, 0);
            Point c = new Point(3.1, 10.4, 0); 
           
            // Point a = new Point(1, 1, 0);            
            // Point b = new Point(1, 2, 0);
            // Point c = new Point(2, 1, 0); 

            Vector3D va = new Vector3D(a.X,a.Y, 0);
            Vector3D vb = new Vector3D(b.X,b.Y, 0);
            Vector3D vc = new Vector3D(c.X,c.Y, 0);
 
            // points to check
 
            // Point p = new Point(-4.8, 9.2, 0);
            // Vector3D vp = new Vector3D(p.X, p.Y, 0);
 
            Point p = new Point(3.2, 4.82, 0);
            Vector3D vp = new Vector3D(p.X, p.Y, 0);
 
            //Point p = new Point(1.9, 1.9, 0);
            //Vector3D vp = new Vector3D(p.X,p.Y,0);
 
 
            //  check if the point is in the triangle or not
            bool inTriangle = Vector3D.PointTriangle(vp, va, vb, vc);
            Console.Write("Is the point {0} inside the triangle\n\n{1} {2} {3} ? \t", p, a, b, c);
            Console.WriteLine(inTriangle);
            Console.WriteLine();
        }
    }
}
 

 
