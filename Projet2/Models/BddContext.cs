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
            Activite activite = new Activite() { Id = 1, NomActivite = "Activite1", DateActivite = new DateTime(2023, 3, 29), DureeActiviteHeure = 3, TypeActivite = "Bâpteme air", DescriptionActivite = "Bâpteme air", LieuActivite = "Annemasse" };
            Activite activite1 = new Activite() { Id = 2, NomActivite = "Activite2", DateActivite = new DateTime(2023, 4, 15), DureeActiviteHeure = 3, TypeActivite = "Bâpteme air cross", DescriptionActivite = "Bâpteme air", LieuActivite = "Geneve" };
            EvenementClub evenementClub = new EvenementClub() { Id = 3, NomActivite = "Activite1", DateActivite = new DateTime(2023, 3, 29), DureeActiviteHeure = 3, TypeActivite = "Bâpteme air", DescriptionActivite = "Bâpteme air", LieuActivite = "Annemasse", NiveauRequis = 1, NombrePlace = 8, PrixEvenementClub = 49.99 };
            EvenementClub evenementClub1 = new EvenementClub() { Id = 4, NomActivite = "Activite2", DateActivite = new DateTime(2023, 4, 15), DureeActiviteHeure = 3, TypeActivite = "Bâpteme air cross", DescriptionActivite = "Bâpteme air", LieuActivite = "Geneve", NiveauRequis = 3, NombrePlace = 12, PrixEvenementClub = 79.99 };  

            this.Adresses.Add(adresse);
            this.InfosPersonnelles.Add(infosperso);
            this.Comptes.Add(compte);
            this.Utilisateurs.Add(utilisateur);
            this.OffreAbonnements.Add(offreAbonnement);
            this.OffreAbonnements.Add(offreAbonnement2);
            this.OffreAbonnements.Add(offreAbonnement3);
            this.Activites.Add(activite);
            this.Activites.Add(activite1);
            this.EvenementClubs.Add(evenementClub);
            this.EvenementClubs.Add(evenementClub1);


            this.SaveChanges();


            
        }

    }
}
