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
    public class CreateCommHandler<Commentaires> : IRequestHandler<CreateComm<Commentaires>, Commentaires>
    {
        private readonly IRepositoryComm<Commentaires> _dataRepository;



        public CreateCommHandler(IRepositoryComm<Commentaires> dataRepository)
        {

            _dataRepository = dataRepository;


        }
        public Task<Commentaires> Handle(CreateComm<Commentaires> request, CancellationToken cancellationToken)
        {
            var result = _dataRepository.Add(request.entity,request.id);

            return Task.FromResult(result);
        }
    }
}
