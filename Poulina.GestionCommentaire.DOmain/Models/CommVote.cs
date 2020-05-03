using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Models
{
   public class CommVote
    { 
        public Guid IdCommVote { get; set;  }



        public Guid? IdComm { get; set; }
        public Commentaires commentaires { get; set; }
        public Guid? IdVote { get; set; }
        public Vote votes { get; set;  }
    }
}
