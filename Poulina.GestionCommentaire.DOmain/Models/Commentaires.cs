using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Models
{
   public class Commentaires
    {
        public Guid IdComm { get; set;  }
        public string Description { get; set;  }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set;  }
        public ICollection<CommDemandeInfo> commDemandeInfos { get; set;  }
        public ICollection<CommVote> commVotes { get; set;  }
    }
}
