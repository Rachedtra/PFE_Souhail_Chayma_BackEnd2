﻿using MediatR;
using Poulina.GestionCommentaire.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Commandes
{
   public class CreateIdCommandGeneric<TEntity> : IRequest<TEntity> where TEntity : class
    {
        public TEntity entity { get; set; }
        public Guid id { get; set; }
        public Guid idUser { get; set; }
        public CreateIdCommandGeneric(TEntity en , Guid Id, Guid User)
        {
            entity = en;
            id = Id;
            idUser = User; 
        }
    }
}
