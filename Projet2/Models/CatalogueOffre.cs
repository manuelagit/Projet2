using System.Collections.Generic;
using System.Linq;

namespace Projet2.Models
{
    public class CatalogueOffre
    {
        public static List<OffreAbonnement> offreAbonnements = new List<OffreAbonnement>();

        // get the list of all subscription offers in the bdd
        public static List<OffreAbonnement> GetOfferList()
        {
            return offreAbonnements;
        }

        // add an offer to the list via id, description, duree
        public static void CreateOffer(int id, string descriptionOffre, string typeOffre, int dureeOffreMois, double prix)
        {
            offreAbonnements.Add(new OffreAbonnement() { Id = id, DescriptionOffre = descriptionOffre, TypeOffre = typeOffre, DureeOffreMois = dureeOffreMois, Prix = prix });
        }

        // add an offer to the list via OffreAbonnement
        public static void CreateOffer(OffreAbonnement offreAbonnement)
        {
            offreAbonnements.Add(offreAbonnement);
        }

        // remove an offer from the list via OffreAbonnement
        public static void RemoveOffer(OffreAbonnement offreAbonnement)
        {
            offreAbonnements.Remove(offreAbonnement);
        }

        // remove an offer from the list via the Id
        public static void RemoveOffer(int id)
        {
            OffreAbonnement offreAbonnement = CatalogueOffre.offreAbonnements.FirstOrDefault(mb => mb.Id == id); // retrieve the user having this given Id
            offreAbonnements.Remove(offreAbonnement);
        }

    }
}
