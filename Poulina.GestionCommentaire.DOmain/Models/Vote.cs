using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Models
{
    public class Vote
    {
        public Guid IdVote { get; set;  }
        public int Note { get; set;  }
        public ICollection<CommVote> commVotes { get; set; }

    }
}
