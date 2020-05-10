using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.DTO
{
   public class CommVoteDTO
    {
        public Guid IdCommVote { get; set; }
        public Guid? IdComm { get; set; }
        public Guid? IdVote { get; set; }
        public Boolean IsActiveCommVote { get; set; } = true;
        public string DescriptionComm { get; set; }
        public int Note { get; set; }


    }
}
