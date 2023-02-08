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
        public DbSet<Paiement> Paiements { get; set; }
        public DbSet<Facturation> Facturations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=BDDprojet2");
        }

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

            Adresse adresseClub = new Adresse() { Id = 3, CodePostal = 11170, NomVille = "Gex", NomRue = "rue alphonse", NumeroRue = 4};
            InfosClub infosClub = new InfosClub() { Id = 1, NomClub = "VLG", AdresseId = 3 };

            Compte compteClub = new Compte() { Id =3, AdressEmail = "vlg@gmail.com", MotDePasse = "123" };
            Club club = new Club() { Id = 3, CompteId = 3, InfosClubId = 3};

            Adresse adresseClubAVL = new Adresse() { Id = 4, CodePostal = 38870, NomVille = "Annecy", NomRue = "rue Daudet", NumeroRue = 43 };
            InfosClub infosClubAVL = new InfosClub() { Id = 4, NomClub = "Annecy Vol Libre", AdresseId = 4 };

            Compte compteClubAVL = new Compte() { Id = 4, AdressEmail = "avl@gmail.com", MotDePasse = "12EEE3" };
            Club clubAVL = new Club() { Id = 4, CompteId = 4, InfosClubId = 4 };

            Facturation facturation = new Facturation() { Id = 1, NomFacturation = "Paubel", PrenomFacturation = "Paul", VilleFacturation = "Paris", AdresseFacturation = "11 rue des pigeons", CodePostalFacturation = "75000", PaysFacturation = "France", TelephoneFacturation = "0622113344" };
            Paiement paiement = new Paiement() { Id = 1, NumeroCB = "1111222233334444",DateExpiration= new DateTime(2026,12,1),CodeDeSecurite=123,FacturationId=1 };

            this.Adresses.Add(adresse);
            this.InfosPersonnelles.Add(infosperso);
            this.Comptes.Add(compte);
            this.Utilisateurs.Add(utilisateur);
            this.OffreAbonnements.Add(offreAbonnement);
            this.OffreAbonnements.Add(offreAbonnement2);

            club.Compte = compteClub;
            club.InfosClub = infosClub;
            this.Adresses.Add(adresseClub);
            this.InfosClubs.Add(infosClub);
            this.Comptes.Add(compteClub);
            this.Clubs.Add(club);
            this.Adresses.Add(adresseClubAVL);
            this.InfosClubs.Add(infosClubAVL);
            this.Comptes.Add(compteClubAVL);
            this.Clubs.Add(clubAVL);
            this.SaveChanges();

            this.Facturations.Add(facturation);
            this.Paiements.Add(paiement);
            this.SaveChanges();
        }


    }
}
