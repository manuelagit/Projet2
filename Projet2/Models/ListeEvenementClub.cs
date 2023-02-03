using System.Collections.Generic;
using System.Linq;
using System;

namespace Projet2.Models
{
    public class ListeEvenementClub
    {
        public static List<EvenementClub> listeEvenementClub = new List<EvenementClub>();

        // get the list of all activities in the bdd
        public static List<EvenementClub> GetEventList()
        {
            return listeEvenementClub;
        }

        // add an activity to the list via id, nomActivite... 
        public static void CreateEvent(int id, string nomActivite, DateTime dateActivite, string typeActivite, string descriptionActivite, string lieuActivite, int niveauRequis, int nombrePlace, double prixEvenementClub)
        {
            listeEvenementClub.Add(new EvenementClub() { Id = id, NomActivite = nomActivite, DateActivite = dateActivite, TypeActivite = typeActivite, DescriptionActivite = descriptionActivite, LieuActivite = lieuActivite, NiveauRequis = niveauRequis, NombrePlace = nombrePlace, PrixEvenementClub = prixEvenementClub });
        }

        // add an event to the list via EvenementClub
        public static void CreateEvent(EvenementClub evenementClub)
        {
            listeEvenementClub.Add(evenementClub);
        }

        // remove an event from the list via EvenementClub
        public static void RemoveEvent(EvenementClub evenementClub)
        {
            listeEvenementClub.Remove(evenementClub);
        }

        // remove an event from the list via the Id
        public static void RemoveEvent(int id)
        {
            EvenementClub evenementClub = ListeEvenementClub.listeEvenementClub.FirstOrDefault(mb => mb.Id == id); // retrieve the user having this given Id
            listeEvenementClub.Remove(evenementClub);
        }
    }
}
