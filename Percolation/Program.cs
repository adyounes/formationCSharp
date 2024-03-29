﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PercolationSimulation perco = new PercolationSimulation();

                PclData data = perco.MeanPercolationValue(100, 20);
                Console.WriteLine($"{data.Mean} ; {data.StandardDeviation} ; {data.Fraction}");

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
