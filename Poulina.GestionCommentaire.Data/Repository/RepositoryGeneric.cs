using Microsoft.EntityFrameworkCore;
using Poulina.GestionCommentaire.Data.Context;
using Poulina.GestionCommentaire.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poulina.GestionCommentaire.Data.Repository
{
    public class RepositoryGeneric<TEntity> : IRepositoryGeneric<TEntity> where TEntity : class
    {
        private DbSet<TEntity> tab = null;

        private readonly GestionCommContext _context;
        public RepositoryGeneric(GestionCommContext context)
        {
            _context = context;
            tab = _context.Set<TEntity>();
        }
        public string Add(TEntity entity)
        {
            tab.Add(entity);
            _context.SaveChanges();
            return "add avec succes";
        }

        public string Delete(Guid id)
        {
            TEntity exist = tab.Find(id);
            tab.Remove(exist);
            _context.SaveChanges();

            return "delete avec succes";
        }

        public TEntity Get(Guid id)
        {
            return tab.Find(id);
        }

        public List<TEntity> GetAll()
        {
            return tab.ToList();
        }

        public string Update(TEntity entity)
        {
            tab.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return "update avec succes";
        }

    }
}
