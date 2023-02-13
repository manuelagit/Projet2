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

        public List<Club> GetClubsList()
        {
            return _bddContext.Clubs.Include(U => U.InfosClub).Include(U => U.InfosClub.Adresse).Include(U => U.Compte).ToList(); // charge + jointure
        }

        public int CreateInfosPersonnelles(InfosPersonnelles infosPersonnelles)
        {
            _bddContext.InfosPersonnelles.Add(infosPersonnelles);
            _bddContext.SaveChanges();
            return infosPersonnelles.Id;
        }


        public int CreateInfosClub(InfosClub infosClub)
        {
            _bddContext.InfosClubs.Add(infosClub);
            _bddContext.SaveChanges();
            return infosClub.Id;
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


        public int CreateClub(int idCompte, int IdInfosClub)
        {
            Club club = new Club { CompteId = idCompte, InfosClubId = IdInfosClub };
            _bddContext.Clubs.Add(club);
            _bddContext.SaveChanges();
            return club.Id;
        }



        public int CreateClub(Club club)
        {
            _bddContext.Clubs.Add(club);
            _bddContext.SaveChanges();
            return club.Id;
        }

        public int EspaceClubLogged(Club club)
        {
            return club.Id;
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


        public void ModifyClub(int Id)
        {
            Club club = _bddContext.Clubs.Find(Id);
            if (club != null)
            {
                _bddContext.Clubs.Update(club);
                _bddContext.SaveChanges();
            }
        }

        public int ModifyClub(Club club)
        {
            _bddContext.Clubs.Update(club);
            _bddContext.SaveChanges();
            return club.Id;
        }


        public void ModifyClubCreation(int Id)
        {
            Club club = _bddContext.Clubs.Find(Id);
            if (club != null)
            {
                _bddContext.Clubs.Update(club);
                _bddContext.SaveChanges();
            }
        }

        public int ModifyClubCreation(Club club)
        {
            _bddContext.Clubs.Update(club);
            _bddContext.SaveChanges();
            return club.Id;
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


        public void RemoveClub(Club club)
        {
            if (club != null)
            {
                Compte tmpCompte = club.Compte;
                Adresse tmpAdresse = club.InfosClub.Adresse;

                _bddContext.Clubs.Remove(club);
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
            return _bddContext.Activites.Include(U => U.EvenementClub).Include(U => U.SortieAdherent).ToList(); // charge + jointure
        }

        public List<EvenementClub> GetEvenementClubList()
        {
            return _bddContext.EvenementClubs.ToList();
        }

      

        public List<SortieAdherent> GetSortieAdherentList()
        {
            return _bddContext.SortieAdherents.ToList();
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


        //public void RemoveActivite(Activite activite)
        //{
        //    if (activite != null)
        //    {
        //        EvenementClub tmpEvenementClub = activite.EvenementClub;
        //        SortieAdherent tmpSortieAdherent = activite.SortieAdherent;
        //        Stage tmpStage = activite.EvenementClub.Stage;
        //        Voyage tmpVoyage = activite.EvenementClub.Voyage;

        //    }
        //}

        //Create Facturation
        public int CreateFacturation(string nomFacturation, string prenomFacturation, string villeFacturation, string adresseFacturation, string codePostalFacturation, string paysFacturation, string TelephoneFacturation)
        {
            Facturation facturation = new Facturation { NomFacturation = nomFacturation, PrenomFacturation = prenomFacturation, VilleFacturation = villeFacturation, AdresseFacturation = adresseFacturation, CodePostalFacturation = codePostalFacturation, PaysFacturation = paysFacturation, TelephoneFacturation = TelephoneFacturation };
            _bddContext.Facturations.Add(facturation);
            _bddContext.SaveChanges();
            return facturation.Id;
        }
        public int CreateFacturation(Facturation facturation)
        {
            _bddContext.Facturations.Add(facturation);
            _bddContext.SaveChanges();
            return facturation.Id;
        }
        //Create Payment 
        public int CreatePaiement(string numeroCB, DateTime dateExpiration, int codeDeSecurité, int facturationId)
        {
            Paiement paiement = new Paiement { NumeroCB = numeroCB, DateExpiration = dateExpiration, CodeDeSecurite = codeDeSecurité,FacturationId= facturationId };
            _bddContext.Paiements.Add(paiement);
            _bddContext.SaveChanges();
            return paiement.Id;
        }


        public int CreatePaiement(Paiement paiement)
        {
            _bddContext.Paiements.Add(paiement);
            _bddContext.SaveChanges();
            return paiement.Id;
        }

        public List<Facturation> GetFacturesList()
        {
            return _bddContext.Facturations.Include(U => U.Club).Include(U => U.Club.InfosClub).ToList();
            
        }

        public List<Adherent> GetAdherentsList()
        {
            return _bddContext.Adherents.Include(U => U.Utilisateur).Include(U=>U.Utilisateur.InfosPersonnelles).Include(U => U.Utilisateur.InfosPersonnelles.Adresse).Include(U => U.Utilisateur.Compte).ToList(); 
        }


        //public int CreateAdherent(string nomClub, int idCompte, int IdInfosPersonnelles)
        //{   
        //    Dal dal = new Dal();
        //    Utilisateur utilisateur = new Utilisateur { CompteId = idCompte, InfosPersonnellesId = IdInfosPersonnelles };
        //    Club club = dal.GetClubsList().Where(r => r.InfosClub.NomClub == nomClub).FirstOrDefault();
            
        //    Adherent adherent = new Adherent { Club = club, Utilisateur= utilisateur };

        //    CreateAdherent(adherent);
        //    return adherent.Id;
        //}


        public int CreateAdherent(Adherent adherent)
        {
            _bddContext.Adherents.Add(adherent);
            _bddContext.SaveChanges();
            return adherent.Id;
        }



    }
}

