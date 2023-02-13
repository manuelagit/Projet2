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


        List<Facturation> GetFacturesList();
        int CreateClub(Club club);
        int CreateClub(int idCompte, int IdInfosClub);
        void ModifyClub(int id);
        int ModifyClub(Club club);
        void ModifyClubCreation(int id);

        void RemoveClub(Club club);
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

        //void RemoveActivite(Activite activite);


        List<EvenementClub> GetEvenementClubList();
        int CreateEvenementClub(EvenementClub evenementClub);
        int CreateEvenementClub(int idEvenementClub);

   

        List<SortieAdherent> GetSortieAdherentList();
        int CreateSortieAdherent(SortieAdherent sortieAdherent);
        int CreateSortieAdherent(int idSortieAdherent);

        List<Adherent> GetAdherentsList();

        int CreateAdherent(Adherent adherent);

    }
}

