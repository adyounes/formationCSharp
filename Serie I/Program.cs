using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    class Program
    {
        
        static void Main(string[] args)
        {
            #region Exercice 1 - Operation Basique
            Console.WriteLine("------------------------");
            Console.WriteLine("Exo 1 : Opérations élémentaires");
            Console.WriteLine("Operation de base");
            Console.WriteLine("------------------------");
            ElementaryOperations.BasicOperation(3,4,'+');
            ElementaryOperations.BasicOperation(6, 2, '/');
            ElementaryOperations.BasicOperation(3, 0, '/');
            ElementaryOperations.BasicOperation(6, 9, 'L');
            Console.WriteLine("------------------------");
            Console.WriteLine("Division entière");
            Console.WriteLine("------------------------");
            ElementaryOperations.IntegerDivision(8, 2);
            ElementaryOperations.IntegerDivision(81, 22);
            ElementaryOperations.IntegerDivision(8, 0);
            Console.WriteLine("------------------------");
            Console.WriteLine("Puissance entière");
            Console.WriteLine("------------------------");
            ElementaryOperations.Pow(12, 2);
            ElementaryOperations.Pow(24, 6);
            ElementaryOperations.Pow(125, 452);
            #endregion

            #region Exercice 3 - Construction d'une pyramide
            Console.WriteLine("------------------------");
            Console.WriteLine("Exo 3 : Construction d'une pyramide");
            Console.WriteLine("------------------------");
            Pyramid.PyramidConstruction(10,false);
            Pyramid.PyramidConstruction(10,true);
            #endregion

            #region Exercice 2 - Horloge parlante
            Console.WriteLine("------------------------");
            Console.WriteLine("Exo 2 : horloge parlante");
            Console.WriteLine("------------------------");
            Console.WriteLine(SpeakingClock.GoodDay(DateTime.Now.Hour));
            #endregion
            
            #region Exercice 4 - Factorielle
            Console.WriteLine("------------------------");
            Console.WriteLine("Exo 4.1 : Factorielle");
            Console.WriteLine("------------------------");
            Console.WriteLine(Factorial.Factorial_(9));
            Console.WriteLine("------------------------");
            Console.WriteLine("Exo 4.2 : Factorielle recursive");
            Console.WriteLine("------------------------");
            Console.WriteLine(Factorial.FactorialRecursive(9));
            #endregion

            #region Exercice 5 - Nombres premiers
            Console.WriteLine("------------------------");
            Console.WriteLine("Exo 5 : Nombres premiers");
            Console.WriteLine("------------------------");
            PrimeNumbers.DisplayPrimes();
            #endregion

            #region Exercice 6 - algorithme d'euclide
            Console.WriteLine("------------------------");
            Console.WriteLine("Exo 6.1 : algorithme d'euclide");
            Console.WriteLine("------------------------");
            Console.WriteLine(Euclide.Pgcd(42, 68));
            Console.WriteLine("------------------------");
            Console.WriteLine("Exo 6.2 : algorithme d'euclide recursif");
            Console.WriteLine("------------------------");
            Console.WriteLine(Euclide.PgcdRecursive(42, 68));
            #endregion

            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
