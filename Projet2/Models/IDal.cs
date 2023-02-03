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

        List<OffreAbonnement> GetOfferCatalog();
        int CreateOffreAbonnements(string descriptionOffre, int dureeOffreMois, string typeOffre, double prix);
        int CreateOffreAbonnements(OffreAbonnement offreAbonnement);
        void ModifyOffreAbonnements(OffreAbonnement offreAbonnement);
        void ModifyOffreAbonnements(int Id, string descriptionOffre, int dureeOffreMois, string typeOffre, double prix);


        List<Activite> GetActivityList();
        int CreateActivite(string nomActivite, DateTime dateActivite, string typeActivite, string descriptionActivite, string lieuActivite);
        int CreateActivite(Activite activite);
        void ModifyActivite(Activite activite);
        void ModifyActivite(int Id, string nomActivite, DateTime dateActivite, string typeActivite, string descriptionActivite, string lieuActivite);


        List<EvenementClub> GetEvenementClubListe();
        int CreateEvenementClub(string nomActivite, DateTime dateActivite, string typeActivite, string descriptionActivite, string lieuActivite, int niveauRequis, int nombrePlace, double prixEvenementClub);
        int CreateEvenementClub(EvenementClub evenementClub);
        void ModifyEvenementClub(EvenementClub evenementClub);
        void ModifyEvenementClub(int Id, string nomActivite, DateTime dateActivite, string typeActivite, string descriptionActivite, string lieuActivite, int niveauRequis, int nombrePlace, double prixEvenementClub);
    }
}

