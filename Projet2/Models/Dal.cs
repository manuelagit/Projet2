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

        public void RemoveOffreAbonnements(OffreAbonnement offreAbonnement)
        {
            _bddContext.OffreAbonnements.Remove(offreAbonnement);
            _bddContext.SaveChanges();
        }






        public List<Activite> GetActivityList()
        {
            return _bddContext.Activites.ToList(); // charge + jointure
        }

        public List<EvenementClub> GetEvenementClubList()
        {
            return _bddContext.EvenementClubs.ToList();
        }

        public List<Activite> StageList()
        {
            return _bddContext.Activites.Include(U => U.EvenementClub.Stage).ToList();
        }

        public List<Activite> VoyageList()
        {
            return _bddContext.Activites.Include(U => U.EvenementClub.Voyage).ToList();
        }

        public List<Activite> SortieAdherentList()
        {
            return _bddContext.Activites.Include(U => U.SortieAdherent).ToList();
        }

        public int CreateEvenementClub(EvenementClub evenementClub)
        {
            _bddContext.EvenementClubs.Add(evenementClub);
            _bddContext.SaveChanges();
            return evenementClub.Id;
        }

        public int CreateEvenementClub(int idEvenementClub)
        {
            Activite activite = new Activite { EvenementClubId = idEvenementClub };
            _bddContext.Activites.Add(activite);
            _bddContext.SaveChanges();
            return activite.Id;
        }

        public int CreateStage(Stage stage)
        {
            _bddContext.Stages.Add(stage);
            _bddContext.SaveChanges();
            return stage.Id;
        }

        public int CreateStage(int idStage)
        {
            EvenementClub evenementClub = new EvenementClub { StageId = idStage };
            _bddContext.EvenementClubs.Add(evenementClub);
            _bddContext.SaveChanges();
            return evenementClub.Id;
        }

        public int CreateVoyage(Voyage voyage)
        {
            _bddContext.Voyages.Add(voyage);
            _bddContext.SaveChanges();
            return voyage.Id;
        }

        public int CreateVoyage(int idVoyage)
        {
            EvenementClub evenementClub = new EvenementClub { VoyageId = idVoyage };
            _bddContext.EvenementClubs.Add(evenementClub);
            _bddContext.SaveChanges();
            return evenementClub.Id;
        }

        public int CreateSortieAdherent(SortieAdherent sortieAdherent)
        {
            _bddContext.SortieAdherents.Add(sortieAdherent);
            _bddContext.SaveChanges();
            return sortieAdherent.Id;
        }

        public int CreateSortieAdherent(int idSortieAdherent)
        {
            Activite activite = new Activite { SortieAdherentId = idSortieAdherent };
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

        public int ModifyActivite(Activite activite)
        {
            _bddContext.Activites.Update(activite);
            _bddContext.SaveChanges();
            return activite.Id;
        }

        public void ModifyActivite(int Id)
        {
            Activite activite = _bddContext.Activites.Find(Id);
            if (activite != null)
            {
                _bddContext.Activites.Update(activite);
                _bddContext.SaveChanges();
            }
        }


        public void RemoveActivite(Activite activite)
        {
            if (activite != null)
            {
                EvenementClub tmpEvenementClub = activite.EvenementClub;
                SortieAdherent tmpSortieAdherent = activite.SortieAdherent;
                Stage tmpStage = activite.EvenementClub.Stage;
                Voyage tmpVoyage = activite.EvenementClub.Voyage;

                activite.EvenementClubId = 0;
                _bddContext.Activites.Remove(activite);
                _bddContext.EvenementClubs.Remove(tmpEvenementClub);
                _bddContext.SortieAdherents.Remove(tmpSortieAdherent);
                _bddContext.Stages.Remove(tmpStage);
                _bddContext.Voyages.Remove(tmpVoyage);

                _bddContext.SaveChanges();
            }
        }




    }
}

