using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Commandes
{
    public  class CreateObjectCommand<TEntity> : IRequest<TEntity> where TEntity : class
    {
        public TEntity entity { get; set; }
        public CreateObjectCommand(TEntity en)
        {
            entity = en;
        }


    }
    
}
