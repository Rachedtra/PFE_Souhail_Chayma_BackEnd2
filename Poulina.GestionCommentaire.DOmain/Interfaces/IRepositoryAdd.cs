using Poulina.GestionCommentaire.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Interfaces
{
    public interface IRepositoryAdd
    {
        string AddId(DemandeInformation entity, Guid id);
    }
}
