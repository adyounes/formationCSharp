using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    //    int[] tableau, 
    public static class Search
    {
        public static int LinearSearch(int[] tableau, int valeur)
        {
            //TODO

            if (tableau.Length == 0)
            {
                Console.WriteLine("Le tableau est vide");
                return (-1);
            }

            for (int i = 0; i < tableau.Length; i++)
            {
                if (tableau[i] == valeur)
                {
                    Console.WriteLine($"La valeur se trouve à l'indice {i}");
                    return i;
                }

            }
            Console.WriteLine($"La valeur n'a pas été trouvée {-1}");
            return -1;
        }

        public static int BinarySearch(int[] tableau, int valeur)
        {
            //TODO

            if (tableau.Length == 0)
            {
                Console.WriteLine("Le tableau est vide");
                return (-1);
            }
            int milieu = tableau.Length / 2;

            if (tableau[milieu] == valeur)
            {
                return (milieu);
            }
            else if (tableau[milieu] > valeur)
            {
                int[] left = TabGauche(tableau, milieu);
                return (BinarySearch(left, valeur));
            }
            else // tableau[milieu] < valeur
            {
                int[] right = TabDroite(tableau, milieu);
                return (milieu + BinarySearch(right, valeur));
            }
        }
        static int[] TabGauche(int[] tableau, int last)
        {
            int[] left = new int[last];

            for (int i = 0; i < last; i++)
            {
                    left[i] = tableau[i];
            }
            return (left);
        }

        static int[] TabDroite(int[] tableau, int first)
        {
            int longueur = tableau.Length - first;
            int[] right = new int[longueur];

            for (int i = 0; i < longueur; i++)
            {
                 right[i] = tableau[first + i];
            }
            return (right);
        }
        
    }
}
