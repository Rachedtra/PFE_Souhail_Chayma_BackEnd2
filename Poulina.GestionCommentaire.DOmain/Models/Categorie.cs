using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Models
{
  public  class Categorie
    {
        public Guid IdCat { get; set;  }
        public string Label { get; set;  }
        public ICollection<CatDemandeInfo> catDemandeInfos { get; set;  }
        public ICollection<SousCategorie> sousCategories { get; set;  }
    }
}
