using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_III
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Exercice 1 - Conseil de classe
            Console.WriteLine("------------------------");
            Console.WriteLine("Exo 1 : Conseil de classe");
            Console.WriteLine("------------------------");
            ClassCouncil.SchoolMeans("EntreeTest.csv","SortieTest.csv");
            #endregion
            #region Exercice 2 - Performances des tris
            Console.WriteLine("------------------------");
            Console.WriteLine("Exo 2 : Performances des tris");
            Console.WriteLine("------------------------");
            List<int> test = new List<int>() { 2000, 5000, 10000,50000,100000,500000 };
            SortingPerformance.DisplayPerformances(test, 50);
            #endregion
            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
