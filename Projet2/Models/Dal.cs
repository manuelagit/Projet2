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


        public void ModifyUser(int Id)
        {
            Utilisateur utilisateur = _bddContext.Utilisateurs.Find(Id);
            if (utilisateur != null)
            {
                _bddContext.Utilisateurs.Update(utilisateur);
                _bddContext.SaveChanges();
            }
        }

        public int ModifyUser(Utilisateur utilisateur)
        {
            _bddContext.Utilisateurs.Update(utilisateur);
            _bddContext.SaveChanges();
            return utilisateur.Id;
        }

        public void RemoveUser(Utilisateur utilisateur)
        {
            if (utilisateur != null)
            {
                Compte tmpCompte = utilisateur.Compte;
                InfosPersonnelles tmpInfos = utilisateur.InfosPersonnelles;
                Adresse tmpAdresse = utilisateur.InfosPersonnelles.Adresse;

                utilisateur.InfosPersonnellesId = 0;
                _bddContext.Utilisateurs.Remove(utilisateur);
                _bddContext.InfosPersonnelles.Remove(tmpInfos);
                _bddContext.Adresses.Remove(tmpAdresse);
                _bddContext.Comptes.Remove(tmpCompte);
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





        public List<Activite> GetActivityList()
        {
            return _bddContext.Activites.ToList();
        }

        public int CreateActivite(string nomActivite, DateTime dateActivite, string typeActivite, string descriptionActivite, string lieuActivite)
        {
            Activite activite = new Activite { NomActivite = nomActivite, DateActivite = dateActivite, TypeActivite = typeActivite, DescriptionActivite = descriptionActivite, LieuActivite = lieuActivite };
            _bddContext.Activites.Add(activite);
            _bddContext.SaveChanges();
            return activite.Id;
        }

        public int CreateActivite(Activite activite)
        {
            _bddContext.Activites.Add(activite);
            _bddContext.SaveChanges();
            return activite.Id;
        }

        public void ModifyActivite(Activite activite)
        {
            _bddContext.Activites.Update(activite);
            _bddContext.SaveChanges();
        }

        public void ModifyActivite(int Id, string nomActivite, DateTime dateActivite, string typeActivite, string descriptionActivite, string lieuActivite)
        {
            Activite activite = _bddContext.Activites.Find(Id);
            if (activite != null)
            {
                activite.NomActivite = nomActivite;
                activite.DateActivite = dateActivite;
                activite.TypeActivite = typeActivite;
                activite.DescriptionActivite = descriptionActivite;
                activite.LieuActivite = lieuActivite;
                _bddContext.SaveChanges();
            }
        }


        public List<EvenementClub> GetEvenementClubListe()
        {
            return _bddContext.EvenementClubs.ToList();
        }

        public int CreateEvenementClub(string nomActivite, DateTime dateActivite, string typeActivite, string descriptionActivite, string lieuActivite, int niveauRequis, int nombrePlace, double prixEvenementClub)
        {
            EvenementClub evenementClub = new EvenementClub { NomActivite = nomActivite, DateActivite = dateActivite, TypeActivite = typeActivite, DescriptionActivite = descriptionActivite, LieuActivite = lieuActivite, NiveauRequis = niveauRequis, NombrePlace = nombrePlace, PrixEvenementClub = prixEvenementClub };
            _bddContext.EvenementClubs.Add(evenementClub);
            _bddContext.SaveChanges();
            return evenementClub.Id;
        }

        public int CreateEvenementClub(EvenementClub evenementClub)
        {
            _bddContext.EvenementClubs.Add(evenementClub);
            _bddContext.SaveChanges();
            return evenementClub.Id;
        }

        public void ModifyEvenementClub(EvenementClub evenementClub)
        {
            _bddContext.EvenementClubs.Update(evenementClub);
            _bddContext.SaveChanges();
        }

        public void ModifyEvenementClub(int Id, string nomActivite, DateTime dateActivite, string typeActivite, string descriptionActivite, string lieuActivite, int niveauRequis, int nombrePlace, double prixEvenementClub)
        {
            EvenementClub evenementClub = _bddContext.EvenementClubs.Find(Id);
            if (evenementClub != null)
            {
                evenementClub.NomActivite = nomActivite;
                evenementClub.DateActivite = dateActivite;
                evenementClub.TypeActivite = typeActivite;
                evenementClub.DescriptionActivite = descriptionActivite;
                evenementClub.LieuActivite = lieuActivite;
                evenementClub.NiveauRequis= niveauRequis;
                evenementClub.NombrePlace= nombrePlace;
                evenementClub.PrixEvenementClub= prixEvenementClub;

                _bddContext.SaveChanges();
            }
        }
    }
}

