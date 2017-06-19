using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems {
   class DelegateMulticast {

      public delegate void Print (int number);

      static void MainDelegate (String[] args) {
         Print printDelegate;

         printDelegate = PrintNumber;
         printDelegate (1000);

         printDelegate = PrintMoney;
         printDelegate (1000);


         // Multicast delegate
         printDelegate = PrintNumber;
         printDelegate += PrintMoney;
         printDelegate += PrintHexadecimal;
         printDelegate (2000);

         printDelegate -= PrintHexadecimal;
         printDelegate (3000);

      }

      static void PrintNumber (int n) {
         Console.WriteLine ("Number - {0}", n);
      }

      static void PrintMoney (int n) {
         Console.WriteLine ("Money - {0:C}", n);
      }

      static void PrintHexadecimal (int n) {
         Console.WriteLine ("Hexa - {0:X}", n);
      }
   }
}
