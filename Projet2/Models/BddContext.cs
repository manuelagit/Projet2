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

        public DbSet<Activite> Activites { get; set; }

        public DbSet<EvenementClub> EvenementClubs { get; set; }

        public DbSet<SortieAdherent> SortieAdherents { get; set; }


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


            OffreAbonnement offreAbonnement = new OffreAbonnement() { Id = 1, DescriptionOffre = "Avec notre abonnement annuel, vous bénéficiez d'un accès à notre plateforme à compter du jour de votre inscription, valable jusqu'à la même date de l'année suivante.", TypeOffre = "Annuel", DureeOffreMois = 12, Prix = 680.00 };
            OffreAbonnement offreAbonnement2 = new OffreAbonnement() { Id = 2, DescriptionOffre = "Avec notre abonnement mensuel, vous bénéficiez d'un accès à notre plateforme renouvelable 6 mois minimum, payable par mensualité.", TypeOffre = "Mensuel", DureeOffreMois = 6, Prix = 70.00 };

            Adresse adresseClub = new Adresse() { Id = 3, CodePostal = 11170, NomVille = "Gex", NomRue = "rue alphonse", NumeroRue = 4};
            InfosClub infosClub = new InfosClub() { Id = 1, NomClub = "VLG", AdresseId = 3 };

            Compte compteClub = new Compte() { Id =3, AdressEmail = "vlg@gmail.com", MotDePasse = "123" };
            Club club = new Club() { Id = 3, CompteId = 3, InfosClubId = 3};

            Adresse adresseClubAVL = new Adresse() { Id = 4, CodePostal = 38870, NomVille = "Annecy", NomRue = "rue Daudet", NumeroRue = 43 };
            InfosClub infosClubAVL = new InfosClub() { Id = 4, NomClub = "Annecy Vol Libre", AdresseId = 4, urlLogo = "~/Images/btnValider.png", DescritpionClub = "voici notre club", titreClub = "Mon super club" };


            Compte compteClubAVL = new Compte() { Id = 4, AdressEmail = "avl@gmail.com", MotDePasse = "12EEE3" };
            Club clubAVL = new Club() { Id = 4, CompteId = 4, InfosClubId = 4 };

            Facturation facturation = new Facturation() { Id = 1, NomFacturation = "Paubel", PrenomFacturation = "Paul", VilleFacturation = "Paris", AdresseFacturation = "11 rue des pigeons", CodePostalFacturation = "75000", PaysFacturation = "France", TelephoneFacturation = "0622113344", };
            Paiement paiement = new Paiement() { Id = 1, NumeroCB = "1111222233334444",DateExpiration= new DateTime(2026,12,1),CodeDeSecurite=123,FacturationId=1 };


            /*Stage stage = new Stage() { Id = 1, NomStage = "Stage1", DateStage = new DateTime(2023, 3, 23), DescriptionStage = "Stage vol plané", LieuStage = "Annemasse", DureeStageHeure = 3, NiveauRequisStage = 2, NombrePlaceStage = 12, PrixStage = 49.99 };
            Voyage voyage = new Voyage() { Id = 1, NomVoyage = "Voyage1", DateVoyage = new DateTime(2023, 3, 15), DescriptionVoyage = "Voyage bapteme", LieuVoyage = "Bordeaux", DureeVoyageHeure = 3, NiveauRequisVoyage = 3, NombrePlaceVoyage = 20, PrixVoyage = 79.99 };
            SortieAdherent sortieAdherent = new SortieAdherent() { Id = 1, NomSortie = "Sortie1", DateSortie = new DateTime(2023, 4, 28), DescriptionSortie = "Decouverte vin de Alexandre", LieuSortie = "Bordeaux", NomLeader = "Alexandre", TypeSortie = "Ballade" };
            EvenementClub evenementClub1 = new EvenementClub { Id = 1, StageId = 1, Stage = stage };
            EvenementClub evenementClub2 = new EvenementClub { Id = 2, VoyageId = 1, Voyage = voyage };*/

            EvenementClub evenement1 = new EvenementClub() { Id =1, NiveauRequis = 1, Prix = 45.3};
            EvenementClub evenement2 = new EvenementClub() { Id = 2, NiveauRequis = 1, Prix = 50 };
            SortieAdherent sortieAdherent1 = new SortieAdherent() { Id = 1, NomLeader = "Alexandre", Telephone = "0645857812" };
            

            Activite activite1 = new Activite() { Id = 1, EvenementClubId = 1,  NomActivite = "Voyage Maroc", DateActivite = "Du 10 au 20 Mars", DescriptionActivite = "Stage perfectionnement", LieuActivite = "Maroc", NombrePlaceActivite = 12, TypeActivite = "EvenementClub", ClubId = 3, EvenementClub = evenement1 };
            Activite activite2 = new Activite() { Id = 2, EvenementClubId = 2, NomActivite = "Voyage Algerie", DateActivite = "Du 14 au 22 Mai", DescriptionActivite = "Stage aprofondissement", LieuActivite = "Algerie", NombrePlaceActivite = 20, TypeActivite = "EvenementClub", ClubId = 3, EvenementClub = evenement2 };
            Activite activite3 = new Activite() { Id = 3, SortieAdherentId = 1, NomActivite = "Voyage découverte vin", DateActivite = "Du 20 au 23 juin", DescriptionActivite = "Decouverte vin Alexandre", LieuActivite = "Bordeaux", NombrePlaceActivite = 5, TypeActivite = "SortieAdherent", ClubId = 3, SortieAdherent = sortieAdherent1 };



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

            this.Activites.Add(activite1);
            this.Activites.Add(activite2);
            //this.Activites.Add(activite3);

            this.Facturations.Add(facturation);
            this.Paiements.Add(paiement);
            /*try
            {*/
                this.SaveChanges();
            /*}
            catch { }*/
        }


    }
}
