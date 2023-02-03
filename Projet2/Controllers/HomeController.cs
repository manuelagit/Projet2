using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
    }
}

