using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Projet2.Models
{
	public class Dal : IDal
	{
        private BddContext _bddContext;
        public Dal()
        {
            _bddContext = new BddContext();
        }

        public void DeleteCreateDatabase()
        {
            _bddContext.Database.EnsureDeleted();
            _bddContext.Database.EnsureCreated();
        }

        public void Dispose() //Removing the bdd
        {
            _bddContext.Dispose();
        }

        public List<Utilisateur> GetUsersList()
        {
            return _bddContext.Utilisateurs.Include(U => U.InfosPersonnelles).Include(U => U.InfosPersonnelles.Adresse).Include(U => U.Compte).ToList(); // charge + jointure
        }


        public int CreateUser(int idCompte, int IdInfosPersonnelles)
        {
            Utilisateur utilisateur = new Utilisateur { CompteId = idCompte, InfosPersonnellesId = IdInfosPersonnelles };
            _bddContext.Utilisateurs.Add(utilisateur);
            _bddContext.SaveChanges();
            return utilisateur.Id;
        }

        public int CreateUser(Utilisateur utilisateur)
        {
            _bddContext.Utilisateurs.Add(utilisateur);
            _bddContext.SaveChanges();
            return utilisateur.Id;
        }
    }
}

