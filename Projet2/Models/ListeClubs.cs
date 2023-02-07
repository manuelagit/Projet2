using System;
using System.Collections.Generic;
using System.Linq;

namespace Projet2.Models
{
	public class ListeClubs
	{
        public static List<Club> listeClubs = new List<Club>();

        // get the list of all the users in the bdd
        public static List<Club> GetClubsList()
        {
            return listeClubs;
        }

        // add a club to the list
        public static void CreateClub(int id, Compte compte, InfosClub infosClub)
        {
            listeClubs.Add(new Club() { Id = id, Compte = compte, InfosClub = infosClub });
        }

        // add a user to the list via Club
        public static void CreateUser(Club club)
        {
            listeClubs.Add(club);
        }

        // remove a club from the list 
        public static void RemoveClub(Club club)
        {
            listeClubs.Remove(club);
        }

        // remove a user from the list via the Id
        public static void RemoveClub(int id)
        {
            Club club = ListeClubs.listeClubs.FirstOrDefault(mb => mb.Id == id); // retrieve the club having this given Id
            listeClubs.Remove(club);
        }
    }
}

