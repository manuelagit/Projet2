﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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


        // recovers the saved values and displays them
        public IActionResult ModifyUser(int id)
        {
            if (id != 0)
            {
                using (IDal dal = new Dal())
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

        //Creation of a catalog
        public IActionResult OfferCatalog()
        {
            Dal dal = new Dal();
            List<OffreAbonnement> offreAbonnements = dal.GetOfferCatalog(); // to be able to use the helper, instead of ViewData["ListeUtilisateurs"] = dal.GetUsersList();
            return View(offreAbonnements);
        }

        public IActionResult Activite()
        {
            Dal dal = new Dal();
            List<Activite> activites = dal.GetActivityList(); // to be able to use the helper, instead of ViewData["ListeUtilisateurs"] = dal.GetUsersList();
            return View(activites);
        }

        public IActionResult EvenementClub()
        {
            Dal dal = new Dal();
            return View("EvenementClub");
        }

        public IActionResult StageAdherent()
        {
            Dal dal = new Dal();
            List<Stage> stages = dal.GetStageList();
            return View(stages);
        }

        public IActionResult VoyageAdherent()
        {
            Dal dal = new Dal();
            List<Voyage> voyageAdherent = dal.GetVoyageList();
            return View(voyageAdherent);
        }

        public IActionResult SortieAdherent()
        {
            Dal dal = new Dal();
            List<SortieAdherent> sortieAdherent = dal.GetSortieAdherentList();
            return View(sortieAdherent);
        }


        public IActionResult Activites()
        {
            Dal dal = new Dal();
            List<Stage> stages = dal.GetStageList();
            
            return View(stages);
        }

    }
}

