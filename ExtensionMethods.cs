using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExtensionMethods;

namespace PracticeProblems {
   class ExtensionMethods {
      static void MainExtension (String[] args) {
         int i = 100;
         Console.WriteLine (i.IsGreateThan (100));
         Console.WriteLine (i.IsGreateThan (50));

         string s = "Naveen";
         Console.WriteLine (s.IsEqualString ("NAVEEN"));
         Console.WriteLine (s.IsEqualString ("Kumar"));
      }
   }
}

namespace ExtensionMethods {
   public static class DemoExtensions {
      public static bool IsGreateThan (this int i, int value) {
         return i > value;
      }

      public static bool IsEqualString (this string str, string compareStr) {
         return str.Equals (compareStr, StringComparison.OrdinalIgnoreCase);
      }
   }
}
