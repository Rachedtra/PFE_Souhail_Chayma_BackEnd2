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
        public ICollection<CommDemandeInfo> commDemandeInfos { get; set;  }
        public ICollection<CommVote> commVotes { get; set;  }
    }
}
