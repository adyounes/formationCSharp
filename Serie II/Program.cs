using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Exercice 1 - Recherche d'un élément
            Console.WriteLine("------------------------");
            Console.WriteLine("Exo 1.1 : Recherche linéaire");
            Console.WriteLine("------------------------");
            int[] tableau = { 1, 2, 3, 4, 5, 6, 9, 12, 48, 654 };
            int[] tab2 = { };
            Search.LinearSearch(tableau, 654);
            Search.LinearSearch(tableau, 22);
            Search.LinearSearch(tab2, 22);
            Console.WriteLine("------------------------");
            Console.WriteLine("Exo 1.2 : Recherche dichotomique");
            Console.WriteLine("------------------------");
            //            Search.BinarySearch(tableau, 6);
            //            Search.BinarySearch(tableau, 22);
            #endregion

            #region Exercice 3 - Crible d'Eratosthène
            Console.WriteLine("------------------------");
            Console.WriteLine("Exo 3 : Crible d'Eratosthène");
            Console.WriteLine("------------------------");
            Eratosthene.EratosthenesSieve(1000);
            #endregion
            Qcm qst = new Qcm("Quelle est l'année du sacre de Charlemagne ?", new string[4],2,0);
            Quiz.AskQuestion(qst);

            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
