using Poulina.GestionCommentaire.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Interfaces
{
   public interface IRpositoryInfo<DemandeInformation>
    {
        DemandeInformation AddInfo(DemandeInformation de, Guid IdCat, Guid IdUser); 
    }
}
