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
            Console.WriteLine("Exo 1 : Performances des tris");
            Console.WriteLine("------------------------");
            #endregion
            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
