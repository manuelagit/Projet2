using System;

namespace Projet2.Models
{
    public class Voyage
    {
        public int Id { get; set; }

        public string NomVoyage { get; set; }

        public DateTime DateVoyage { get; set; }

        public string DescriptionVoyage { get; set; }
        public string LieuVoyage { get; set; }

        public int DureeVoyageHeure { get; set; }

        public int NiveauRequisVoyage { get; set; }

        public int NombrePlaceVoyage { get; set; }
        public double PrixVoyage { get; set; }
    }
}
