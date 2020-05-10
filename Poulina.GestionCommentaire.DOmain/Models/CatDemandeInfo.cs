using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Models
{
  public  class CatDemandeInfo
    {
        public Guid IdCatDemande { get; set; }
        public Guid? IdCat { get; set; }
        public Categorie categories { get; set;  }
        public Guid IdDemandeInfo { get; set; }
        public Boolean IsActiveCatInfo { get; set; } = true; 
        public DemandeInformation demandeInformations { get; set; }

    }
}
