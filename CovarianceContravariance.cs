using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region References

// http://blogs.msdn.com/b/csharpfaq/archive/2010/02/16/covariance-and-contravariance-faq.aspx
// http://www.tutorialsteacher.com/csharp/csharp-covariance-and-contravariance

#endregion References

// In C#, covariance and contravariance enable "implicit reference conversion" for array types, delegate types, and generic type arguments.Covariance preserves "assignment compatibility" and contravariance reverses it.

namespace PracticeProblems {
   class CovarianceContravariance {
      enum Colors { red, green, blue };

      public delegate Small covarianceDel (Big bg);
      public delegate Small contravarianceDel (Big bg);

      static void MainCovariance (string[] args) {

         #region FromEricLippert

         // Assignment compatibility. 
         string str = "test";
         // An object of a more derived type is assigned to an object of a less derived type. 
         object obj = str;

         // Covariance. 
         IEnumerable<string> strings = new List<string> ();
         // An object that is instantiated with a more derived type argument 
         // is assigned to an object instantiated with a less derived type argument. 
         // Assignment compatibility is preserved. 
         IEnumerable<object> objects = strings;

         // Contravariance.           
         // Assume that I have this method: 
         // static void SetObject(object o) { } 
         Action<object> actObject = SetObject;
         // An object that is instantiated with a less derived type argument 
         // is assigned to an object instantiated with a more derived type argument. 
         // Assignment compatibility is reversed. 
         Action<string> actString = actObject;
         //------------------------------------------------------------

         // Array covariance since C# 1.0
         object[] objString = new String[10];

         // ArrayTypeMismatchException is thrown at run time
         //      objString[0] = 5;
         //------------------------------------------------------------

         // Covariance. A delegate specifies a return type as object,
         // but I can assign a method that returns a string.
         Func<object> del = GetString;

         // Contravariance. A delegate specifies a parameter type as string,
         // but I can assign a method that takes an object.
         Action<string> del2 = SetObject;

         // But implicit conversion between generic delegates is not supported until C# 4.0.
         Func<string> del3 = GetString;
         Func<object> del4 = del3; // Compiler error here until C# 4.0.

         #endregion FromEricLippert

         #region FromTutorialsTeacher
         // ---------------------------------------- From tutorialsteacher ---------------------
         Console.WriteLine ("Covariance");
         covarianceDel cd = Method1;
         cd += Method2;
         Small sm = cd (new Big ());


         Console.WriteLine ("\nContravariance");
         contravarianceDel cvd = Method1;
         cvd += Method2;
         cvd += Method3;
         cvd += Method4;

         Small sm2 = cvd (new Big ());

         #endregion FromTutorialsTeacher

      }

      static object GetObject () { return null; }
      static void SetObject (object obj) { }

      static string GetString () { return ""; }
      static void SetString (string str) { }

      static Big Method1 (Big bg) {
         Console.WriteLine ("Method 1");
         return new Big ();
      }

      static Small Method2 (Big bg) {
         Console.WriteLine ("Method 2");
         return new Small ();
      }

      static Small Method3 (Small sm) {
         Console.WriteLine ("Method 3");
         return new Small ();
      }

      static Big Method4 (Small sml) {
         Console.WriteLine ("Method 4");
         return new Big ();
      }

   }

   class Small {

   }

   class Big : Small {

   }

   class Bigger : Big {

   }
}
