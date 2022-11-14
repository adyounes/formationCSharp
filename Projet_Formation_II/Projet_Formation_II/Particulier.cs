namespace Projet_Formation_II
{
    class Particulier : Gestionnaire
    {
        private const double _frais = 1;

        public Particulier(int identifiant, int nombre_transactions, double frais_gestion = 0) : base(identifiant, nombre_transactions, frais_gestion) { }


        public override double FraisGestion(double montant)
        {
            return (montant * _frais / 100);
        }
    }
}
