using System.Collections.Generic;
using System.Linq;

namespace Projet2.Models
{
    public class ListeAdherents
    {
        public static List<Adherent> listeAdherents = new List<Adherent>();

        // get the list of all the users in the bdd
        public static List<Adherent> GetAdherentsList()
        {
            return listeAdherents;
        }

        // add an Adherent to the list
        public static void CreateAdherent(int id, Compte compte, Club club)
        {
            listeAdherents.Add(new Adherent() { Id = id, Compte = compte, Club = club });
        }

        // remove an Adherent from the list 
        public static void RemoveAdherent(Adherent adherent)
        {
            listeAdherents.Remove(adherent);
        }

        // remove an Adherent from the list via the Id
        public static void RemoveAdherent(int id)
        {
            Adherent adherent = ListeAdherents.listeAdherents.FirstOrDefault(mb => mb.Id == id); // retrieve the Adherent having this given Id
            listeAdherents.Remove(adherent);
        }

        // look for a club by a given data (name, city, dpt...)
        public static Adherent LookForAdherent(int idSearch)
        {

            Adherent adherent = ListeAdherents.listeAdherents.FirstOrDefault(mb => mb.Id == idSearch);
            return adherent;
        }


    }
}
