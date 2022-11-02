using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class Pyramid
    {
        public static void PyramidConstruction(int n, bool isSmooth)
        {
            for (int j = 1; j <= n; j++)
            {
                for (int i = 1; i <= Droite(n, j); i++)
                {
                    if (i < Gauche(n, j))
                    {
                        Console.Write(" ");
                    }
                    else if (i >= Gauche(n, j) && i <= Droite(n, j))
                    {
                        if (!isSmooth && (j % 2 == 0))
                        {
                            Console.Write("-");
                        }
                        else
                        {
                            Console.Write("+");
                        }
                    }
                }
                Console.WriteLine("");
            }
        }

        static int Gauche(int n, int j)
        {
            return (n - j + 1);
        }

        static int Droite(int n, int j)
        {
            return (n + j - 1);
        }
    }
}
