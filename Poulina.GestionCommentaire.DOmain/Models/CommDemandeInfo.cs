using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Models
{
   public class CommDemandeInfo
    {
        public Guid IdCommInfo { get; set;  }
        public Guid? IdDemandeInfo { get; set; }
        public DemandeInformation demandeInformations { get; set; }
        public Guid? IdComm { get; set; }
        public Commentaires commentaires { get; set;  }
        public Boolean IsActiveCommInfo { get; set; } = true;


    }
}
