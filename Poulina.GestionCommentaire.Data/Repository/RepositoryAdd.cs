using Poulina.GestionCommentaire.Data.Context;
using Poulina.GestionCommentaire.Domain.Interfaces;
using Poulina.GestionCommentaire.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Data.Repository
{
   public  class RepositoryAdd : IRepositoryAdd 
    {
        private readonly GestionCommContext _context;
        public RepositoryAdd(GestionCommContext context)
        {
            _context = context;
           
        }
        public string AddId( DemandeInformation entity , Guid id )
        {
            _context.DemandeInformation.Add(entity);
            _context.SaveChanges();
            return "add avec succes";
        }
    }
}
