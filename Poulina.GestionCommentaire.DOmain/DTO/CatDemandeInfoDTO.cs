using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.DTO
{
   public class CatDemandeInfoDTO
    {
        public Guid IdCatDemande { get; set; }
        public Guid? IdCat { get; set; }   
        public Guid IdDemandeInfo { get; set; }
        public Boolean IsActiveCatInfo { get; set; } = true;
        public string LabelCat { get; set; }
        public string DescriptionInfo { get; set; }
        public string TitreInfo { get; set; }
        

    }
}
