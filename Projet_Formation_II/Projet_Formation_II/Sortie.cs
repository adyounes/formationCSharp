﻿using System.Collections.Generic;
using System.IO;

namespace Projet_Formation_II
{
    class Sortie
    {
        public static void EcrireSortieOperations(List<Operation> operations, string path)
        {
            using (FileStream output = File.OpenWrite(path))
            {
                using (StreamWriter ecrivain = new StreamWriter(output))
                {
                    foreach (Operation ope in operations)
                    {
                        if (ope.GetStatut())
                        {
                            ecrivain.Write($"{ope.GetId()};{ope.GetDate():d};{ope.GetSolde()};");
                            if (ope.GetEntree() != -1)
                            {
                                ecrivain.Write(ope.GetEntree());
                            }
                            ecrivain.Write(";");
                            if (ope.GetSortie() != -1)
                            {
                                ecrivain.Write(ope.GetSortie());
                            }
                            ecrivain.WriteLine(";OK");
                        }
                        else
                        {
                            ecrivain.Write($"{ope.GetId()};{ope.GetDate():d};{ope.GetSolde()};");
                            if (ope.GetEntree() != -1)
                            {
                                ecrivain.Write(ope.GetEntree());
                            }
                            ecrivain.Write(";");
                            if (ope.GetSortie() != -1)
                            {
                                ecrivain.Write(ope.GetSortie());
                            }
                            ecrivain.WriteLine(";KO");
                        }
                    }
                }
            }
        }

        public static void EcrireSortieTransactions(List<Transaction> transactions, string path)
        {
            using (FileStream output = File.OpenWrite(path))
            {
                using (StreamWriter ecrivain = new StreamWriter(output))
                {
                    foreach (Transaction tran in transactions)
                    {
                        if (tran.GetStatut())
                        {
                            ecrivain.WriteLine($"{tran.GetIdentifiant()};{tran.GetDate():d};{tran.GetMontant()};{tran.GetExpediteur()};{tran.GetDestinataire()};OK");
                        }
                        else
                        {
                            ecrivain.WriteLine($"{tran.GetIdentifiant()};{tran.GetDate():d};{tran.GetMontant()};{tran.GetExpediteur()};{tran.GetDestinataire()};KO");
                        }
                    }
                }
            }
        }

        public static void EcrireSortieMetrologie(List<Gestionnaire> gestionnaires, string path)
        {
            using (FileStream output = File.OpenWrite(path))
            {
                using (StreamWriter metrologie = new StreamWriter(output))
                {
                    metrologie.WriteLine("Statistiques :");
                    metrologie.WriteLine($"Nombre de comptes : {Compte.GetNombreComptes()}");
                    metrologie.WriteLine($"Nombre de transactions : {Transaction.GetNombreTransactions()}");
                    metrologie.WriteLine($"Nombre de réussites : {Transaction.GetNombreTransactionsOk()}");
                    metrologie.WriteLine($"Nombre d'échecs : {Transaction.GetNombreTransactionsKo()}");
                    metrologie.WriteLine($"Montant total des réussites : {Transaction.GetMontantTransactionsOk()} euros");
                    metrologie.WriteLine();
                    metrologie.WriteLine("Frais de gestion :");

                    foreach (Gestionnaire gest in gestionnaires)
                    {
                        metrologie.WriteLine($"{gest.GetIdentifiant()} : {gest.GetFraisGestion()} euros");
                    }

                }
            }
        }
    }
}
