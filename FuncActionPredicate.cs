using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Points to Remember : Func
//Func is built-in delegate type.
//Func delegate type must return a value.
//Func delegate type can have zero to 16 input parameters.
//Func delegate type can be used with an anonymous method or lambda expression.
//Next » « Previous


//Points to Remember : Action
//Action delegate is same as func delegate except that it does not return anything. Return type must be void.
//Action delegate can have 1 to 16 input parameters.
//Action delegate can be used with anonymous methods or lambda expressions.

namespace PracticeProblems {
   class FuncActionPredicate {
      static void MainFunc (string[] args) {

         //--------------------------------Func------------------------------------
         Func<int, int, int> f = Sum; 
         Console.WriteLine("Sum = " + f(10, 20));
         Random r = new Random ();

         // Anonymous method
         Func<int> getRandomNumber = delegate () {
            return r.Next (1, 100);
         };
         Console.WriteLine ("Random value = " + getRandomNumber ());

         // Lambda function
         Func<int> getRandNumber = () => r.Next(1, 100);
         Console.WriteLine (getRandNumber ());

         // ---------------------------------Action------------------------------
         // Put Random class object outside and use same object to generate different number each time.
         // If you create new object each time, you will get the same output.
         Action<int> printDel = Print;
         // or
         // Action<int> printDel = new Action<int>(Print);
         printDel (100);

         // Anonymous method
         Action<int> printDel2 = delegate (int x) {
            Console.WriteLine (x);
         };
         printDel2 (200);

         // Lambda function
         Action<int> printDel3 = (i) => Console.WriteLine (i);
         printDel3 (300);

         //--------------------------------Predicate---------------------------
         Predicate<string> predictUpper = IsUpperCase;
         Console.WriteLine (predictUpper ("Naveen"));
         Console.WriteLine (predictUpper ("NAVEEN"));

         // Anonymous method
         Predicate<string> predicateUpper2 = delegate (string s) {
            return s.Equals (s.ToUpper ());
         };
         Console.WriteLine (predicateUpper2 ("Naveen"));
         Console.WriteLine (predicateUpper2 ("NAVEEN"));

         // Lambda function
         Predicate<string> predicateUpper3 = (string s) => s.Equals (s.ToUpper ());
         Console.WriteLine (predicateUpper3 ("Naveen"));
         Console.WriteLine (predicateUpper3 ("NAVEEN"));

      }
      
      static int Sum(int x, int y) {
         return x + y;
      }

      static void Print (int x) {
         Console.WriteLine (x);
      }

      static bool IsUpperCase (string str) {
         return str.Equals (str.ToUpper ());
      }
   }
}
