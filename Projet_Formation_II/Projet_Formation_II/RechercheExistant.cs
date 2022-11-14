using System.Collections.Generic;
using System.Linq;

namespace Projet_Formation_II
{
    class RechercheExistant
    {
        public static bool GestExiste(List<Gestionnaire> gestionnaires, int identifiant)
        {
            foreach (Gestionnaire gest in gestionnaires)
            {
                if (gest.GetIdentifiant() == identifiant)
                {
                    return true;
                }
            }
            return false;
        }

        public static int TrouverGest(List<Gestionnaire> gestionnaires, int identifiant)
        {
            for (int i = 0; i < gestionnaires.Count(); i++)
            {
                if (gestionnaires[i].GetIdentifiant() == identifiant)
                {
                    return i;
                }
            }
            return -1;
        }

        public static bool CompteExiste(List<Gestionnaire> gestionnaires, int identifiant)
        {
            foreach (Gestionnaire gest in gestionnaires)
            {
                if (gest.CompteExiste(identifiant))
                {
                    return true;
                }
            }
            return false;
        }

        public static int GestOfCompte(List<Gestionnaire> gestionnaires, int identifiant)
        {

            for (int i = 0; i < gestionnaires.Count(); i++)
            {
                if (gestionnaires[i].CompteExiste(identifiant))
                {
                    return i;
                }
            }
            return -1;
        }

        public static bool TransactionExiste(List<Transaction> transactions, int identifiant)
        {
            foreach (Transaction tran in transactions)
            {
                if (tran.GetIdentifiant() == identifiant)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
