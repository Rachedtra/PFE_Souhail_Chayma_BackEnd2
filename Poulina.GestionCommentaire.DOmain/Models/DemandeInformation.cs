﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Models
{
   public  class DemandeInformation
    {
        public Guid IdDemandeInfo { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public ICollection<CommDemandeInfo> commDemandeInfos { get; set; }
        public ICollection<CatDemandeInfo> catDemandeInfos { get; set; }


    }
}


