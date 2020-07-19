using MediatR;
using Poulina.GestionCommentaire.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Commandes
{
   public class CreateInfoCommand<DemandeInformation> : IRequest<DemandeInformation>
    {
        public DemandeInformation entity { get; set; }
        public Guid id { get; set; }

        public Guid idUser { get; set; }
        public CreateInfoCommand(DemandeInformation en, Guid Id, Guid IDuser)
        {
            entity = en;
            id = Id;
            idUser = IDuser;
        }
    
    }
}
