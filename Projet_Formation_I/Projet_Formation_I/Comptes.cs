using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Formation_I
{
    class Comptes
    {
        private readonly int _identifiant;
        private double _solde;
        private readonly double _maxRetrait;
        private List<Transactions> _transactions;



        public Comptes(int id, double sld = 0, double maxR = 1000)
        {
            _identifiant  = id;
            _solde        = sld;
            _maxRetrait   = maxR;
            _transactions = new List<Transactions>();
        }

        public int GetId()
        {
            return _identifiant;
        }

        public double GetSolde()
        {
            return _solde;
        }
        public void SetSolde(double nvSolde)
        {
           _solde = nvSolde;
        }

        public double GetMaxR()
        {
            return _maxRetrait;
        }

        public List<Transactions> GetTransactions()
        {
            return _transactions;
        }

        public void AddTransaction(Transactions tr)
        {
            _transactions.Add(tr);
        }

        public bool ValidityTr(Transactions tr)
        {
            if (tr.GetMontantTr() + TenLastTransactions() > _maxRetrait)
            {
                return false;
            }
            return true;
        }

        private double TenLastTransactions()
        {
            double total = 0;

            for (int i = _transactions.Count - 1; i > 0 && i > _transactions.Count - 10; i--)
            {
                if (_transactions[i].GetExpediteur() == _identifiant)
                {
                    total += _transactions[i].GetMontantTr();
                }
            }

            return total;
        }

    }
}
