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
        public DbSet<Adherent> Adherents { get; set; }

        public DbSet<Activite> Activites { get; set; }

        public DbSet<EvenementClub> EvenementClubs { get; set; }

        public DbSet<SortieAdherent> SortieAdherents { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrrrrr;database=BDDprojet2");
        }

        public void InitialiseDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
            Adresse adresse = new Adresse() { Id = 1, CodePostal = 75014, NomVille = "Paris", NomRue = "pigeon", NumeroRue = 48 };
            InfosPersonnelles infosperso = new InfosPersonnelles() { Id = 1, Nom = "Paubel", Prenom = "Paul", DateNaissance = new DateTime(2008, 3, 15), AdresseId = 1 };
            Compte compte = new Compte() { Id = 1, AdressEmail = "papa@gmail.com", MotDePasse = "123" };
            Utilisateur utilisateur = new Utilisateur() { Id = 1, InfosPersonnellesId = 1, CompteId = 1 };


            OffreAbonnement offreAbonnement = new OffreAbonnement() { Id = 1, DescriptionOffre = "Avec notre abonnement annuel, vous bénéficiez d'un accès à notre plateforme à compter du jour de votre inscription, valable jusqu'à la même date de l'année suivante.", TypeOffre = "Annuel", DureeOffreMois = 12, Prix = 680.00 };
            OffreAbonnement offreAbonnement2 = new OffreAbonnement() { Id = 2, DescriptionOffre = "Avec notre abonnement mensuel, vous bénéficiez d'un accès à notre plateforme renouvelable 6 mois minimum, payable par mensualité.", TypeOffre = "Mensuel", DureeOffreMois = 6, Prix = 70.00 };




            ///// AVL
            Adresse adresseClubAVL = new Adresse() { Id = 4, CodePostal = 38870, NomVille = "Annecy", NomRue = "rue Daudet", NumeroRue = 43 };
            InfosClub infosClubAVL = new InfosClub() { Id = 4, NomClub = "Annecy Vol Libre", AdresseId = 4, urlLogo = "logoAVL.png", DescriptionClub = "Le club de vol libre Gessien (FFVL n°03173) est une association qui est super dynamique et où l’on est super bien accueilli.\n\nOn y trouve de tout, du débutant au vieux baroudeur qui connaît le Jura comme sa poche et qui se fera un plaisir de vous indiquer les pièges à éviter et les bons thermiques à exploiter pour crosser jusqu’à Bellegarde.\n\nIls s’occupent de l’entretien des aires de décollage et d’atterrissage*, organisent des manifestations (Rallye de la Saucisse), des formations de sécurité (soirée repliage de secours avec l’aide de professionnels bénévoles), etc.\n\nVous pouvez prendre contact avec le club au travers de la page FFVL (en cliquant ici) ou en remplissant directement le formulaire ci-dessous.", titreClub = "Bienvenue sur Annecy Vol Libre" };
            Compte compteClubAVL = new Compte() { Id = 4, AdressEmail = "avl@gmail.com", MotDePasse = "12EEE3" };
            Club clubAVL = new Club() { Id = 4, CompteId = 4, InfosClubId = 4 };

            ///// Prevol
            Adresse adresseClubPrevol = new Adresse() { Id = 5, CodePostal = 38870, NomVille = "St-Hilaire-du-Touvet", NomRue = "rue Daudet", NumeroRue = 43 };
            InfosClub infosClubPrevol = new InfosClub() { Id = 5, NomClub = "Prevol", AdresseId = 4, urlLogo = "logoPrevol.png", DescriptionClub = "Le club de vol libre Gessien (FFVL n°03173) est une association qui est super dynamique et où l’on est super bien accueilli.\n\nOn y trouve de tout, du débutant au vieux baroudeur qui connaît le Jura comme sa poche et qui se fera un plaisir de vous indiquer les pièges à éviter et les bons thermiques à exploiter pour crosser jusqu’à Bellegarde.\n\nIls s’occupent de l’entretien des aires de décollage et d’atterrissage*, organisent des manifestations (Rallye de la Saucisse), des formations de sécurité (soirée repliage de secours avec l’aide de professionnels bénévoles), etc.\n\nVous pouvez prendre contact avec le club au travers de la page FFVL (en cliquant ici) ou en remplissant directement le formulaire ci-dessous.", titreClub = "Bienvenue chez Prevol" };
            Compte compteClubPrevol = new Compte() { Id = 5, AdressEmail = "prevol@gmail.com", MotDePasse = "12EEE3" };
            Club clubPrevol = new Club() { Id = 5, CompteId = 5, InfosClubId = 5 };

            ///// Air Alpin
            Adresse adresseClubAirAlpin = new Adresse() { Id = 7, CodePostal = 38870, NomVille = "St-Hilaire-du-Touvet", NomRue = "rue Daudet", NumeroRue = 43 };
            InfosClub infosClubAirAlpin = new InfosClub() { Id = 7, NomClub = "Air Alpin", AdresseId = 4, urlLogo = "logoAA.png", DescriptionClub = "Le club de vol libre Gessien (FFVL n°03173) est une association qui est super dynamique et où l’on est super bien accueilli.\n\nOn y trouve de tout, du débutant au vieux baroudeur qui connaît le Jura comme sa poche et qui se fera un plaisir de vous indiquer les pièges à éviter et les bons thermiques à exploiter pour crosser jusqu’à Bellegarde.\n\nIls s’occupent de l’entretien des aires de décollage et d’atterrissage*, organisent des manifestations (Rallye de la Saucisse), des formations de sécurité (soirée repliage de secours avec l’aide de professionnels bénévoles), etc.\n\nVous pouvez prendre contact avec le club au travers de la page FFVL (en cliquant ici) ou en remplissant directement le formulaire ci-dessous.", titreClub = "Bienvenue chez Air Alpin" };
            Compte compteClubAirAlpin = new Compte() { Id = 7, AdressEmail = "airalpin@gmail.com", MotDePasse = "12EEE3" };
            Club clubAirAlpin = new Club() { Id = 7, CompteId = 7, InfosClubId = 7 };


            ///// CVLS
            Adresse adresseClubCVLS = new Adresse() { Id = 6, CodePostal = 38870, NomVille = "Annemasse", NomRue = "rue Daudet", NumeroRue = 43 };
            InfosClub infosClubCVLS = new InfosClub() { Id = 6, NomClub = "Club de Vol Libre du Salève", AdresseId = 4, urlLogo = "logoCVLS.png", DescriptionClub = "Le club de vol libre Gessien (FFVL n°03173) est une association qui est super dynamique et où l’on est super bien accueilli.\n\nOn y trouve de tout, du débutant au vieux baroudeur qui connaît le Jura comme sa poche et qui se fera un plaisir de vous indiquer les pièges à éviter et les bons thermiques à exploiter pour crosser jusqu’à Bellegarde.\n\nIls s’occupent de l’entretien des aires de décollage et d’atterrissage*, organisent des manifestations (Rallye de la Saucisse), des formations de sécurité (soirée repliage de secours avec l’aide de professionnels bénévoles), etc.\n\nVous pouvez prendre contact avec le club au travers de la page FFVL (en cliquant ici) ou en remplissant directement le formulaire ci-dessous.", titreClub = "Bienvenue au Club de Vol Libre du Salève !" };
            Compte compteClubCVLS = new Compte() { Id = 6, AdressEmail = "CVLS@gmail.com", MotDePasse = "12EEE3" };
            Club clubCVLS = new Club() { Id = 6, CompteId = 6, InfosClubId = 6 };



            Facturation facturation = new Facturation() { Id = 1, NomFacturation = "Paubel", PrenomFacturation = "Paul", VilleFacturation = "Paris", AdresseFacturation = "11 rue des pigeons", CodePostalFacturation = "75000", PaysFacturation = "France", TelephoneFacturation = "0622113344", ClubId=5};
            Paiement paiement = new Paiement() { Id = 1, NumeroCB = "1111222233334444",DateExpiration= new DateTime(2026,12,1),CodeDeSecurite=123,FacturationId=1 };


            /*Stage stage = new Stage() { Id = 1, NomStage = "Stage1", DateStage = new DateTime(2023, 3, 23), DescriptionStage = "Stage vol plané", LieuStage = "Annemasse", DureeStageHeure = 3, NiveauRequisStage = 2, NombrePlaceStage = 12, PrixStage = 49.99 };
            Voyage voyage = new Voyage() { Id = 1, NomVoyage = "Voyage1", DateVoyage = new DateTime(2023, 3, 15), DescriptionVoyage = "Voyage bapteme", LieuVoyage = "Bordeaux", DureeVoyageHeure = 3, NiveauRequisVoyage = 3, NombrePlaceVoyage = 20, PrixVoyage = 79.99 };
            SortieAdherent sortieAdherent = new SortieAdherent() { Id = 1, NomSortie = "Sortie1", DateSortie = new DateTime(2023, 4, 28), DescriptionSortie = "Decouverte vin de Alexandre", LieuSortie = "Bordeaux", NomLeader = "Alexandre", TypeSortie = "Ballade" };
            EvenementClub evenementClub1 = new EvenementClub { Id = 1, StageId = 1, Stage = stage };
            EvenementClub evenementClub2 = new EvenementClub { Id = 2, VoyageId = 1, Voyage = voyage };*/

            EvenementClub evenement1 = new EvenementClub() { Id =1, NiveauRequis = 1, Prix = 45.3};
            EvenementClub evenement2 = new EvenementClub() { Id = 2, NiveauRequis = 1, Prix = 50 };
            SortieAdherent sortieAdherent1 = new SortieAdherent() { Id = 1, NomLeader = "Alexandre", Telephone = "0645857812" };
            

            Activite activite1 = new Activite() { Id = 1, EvenementClubId = 1,  NomActivite = "Voyage Maroc", DateDebutActivite = new DateTime(2023/03/18), DateFinActivite = new DateTime(2023 / 03 / 18), DescriptionActivite = "Stage perfectionnement", LieuActivite = "Maroc", NombrePlaceActivite = 12, TypeActivite = "EvenementClub", ClubId = 5, EvenementClub = evenement1 };
            Activite activite2 = new Activite() { Id = 2, EvenementClubId = 2, NomActivite = "Voyage Algerie", DateDebutActivite = new DateTime(2023 / 03 / 18), DateFinActivite = new DateTime(2023 / 03 / 18), DescriptionActivite = "Stage aprofondissement", LieuActivite = "Algerie", NombrePlaceActivite = 20, TypeActivite = "EvenementClub", ClubId = 6, EvenementClub = evenement2 };
            Activite activite3 = new Activite() { Id = 3, SortieAdherentId = 1, NomActivite = "Voyage découverte vin", DateDebutActivite = new DateTime(2023 / 03 / 18), DateFinActivite = new DateTime(2023 / 03 / 18), DescriptionActivite = "Decouverte vin Alexandre", LieuActivite = "Bordeaux", NombrePlaceActivite = 5, TypeActivite = "SortieAdherent", ClubId = 6, SortieAdherent = sortieAdherent1 };

            Adherent adherent1 = new Adherent() { Id = 1, ClubId = 6, UtilisateurId=1 };


            this.Adresses.Add(adresse);
            this.InfosPersonnelles.Add(infosperso);
            this.Comptes.Add(compte);
            this.Utilisateurs.Add(utilisateur);

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

            this.Facturations.Add(facturation);
            this.Paiements.Add(paiement);

            this.SaveChanges();

        }


    }
}
