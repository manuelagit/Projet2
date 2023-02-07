using System;
using System.Collections.Generic;

namespace Projet2.Models
{
	public interface IDal : IDisposable
	{
        void DeleteCreateDatabase();

        List<Utilisateur> GetUsersList();
        int CreateUser(int idCompte, int IdInfosPersonnelles);
        int CreateUser(Utilisateur utilisateur);
        int ModifyUser(Utilisateur utilisateur);
        void ModifyUser(int id);
        void RemoveUser(Utilisateur utilisateur);


        int CreatePaiement(string numeroCB, DateTime dateExpiration, int codeDeSecurité, int facturationId);
        int CreatePaiement(Paiement paiement);

        int CreateFacturation(string nomFacturation, string prenomFacturation, string villeFacturation, string adresseFacturation, string codePostalFacturation, string paysFacturation, string TelephoneFacturation);
        int CreateFacturation(Facturation facturation);

        List<Club> GetClubsList();
        int CreateClub(Club club);
        int CreateClub(int idCompte, int IdInfosClub);
        void ModifyClub(int id);
        int ModifyClub(Club club);
        void RemoveClub(Club club);


    }
}

