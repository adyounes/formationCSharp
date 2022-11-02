using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class Euclide
    {
        public static int Pgcd(int a, int b)
        {
            int r = a % b;

            if (r == 0)
            {
                return (b);
            }
            else
            {
                while(r != 0)
                {
                    a = b;
                    b = r;
                    r = a % b;
                    
                }
                return (b);
            }
        }

        public static int PgcdRecursive(int a, int b)
        {
            int r = a % b;

            if (r == 0)
            {
                return (b);
            }
            else
            {
                return PgcdRecursive(b, r);
            }
        }
    }
}
