using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.DTO
{
   public class CommDemandeInfoDTO
    {
        public Guid IdCommInfo { get; set; }
        public Guid? IdDemandeInfo { get; set; }
        public Guid? IdComm { get; set; }
        public Boolean IsActiveCommInfo { get; set; } = true;
        public string DescriptionComm { get; set; }
        public string DescriptionInfo { get; set; }


    }
}
