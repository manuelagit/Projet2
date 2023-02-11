using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projet2.Models;
//using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Projet2.ViewModels;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;
using Microsoft.AspNetCore.Authentication;

namespace Projet2.Controllers
{

    public class HomeController : Controller
    {



        public IActionResult Index()
        {
            return View("WelcomeView");
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult UserList()
        {
            Dal dal = new Dal();
            List<Utilisateur> listeUsers = dal.GetUsersList(); // to be able to use the helper, instead of ViewData["ListeUtilisateurs"] = dal.GetUsersList();
            return View(listeUsers);
        }

        public IActionResult ClubList()
        {
            Dal dal = new Dal();
            List<Club> listeClubs = dal.GetClubsList(); // to be able to use the helper, instead of ViewData["ListeUtilisateurs"] = dal.GetUsersList();
            return View(listeClubs);
        }


        private readonly IWebHostEnvironment _env;

        public HomeController(IWebHostEnvironment env)
        {
            _env = env;
        }

        private bool UploadFile(IFormFile iFormFile)
        {

            if (iFormFile == null || iFormFile.Length == 0)
            {
                return false;
            }

            var filePath = _env.WebRootPath + "/Images/" + iFormFile.FileName;
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                iFormFile.CopyTo(stream);
            }
            return true;
        }

        [HttpPost]
        public IActionResult GetLogo(Club club, IFormFile iFormFile)
        {
            if (club.Id != 0)
            {
                if (iFormFile != null)
                {
                    UploadFile(iFormFile);
                    club.InfosClub.urlLogo = "~/Images/" + iFormFile.FileName;
                }
                HttpContext.SignOutAsync();
                return RedirectToAction("CreateClub");
            }
            else
            {
                return View("Error");
            }
        }


        // recovers the saved values and displays them
        public IActionResult ModifyUser(int id)
        {
            if (id != 0)
            {
                using (Dal dal = new Dal())
                {
                    Utilisateur utilisateur = dal.GetUsersList().Where(r => r.Id == id).FirstOrDefault();

                    if (utilisateur == null)
                    {
                        return View("Error");
                    }
                    return View("ModifyUser", utilisateur);
                }
            }
            return View("Error");
        }



        // sends the modified data
        [HttpPost]
        public IActionResult ModifyUser(Utilisateur utilisateur)
        {
            if (utilisateur.Id != 0)
            {
                using (Dal dal = new Dal())
                {
                    dal.ModifyUser(utilisateur);
                    return RedirectToAction("UserList");
                }
            }
            else
            {
                return View("Error");
            }
        }






        // recovers the saved values and displays them
        public IActionResult ModifyClub(int id)
        {
            if (id != 0)
            {
                using (Dal dal = new Dal())
                {
                    Club club = dal.GetClubsList().Where(r => r.Id == id).FirstOrDefault();

                    if (club == null)
                    {
                        return View("Error");
                    }
                    return View("ModifyClub", club);
                }
            }
            return View("Error");
        }



        // sends the modified data
        [HttpPost]
        public IActionResult ModifyClub(Club club)
        {
            if (club.Id != 0)
            {
                using (Dal dal = new Dal())
                {
                    dal.ModifyClub(club);
                    return RedirectToAction("ClubList");
                }
            }
            else
            {
                return View("Error");
            }
        }







        // recovers the saved values and displays them
        public IActionResult ModifyClubCreation(int id)
        {
            if (id != 0)
            {
                using (Dal dal = new Dal())
                {
                    Club club = dal.GetClubsList().Where(r => r.Id == id).FirstOrDefault();

                    if (club == null)
                    {
                        return View("Error");
                    }
                    return View("ModifyClubCreation", club);
                }
            }
            return View("Error");
        }





        // sends the modified data
        [HttpPost]
        public IActionResult ModifyClubCreation(Club club)
        {
            if (club.Id != 0)
            {
                using (Dal dal = new Dal())
                {
                    dal.ModifyClubCreation(club.Id);
                    CreateClubViewModel createClubViewModel = new CreateClubViewModel { Club = club };

                    return View("EspaceClubLogged", createClubViewModel);
                }
            }
            else
            {
                return View("Error");
            }
        }


        //[HttpPost]
        //public IActionResult ModifyClubCreation(Club club)
        //{
        //    Dal dal = new Dal();
        //    List<Utilisateur> utilisateurs = dal.GetUsersList();
        //    club.CompteId = dal.CreateCompte(club.Compte);
        //    club.InfosClubId = dal.CreateInfosClub(club.InfosClub);
        //    dal.CreateClub(club);

        //    CreateClubViewModel createClubViewModel = new CreateClubViewModel { Club = club, Utilisateurs = utilisateurs };

        //    return View("EspaceClubLogged", createClubViewModel);
        //}






        // Creation of a user
        // Display of the view
        public IActionResult CreateUser()
        {
            return View();
        }

        // sending the data
        [HttpPost]
        public IActionResult CreateUser(Utilisateur utilisateur)
        {
            Dal dal = new Dal();
            utilisateur.InfosPersonnellesId = dal.CreateInfosPersonnelles(utilisateur.InfosPersonnelles);
            utilisateur.CompteId = dal.CreateCompte(utilisateur.Compte);

            //ListeUtilisateurs.CreateUser(idCount, utilisateur.Compte, utilisateur.InfosPersonnelles);
            dal.CreateUser(utilisateur);
            return RedirectToAction("UserList");
        }


        public IActionResult CreateUser4Club()
        {
            return View();
        }

        // sending the data
        [HttpPost]
        public IActionResult CreateUser4Club(Utilisateur utilisateur, Club club)
        {
            Dal dal = new Dal();
            utilisateur.InfosPersonnellesId = dal.CreateInfosPersonnelles(utilisateur.InfosPersonnelles);
            utilisateur.CompteId = dal.CreateCompte(utilisateur.Compte);

            //ListeUtilisateurs.CreateUser(idCount, utilisateur.Compte, utilisateur.InfosPersonnelles);
            dal.CreateUser(utilisateur);
            CreateClubViewModel createClubViewModel = new CreateClubViewModel { Club = club};

            return View("EspaceClubLogged", createClubViewModel);
        }
        


        // Creation of a club
        // Display of the view
        public IActionResult CreateClub()
        {
            return View();
        }

        // sending the data
        [HttpPost]
        public IActionResult CreateClub(Club club)
        {
            Dal dal = new Dal();
            List<Utilisateur> utilisateurs = dal.GetUsersList();
            club.CompteId = dal.CreateCompte(club.Compte);
            club.InfosClubId = dal.CreateInfosClub(club.InfosClub);
            dal.CreateClub(club);

            CreateClubViewModel createClubViewModel = new CreateClubViewModel { Club = club, Utilisateurs = utilisateurs };

            return View("EspaceClubLogged", createClubViewModel);
        }

        public IActionResult EspaceClubLogged(int Id)
        {
            Dal dal = new Dal();

            Club club = dal.GetClubsList().Where(r => r.Id == Id).FirstOrDefault();

            CreateClubViewModel createClubViewModel = new CreateClubViewModel { Club = club };

            return View(createClubViewModel);
        }

        [HttpPost]
        public IActionResult EspaceClubVisible(Club club)
        {
            Dal dal = new Dal();
            club.CompteId = dal.CreateCompte(club.Compte);
            club.InfosClubId = dal.CreateInfosClub(club.InfosClub);
            List<Utilisateur> utilisateurs = dal.GetUsersList();
            dal.CreateClub(club);

            CreateClubViewModel createClubViewModel = new CreateClubViewModel { Club = club, Utilisateurs = utilisateurs };

            return View("EspaceClubVisible", createClubViewModel);
        }





        public IActionResult EspaceAdmin(Utilisateur utilisateur)
        {
            return View(utilisateur);
        }


        public IActionResult EspaceClub()
        {
            return View();
        }

        public IActionResult EspaceClubVisible(int Id)
        {

            using (Dal dal = new Dal())
            {
                Club club = dal.GetClubsList().Where(r => r.Id == Id).FirstOrDefault();
                if (club == null)
                {
                    return View("Error");
                }
                CreateClubViewModel createClubViewModel = new CreateClubViewModel { Club = club};

                return View(createClubViewModel);
            }
        }





        public IActionResult ClubLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ClubLogin(Club club)
        {
            using (Dal dal = new Dal())
            {
                Club club1 = dal.GetClubsList().Where(r => r.InfosClub.NomClub == club.InfosClub.NomClub).FirstOrDefault();
                if (club1 == null)
                {
                    return View("Error");
                }
                CreateClubViewModel createClubViewModel = new CreateClubViewModel { Club = club1 };

                return View("EspaceClubLogged", createClubViewModel);
            }
        }

        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(Utilisateur utilisateur)
        {
            using (Dal dal = new Dal())
            {
                //Utilisateur utilisateur = dal.GetUsersList().Where(r => r.InfosPersonnelles.Nom == Nom).FirstOrDefault();
                if (utilisateur == null)
                {
                    return View("Error");
                }
                return View("EspaceAdmin", utilisateur);
            }
        }

        public IActionResult EspaceParapentiste()
        {
            return View();
        }

        public IActionResult PageEvents()
        {
            return View();
        }

        public IActionResult ClubList4Admin()
        {
            Dal dal = new Dal();
            List<Club> listeClubs4Admin = dal.GetClubsList(); // to be able to use the helper, instead of ViewData["ListeUtilisateurs"] = dal.GetUsersList();
            return View(listeClubs4Admin);
        }
        //public async Task<IActionResult> Search(string SearchString)
        //{
        //    using (Dal dal = new Dal())
        //    {
        //        if (id != 0)
        //        {

        //            Club clubFiltered = dal.GetClubsList().Where(clubFiltered.name.contains(SearchString)).FirstOrDefault();
        //            if (clubFiltered == null)
        //            {
        //                return Problem("Entity is null.");
        //            }



        //            return View(await clubsFiltered.ToListAsync());
        //        }
        //    }
        //}




        public IActionResult RemoveUser(int Id)
        {
            if (Id != 0)
            {
                using (Dal dal = new Dal())
                {
                    Utilisateur utilisateur = dal.GetUsersList().Where(r => r.Id == Id).FirstOrDefault();
                    dal.RemoveUser(utilisateur);
                    return RedirectToAction("UserList");
                }
            }
            else
            {
                return View("Error");
            }
        }



        public IActionResult RemoveClub(int Id)
        {
            if (Id != 0)
            {
                using (Dal dal = new Dal())
                {
                    Club club = dal.GetClubsList().Where(r => r.Id == Id).FirstOrDefault();
                    dal.RemoveClub(club);
                    return RedirectToAction("ClubList");
                }
            }
            else
            {
                return View("Error");
            }
        }



        public IActionResult FacturationView()
        {
            return View();
        }


        public IActionResult PaymentViewUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult User(Paiement paiement)
        {
            Dal dal = new Dal();
            paiement.FacturationId = dal.CreateFacturation(paiement.Facturation);
            dal.CreatePaiement(paiement);
            return View("CreateClub");
        }

        public IActionResult PaymentViewClub()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PaymentViewClub(Paiement paiement)
        {
            Dal dal = new Dal();
            paiement.FacturationId = dal.CreateFacturation(paiement.Facturation);
            dal.CreatePaiement(paiement);
            return View("CreateClub");
        }

        public IActionResult FacturationList()
        {
            Dal dal = new Dal();
            List<Facturation> listeFacturation = dal.GetFacturesList(); // to be able to use the helper
            return View(listeFacturation);

        }

        public IActionResult CreatePDFDocument()
        {
            Dal dal = new Dal();
            List<Facturation> listeFacturation = dal.GetFacturesList(); // to be able to use the helper

            //Generate a new PDF document.
            PdfDocument document = new PdfDocument();

            //Add a page.
            PdfPage page = document.Pages.Add();

            //Create a PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();

            //Add values to list.

            List<object> data = new List<object>();


            //Add rows. 
            foreach (Facturation f in listeFacturation)
            {
                data.Add(new
                {
                    Id = f.Id,
                    Nom = f.NomFacturation,
                    Prenom = f.PrenomFacturation,
                    Ville = f.VilleFacturation,
                    Adresse = f.AdresseFacturation,
                    CodePostal = f.CodePostalFacturation,
                    Pays = f.PaysFacturation,
                    Telephone = f.TelephoneFacturation,
                    Club = f.Club.InfosClub.NomClub
                });
            }



            //Add list to IEnumerable.
            IEnumerable<object> dataTable = data;

            //Assign data source.
            pdfGrid.DataSource = dataTable;

            //Draw grid to the page of PDF document.
            pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(10, 10));

            //Write the PDF document to stream
            MemoryStream stream = new MemoryStream();
            document.Save(stream);

            //If the position is not set to '0' then the PDF will be empty.
            stream.Position = 0;

            //Close the document.
            document.Close(true);

            //Defining the ContentType for pdf file.
            string contentType = "application/pdf";

            //Define the file name.
            string fileName = "Liste Facture.pdf";

            //Creates a FileContentResult object by using the file contents, content type, and file name.
            return File(stream, contentType, fileName);
        }

            //Creation of a catalog
        public IActionResult OfferCatalog()
        {
            Dal dal = new Dal();
            List<OffreAbonnement> offreAbonnements = dal.GetOfferCatalog(); // to be able to use the helper, instead of ViewData["ListeUtilisateurs"] = dal.GetUsersList();
            return View(offreAbonnements);
        }

        [HttpPost]
        public IActionResult OfferCatalog(OffreAbonnement offreAbonnement)
        {
            return View("PaymentViewClub");
        }

        public IActionResult EvenementClub()
        {
            Dal dal = new Dal();
            return View("EvenementClub");
        }

        //public IActionResult StageAdherent()
        //{
        //    Dal dal = new Dal();
        //    List<Stage> stages = dal.GetStageList();
        //    return View(stages);
        //}

        //public IActionResult VoyageAdherent()
        //{
        //    Dal dal = new Dal();
        //    List<Voyage> voyageAdherent = dal.GetVoyageList();
        //    return View(voyageAdherent);
        //}

        public IActionResult SortieAdherent()
        {
            Dal dal = new Dal();
            List<SortieAdherent> sortieAdherent = dal.GetSortieAdherentList();
            return View(sortieAdherent);
        }

        public IActionResult ListeAdherentsView()
        {
            Dal dal = new Dal();
            List<Adherent> adherent = dal.GetAdherentsList();
            return View(adherent);
            
        }

        public IActionResult Activites()
        {
            Dal dal = new Dal();

            List<Activite> activites = dal.GetActivityList();
            List<EvenementClub> evenementClubs = dal.GetEvenementClubList();
            List<SortieAdherent> sortieAdherents = dal.GetSortieAdherentList();

            ActiviteViewModel viewModel = new ActiviteViewModel
            {
                EvenementClubs = evenementClubs,
                SortieAdherents = sortieAdherents,
                Activites = activites,


            };

            return View(viewModel);
        }

        public IActionResult CreateEvenementClub()
        {
            return View("CreateEvenementClub");
        }

        public IActionResult CreateSortieAdherent()
        {
            return View("CreateSortieAdherent");
        }

        [HttpPost]
        public IActionResult AddEvenementClub(int evenmentClubId, string datefilter)
        {
            var splitDate = datefilter.Split('-');

            string dateDebutActivite = splitDate[0].Remove(splitDate[0].Length - 1);
            var arrayDateDebutActivite = dateDebutActivite.Split('/');

            int monthBegin = Convert.ToInt32(arrayDateDebutActivite[0]);
            int dayBegin = Convert.ToInt32(arrayDateDebutActivite[1]);
            int yearBegin = Convert.ToInt32(arrayDateDebutActivite[2]);

            string dateFinActivite = splitDate[1].TrimStart(' ');
            var arrayDateFinActivite = dateFinActivite.Split('/');

            int monthEnd = Convert.ToInt32(arrayDateFinActivite[0]);
            int dayEnd = Convert.ToInt32(arrayDateFinActivite[1]);
            int yearEnd = Convert.ToInt32(arrayDateFinActivite[2]);

            DateTime activiteStart = new DateTime(yearBegin, monthBegin, dayBegin);
            DateTime activiteEnd = new DateTime(yearEnd, monthEnd, dayEnd);

            return View("PageEvents");
        }
    
    public IActionResult ModifyEvenementClub(int id)
        {
            if (id != 0)
            {
                using (Dal dal = new Dal())
                {
                    Activite activite = dal.GetActivityList().Where(r => r.Id == id).FirstOrDefault();

                    if (activite == null)
                    {
                        return View("Error");
                    }
                    return View("ModifyEvenementClub", activite);
                }
            }
            return View("Error");
        }



        // sends the modified data
        [HttpPost]
        public IActionResult ModifyEvenementClub(Activite activite)
        {
            if (activite.Id != 0)
            {
                using (Dal dal = new Dal())
                {
                    dal.ModifyActivite(activite);
                    return RedirectToAction("Activites");
                }
            }
            else
            {
                return View("Error");
            }
        }


        public IActionResult ModifySortieAdherent(int id)
        {
            if (id != 0)
            {
                using (Dal dal = new Dal())
                {
                    Activite activite = dal.GetActivityList().Where(r => r.Id == id).FirstOrDefault();

                    if (activite == null)
                    {
                        return View("Error");
                    }
                    return View("ModifySortieAdherent", activite);
                }
            }
            return View("Error");
        }



        // sends the modified data
        [HttpPost]
        public IActionResult ModifySortieAdherent(Activite activite)
        {
            if (activite.Id != 0 && activite.SortieAdherentId != 0)
            {
                using (Dal dal = new Dal())
                {
                    dal.ModifyActivite(activite);
                    return RedirectToAction("Activites");
                }
            }
            else
            {
                return View("Error");
            }
        }



        //Activite activite = new Activite{ EvenementClubId = evenmentClubId, DateDebutActivite = activiteStart, DateFinActivite = activiteEnd };

        //var ctx = new BddContext();
        //ctx.Activites.Add(activite);
        //ctx.SaveChanges();


        //return RedirectToAction("EspaceClubLogged");

        public IActionResult CreateAdherent()
        {
            return View();
        }

        //sending the data
       [HttpPost]
        public IActionResult CreateAdherent(Adherent adherent)
        {
            Dal dal = new Dal();
            adherent.ClubId = dal.CreateClub(adherent.Club);


            //ListeUtilisateurs.CreateUser(idCount, utilisateur.Compte, utilisateur.InfosPersonnelles);
            dal.CreateAdherent(adherent.Id);
            return RedirectToAction("Activites");
        }

        public IActionResult CreateUser(Utilisateur utilisateur)
        {
            Dal dal = new Dal();
            utilisateur.InfosPersonnellesId = dal.CreateInfosPersonnelles(utilisateur.InfosPersonnelles);
            utilisateur.CompteId = dal.CreateCompte(utilisateur.Compte);

            //ListeUtilisateurs.CreateUser(idCount, utilisateur.Compte, utilisateur.InfosPersonnelles);
            dal.CreateUser(utilisateur);
            return RedirectToAction("UserList");
        }


    }


    

}


