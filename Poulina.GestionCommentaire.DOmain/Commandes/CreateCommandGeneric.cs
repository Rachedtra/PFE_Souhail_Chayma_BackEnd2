using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Commandes
{
    public class CreateCommandGeneric<TEntity> : IRequest<string> where TEntity : class
    {
        public TEntity entity { get; set; }
        public CreateCommandGeneric(TEntity en)
        {
            entity = en;
        }

    }
}
