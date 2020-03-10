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
    public class DeleteHandlerGeneric<TEntity> : IRequestHandler<DeleteCommandGeneric<TEntity>, string> where TEntity : class
    {
        private readonly IRepositoryGeneric<TEntity> _dataRepository;


        public DeleteHandlerGeneric(IRepositoryGeneric<TEntity> dataRepository)
        {

            _dataRepository = dataRepository;


        }

        public Task<string> Handle(DeleteCommandGeneric<TEntity> request, CancellationToken cancellationToken)
        {
            var result = _dataRepository.Delete(request.Id);

            return Task.FromResult(result);
        }
    }
}
