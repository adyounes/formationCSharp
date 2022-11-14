namespace Projet_Formation_II
{
    class Entreprise : Gestionnaire
    {
        private const double _frais = 10;

        public Entreprise(int identifiant, int nombre_transactions, double frais_gestion = 0) : base(identifiant, nombre_transactions, frais_gestion) { }

        public override double FraisGestion(double montant)
        {
            return _frais;
        }
    }
}
