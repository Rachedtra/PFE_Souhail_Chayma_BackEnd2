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
   public class CreateIdHandler : IRequestHandler<CreateIdCommandGeneric, string> 
    {
        private readonly IRepositoryAdd _dataRepository;



        public CreateIdHandler(IRepositoryAdd dataRepository)
        {

            _dataRepository = dataRepository;


        }

        public Task<string> Handle(CreateIdCommandGeneric request, CancellationToken cancellationToken)
        {
            var result = _dataRepository.AddId(request.entity,request.id);

            return Task.FromResult(result);
        }
    }
}
