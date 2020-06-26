using Microsoft.EntityFrameworkCore;
using Poulina.GestionCommentaire.Data.Context;
using Poulina.GestionCommentaire.Domain.Interfaces;
using Poulina.GestionCommentaire.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Data.Repository
{
   public  class RepositoryAdd<TEntity> : IRepositoryAdd<TEntity> where TEntity : class
    {
        private DbSet<TEntity> tab = null;
        private readonly GestionCommContext _context;
        public RepositoryAdd(GestionCommContext context)
        {
            _context = context;
            tab = _context.Set<TEntity>();
        }
        public TEntity AddId(TEntity entity , Guid id )
        {
            tab.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public TEntity AddObject(TEntity entity)
        {
            tab.Add(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
