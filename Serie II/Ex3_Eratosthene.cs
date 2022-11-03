using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    public static class Eratosthene
    {
        public static int[] EratosthenesSieve(int n)
        {
            //TODO
            bool[] premiers = new bool[n + 1];
            int[] entiers = new int[n + 1];

            for (int i = 0; i < n+1; i++)
            {
                premiers[i] = true;
                entiers[i] = i;
            }

            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (premiers[i])
                {
                    for (int j = 2; i * j < n; j++)
                    {
                        premiers[i * j] = false;
                    }

                }
            }

            List<int> sortie = new List<int>();

            for (int i = 0; i < n; i++)
            {
                if (premiers[i])
                {
                    sortie.Add(entiers[i]);
                }
            }
            for (int i = 0; i < sortie.Count; i++)
            {
                Console.WriteLine(sortie.ElementAt(i));
            }
            return (sortie.ToArray());
        }
    }
}
