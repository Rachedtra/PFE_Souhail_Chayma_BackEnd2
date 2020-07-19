﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Commandes
{
  public  class CreateCommMs <Commentaires> : IRequest<Commentaires>
    {
        public Commentaires entity { get; set; }
        public Guid id { get; set; }
        public Guid idUser { get; set; }

        public CreateCommMs(Commentaires en, Guid Id , Guid User)
        {
            entity = en;
            id = Id;
            idUser = User; 
        }
    }
}
