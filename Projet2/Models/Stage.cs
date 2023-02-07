using System;

namespace Projet2.Models
{
    public class Stage
    {   
        public int Id { get; set; }

        public string NomStage { get; set; }

        public DateTime DateStage { get; set; }

        public string DescriptionStage { get; set; }
        public string LieuStage { get; set; }

        public int DureeStageHeure { get; set; }

        public int NiveauRequisStage { get; set; }
        public int NombrePlaceStage { get; set; }
        public double PrixStage { get; set; }
        
    }
}
