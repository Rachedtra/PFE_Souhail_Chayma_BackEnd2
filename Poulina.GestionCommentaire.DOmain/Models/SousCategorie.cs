using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Models
{
   public class SousCategorie

    {
        public Guid IdSousCate { get; set; }
        public string Label { get; set;  }
        public virtual Categorie Categories { get; set; }
        public Guid CatFK { get; set; }

    }
}
