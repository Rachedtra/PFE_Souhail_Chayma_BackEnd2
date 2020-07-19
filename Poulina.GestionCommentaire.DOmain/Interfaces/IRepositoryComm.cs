using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionCommentaire.Domain.Interfaces
{
    public interface IRepositoryComm<Commentaires>
    {
        Commentaires Add(Commentaires c, Guid id, Guid idUser);
        Commentaires AddCommMs(Commentaires c, Guid id , Guid idUser);


    }
}
