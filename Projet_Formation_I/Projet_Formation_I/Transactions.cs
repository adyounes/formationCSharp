using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Formation_I
{
    class Transactions
    {
        private readonly int _identifiant;
        private double _montantTr;
        private int _expediteur;
        private int _destinataire;
        private bool _status;
        private bool _is_dupe;

        public Transactions(int id, int expe, int desti, bool dupe, double tr = 0, double maxR =1000)
        {
            _identifiant  = id;
            _montantTr    = tr;
            _expediteur   = expe;
            _destinataire = desti;
            _is_dupe      = dupe;
        }
        public int GetId()
        {
            return _identifiant;
        }

        public double GetMontantTr()
        {
            return _montantTr;
        }

        public int GetExpediteur()
        {
            return _expediteur;
        }

        public int GetDestinataire()
        {
            return _destinataire;
        }

        public bool GetStatus()
        {
            return _status;
        }

        public void SetStatus(bool newstatus)
        {
            _status = newstatus;
        }

        public bool IsDoublon()
        {
            return _is_dupe;
        }

    }
}
