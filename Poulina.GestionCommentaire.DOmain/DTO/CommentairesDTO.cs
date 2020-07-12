using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.DTO
{
   public class CommentairesDTO
    {
        public Guid IdComm { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Boolean IsActiveComm { get; set; } = true;
        public Guid? FkInfo { get; set; }
        public string DescriptionInfo { get; set;  }
        public Guid? FkMs { get; set; }

        public string LabelMs { get; set;  }
    }
}
