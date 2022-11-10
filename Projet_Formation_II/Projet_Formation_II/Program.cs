using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Formation_II
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            for (int i = 1; i < 7; i++)
            {
                #region Files
                // Entrées
                string mngrPath = path + $@"\Gestionnaires_{i}.txt";
                string oprtPath = path + $@"\Comptes_{i}.txt";
                string trxnPath = path + $@"\Transactions_{i}.txt";
                // Sorties
                string sttsOprtPath = path + $@"\StatutOpe_{i}.txt";
                string sttsTrxnPath = path + $@"\StatutTra_{i}.txt";
                string mtrlPath = path + $@"\Metrologie_{i}.txt";
                #endregion

            }
        }
    }
}
