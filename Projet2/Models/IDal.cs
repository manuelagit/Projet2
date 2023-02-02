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

        List<OffreAbonnement> GetOfferCatalog();
        int CreateOffreAbonnements(string descriptionOffre, int dureeOffreMois, string typeOffre, double prix);
        int CreateOffreAbonnements(OffreAbonnement offreAbonnement);

    }
}

