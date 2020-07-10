using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.DTO
{
   public  class DemandeInformationDTO
    {
        public Guid IdDemandeInfo { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }
        public Boolean IsActiveInfo { get; set; } = true;
        public string Titre { get; set; }
        public Guid IdDomain { get; set;  }
        
        public string DomaineNom { get; set; }
    }
}
