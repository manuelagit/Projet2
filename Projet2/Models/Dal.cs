using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Projet2.Models
{
	public class Dal : IDal
	{
        private BddContext _bddContext;
        public Dal()
        {
            _bddContext = new BddContext();
        }

        public void DeleteCreateDatabase()
        {
            _bddContext.Database.EnsureDeleted();
            _bddContext.Database.EnsureCreated();
        }

        public void Dispose() //Removing the bdd
        {
            _bddContext.Dispose();
        }

        public List<Utilisateur> GetUsersList()
        {
            return _bddContext.Utilisateurs.Include(U => U.InfosPersonnelles).Include(U => U.InfosPersonnelles.Adresse).Include(U => U.Compte).ToList(); // charge + jointure
        }
       

        public int CreateInfosPersonnelles(InfosPersonnelles infosPersonnelles)
        {
            _bddContext.InfosPersonnelles.Add(infosPersonnelles);
            _bddContext.SaveChanges();
            return infosPersonnelles.Id;
        }

        public int CreateCompte(Compte compte)
        {
            _bddContext.Comptes.Add(compte);
            _bddContext.SaveChanges();
            return compte.Id;
        }

        public int CreateUser(int idCompte, int IdInfosPersonnelles)
        {
            Utilisateur utilisateur = new Utilisateur { CompteId = idCompte, InfosPersonnellesId = IdInfosPersonnelles };
            _bddContext.Utilisateurs.Add(utilisateur);
            _bddContext.SaveChanges();
            return utilisateur.Id;
        }



        public int CreateUser(Utilisateur utilisateur)
        {
            _bddContext.Utilisateurs.Add(utilisateur);
            _bddContext.SaveChanges();
            return utilisateur.Id;
        }


        public void ModifyUser(Utilisateur utilisateur)
        {
            _bddContext.Utilisateurs.Update(utilisateur);
            _bddContext.SaveChanges();
        }

        public void ModifyUser(int Id, int idCompte, int IdInfosPersonnelles)
        {
            Utilisateur utilisateur = _bddContext.Utilisateurs.Find(Id);
            if (utilisateur != null)
            {
                utilisateur.CompteId = idCompte;
                utilisateur.InfosPersonnellesId = IdInfosPersonnelles;
                utilisateur.InfosPersonnelles.Nom = utilisateur.InfosPersonnelles.Nom;
                utilisateur.InfosPersonnelles.Prenom = utilisateur.InfosPersonnelles.Prenom;

                _bddContext.SaveChanges();
            }
        }


        public List<OffreAbonnement> GetOfferCatalog()
        {
            return _bddContext.OffreAbonnements.ToList();
        }

        public int CreateOffreAbonnements(string descriptionOffre, int dureeOffreMois, string typeOffre, double prix)
        {
            OffreAbonnement offreAbonnement = new OffreAbonnement { DescriptionOffre = descriptionOffre, DureeOffreMois = dureeOffreMois, TypeOffre = typeOffre, Prix = prix };
            _bddContext.OffreAbonnements.Add(offreAbonnement);
            _bddContext.SaveChanges();
            return offreAbonnement.Id;
        }

        public int CreateOffreAbonnements(OffreAbonnement offreAbonnement)
        {
            _bddContext.OffreAbonnements.Add(offreAbonnement);
            _bddContext.SaveChanges();
            return offreAbonnement.Id;
        }

        public void ModifyOffreAbonnements(OffreAbonnement offreAbonnement)
        {
            _bddContext.OffreAbonnements.Update(offreAbonnement);
            _bddContext.SaveChanges();
        }

        public void ModifyOffreAbonnements(int Id, string descriptionOffre, int dureeOffreMois, string typeOffre, double prix)
        {
            OffreAbonnement offreAbonnement = _bddContext.OffreAbonnements.Find(Id);
            if (offreAbonnement != null)
            {
                offreAbonnement.DescriptionOffre= descriptionOffre;
                offreAbonnement.DureeOffreMois= dureeOffreMois;
                offreAbonnement.TypeOffre= typeOffre;
                offreAbonnement.Prix= prix;
                _bddContext.SaveChanges();
            }


        }
    }
}

