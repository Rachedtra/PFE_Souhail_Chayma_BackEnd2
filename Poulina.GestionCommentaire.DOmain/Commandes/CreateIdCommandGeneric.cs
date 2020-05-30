using MediatR;
using Poulina.GestionCommentaire.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Commandes
{
   public class CreateIdCommandGeneric<TEntity> : IRequest<string> where TEntity : class
    {
        public TEntity entity { get; set; }
        public Guid id { get; set; }
        public CreateIdCommandGeneric(TEntity en , Guid Id)
        {
            entity = en;
            id = Id; 
        }
    }
}
