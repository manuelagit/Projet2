using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrrrrr;database=BDDprojet2");

        }

        public void InitialiseDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
            Adresse adresse = new Adresse() { Id = 1, CodePostal = 75014, NomVille = "PARIS", NomRue = "rue des pigeons", NumeroRue = 48 };
            InfosPersonnelles infosperso = new InfosPersonnelles() { Id = 1, Nom = "Paubel", Prenom = "Paul", DateNaissance = new DateTime(1993, 3, 15), AdresseId = 1 };
            Compte compte = new Compte() { Id = 1, AdressEmail = "papa@gmail.com", MotDePasse = "123" };
            Utilisateur utilisateur = new Utilisateur() { Id = 1, InfosPersonnellesId = 1, CompteId = 1 };


            OffreAbonnement offreAbonnement = new OffreAbonnement() { Id = 1, DescriptionOffre = "Avec notre abonnement annuel, vous bénéficiez d'un accès à notre plateforme à compter du jour de votre inscription, valable jusqu'à la même date de l'année suivante.", TypeOffre = "Annuel", DureeOffreMois = 12, Prix = 680.00 };
            OffreAbonnement offreAbonnement2 = new OffreAbonnement() { Id = 2, DescriptionOffre = "Avec notre abonnement mensuel, vous bénéficiez d'un accès à notre plateforme renouvelable 6 mois minimum, payable par mensualité.", TypeOffre = "Mensuel", DureeOffreMois = 6, Prix = 70.00 };




            ///// AVL
            Adresse adresseClubAVL = new Adresse() { Id = 7, CodePostal = 38870, NomVille = "ANNECY", NomRue = "rue Daudet", NumeroRue = 43 };
            InfosClub infosClubAVL = new InfosClub() { Id = 4, NomClub = "Annecy Vol Libre", AdresseId = 7, urlLogo = "logoAVL.png", DescriptionClub = "Le club de vol libre Gessien (FFVL n°03173) est une association qui est super dynamique et où l’on est super bien accueilli.\n\nOn y trouve de tout, du débutant au vieux baroudeur qui connaît le Jura comme sa poche et qui se fera un plaisir de vous indiquer les pièges à éviter et les bons thermiques à exploiter pour crosser jusqu’à Bellegarde.\n\nIls s’occupent de l’entretien des aires de décollage et d’atterrissage*, organisent des manifestations (Rallye de la Saucisse), des formations de sécurité (soirée repliage de secours avec l’aide de professionnels bénévoles), etc.\n\nVous pouvez prendre contact avec le club au travers de la page FFVL (en cliquant ici) ou en remplissant directement le formulaire ci-dessous.", titreClub = "Bienvenue sur Annecy Vol Libre" };
            Compte compteClubAVL = new Compte() { Id = 7, AdressEmail = "avl@gmail.com", MotDePasse = "12EEE3" };
            Club clubAVL = new Club() { Id = 4, CompteId = 7, InfosClubId = 4 };

            ///// Prevol
            Adresse adresseClubPrevol = new Adresse() { Id = 8, CodePostal = 38870, NomVille = "ST-HILAIRE-DU-TOUVET", NomRue = "rue Daudet", NumeroRue = 43 };
            InfosClub infosClubPrevol = new InfosClub() { Id = 5, NomClub = "Prevol", AdresseId = 8, urlLogo = "logoPrevol.png", DescriptionClub = "Le club de vol libre Gessien (FFVL n°03173) est une association qui est super dynamique et où l’on est super bien accueilli.\n\nOn y trouve de tout, du débutant au vieux baroudeur qui connaît le Jura comme sa poche et qui se fera un plaisir de vous indiquer les pièges à éviter et les bons thermiques à exploiter pour crosser jusqu’à Bellegarde.\n\nIls s’occupent de l’entretien des aires de décollage et d’atterrissage*, organisent des manifestations (Rallye de la Saucisse), des formations de sécurité (soirée repliage de secours avec l’aide de professionnels bénévoles), etc.\n\nVous pouvez prendre contact avec le club au travers de la page FFVL (en cliquant ici) ou en remplissant directement le formulaire ci-dessous.", titreClub = "Bienvenue chez Prevol" };
            Compte compteClubPrevol = new Compte() { Id = 8, AdressEmail = "prevol@gmail.com", MotDePasse = "hgèeeE3" };
            Club clubPrevol = new Club() { Id = 5, CompteId = 8, InfosClubId = 5 };

            ///// Air Alpin
            Adresse adresseClubAirAlpin = new Adresse() { Id = 9, CodePostal = 38870, NomVille = "ST-HILAIRE-DU-TOUVET", NomRue = "rue Daudet", NumeroRue = 43 };
            InfosClub infosClubAirAlpin = new InfosClub() { Id = 7, NomClub = "Air Alpin", AdresseId = 9, urlLogo = "logoAA.png", DescriptionClub = "Le club de vol libre Gessien (FFVL n°03173) est une association qui est super dynamique et où l’on est super bien accueilli.\n\nOn y trouve de tout, du débutant au vieux baroudeur qui connaît le Jura comme sa poche et qui se fera un plaisir de vous indiquer les pièges à éviter et les bons thermiques à exploiter pour crosser jusqu’à Bellegarde.\n\nIls s’occupent de l’entretien des aires de décollage et d’atterrissage*, organisent des manifestations (Rallye de la Saucisse), des formations de sécurité (soirée repliage de secours avec l’aide de professionnels bénévoles), etc.\n\nVous pouvez prendre contact avec le club au travers de la page FFVL (en cliquant ici) ou en remplissant directement le formulaire ci-dessous.", titreClub = "Bienvenue chez Air Alpin" };
            Compte compteClubAirAlpin = new Compte() { Id = 9, AdressEmail = "airalpin@gmail.com", MotDePasse = "totèd!a" };
            Club clubAirAlpin = new Club() { Id = 7, CompteId = 9, InfosClubId = 7 };


            ///// CVLS
            Adresse adresseClubCVLS = new Adresse() { Id = 10, CodePostal = 38870, NomVille = "ANNEMASSE", NomRue = "rue Daudet", NumeroRue = 43 };
            InfosClub infosClubCVLS = new InfosClub() { Id = 6, NomClub = "Club de Vol Libre du Salève", AdresseId = 10, urlLogo = "logoCVLS.png", DescriptionClub = "Le club de vol libre Gessien (FFVL n°03173) est une association qui est super dynamique et où l’on est super bien accueilli.\n\nOn y trouve de tout, du débutant au vieux baroudeur qui connaît le Jura comme sa poche et qui se fera un plaisir de vous indiquer les pièges à éviter et les bons thermiques à exploiter pour crosser jusqu’à Bellegarde.\n\nIls s’occupent de l’entretien des aires de décollage et d’atterrissage*, organisent des manifestations (Rallye de la Saucisse), des formations de sécurité (soirée repliage de secours avec l’aide de professionnels bénévoles), etc.\n\nVous pouvez prendre contact avec le club au travers de la page FFVL (en cliquant ici) ou en remplissant directement le formulaire ci-dessous.", titreClub = "Bienvenue au Club de Vol Libre du Salève !" };
            Compte compteClubCVLS = new Compte() { Id = 10, AdressEmail = "CVLS@gmail.com", MotDePasse = "klll'r'rs" };
            Club clubCVLS = new Club() { Id = 6, CompteId = 10, InfosClubId = 6 };



            Facturation facturation = new Facturation() { Id = 1, NomFacturation = "Paubel", PrenomFacturation = "Paul", VilleFacturation = "Paris", AdresseFacturation = "11 rue des pigeons", CodePostalFacturation = "75000", PaysFacturation = "France", TelephoneFacturation = "0622113344", ClubId=5};
            Paiement paiement = new Paiement() { Id = 1, NumeroCB = "1111222233334444",DateExpiration= new DateTime(2026,12,1),CodeDeSecurite=123,FacturationId=1 };


            /*Stage stage = new Stage() { Id = 1, NomStage = "Stage1", DateStage = new DateTime(2023, 3, 23), DescriptionStage = "Stage vol plané", LieuStage = "Annemasse", DureeStageHeure = 3, NiveauRequisStage = 2, NombrePlaceStage = 12, PrixStage = 49.99 };
            Voyage voyage = new Voyage() { Id = 1, NomVoyage = "Voyage1", DateVoyage = new DateTime(2023, 3, 15), DescriptionVoyage = "Voyage bapteme", LieuVoyage = "Bordeaux", DureeVoyageHeure = 3, NiveauRequisVoyage = 3, NombrePlaceVoyage = 20, PrixVoyage = 79.99 };
            SortieAdherent sortieAdherent = new SortieAdherent() { Id = 1, NomSortie = "Sortie1", DateSortie = new DateTime(2023, 4, 28), DescriptionSortie = "Decouverte vin de Alexandre", LieuSortie = "Bordeaux", NomLeader = "Alexandre", TypeSortie = "Ballade" };
            EvenementClub evenementClub1 = new EvenementClub { Id = 1, StageId = 1, Stage = stage };
            EvenementClub evenementClub2 = new EvenementClub { Id = 2, VoyageId = 1, Voyage = voyage };*/

            EvenementClub evenement1 = new EvenementClub() { Id =1, NiveauRequis = 1, Prix = 450};
            EvenementClub evenement2 = new EvenementClub() { Id = 2, NiveauRequis = 1, Prix = 590 };
            SortieAdherent sortieAdherentVolSoir = new SortieAdherent() { Id = 1, NomLeader = "Marc", Telephone = "0612327812" };
            SortieAdherent sortieAdherentDune = new SortieAdherent() { Id = 2, NomLeader = "Alexandre", Telephone = "0645857812" };


            Activite activite1 = new Activite() { Id = 1, EvenementClubId = 1,  NomActivite = "Voyage Maroc", DateDebutActivite = new DateTime(2023,03,18), DateFinActivite = new DateTime(2023,03,23), DescriptionActivite = "Stage perfectionnement", LieuActivite = "Maroc", NombrePlaceActivite = 12, TypeActivite = "EvenementClub", ClubId = 4, EvenementClub = evenement1 };
            Activite activite2 = new Activite() { Id = 2, EvenementClubId = 2, NomActivite = "Voyage Slovénie", DateDebutActivite = new DateTime(2023,06,19), DateFinActivite = new DateTime(2023,06,28), DescriptionActivite = "Stage cross", LieuActivite = "Slovénie", NombrePlaceActivite = 20, TypeActivite = "EvenementClub", ClubId = 6, EvenementClub = evenement2 };
            Activite activite3 = new Activite() { Id = 3, SortieAdherentId = 1, NomActivite = "Vol du soir", DateDebutActivite = new DateTime(2023,05,18), DateFinActivite = new DateTime(2023,05,28), DescriptionActivite = "Découverte vin Alexandre", LieuActivite = "Bordeaux", NombrePlaceActivite = 5, TypeActivite = "SortieAdherent", ClubId = 6, SortieAdherent = sortieAdherentVolSoir };
            Activite activite4 = new Activite() { Id = 4, SortieAdherentId = 2, NomActivite = "Wagas à la Dune", DateDebutActivite = new DateTime(2023,05,12), DateFinActivite = new DateTime(2023,05,20), DescriptionActivite = "Dune du Pilat et vin", LieuActivite = "Bordeaux", NombrePlaceActivite = 10, TypeActivite = "SortieAdherent", ClubId = 6, SortieAdherent = sortieAdherentDune };

            Admin admin1 = new Admin() { Id = 1, UtilisateurId = 1, IsAdmin=true};

            Adresse adresse2 = new Adresse() { Id = 2, CodePostal = 38570, NomVille = "THEYS", NomRue = "route de Montfarcy", NumeroRue = 704 };
            InfosPersonnelles infosperso2 = new InfosPersonnelles() { Id = 2, Nom = "Raimbault", Prenom = "Manuela", DateNaissance = new DateTime(1988, 8, 11), AdresseId = 2 };
            Compte compte2 = new Compte() { Id = 2, AdressEmail = "manuela@gmail.com", MotDePasse = "HD!Tzdzlm" };
            Utilisateur utilisateur2 = new Utilisateur() { Id = 2, InfosPersonnellesId = 2, CompteId = 2 };

            Adresse adresse3 = new Adresse() { Id = 3, CodePostal = 33000, NomVille = "BORDEAUX", NomRue = "route de la Plage", NumeroRue = 70 };
            InfosPersonnelles infosperso3 = new InfosPersonnelles() { Id = 3, Nom = "Hary", Prenom = "Alexandre", DateNaissance = new DateTime(1992, 12, 11), AdresseId = 3 };
            Compte compte3 = new Compte() { Id = 3, AdressEmail = "alex@hotmail.com", MotDePasse = "Hhzhoèé" };
            Utilisateur utilisateur3 = new Utilisateur() { Id = 3, InfosPersonnellesId = 3, CompteId = 3 };

            Adresse adresse4 = new Adresse() { Id = 4, CodePostal = 78450, NomVille = "PARIS", NomRue = "rue Montparnasse", NumeroRue = 7 };
            InfosPersonnelles infosperso4 = new InfosPersonnelles() { Id = 4, Nom = "Tiwa", Prenom = "Gabin", DateNaissance = new DateTime(1990, 12, 4), AdresseId = 4 };
            Compte compte4 = new Compte() { Id = 4, AdressEmail = "gabin@hotmail.com", MotDePasse = "fzè'fjfezu" };
            Utilisateur utilisateur4 = new Utilisateur() { Id = 4, InfosPersonnellesId = 4, CompteId = 4 };

            Adresse adresse5 = new Adresse() { Id = 5, CodePostal = 01170, NomVille = "GEX", NomRue = "rue Motelle", NumeroRue = 7 };
            InfosPersonnelles infosperso5 = new InfosPersonnelles() { Id = 5, Nom = "Durand", Prenom = "Sarah", DateNaissance = new DateTime(1995, 2, 4), AdresseId = 5 };
            Compte compte5 = new Compte() { Id = 5, AdressEmail = "durand@hotmail.com", MotDePasse = "toutdzada" };
            Utilisateur utilisateur5 = new Utilisateur() { Id = 5, InfosPersonnellesId = 5, CompteId = 5 };

            Adresse adresse6 = new Adresse() { Id = 6, CodePostal = 38000, NomVille = "GRENOBLE", NomRue = "rue du passage", NumeroRue = 78 };
            InfosPersonnelles infosperso6 = new InfosPersonnelles() { Id = 6, Nom = "Reta", Prenom = "Elsa", DateNaissance = new DateTime(1980, 12, 5), AdresseId = 6 };
            Compte compte6 = new Compte() { Id = 6, AdressEmail = "elsareta@hotmail.com", MotDePasse = "12jgjd23" };
            Utilisateur utilisateur6 = new Utilisateur() { Id = 6, InfosPersonnellesId = 6, CompteId = 6 };


            Adherent adherent1 = new Adherent() { Id = 1, ClubId = 4, UtilisateurId = 1 };
            Adherent adherent2 = new Adherent() { Id = 2, ClubId = 4, UtilisateurId = 2 };
            Adherent adherent3 = new Adherent() { Id = 3, ClubId = 5, UtilisateurId = 3 };
            Adherent adherent4 = new Adherent() { Id = 4, ClubId = 6, UtilisateurId = 4 };
            Adherent adherent5 = new Adherent() { Id = 5, ClubId = 6, UtilisateurId = 5 };
            Adherent adherent6 = new Adherent() { Id = 6, ClubId = 7, UtilisateurId = 6 };

            //Adherent alexandre = new Adherent() { Id = 2, ClubId = 6, UtilisateurId = 2 };

            this.Adherents.Add(adherent1);
            this.Adherents.Add(adherent2);
            this.Adherents.Add(adherent3);
            this.Adherents.Add(adherent4);
            this.Adherents.Add(adherent5);
            this.Adherents.Add(adherent6);

            this.Adresses.Add(adresse);
            this.InfosPersonnelles.Add(infosperso);
            this.Comptes.Add(compte);
            this.Utilisateurs.Add(utilisateur);

            this.Adresses.Add(adresse2);
            this.InfosPersonnelles.Add(infosperso2);
            this.Comptes.Add(compte2);
            this.Utilisateurs.Add(utilisateur2);

            this.Adresses.Add(adresse3);
            this.InfosPersonnelles.Add(infosperso3);
            this.Comptes.Add(compte3);
            this.Utilisateurs.Add(utilisateur3);

            this.Adresses.Add(adresse4);
            this.InfosPersonnelles.Add(infosperso4);
            this.Comptes.Add(compte4);
            this.Utilisateurs.Add(utilisateur4);

            this.Adresses.Add(adresse5);
            this.InfosPersonnelles.Add(infosperso5);
            this.Comptes.Add(compte5);
            this.Utilisateurs.Add(utilisateur5);

            this.Adresses.Add(adresse6);
            this.InfosPersonnelles.Add(infosperso6);
            this.Comptes.Add(compte6);
            this.Utilisateurs.Add(utilisateur6);

            this.OffreAbonnements.Add(offreAbonnement);
            this.OffreAbonnements.Add(offreAbonnement2);



            this.Adresses.Add(adresseClubAVL);
            this.InfosClubs.Add(infosClubAVL);
            this.Comptes.Add(compteClubAVL);
            this.Clubs.Add(clubAVL);

            this.Adresses.Add(adresseClubPrevol);
            this.InfosClubs.Add(infosClubPrevol);
            this.Comptes.Add(compteClubPrevol);
            this.Clubs.Add(clubPrevol);

            this.Adresses.Add(adresseClubAirAlpin);
            this.InfosClubs.Add(infosClubAirAlpin);
            this.Comptes.Add(compteClubAirAlpin);
            this.Clubs.Add(clubAirAlpin);

            this.Adresses.Add(adresseClubCVLS);
            this.InfosClubs.Add(infosClubCVLS);
            this.Comptes.Add(compteClubCVLS);
            this.Clubs.Add(clubCVLS);

            this.Activites.Add(activite1);
            this.Activites.Add(activite2);
            this.Activites.Add(activite3);
            this.Activites.Add(activite4);

            this.Facturations.Add(facturation);
            this.Paiements.Add(paiement);


            this.Admins.Add(admin1);
            this.SaveChanges();
        }


    }
}
