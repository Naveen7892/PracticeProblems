using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;

namespace PracticeProblems {
   class GcdOfFibo {
      static void MainGcd (string[] args) {
         //Console.WriteLine (fibo (100000000));
         // Sample input 
         // 3, 6 = 2
         // 13, 21 = 1
         // 2, 3, 5 = 1


         int[] arr = new int[] {
            1000000001, 100002, 100003
         };
         computeGCD (arr, 0, arr.Length - 1);
      }

      static BigInteger fibo (int n) {
         BigInteger a = new BigInteger (0);
         BigInteger b = new BigInteger (1);
         BigInteger c = new BigInteger (0);
         for (int i = 1; i < n; i++) {
            //Console.WriteLine (b);
            c = a + b;
            a = b;
            b = c;
         }
         Console.WriteLine ("Gcd of " + n + " is " + b);
         return b;
      }

      static BigInteger gcd (BigInteger a, BigInteger b) {
         // non - recursive
         while (a != 0 && b != 0) {
            if (a > b) {
               a %= b;
            } else {
               b %= a;
            }
         }

         if (a == 0) {
            return b;
         }
         return a;
      }

      static void computeGCD (int[] arr, int L, int R) {
         BigInteger res = new BigInteger (0);
         for (int i = L + 1; i <= R; i++) {
            res = gcd (fibo(arr[i - 1]), fibo(arr[i]));
         }

         res = res % 1000000007;
         Console.WriteLine ("Result: " + res);
      }
   }


}
