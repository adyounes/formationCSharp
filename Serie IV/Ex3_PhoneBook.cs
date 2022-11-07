using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Serie_IV
{
    public class PhoneBook
    {
        private Dictionary<string, string> _annuaire;

        public PhoneBook()
        {
            _annuaire = new Dictionary<string, string>();
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {

            if (phoneNumber.Length == 10 && phoneNumber[0] == '0' && phoneNumber[1] != '0')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ContainsPhoneContact(string phoneNumber)
        {

            if (_annuaire.ContainsKey(phoneNumber))
            {
                return true;
            }
            return false;
        }

        public void PhoneContact(string phoneNumber)
        {
            if (ContainsPhoneContact(phoneNumber))
            {
                Console.WriteLine($"{phoneNumber} : {_annuaire[phoneNumber]}");
            }
            else
            {
                throw new KeyNotFoundException($"Le numéro de téléphone {phoneNumber} n'existe pas !");
            }
        }

        public bool AddPhoneNumber(string phoneNumber, string name)
        {
            if (!ContainsPhoneContact(phoneNumber) && IsValidPhoneNumber(phoneNumber) && !string.IsNullOrEmpty(name))
            {
                _annuaire.Add(phoneNumber, name);
                return true;
            }
            return false;
        }

        public bool DeletePhoneNumber(string phoneNumber)
        {

            _annuaire.Remove(phoneNumber);
            return false;
        }

        public void DisplayPhoneBook()
        {
            Console.WriteLine("Annuaire téléphonique :");
            Console.WriteLine("------------------------");
            if (_annuaire.Count() == 0)
            {
                Console.WriteLine("Pas de numéros téléphoniques");
            }
            foreach (KeyValuePair<string, string> personne in _annuaire)
            {
                PhoneContact(personne.Key);
            }

            Console.WriteLine("------------------------");
        }
    }
}
