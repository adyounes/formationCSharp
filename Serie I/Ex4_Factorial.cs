using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class Factorial
    {
        public static int Factorial_(int n)
        {
            int result = n;

            if (n < 0)
            {
                Console.WriteLine("Le nombre n'est pas positive");
            }
            else if (n == 0)
            {
                return (1);
            }
            for (int i = n - 1; i > 0; i--)
            {
                result *= i;
            }
            return result;
        }

        public static int FactorialRecursive(int n)
        {
            if (n < 0)
            {
               return -1;
            }
            else if (n == 0)
            {
                return (1);
            }
            else
            {
                return (n * FactorialRecursive(n - 1));
            }
        }
    }
}
