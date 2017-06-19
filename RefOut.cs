using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems {
   class RefOut {
      static void MainRef (String[] args) {
         int refVar = 5;
         int outVar;

         // Test REF keyword, must be initialized before
         Console.WriteLine ("before ref: " + refVar);
         squareRef (ref refVar);
         Console.WriteLine ("after ref: " + refVar);

         // Test OUT keyword, not need to be initiazed before
         //Console.WriteLine ("before out: " + outVar);
         squareOut (5, out outVar);
         Console.WriteLine ("after out: " + outVar);

         // Test Combined ref and out, Will show compile error
         //squareCombined (10, ref outVar);
         //Console.WriteLine ("after out: " + outVar);


      }

      static void squareRef (ref int x) {
         x = x * x;
      }

      static int squareOut (int x, out int y) {
         y = x * x;
         return y;
      }

      static int squareCombined (int x, out int y) {
         y = x * x;
         return y;
      }
   }
}
