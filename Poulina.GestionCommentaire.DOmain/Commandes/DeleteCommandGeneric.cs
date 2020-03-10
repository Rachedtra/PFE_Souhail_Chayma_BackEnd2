using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Commandes
{
    public class DeleteCommandGeneric<TEntity> : IRequest<string> where TEntity : class
    {
        public Guid Id { get; }

        public DeleteCommandGeneric(Guid id)
        {
            Id = id;
        }


    }
}
