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
   public class CreateIdHandler<TEntity> : IRequestHandler<CreateIdCommandGeneric<TEntity>, TEntity> where TEntity : class
    {
        private readonly IRepositoryAdd<TEntity> _dataRepository;



        public CreateIdHandler(IRepositoryAdd<TEntity> dataRepository)
        {

            _dataRepository = dataRepository;


        }

   
        Task<TEntity> IRequestHandler<CreateIdCommandGeneric<TEntity>, TEntity>.Handle(CreateIdCommandGeneric<TEntity> request, CancellationToken cancellationToken)
        {
            var result = _dataRepository.AddId(request.entity, request.id);

            return Task.FromResult(result);
        }
    }
}
