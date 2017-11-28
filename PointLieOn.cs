using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PracticeProblems;

namespace PracticeProblems {
   class PointLieOn {
      static void Main (String[] args) {
         Point3 a = new Point3 ();
         a.X = 0.1;
         a.Y = 0.2;
         a.Z = 0.3;


      }

      /// <summary>Returns the _lie_ of this Point3 on the line a-b</summary>
      /// The _lie_ of a point on a finite line a-b is the normalized position of that point along
      /// the line joining a-b. If the point is at a, then its lie is 0. If the point is at b, then
      /// the lie is 1. If the point is exactly at the midpoint, the lie is 0.5 etc. Lies below 0
      /// or above 1 are possible; this just means the point lies _before_ a, or _beyond_ b.
      ///
      /// This point must be on that line; if not use ClosestPointOnLine to snap it to
      /// the line. If the given point pt is not on the line a-b, the results are unpredictable.
      /// If the points a and b are the same, this returns 0.
      /// <param name="a">The start point of the reference line</param>
      /// <param name="b">End point of the reference line</param>
      /// <returns>The lie of that point (0 means at a, 1 means at b etc)</returns>
      public double LieOn (Point3 a, Point3 b) {
         int n = 0;
         double dx = b.X - a.X, dy = b.Y - a.Y, dz = b.Z - a.Z;
         double adx = Math.Abs (dx), ady = Math.Abs (dy), adz = Math.Abs (dz);
         if (ady > adx && ady > adz) n = 1;
         if (adz > adx && adz > ady) n = 2;
         switch (n) {
            case 0: return (X - a.X) / dx;
            case 1: return (Y - a.Y) / dy;
            default: return (Z - a.Z) / dz;
         }
      }
   }

   public class Point3 {
      public double X;
      public double Y;
      public double Z;

      public Point3 () {
         this.X = 0.0;
         this.Y = 0.0;
         this.Z = 0.0;
      }
   }
}
