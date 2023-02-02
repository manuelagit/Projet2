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
        public DbSet<Club> Clubs { get; set; }
        public DbSet<InfosClub> InfosClubs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrrrrr;database=BDDprojet2");
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
            Adresse adresse = new Adresse() { Id = 1, CodePostal = 75014, NomVille = "Paris", NomRue = "pigeon", NumeroRue = 48 };
            InfosPersonnelles infosperso = new InfosPersonnelles() { Id = 1, Nom = "Paubel", Prenom = "Paul", DateNaissance = new DateTime(2008, 3, 15), AdresseId = 1 };
            Compte compte = new Compte() { Id = 1, AdressEmail = "papa@gmail.com", MotDePasse = "123" };
            Utilisateur utilisateur = new Utilisateur() { Id = 1, InfosPersonnellesId = 1, CompteId = 1 };

            OffreAbonnement offreAbonnement = new OffreAbonnement() { Id = 1, DescriptionOffre = "Quelques années après la publication de cet ouvrage, force est de constater que le mot d’ordre « Expérimenter plutôt que posséder » est plus que jamais au cœur de la relation client.", TypeOffre = "Annuelle", DureeOffreMois = 12, Prix = 680.75 };
            OffreAbonnement offreAbonnement2 = new OffreAbonnement() { Id = 2, DescriptionOffre = "Quelques années après la publication de cet ouvrage, force est de constater que le mot d’ordre « Expérimenter plutôt que posséder » est plus que jamais au cœur de la relation client.", TypeOffre = "Mensuelle", DureeOffreMois = 6, Prix = 249.99 };

            Adresse adresseClub = new Adresse() { Id = 3, CodePostal = 01170, NomVille = "Gex", NomRue = "rue alphonse", NumeroRue = 4};
            InfosClub infosClub = new InfosClub() { Id = 1, NomClub = "VLG", AdresseId = 3 };

            Compte compteClub = new Compte() { Id =3, AdressEmail = "vlg@gmail.com", MotDePasse = "123" };
            Club club = new Club() { Id = 3, CompteId = 3, InfosClubId = 3};

            this.Adresses.Add(adresse);
            this.InfosPersonnelles.Add(infosperso);
            this.Comptes.Add(compte);
            this.Utilisateurs.Add(utilisateur);
            this.OffreAbonnements.Add(offreAbonnement);
            this.OffreAbonnements.Add(offreAbonnement2);

            this.Adresses.Add(adresseClub);
            this.InfosClubs.Add(infosClub);
            this.Comptes.Add(compteClub);
            this.Clubs.Add(club);
            this.SaveChanges();


            
        }

    }
}
