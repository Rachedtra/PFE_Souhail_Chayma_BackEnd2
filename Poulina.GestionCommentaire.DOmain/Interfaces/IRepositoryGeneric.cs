using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Interfaces
{
    public interface IRepositoryGeneric<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity Get(Guid id);
        string Add(TEntity entity);
        string Update(TEntity entity);
        string Delete(Guid id);


    }
}
