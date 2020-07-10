using Microsoft.EntityFrameworkCore;
using Poulina.GestionCommentaire.Data.Context;
using Poulina.GestionCommentaire.Domain.Interfaces;
using Poulina.GestionCommentaire.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Data.Repository
{
   public class RepositoryComm : IRepositoryComm<Commentaires> 
    {
      
        private DbSet<Commentaires> tabcomm = null;
        private readonly GestionCommContext _context;
        public RepositoryComm(GestionCommContext context)
        {
            _context = context;
            tabcomm = _context.Set<Commentaires>();
        }


        public Commentaires Add(Commentaires c, Guid id)
        {
            tabcomm.Add(c);
            c.FkInfo = id;
            _context.SaveChanges();
            return c;
        }
    }
}
