using Projet2.Models;
using System.Collections.Generic;

namespace Projet2.ViewModels
{
    public class CreateClubViewModel
    {
        public Club club { get; set; }
        public List<Club> Clubs { get; set; }

        public Utilisateur utilisateur { get; set; }
        public List<Utilisateur> Utilisateurs { get; set; }
    }
}
