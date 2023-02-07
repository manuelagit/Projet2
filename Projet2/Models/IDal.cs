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
        void RemoveOffreAbonnements(OffreAbonnement offreAbonnement);


        List<Activite> GetActivityList();
        int CreateActivite(Activite activite);
        int ModifyActivite(Activite activite);
        void ModifyActivite(int Id);

        void RemoveActivite(Activite activite);


        List<EvenementClub> GetEvenementClubList();
        int CreateEvenementClub(EvenementClub evenementClub);
        int CreateEvenementClub(int idEvenementClub);

        List<Activite> StageList();
        int CreateStage(Stage stage);
        int CreateStage(int idStage);

        List<Activite> VoyageList();
        int CreateVoyage(Voyage voyage);
        int CreateVoyage(int idVoyage);

        List<Activite> SortieAdherentList();
        int CreateSortieAdherent(SortieAdherent sortieAdherent);
        int CreateSortieAdherent(int idSortieAdherent);



    }
}

