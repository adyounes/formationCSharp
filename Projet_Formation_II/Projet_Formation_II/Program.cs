using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Projet_Formation_II
{
    class Program
    {
        static void Main()
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

                List<Gestionnaire> gestionnaires = Entree.LireFichierGest(mngrPath);
                List<Operation> operations = Entree.LireFichierComptes(gestionnaires, oprtPath);
                List<Transaction> transactions = Entree.LireFichierTransactions(trxnPath);

                Traitement(gestionnaires, operations, transactions);

                Sortie.EcrireSortieOperations(operations, sttsOprtPath);
                Sortie.EcrireSortieTransactions(transactions, sttsTrxnPath);
                Sortie.EcrireSortieMetrologie(gestionnaires, mtrlPath);
                #endregion
                Console.ReadKey();
            }
        }

        static void Traitement(List<Gestionnaire> gestionnaires, List<Operation> operations, List<Transaction> transactions)
        {
            int nb_ope = 0;
            int nb_tra = 0;

            while (nb_ope < operations.Count() || nb_tra < transactions.Count())
            {
                if (nb_ope < operations.Count() && nb_tra < transactions.Count())   // il reste des opérations et des transactions
                {
                    int dateCompare = DateTime.Compare(operations[nb_ope].GetDate(), transactions[nb_tra].GetDate());

                    if (dateCompare <= 0)               // opération avant transaction
                    {
                        operations[nb_ope].SetStatut(OperationCompte(operations[nb_ope], gestionnaires));
                        nb_ope++;
                    }
                    else                                // transaction avant opération
                    {
                        transactions[nb_tra].SetStatut(TraiterTransaction(transactions[nb_tra], gestionnaires));
                        nb_tra++;
                    }
                }
                else if (nb_tra == transactions.Count())                // il ne reste que des opérations
                {
                    operations[nb_ope].SetStatut(OperationCompte(operations[nb_ope], gestionnaires));
                    nb_ope++;
                }
                else                                    // il ne reste que des transactions
                {
                    transactions[nb_tra].SetStatut(TraiterTransaction(transactions[nb_tra], gestionnaires));
                    nb_tra++;
                }
            }
        }

        static bool OperationCompte(Operation ope, List<Gestionnaire> gestionnaires)
        {
            int gest_in = RechercheExistant.TrouverGest(gestionnaires, ope.GetEntree());
            int gest_out = RechercheExistant.TrouverGest(gestionnaires, ope.GetSortie());

            if (ope.GetEntree() != -1 && ope.GetSortie() == -1)                 // ouverture de compte
            {
                if (!RechercheExistant.CompteExiste(gestionnaires, ope.GetId()))  // on vérifie que le compte n'existe pas déjà
                {
                    gestionnaires[gest_in].AddCompte(new Compte(ope.GetId(), ope.GetDate(), ope.GetSolde()));
                    Compte.SetNombreComptes(Compte.GetNombreComptes() + 1);

                    return true;
                }

                return false;
            }
            else if (ope.GetEntree() == -1 && ope.GetSortie() != -1)            // fermeture de compte
            {
                if (RechercheExistant.CompteExiste(gestionnaires, ope.GetId()))   // on vérifie que le compte existe bien
                {
                    gestionnaires[gest_out].CloseCompte(ope.GetId(), ope.GetDate());

                    return true;
                }

                return false;
            }
            else if (ope.GetEntree() != -1 && ope.GetSortie() != -1)                    // transfert de compte
            {
                if (RechercheExistant.GestExiste(gestionnaires, ope.GetEntree()) && RechercheExistant.GestExiste(gestionnaires, ope.GetSortie()) && gestionnaires[gest_in].CompteExiste(ope.GetId()) &&
                    gestionnaires[gest_in].GetCompte(ope.GetId()).GetDateResiliation() == DateTime.MaxValue)   // on vérifie l'existance des deux gestionnaires et du compte à transférer, et on vérifie que le compte est actif
                {
                    gestionnaires[gest_in].AddCompte(gestionnaires[gest_out].GetCompte(ope.GetId()));
                    gestionnaires[gest_out].DelCompte(ope.GetId());

                    return true;
                }
            }

            return false;
        }

        static bool TraiterTransaction(Transaction tran, List<Gestionnaire> gestionnaires)
        {
            if (tran.IsDoublon())
            {
                return false;
            }
            else if (tran.GetDestinataire() != 0 && tran.GetExpediteur() == 0)  // dépot
            {
                return TraiterDepot(tran, gestionnaires);
            }
            else if (tran.GetDestinataire() == 0 && tran.GetExpediteur() != 0)  // retrait
            {
                return TraiterRetrait(tran, gestionnaires);
            }
            else if (tran.GetDestinataire() != 0 && tran.GetExpediteur() != 0)  // virement
            {
                return TraiterVirement(tran, gestionnaires);
            }
            else // environnement vers environnement -> invalide
            {
                return false;
            }
        }

        static bool TraiterDepot(Transaction tran, List<Gestionnaire> gestionnaires)
        {
            if (tran.GetMontant() > 0)
            {
                int gest_des = RechercheExistant.GestOfCompte(gestionnaires, tran.GetDestinataire());

                if (gest_des != -1)
                {
                    Compte destinataire = gestionnaires[gest_des].GetCompte(tran.GetDestinataire());

                    if (destinataire != null && tran.DateIsOk(destinataire))
                    {
                        destinataire.SetSolde(destinataire.GetSolde() + tran.GetMontant());
                        destinataire.AddTransaction(tran);
                        Transaction.SetNombreTransactions(Transaction.GetNombreTransactions() + 1);
                        Transaction.SetNombreTransactionsOk(Transaction.GetNombreTransactionsOk() + 1);
                        Transaction.SetMontantTransactionsOk(Transaction.GetMontantTransactionsOk() + tran.GetMontant());

                        return true;
                    }
                }
            }

            Transaction.SetNombreTransactions(Transaction.GetNombreTransactions() + 1);
            Transaction.SetNombreTransactionsKo(Transaction.GetNombreTransactionsKo() + 1);
            return false;
        }

        static bool TraiterRetrait(Transaction tran, List<Gestionnaire> gestionnaires)
        {
            if (tran.GetMontant() > 0)
            {
                int gest_exp = RechercheExistant.GestOfCompte(gestionnaires, tran.GetExpediteur());

                if (gest_exp != -1)
                {
                    Compte expediteur = gestionnaires[gest_exp].GetCompte(tran.GetDestinataire());

                    if (expediteur != null && tran.GetMontant() <= expediteur.GetSolde() && expediteur.TransactionIsValid(tran) && tran.DateIsOk(expediteur))
                    {
                        expediteur.SetSolde(expediteur.GetSolde() - tran.GetMontant());
                        expediteur.AddTransaction(tran);
                        Transaction.SetNombreTransactions(Transaction.GetNombreTransactions() + 1);
                        Transaction.SetNombreTransactionsOk(Transaction.GetNombreTransactionsOk() + 1);
                        Transaction.SetMontantTransactionsOk(Transaction.GetMontantTransactionsOk() + tran.GetMontant());

                        return true;
                    }
                }
            }

            Transaction.SetNombreTransactions(Transaction.GetNombreTransactions() + 1);
            Transaction.SetNombreTransactionsKo(Transaction.GetNombreTransactionsKo() + 1);

            return false;
        }

        static bool TraiterVirement(Transaction tran, List<Gestionnaire> gestionnaires)
        {
            if (tran.GetMontant() > 0)
            {
                // Gestionnaire ges1 = gestionnaires.Where(p => p.GetIdentifiant() == tran.GetExpediteur()).FirstOrDefault();
                int gest_exp = RechercheExistant.GestOfCompte(gestionnaires, tran.GetExpediteur());
                int gest_des = RechercheExistant.GestOfCompte(gestionnaires, tran.GetDestinataire());

                if (gest_exp != -1 && gest_des != -1)
                {
                    Compte expediteur = gestionnaires[gest_exp].GetCompte(tran.GetExpediteur());
                    Compte destinataire = gestionnaires[gest_des].GetCompte(tran.GetDestinataire());

                    if (expediteur != null && destinataire != null && tran.GetMontant() <= expediteur.GetSolde() && expediteur.TransactionIsValid(tran) && tran.DateIsOk(expediteur))
                    {
                        expediteur.SetSolde(expediteur.GetSolde() - tran.GetMontant());

                        if (gest_exp == gest_des)   // virement entre deux comptes d'un même gestionnaire -> pas de frais de gestion
                        {
                            destinataire.SetSolde(expediteur.GetSolde() + tran.GetMontant());
                        }
                        else                        // virement d'un gestionnaire à l'autre -> frais de gestion
                        {
                            double frais_gestion = gestionnaires[gest_exp].FraisGestion(tran.GetMontant());
                            destinataire.SetSolde(expediteur.GetSolde() + tran.GetMontant() - frais_gestion);
                            gestionnaires[gest_exp].AddFraisGestion(frais_gestion);
                        }

                        expediteur.AddTransaction(tran);
                        destinataire.AddTransaction(tran);
                        Transaction.SetNombreTransactions(Transaction.GetNombreTransactions() + 1);
                        Transaction.SetNombreTransactionsOk(Transaction.GetNombreTransactionsOk() + 1);
                        Transaction.SetMontantTransactionsOk(Transaction.GetMontantTransactionsOk() + tran.GetMontant());

                        return true;
                    }
                }
            }

            Transaction.SetNombreTransactions(Transaction.GetNombreTransactions() + 1);
            Transaction.SetNombreTransactionsKo(Transaction.GetNombreTransactionsKo() + 1);

            return false;
        }

    }
}
