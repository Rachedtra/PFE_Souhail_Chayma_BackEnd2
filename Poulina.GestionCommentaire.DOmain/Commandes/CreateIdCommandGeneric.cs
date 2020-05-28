using MediatR;
using Poulina.GestionCommentaire.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Commandes
{
   public class CreateIdCommandGeneric : IRequest<string> 
    {
        public DemandeInformation entity { get; set; }
        public Guid id { get; set; }
        public CreateIdCommandGeneric(DemandeInformation en , Guid Id)
        {
            entity = en;
            id = Id; 
        }
    }
}
