using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Models
{
  public  class Ms
    {
        public Guid IdMs { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Lien { get; set; }
        public string DiagClass { get; set; }
        public Boolean IsActiveMs { get; set; }
    }
}
