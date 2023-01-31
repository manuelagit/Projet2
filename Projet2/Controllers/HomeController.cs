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

        public IActionResult ModifyUser()
        {
            return View();
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

            int idCount = ListeUtilisateurs.listeUtilisateurs.Count() + 1;
            utilisateur.Id = idCount;
            ListeUtilisateurs.CreateUser(idCount, utilisateur.Compte, utilisateur.InfosPersonnelles);
            Dal dal = new Dal();

            dal.CreateUser(utilisateur);
            return RedirectToAction("UserList");
        }

    }
}

