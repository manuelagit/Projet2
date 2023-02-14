using Projet2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoixSejour.ViewModels
{
    public class UtilisateurViewModel
    {
        public Utilisateur Utilisateur { get; set; }
        public bool Authentifie { get; set; }
    }
}