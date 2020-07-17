using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Models
{
   public class Domaine
    {
        [Key]
        public Guid IdDomain { get; set; }
        public string Nom { get; set; }
        public Boolean IsActiveDomaine { get; set; }

    }
}
