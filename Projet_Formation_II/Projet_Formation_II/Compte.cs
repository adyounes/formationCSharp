﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Projet_Formation_II
{

    class Compte
    {
        static int _nombre_comptes;

        private readonly int _identifiant;

        private double _solde;
        private readonly double _max_retrait;
        private readonly int _dernieres_transactions;
        private List<Transaction> _transactions;

        private DateTime _date_creation;
        private DateTime _date_resiliation;


        public Compte()
        {
            _nombre_comptes = 0;
        }

        public static int GetNombreComptes()
        {
            return _nombre_comptes;
        }

        public static void SetNombreComptes(int n)
        {
            _nombre_comptes = n;
        }

        public Compte(int id, DateTime cre, double sld = 0, double maxR = 2000, int ndt = 10)
        {
            _identifiant = id;
            _date_creation = cre;
            _date_resiliation = DateTime.MaxValue;
            _solde = sld;
            _max_retrait = maxR;
            _dernieres_transactions = ndt;
            _transactions = new List<Transaction>();
        }

        public void FermerCompte(DateTime res)
        {
            _date_resiliation = res;
        }

        public int GetIdentifiant()
        {
            return _identifiant;
        }

        public DateTime GetDateCreation()
        {
            return _date_creation;
        }

        public DateTime GetDateResiliation()
        {
            return _date_resiliation;
        }

        public double GetSolde()
        {
            return _solde;
        }

        public void SetSolde(double montant)
        {
            _solde = montant;
        }

        public double GetMaxRetrait()
        {
            return _max_retrait;
        }

        public List<Transaction> GetTransactions()
        {
            return _transactions;
        }

        public void AddTransaction(Transaction tran)
        {
            _transactions.Add(tran);
        }

        // renvoie true si la somme des dernières transactions + la transaction en paramètre est inférieure au montant de retrait maximum
        public bool TransactionIsValid(Transaction tran)
        {
            if (tran.GetMontant() + LastTransactions(_dernieres_transactions) > _max_retrait)
            {
                return false;
            }
            return true;
        }

        // renvoie la somme des n dernières transactions
        private double LastTransactions(int n)
        {
            double total = 0;

            for (int i = _transactions.Count() - 1; i >= 0 && i > _transactions.Count() - n; i--)
            {
                if (_transactions[i].GetExpediteur() == _identifiant)
                {
                    total += _transactions[i].GetMontant();
                }
            }

            return total;
        }
    }
}
