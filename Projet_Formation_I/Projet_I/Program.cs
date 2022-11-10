using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_I
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            string acctPath = path + @"\Comptes_1.txt";
            string trxnPath = path + @"\Transactions_1.txt";
            string sttsPath = path + @"\Statut_1.txt";

            // lecture des fichiers d'entrées pour obtenir la liste des comptes et des transactions
            List<Comptes> comptes = LectureFichierComptes(acctPath);
            List<Transactions> transactions = LectureFichierTransactions(trxnPath);

            // traitement des transactions pour obtenir leur statut
            TraitementTransactions(transactions, comptes);

            // ecriture des statuts dans le fichier de sortie
            EcritureFichierSortie(transactions, sttsPath);
        }

        //Vérifie si le compte est existant ou non
        static bool CompteExiste(List<Comptes> comptes, int id)
        {
            foreach (Comptes cpt in comptes)
            {
                if (cpt.GetId() == id)
                {
                    return true;
                }

            }
            return false;
        }

        //Parcours la liste de comptes pour trouver le compte correspondant et renvoie l'indice correspondant
        static int CompteTrouve(List<Comptes> comptes, int id)
        {
            for (int i = 0; i < comptes.Count; i++)
            {
                if (comptes[i].GetId() == id)
                {
                    return i;
                }

            }
            return -1;
        }

        //Vérifie si la transaction est existante ou non
        static bool TransactionExiste(List<Transactions> tr, int id)
        {
            foreach (Transactions tran in tr)
            {
                if (tran.GetId() == id)
                {
                    return true;
                }

            }
            return false;
        }

        /* lecture de Comptes.csv et en ressortir une liste de strings qui sera ensuite convertie 
           en liste de comptes par ParseDataComptes()*/
        static List<Comptes> LectureFichierComptes(string path)
        {
            List<string> dataComptes = new List<string>();

            using (FileStream input = File.OpenRead(path))
            {
                using (StreamReader lecteur = new StreamReader(input))
                    while (!lecteur.EndOfStream)
                    {
                        dataComptes.Add(lecteur.ReadLine());
                    }
            }

            return ParseComptes(dataComptes);
        }

        // traduit une liste de string ou chaque string est au format "identifiant;solde" en liste de comptes
        static List<Comptes> ParseComptes(List<string> dataComptes)
        {
            List<Comptes> comptes = new List<Comptes>();

            foreach (string ligne in dataComptes)
            {
                string[] data = ligne.Split(';'); // Effectue la séparation de la string tout en enlevant les ';'
                int identifiant = int.Parse(data[0]);

                if (!CompteExiste(comptes, identifiant))
                {
                    // Vérification de la présence du solde. Si non renseigné, mis à zéro par défaut.
                    if (data[1].Length != 0)
                    {
                        double solde = double.Parse(data[1].Replace('.', ','));
                        if (solde >= 0)
                        {
                            comptes.Add(new Comptes(identifiant, solde));
                        }
                    }
                    else
                    {
                        comptes.Add(new Comptes(identifiant));
                    }
                }
            }

            return comptes;
        }

        /* Lecture de Transactions.csv et en ressortir une liste de strings qui sera ensuite convertie 
           en liste de transactions par ParseDataTransactions*/
        static List<Transactions> LectureFichierTransactions(string path)
        {
            List<string> dTransactions = new List<string>();

            using (FileStream input = File.OpenRead(path))
            {
                using (StreamReader lecteur = new StreamReader(input))
                    while (!lecteur.EndOfStream)
                    {
                        dTransactions.Add(lecteur.ReadLine());
                    }
            }

            return ParseTransactions(dTransactions);
        }

        /* traduit une liste de string ou chaque string est au format 
           "identifiant;montant;expediteur;destinataire" en liste de transactions*/
        static List<Transactions> ParseTransactions(List<string> dTransactions)
        {
            List<Transactions> transactions = new List<Transactions>();

            foreach (string ligne in dTransactions)
            {
                string[] data = ligne.Split(';'); // Effectue la séparation de la string tout en enlevant les ';'
                int identifiant = int.TryParse(data[0], out int ParseId) ? ParseId : int.MinValue;
                //int identifiant = int.Parse(data[0]);
                double montant = double.TryParse(data[1], out double ParseMontant) ? ParseMontant : double.MinValue;
                int expediteur = int.TryParse(data[2], out int ParseExpe) ? ParseExpe : int.MinValue;
                int destinataire = int.TryParse(data[3], out int ParseDesti) ? ParseDesti : int.MinValue;

                if (!TransactionExiste(transactions, identifiant))
                {
                    transactions.Add(new Transactions(identifiant, expediteur, destinataire, false, montant));
                }
                else
                {
                    transactions.Add(new Transactions(identifiant, expediteur, destinataire, true, montant));
                }
            }

            return transactions;
        }


        //Traitement de la transaction et renvoi le status de la transaction en cours
        static void TraitementTransactions(List<Transactions> tr, List<Comptes> comptes)
        {
            foreach (Transactions tran in tr)
            {
                tran.SetStatus(Traitement(tran, comptes));
            }
        }

        //Effectue le traitement selon le type de transaction demandé
        static bool Traitement(Transactions tran, List<Comptes> comptes)
        {
            //Vérification que la transaction n'est pas présente en doublon
            if (tran.IsDoublon())
            {
                return false;
            }
            if (tran.GetDestinataire() == 0 && tran.GetExpediteur() != 0)
            {
                return TraitementRetrait(tran, comptes);
            }
            else if (tran.GetDestinataire() != 0 && tran.GetExpediteur() == 0)
            {
                return TraitementDepot(tran, comptes);
            }
            else if (tran.GetDestinataire() != 0 && tran.GetExpediteur() != 0)
            {
                return TraitementVirement(tran, comptes);
            }
            return false;
        }

        //Si les conditions sont remplies, le retrait est effectué
        static bool TraitementRetrait(Transactions tran, List<Comptes> comptes)
        {
            if (tran.GetMontantTr() > 0)
            {
                int expediteur = CompteTrouve(comptes, tran.GetExpediteur());

                /* le compte expéditeur doit exister, le montant doit être inférieur ou égal à son solde,
                   et le montant des 10 dernières transactions ne doit pas dépasser le montant max */
                if (expediteur != -1 && tran.GetMontantTr() <= comptes[expediteur].GetSolde() && comptes[expediteur].ValidityTr(tran))
                {
                    comptes[expediteur].SetSolde(comptes[expediteur].GetSolde() - tran.GetMontantTr());
                    comptes[expediteur].AddTransaction(tran);
                    return true;
                }
            }
            return false;
        }

        //Si les conditions sont remplies, le dépot est effectué
        static bool TraitementDepot(Transactions tran, List<Comptes> comptes)
        {

            if (tran.GetMontantTr() > 0)
            {
                int destinataire = CompteTrouve(comptes, tran.GetDestinataire());

                // le compte destinataire doit exister
                if (destinataire != -1)
                {
                    comptes[destinataire].SetSolde(comptes[destinataire].GetSolde() + tran.GetMontantTr());
                    comptes[destinataire].AddTransaction(tran);
                    return true;
                }
            }
            return false;
        }

        //Si les conditions sont remplies, le virement est effectué
        static bool TraitementVirement(Transactions tran, List<Comptes> comptes)
        {
            if (tran.GetMontantTr() > 0) // le montant doit être strictement positif
            {
                int expediteur = CompteTrouve(comptes, tran.GetExpediteur());
                int destinataire = CompteTrouve(comptes, tran.GetDestinataire());

                /* le compte expéditeur doit exister, le montant doit être inférieur ou égal à son solde,
                  et le montant des 10 dernières transactions ne doit pas dépasser le montant max */
                if (expediteur != -1 && destinataire != -1 && tran.GetMontantTr() <= comptes[expediteur].GetSolde() && comptes[expediteur].ValidityTr(tran))
                {
                    comptes[expediteur].SetSolde(comptes[expediteur].GetSolde() - tran.GetMontantTr());
                    comptes[destinataire].SetSolde(comptes[destinataire].GetSolde() + tran.GetMontantTr());
                    comptes[expediteur].AddTransaction(tran);
                    comptes[destinataire].AddTransaction(tran);
                    return true;
                }
            }
            return false;
        }

        static void EcritureFichierSortie(List<Transactions> tran, string path)
        {
            using (FileStream output = File.OpenWrite(path))
            using (StreamWriter transactions = new StreamWriter(output))
                foreach (Transactions tr in tran)
                {
                    if (tr.GetStatus() && tr.GetDestinataire() != int.MinValue && tr.GetExpediteur() != int.MinValue && tr.GetMontantTr() != double.MinValue)
                    {
                        transactions.WriteLine($"{tr.GetId()};OK");
                    }
                    else
                    {
                        transactions.WriteLine($"{tr.GetId()};KO");
                    }
                }
        }
    }
}
