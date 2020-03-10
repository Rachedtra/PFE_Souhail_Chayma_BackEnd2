using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Queries
{
    public class GetIdQueryGeneric<TEntity> : IRequest<TEntity> where TEntity : class
    {

        public Guid Id { get; }

        public GetIdQueryGeneric(Guid id)
        {
            Id = id;
        }
    }
}
