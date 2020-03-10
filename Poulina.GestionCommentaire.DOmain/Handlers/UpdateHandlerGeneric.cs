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
    public class UpdateHandlerGeneric<TEntity> : IRequestHandler<UpdateCommandGeneric<TEntity>, string> where TEntity : class
    {
        private readonly IRepositoryGeneric<TEntity> _dataRepository;


        public UpdateHandlerGeneric(IRepositoryGeneric<TEntity> dataRepository)
        {

            _dataRepository = dataRepository;


        }

        public Task<string> Handle(UpdateCommandGeneric<TEntity> request, CancellationToken cancellationToken)
        {
            var result = _dataRepository.Update(request.entity);

            return Task.FromResult(result);
        }
    }
}
