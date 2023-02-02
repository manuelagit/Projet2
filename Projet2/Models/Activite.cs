using System;

namespace Projet2.Models
{
    public class Activite
    {
        public int Id { get; set; }
        public string NomActivite { get; set; }

        public DateTime DateActivite { get; set;}

        public string TypeActivite { get; set; }
        public string DescriptionActivite { get; set;}

        public string LieuActivite { get; set; }

    }
}
