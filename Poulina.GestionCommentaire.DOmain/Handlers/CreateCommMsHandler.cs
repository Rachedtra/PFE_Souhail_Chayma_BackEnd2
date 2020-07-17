using MediatR;
using Poulina.GestionCommentaire.Domain.Commandes;
using Poulina.GestionCommentaire.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Poulina.GestionCommentaire.Domain.Handlers
{
    public class CreateCommMsHandler <Commentaires> : IRequestHandler<CreateCommMs<Commentaires>, Commentaires>
    {
        private readonly IRepositoryComm<Commentaires> _dataRepository;



        public CreateCommMsHandler(IRepositoryComm<Commentaires> dataRepository)
        {

            _dataRepository = dataRepository;


        }

        public Task<Commentaires> Handle(CreateCommMs<Commentaires> request, CancellationToken cancellationToken)
        {
            var result = _dataRepository.AddCommMs(request.entity, request.id);

            return Task.FromResult(result);
        }
    }
}


