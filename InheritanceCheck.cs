using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/inheritance

namespace PracticeProblems {
   class InheritanceCheck {
      static void MainInheritance (String[] args) {

         Console.WriteLine ("---------CLASS B, accesses A and B----------");
         B b = new B ();
         Console.WriteLine (b.aMem1);
         Console.WriteLine (b.aProp1);
         b.aMethod1();
         Console.WriteLine (b.bMem1);
         Console.WriteLine (b.bProp1);
         b.bMethod1 ();

         Console.WriteLine ("---------CLASS A, accesses A only----------");

         A a = new A ();
         Console.WriteLine (a.aMem1);
         Console.WriteLine (a.aProp1);
         b.aMethod1 ();
         // Throws Error
         //Console.WriteLine (a.bMem1);
         //Console.WriteLine (a.bProp1);
         //a.bMethod1 ();

         Console.WriteLine ("---------CLASS A: B, accesses A only----------");

         A ab = new B ();
         Console.WriteLine (ab.aMem1);
         Console.WriteLine (ab.aProp1);
         ab.aMethod1();
         // Console.WriteLine (ab.b1); // Throws error - Error 1	'PracticeProblems.A' does not contain a definition for 'b1' and no extension method 'b1' accepting a first argument of type 'PracticeProblems.A' could be found (are you missing a using directive or an assembly reference?)	C:\Users\naveenkumar\documents\visual studio 2013\Projects\PracticeProblems\InheritanceCheck.cs	15	31	PracticeProblems

         Console.WriteLine ("---------CLASS B: A, accesses Nothing----------");
         Console.WriteLine ("Not possible");
         // B ba = new A (); // Throws error because we can't create instance of parent class from type child


         Console.WriteLine ("---------CLASS B: A (Explicitly Cast, Correct type), accesses A and B----------");
         A a1 = new B ();
         B b1 = (B)a1; // OK
         Console.WriteLine (b1.aMem1);
         Console.WriteLine (b1.aProp1);
         b1.aMethod1 ();
         Console.WriteLine (b1.bMem1);
         Console.WriteLine (b1.bProp1);
         b1.bMethod1 ();



         Console.WriteLine ("---------CLASS B: A (Explicitly Cast, Incorrect type)----------");
         A a2 = new C ();
         // B b2 = (B)a2; // Invalid cast exception
         Console.WriteLine ("Invalid Cast exception");
         // safe casting
         B b3 = a2 as B; // will be null, if incorrect type
         if (b3 == null) {
            Console.WriteLine ("Null");
         }
         

      }

   }

   class A {
      public static int aStat1 = 1;

      public int aMem1 = 10;

      public int aProp1 { get; set; }

      public void aMethod1 () {
         Console.WriteLine ("Class A method");
      }

      public A () {
         Console.WriteLine ("Constructor A");
         aProp1 = 10;
      }
   }

   class B: A {
      public int bMem1 = 20;
      public new int aMem1 = 30; // to avoid conflict, use new keyword

      public int bProp1 { get; set; }

      public void bMethod1 () {
         Console.WriteLine ("Class B method");
      }

      public B () {
         Console.WriteLine ("Constructor B");
         bProp1 = 20;
         A.aStat1 = 5;
      }
   }

   class C: A {
      public static int cStat1 = 1;

      public int cMem1 = 10;

      public int cProp1 { get; set; }

      public void cMethod1 () {
         Console.WriteLine ("Class C method");
      }

      public C () {
         Console.WriteLine ("Constructor C");
         cProp1 = 10;
      }
   }

}
