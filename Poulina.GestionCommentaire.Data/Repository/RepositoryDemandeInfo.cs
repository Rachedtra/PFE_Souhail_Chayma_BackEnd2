using Microsoft.EntityFrameworkCore;
using Poulina.GestionCommentaire.Data.Context;
using Poulina.GestionCommentaire.Domain.Interfaces;
using Poulina.GestionCommentaire.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Data.Repository
{
    public class RepositoryDemandeInfo : IRpositoryInfo<DemandeInformation>
    {
        private DbSet<DemandeInformation> tabcomm = null;
        private readonly GestionCommContext _context;
        public RepositoryDemandeInfo(GestionCommContext context)
        {
            _context = context;
            tabcomm = _context.Set<DemandeInformation>();
        }
        public DemandeInformation AddInfo(DemandeInformation de, Guid IdCat, Guid IdUser)
        {
            tabcomm.Add(de);
            de.FkUser = IdUser;
            _context.SaveChanges();
            return de;
        }
    }
}
