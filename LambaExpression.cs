using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;

// http://www.tutorialsteacher.com/linq/linq-lambda-expression
// https://www.codeproject.com/Tips/298963/Understand-Lambda-Expressions-in-minutes

namespace PracticeProblems {
   class LambaExpression {

      static void MainLambdaExpression (String[] args) {
         List<int> numbers = new List<int> () { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
         List<int> evenNumbers = numbers.Where (n => n % 2 == 0).ToList ();

         IEnumerator<int> e = evenNumbers.GetEnumerator ();
         while (e.MoveNext ()) {
            Console.WriteLine (e.Current);
         }

         int i = numbers.Count (n => n % 2 == 0);
         Console.WriteLine ("Count: " + i);

         Console.WriteLine (numbers.Find (delegate (int s) { return s.Equals (5); }));
         Console.WriteLine (numbers.Find ((s) => s.Equals (5) ));
         
      }

   }
}
