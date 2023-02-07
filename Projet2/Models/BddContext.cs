using System;
using Microsoft.EntityFrameworkCore;

namespace Projet2.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<InfosPersonnelles> InfosPersonnelles { get; set; }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Compte> Comptes { get; set; }
        public DbSet<OffreAbonnement> OffreAbonnements { get; set; }

        public DbSet<Activite> Activites { get; set; }

        public DbSet<EvenementClub> EvenementClubs { get; set; }

        public DbSet<Stage> Stages { get; set; }

        public DbSet<Voyage> Voyages { get; set; }

        public DbSet<SortieAdherent> SortieAdherents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=BDDprojet2");
        }

        //public void InitialiseDb()
        //{
        //    this.Database.EnsureDeleted();
        //    this.Database.EnsureCreated();
        //    this.SaveChanges();
        //}
        public void InitialiseDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
            Adresse adresse = new Adresse() { Id = 1, CodePostal = 75014, NomVille = "Paris", NomRue = "pigeon" };
            InfosPersonnelles infosperso = new InfosPersonnelles() { Id = 1, Nom = "Paubel", Prenom = "Paul", DateNaissance = new DateTime(2008, 3, 15), AdresseId = 1 };
            Compte compte = new Compte() { Id = 1, AdressEmail = "papa@gmail.com", MotDePasse = "123" };
            Utilisateur utilisateur = new Utilisateur() { Id = 1, InfosPersonnellesId = 1, CompteId = 1 };
            OffreAbonnement offreAbonnement = new OffreAbonnement() { Id = 1, DescriptionOffre = "Offre Annuelle sans engagement : 680.75 Euros", TypeOffre = "Annuelle", DureeOffreMois = 12, Prix = 680.75 };
            OffreAbonnement offreAbonnement2 = new OffreAbonnement() { Id = 2, DescriptionOffre = "Offre Mensuelle sans engagement : 69.99 Euros", TypeOffre = "Mensuelle", DureeOffreMois = 1, Prix = 69.99 };
            OffreAbonnement offreAbonnement3 = new OffreAbonnement() { Id = 3, DescriptionOffre = "Forfait Mensuelle : 49.99 Euros", TypeOffre = "Mensuelle", DureeOffreMois = 1, Prix = 49.99 };

            Stage stage = new Stage() { Id = 1, NomStage = "Stage1", DateStage = new DateTime(2023, 3, 23), DescriptionStage = "Stage vol plané", LieuStage = "Annemasse", DureeStageHeure = 3, NiveauRequisStage = 2, NombrePlaceStage = 12, PrixStage = 49.99 };
            Voyage voyage = new Voyage() { Id = 1, NomVoyage = "Voyage1", DateVoyage = new DateTime(2023, 3, 15), DescriptionVoyage = "Voyage bapteme", LieuVoyage = "Bordeaux", DureeVoyageHeure = 3, NiveauRequisVoyage = 3, NombrePlaceVoyage = 20, PrixVoyage = 79.99 };
            SortieAdherent sortieAdherent = new SortieAdherent() { Id = 1, NomSortie = "Sortie1", DateSortie = new DateTime(2023, 4, 28), DescriptionSortie = "Decouverte vin de Alexandre", LieuSortie = "Bordeaux", NomLeader = "Alexandre", TypeSortie = "Ballade" };
            EvenementClub evenementClub1 = new EvenementClub { Id = 1, StageId = 1, Stage = stage };
            EvenementClub evenementClub2 = new EvenementClub { Id = 2, VoyageId = 1, Voyage = voyage };

            Activite activite1 = new Activite() { Id = 1, EvenementClubId = 1, EvenementClub = evenementClub1 };
            Activite activite2 = new Activite() { Id = 2, EvenementClubId = 2, EvenementClub = evenementClub2 };
            Activite activite3 = new Activite() { Id = 3, SortieAdherentId = 1, SortieAdherent = sortieAdherent };

            this.Adresses.Add(adresse);
            this.InfosPersonnelles.Add(infosperso);
            this.Comptes.Add(compte);
            this.Utilisateurs.Add(utilisateur);
            this.OffreAbonnements.Add(offreAbonnement);
            this.OffreAbonnements.Add(offreAbonnement2);
            this.OffreAbonnements.Add(offreAbonnement3);
            this.Activites.Add(activite1);
            this.Activites.Add(activite2);
            this.Activites.Add(activite3);
            

            this.SaveChanges();


            
        }

    }
}
