using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projet2.Models;

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

        public IActionResult EspaceAdmin()
        {
            return View();
        }

        public IActionResult EspaceClub()
        {
            return View();
        }

        public IActionResult EspaceClubVisible()
        {
            return View();
        }

        public IActionResult EspaceClubLogged()
        {
            return View();
        }

        public IActionResult ClubLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ClubLogin(string NomClub)
        {
            using (Dal dal = new Dal())
            {
                Club club = dal.GetClubsList().Where(r => r.InfosClub.NomClub == NomClub).FirstOrDefault();
                if (club == null)
                {
                    return View("Error");
                }
                return View("EspaceClubLogged", club);
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


        public IActionResult ClubList4Admin()
        {
            Dal dal = new Dal();
            List<Club> listeClubs4Admin = dal.GetClubsList(); // to be able to use the helper, instead of ViewData["ListeUtilisateurs"] = dal.GetUsersList();
            return View(listeClubs4Admin);
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
            club.CompteId = dal.CreateCompte(club.Compte);
            club.InfosClubId = dal.CreateInfosClub(club.InfosClub);

            dal.CreateClub(club);
            return RedirectToAction("ClubList");
        }


        //Creation of a catalog
        public IActionResult OfferCatalog()
        {
            Dal dal = new Dal();
            List<OffreAbonnement> offreAbonnements = dal.GetOfferCatalog(); // to be able to use the helper, instead of ViewData["ListeUtilisateurs"] = dal.GetUsersList();
            return View(offreAbonnements);
        }


        public IActionResult LookForClub(int Id)
        {
            return View();
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


        public IActionResult PaymentView() 
        { 

            return View();
        }

        public IActionResult FacturationView()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult PaymentView(Paiement paiement)
        {
            Dal dal = new Dal();
            paiement.FacturationId = dal.CreateFacturation(paiement.Facturation);
            dal.CreatePaiement(paiement);
            return RedirectToAction("");
        }
        public IActionResult FacturationList()
        {
            Dal dal = new Dal();
            List<Facturation> listeFacturation = dal.GetFacturesList(); // to be able to use the helper, instead of ViewData["ListeUtilisateurs"] = dal.GetUsersList();
            return View(listeFacturation);
           
        }
    }
}

