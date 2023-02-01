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


        public int CreateInfosPersonnelles(InfosPersonnelles infosPersonnelles)
        {
            _bddContext.InfosPersonnelles.Add(infosPersonnelles);
            _bddContext.SaveChanges();
            return infosPersonnelles.Id;
        }

        public int CreateCompte(Compte compte)
        {
            _bddContext.Comptes.Add(compte);
            _bddContext.SaveChanges();
            return compte.Id;
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


        public void ModifyUser(int Id)
        {
            Utilisateur utilisateur = _bddContext.Utilisateurs.Find(Id);
            if (utilisateur != null)
            {
                _bddContext.Utilisateurs.Update(utilisateur);
                _bddContext.SaveChanges();
            }
        }

        public int ModifyUser(Utilisateur utilisateur)
        {
            _bddContext.Utilisateurs.Update(utilisateur);
            _bddContext.SaveChanges();
            return utilisateur.Id;
        }

        public void RemoveUser(Utilisateur utilisateur)
        {
            if (utilisateur != null)
            {
                Compte tmpCompte = utilisateur.Compte;
                InfosPersonnelles tmpInfos = utilisateur.InfosPersonnelles;
                Adresse tmpAdresse = utilisateur.InfosPersonnelles.Adresse;

                utilisateur.InfosPersonnellesId = 0;
                _bddContext.Utilisateurs.Remove(utilisateur);
                _bddContext.InfosPersonnelles.Remove(tmpInfos);
                _bddContext.Adresses.Remove(tmpAdresse);
                _bddContext.Comptes.Remove(tmpCompte);
                _bddContext.SaveChanges();
            }
        }



    }
}

