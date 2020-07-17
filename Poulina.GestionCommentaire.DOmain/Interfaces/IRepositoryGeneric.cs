using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Interfaces
{
    public interface IRepositoryGeneric<TEntity> where TEntity : class
    {
        //ist<TEntity> GetAll();
        TEntity Get(Guid id);
        string Add(TEntity entity);
       
        string Update(TEntity entity);
        string Delete(Guid id);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> condition = null,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null);


    }
}
