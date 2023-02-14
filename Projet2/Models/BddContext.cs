﻿using System;
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
        public DbSet<Adherent> Adherents { get; set; }

        public DbSet<Activite> Activites { get; set; }

        public DbSet<EvenementClub> EvenementClubs { get; set; }

        public DbSet<SortieAdherent> SortieAdherents { get; set; }

        public DbSet<Admin> Admins { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=BDDprojet2");
        }

        public void InitialiseDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
            Adresse adresse = new Adresse() { Id = 1, CodePostal = 75014, NomVille = "Paris", NomRue = "pigeon", NumeroRue = 48 };
            InfosPersonnelles infosperso = new InfosPersonnelles() { Id = 1, Nom = "Paubel", Prenom = "Paul", DateNaissance = new DateTime(1993, 3, 15), AdresseId = 1 };
            Compte compte = new Compte() { Id = 1, AdressEmail = "papa@gmail.com", MotDePasse = "123" };
            Utilisateur utilisateur = new Utilisateur() { Id = 1, InfosPersonnellesId = 1, CompteId = 1 };


            OffreAbonnement offreAbonnement = new OffreAbonnement() { Id = 1, DescriptionOffre = "Avec notre abonnement annuel, vous bénéficiez d'un accès à notre plateforme à compter du jour de votre inscription, valable jusqu'à la même date de l'année suivante.", TypeOffre = "Annuel", DureeOffreMois = 12, Prix = 680.00 };
            OffreAbonnement offreAbonnement2 = new OffreAbonnement() { Id = 2, DescriptionOffre = "Avec notre abonnement mensuel, vous bénéficiez d'un accès à notre plateforme renouvelable 6 mois minimum, payable par mensualité.", TypeOffre = "Mensuel", DureeOffreMois = 6, Prix = 70.00 };

            Adresse adresseClub = new Adresse() { Id = 3, CodePostal = 11170, NomVille = "Gex", NomRue = "rue alphonse", NumeroRue = 4};
            InfosClub infosClub = new InfosClub() { Id = 1, NomClub = "VLG", AdresseId = 3, urlLogo = "~/Images/btnValider.png", DescriptionClub = "Notre école de parapente Air et Aventure est basée à Lumbin en Isère. L’Isère, c’est The Place to Be pour la pratique du parapente. Grâce à sa position géographique, notre école jouit de la proximité de l’un des spots les plus réputés au monde, celui de Saint-Hilaire-du-Touvet ! C’est d’ailleurs de ce lieu idéal que vous effectuerez la plupart de vos vols lors de votre stage de parapente. \n\nAfin de mieux s’adapter à tous les types de pilotes ou nouveaux pilotes et leurs besoins, nous proposons 10 types de stages différents. Allant du mini-stage découverte pour les débutants jusqu’à des stages plus techniques comme des stages de cross ou de performance thermique qui s’adresse à des parapentistes plus expérimentés.  Nous proposons également des stages pour des parapentistes de niveau intermédiaire, ayant pour objectif le perfectionnement de leurs capacités et de leur mental. ", titreClub = "VLG" };

            Compte compteClub = new Compte() { Id =3, AdressEmail = "vlg@gmail.com", MotDePasse = "123" };
            Club club = new Club() { Id = 3, CompteId = 3, InfosClubId = 1};

            Adresse adresseClubAVL = new Adresse() { Id = 4, CodePostal = 38870, NomVille = "Annecy", NomRue = "rue Daudet", NumeroRue = 43 };
            InfosClub infosClubAVL = new InfosClub() { Id = 4, NomClub = "Annecy Vol Libre", AdresseId = 4, urlLogo = "~/Images/btnValider.png", DescriptionClub = "Le club de vol libre Gessien (FFVL n°03173) est une association qui est super dynamique et où l’on est super bien accueilli.\n\nOn y trouve de tout, du débutant au vieux baroudeur qui connaît le Jura comme sa poche et qui se fera un plaisir de vous indiquer les pièges à éviter et les bons thermiques à exploiter pour crosser jusqu’à Bellegarde.\n\nIls s’occupent de l’entretien des aires de décollage et d’atterrissage*, organisent des manifestations (Rallye de la Saucisse), des formations de sécurité (soirée repliage de secours avec l’aide de professionnels bénévoles), etc.\n\nVous pouvez prendre contact avec le club au travers de la page FFVL (en cliquant ici) ou en remplissant directement le formulaire ci-dessous.", titreClub = "Mon super club" };


            Compte compteClubAVL = new Compte() { Id = 4, AdressEmail = "avl@gmail.com", MotDePasse = "12EEE3" };
            Club clubAVL = new Club() { Id = 4, CompteId = 4, InfosClubId = 4 };

            Facturation facturation = new Facturation() { Id = 1, NomFacturation = "Paubel", PrenomFacturation = "Paul", VilleFacturation = "Paris", AdresseFacturation = "11 rue des pigeons", CodePostalFacturation = "75000", PaysFacturation = "France", TelephoneFacturation = "0622113344", ClubId=3};
            Paiement paiement = new Paiement() { Id = 1, NumeroCB = "1111222233334444",DateExpiration= new DateTime(2026,12,1),CodeDeSecurite=123,FacturationId=1 };


            /*Stage stage = new Stage() { Id = 1, NomStage = "Stage1", DateStage = new DateTime(2023, 3, 23), DescriptionStage = "Stage vol plané", LieuStage = "Annemasse", DureeStageHeure = 3, NiveauRequisStage = 2, NombrePlaceStage = 12, PrixStage = 49.99 };
            Voyage voyage = new Voyage() { Id = 1, NomVoyage = "Voyage1", DateVoyage = new DateTime(2023, 3, 15), DescriptionVoyage = "Voyage bapteme", LieuVoyage = "Bordeaux", DureeVoyageHeure = 3, NiveauRequisVoyage = 3, NombrePlaceVoyage = 20, PrixVoyage = 79.99 };
            SortieAdherent sortieAdherent = new SortieAdherent() { Id = 1, NomSortie = "Sortie1", DateSortie = new DateTime(2023, 4, 28), DescriptionSortie = "Decouverte vin de Alexandre", LieuSortie = "Bordeaux", NomLeader = "Alexandre", TypeSortie = "Ballade" };
            EvenementClub evenementClub1 = new EvenementClub { Id = 1, StageId = 1, Stage = stage };
            EvenementClub evenementClub2 = new EvenementClub { Id = 2, VoyageId = 1, Voyage = voyage };*/

            EvenementClub evenement1 = new EvenementClub() { Id =1, NiveauRequis = 1, Prix = 45.3};
            EvenementClub evenement2 = new EvenementClub() { Id = 2, NiveauRequis = 1, Prix = 50 };
            SortieAdherent sortieAdherent1 = new SortieAdherent() { Id = 1, NomLeader = "Alexandre", Telephone = "0645857812" };
            

            Activite activite1 = new Activite() { Id = 1, EvenementClubId = 1,  NomActivite = "Voyage Maroc", DateDebutActivite = new DateTime(2023/03/18), DateFinActivite = new DateTime(2023 / 03 / 18), DescriptionActivite = "Stage perfectionnement", LieuActivite = "Maroc", NombrePlaceActivite = 12, TypeActivite = "EvenementClub", ClubId = 3, EvenementClub = evenement1 };
            Activite activite2 = new Activite() { Id = 2, EvenementClubId = 2, NomActivite = "Voyage Algerie", DateDebutActivite = new DateTime(2023 / 03 / 18), DateFinActivite = new DateTime(2023 / 03 / 18), DescriptionActivite = "Stage aprofondissement", LieuActivite = "Algerie", NombrePlaceActivite = 20, TypeActivite = "EvenementClub", ClubId = 3, EvenementClub = evenement2 };
            Activite activite3 = new Activite() { Id = 3, SortieAdherentId = 1, NomActivite = "Voyage découverte vin", DateDebutActivite = new DateTime(2023 / 03 / 18), DateFinActivite = new DateTime(2023 / 03 / 18), DescriptionActivite = "Decouverte vin Alexandre", LieuActivite = "Bordeaux", NombrePlaceActivite = 5, TypeActivite = "SortieAdherent", ClubId = 3, SortieAdherent = sortieAdherent1 };

            Adherent adherent1 = new Adherent() { Id = 1, ClubId = 3, UtilisateurId=1 };
            Admin admin1 = new Admin() { Id = 1, UtilisateurId = 1, IsAdmin=true};

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

            this.Activites.Add(activite1);
            this.Activites.Add(activite2);
            this.Activites.Add(activite3);

            this.Facturations.Add(facturation);
            this.Paiements.Add(paiement);

            this.Admins.Add(admin1);
            this.SaveChanges();
        }


    }
}
