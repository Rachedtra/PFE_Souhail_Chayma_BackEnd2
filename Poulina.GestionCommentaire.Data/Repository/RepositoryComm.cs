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


        public Commentaires Add(Commentaires c, Guid id,Guid iduser)
        {
            tabcomm.Add(c);
            c.FkInfo = id;
            c.FkUser = iduser; 
            _context.SaveChanges();
            return c;
        }

        public Commentaires AddCommMs(Commentaires c, Guid id , Guid idUser)
        {
            tabcomm.Add(c);
            c.FkMs = id;
            c.FkUser = idUser; 
            _context.SaveChanges();
            return c;
        }
    }
}
