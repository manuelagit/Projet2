using Projet2.Models;
using System.Collections.Generic;

namespace Projet2.ViewModels
{
    public class CreateClubViewModel
    {
        public Club Club { get; set; }
        public List<Club> Clubs { get; set; }

        public Utilisateur Utilisateur { get; set; }
        public List<Utilisateur> Utilisateurs { get; set; }


    }
}
