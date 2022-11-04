using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_III
{
    public static class ClassCouncil
    {
        static string[] Moyennes(List<string> entrees)
        {
            Dictionary<string, List<double>> dico = new Dictionary<string, List<double>>();

            foreach (string ligne in entrees)
            {

                string[] line = ligne.Split(';');
                string matiere = line[1];
                string note = line[2];
                note = note.Replace('.', ',');

                if (!dico.ContainsKey(matiere))
                {
                    dico.Add(matiere, new List<double>());
                }

                dico[matiere].Add(double.Parse(note));
            }

            List<string> sorties = new List<string>();

            foreach (KeyValuePair<string, List<double>> matiere in dico)
            {
                double total = 0;

                foreach (double note in matiere.Value)
                {
                    total += note;
                }

                double moyenne = total / matiere.Value.Count;
                sorties.Add($"{matiere.Key};{moyenne:F1}");
                //sorties.Add($"{matiere.Key};{Math.Round(moyenne, 1)}");
            }
            
            return (sorties.ToArray());
        }
        public static void SchoolMeans(string input, string output)
        {
            //TODO
            List<string> entrees = new List<string>();

            using (FileStream inputStream = File.OpenRead(input))
            {
                using (TextReader lecteur = new StreamReader(inputStream))
                {

                    while (lecteur.Peek() != -1)
                    {
                        entrees.Add(lecteur.ReadLine());
                    }

                }
            }

            string[] sorties = Moyennes(entrees);

            using (FileStream outputStream = File.OpenWrite(output))
            {
                using (TextWriter sortie = new StreamWriter(outputStream))
                {
                    foreach (string ligne in sorties)
                    {
                        sortie.WriteLine(ligne);
                    }
                }
            }
        }
    }
}
