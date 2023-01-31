using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Projet2.Models
{
	public class ListeUtilisateurs
	{
        public static List<Utilisateur> listeUtilisateurs = new List<Utilisateur>();

        // get the list of all the users in the bdd
        public static List<Utilisateur> GetUsersList()
        {
            return listeUtilisateurs;
        }

        // add a user to the list via id, compte, infos
        public static void CreateUser(int id, Compte compte, InfosPersonnelles infosPersonnelles)
        {
            listeUtilisateurs.Add(new Utilisateur() { Id = id, Compte = compte, InfosPersonnelles = infosPersonnelles});
        }

        // add a user to the list via Utisateur
        public static void CreateUser(Utilisateur utilisateur)
        {
            listeUtilisateurs.Add(utilisateur);
        }


        // remove a user from the list via Utisateur
        public static void RemoveUser(Utilisateur utilisateur)
        {
            listeUtilisateurs.Remove(utilisateur);
        }

        // remove a user from the list via the Id
        public static void RemoveUser(int id)
        {
            Utilisateur utilisateur = ListeUtilisateurs.listeUtilisateurs.FirstOrDefault(mb => mb.Id == id); // retrieve the user having this given Id
            listeUtilisateurs.Remove(utilisateur);
        }

    }
}

