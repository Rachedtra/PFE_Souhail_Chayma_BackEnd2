using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.DTO
{
   public class SousCategorieDTO
    {
        public Guid IdSousCate { get; set; }
        public string Label { get; set; }
        public Guid CatFK { get; set; }
        public Boolean IsActiveSousCat { get; set; } = true;
        public string CatLabel { get; set;  }
    }
}
