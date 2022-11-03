using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    public struct Qcm
    {
        public string Question;
        public string[] Reponses;
        public int Solution;
        public int Points;

        public Qcm(string question, string[] reponses, int solution, int points)
        {
            Question = question;
            Reponses = reponses;
            Solution = solution;
            Points = points;
        }
    }

    public static class Quiz
    {
        public static void AskQuestions(Qcm[] qcms)
        {
            //TODO

        }

        public static int AskQuestion(Qcm qcm)
        {

            //TODO
            if (QcmValidity(qcm))
            {
               
                Console.WriteLine("Reponse invalide !");
                Console.WriteLine("Entrez une nouvelle réponse !");
                string input = Console.ReadLine();
                // int answer;
                // bool b = int.TryParse(input,out answer);
                for (int i = 0; i < qcm.Solution; i++)
                {

                }
                return 0;
            }
            else
            {
                Console.WriteLine(qcm.Question);
                for (int i = 0; i < qcm.Reponses.Length; i++)
                {
                    Console.Write(qcm.Reponses[i] + " ");
                }

                //qcm.Points += 1;
            }

            return -1;
        }

        public static bool QcmValidity(Qcm qcm)
        {

            if (qcm.Solution <= 0 || qcm.Solution > qcm.Reponses.Length)
            {
                return false;
            }

            if (qcm.Points < 0)
            {
                return false;
            }
            return true;

        }
    }
}
