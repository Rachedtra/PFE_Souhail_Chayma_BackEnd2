using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Models
{
   public class Commentaires
    {
        public Guid IdComm { get; set;  }
        public string Description { get; set;  }
        public DateTime Date { get; set;  }
        public Boolean IsActiveComm { get; set; } = true;

        public DemandeInformation demandeInformation { get; set; }
        public Guid? FkInfo { get; set;  }
        public Guid? FkMs { get; set;  }
        public virtual ICollection<CommVote> commVotes { get; set;  }
    }
}

