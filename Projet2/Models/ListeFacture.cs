using System.Collections.Generic;
using System.Linq;

namespace Projet2.Models
{
    public class ListeFacture
    {
        public static List<Facturation> listeFacture = new List<Facturation>();

        // get the list of all facture in the bdd
        public static List<Facturation> GetFacturesList()
        {
            return listeFacture;
        }

        // add a facture to the list
        public static void CreateFacturation(int id, string nomFacturation, string prenomFacturation, string villeFacturation, string adresseFacturation, string codePostalFacturation, string paysFacturation, string TelephoneFacturation)
        {
            listeFacture.Add(new Facturation() { Id = id, NomFacturation = nomFacturation, PrenomFacturation = prenomFacturation, VilleFacturation = villeFacturation, AdresseFacturation = adresseFacturation, CodePostalFacturation= codePostalFacturation, PaysFacturation = paysFacturation, TelephoneFacturation = TelephoneFacturation });
        }

        
        // remove a facture from the list 
        public static void RemoveFacturation(Facturation facturation)
        {
            listeFacture.Remove(facturation);
        }

        // remove a Facture from the list via the Id
        public static void RemoveFacturation(int id)
        {
            Facturation facturation = ListeFacture.listeFacture.FirstOrDefault(mb => mb.Id == id); // retrieve the facture having this given Id
            listeFacture.Remove(facturation);
        }

        // look for a club by a given data (name, city, dpt...)
        public static Facturation LookForFacture(string nomSearch)
        {

            Facturation facturation = ListeFacture.listeFacture.FirstOrDefault(mb => mb.NomFacturation == nomSearch);
            return facturation;
        }
    }
}
