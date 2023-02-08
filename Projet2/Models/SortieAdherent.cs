using System;

namespace Projet2.Models
{
    public class SortieAdherent
    {
        public int Id { get; set; }

        public string NomSortie { get; set; }

        public DateTime DateSortie { get; set; }

        public string DescriptionSortie { get; set; }
        public string LieuSortie { get; set; }

        public string NomLeader { get; set; }

        public string TypeSortie { get; set; }
    }
}
