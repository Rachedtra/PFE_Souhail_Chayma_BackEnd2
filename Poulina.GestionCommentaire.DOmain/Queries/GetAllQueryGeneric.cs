using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Queries
{
    public class GetAllQueryGeneric<TEntity> : IRequest<List<TEntity>> where TEntity : class
    {

    }
}

