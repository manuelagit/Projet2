using System;
using System.Collections.Generic;
using System.Linq;

namespace Projet2.Models
{
    public class ListeActivites
    {
        public static List<Activite> listeActivites = new List<Activite>();

        // get the list of all activities in the bdd
        public static List<Activite> GetActivityList()
        {
            return listeActivites;
        }

        // add an event to the list via id, EvenementClub
        public static void CreateActivity(int id, EvenementClub evenementClub)
        {
            listeActivites.Add(new Activite() { Id = id, EvenementClub = evenementClub });
        }

        // add a travel to the list via id, SortieAdherent
        public static void CreateActivity(int id, SortieAdherent sortieAdherent)
        {
            listeActivites.Add(new Activite() { Id = id, SortieAdherent  = sortieAdherent });
        }

        // add an activity to the list via Activite
        public static void CreateActivity(Activite activite)
        {
            listeActivites.Add(activite);
        }

        // remove an activity from the list via Activity
        public static void RemoveActivity(Activite activite)
        {
            listeActivites.Remove(activite);
        }

        // remove an offer from the list via the Id
        public static void RemoveActivity(int id)
        {
            Activite activite = ListeActivites.listeActivites.FirstOrDefault(mb => mb.Id == id); // retrieve the user having this given Id
            listeActivites.Remove(activite);
        }
    }
}
