using MediatR;
using Poulina.GestionCommentaire.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Commandes
{
    public class CreateComm<Commentaires> : IRequest<Commentaires>
    {
        public Commentaires entity { get; set; }
        public Guid id { get; set; }
        public CreateComm(Commentaires en, Guid Id)
        {
            entity = en;
            id = Id;
        }
    }
}
