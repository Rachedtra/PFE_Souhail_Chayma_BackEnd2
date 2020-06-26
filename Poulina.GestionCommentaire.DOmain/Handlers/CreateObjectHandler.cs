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
    public class CreateObjectHandler<TEntity> : IRequestHandler<CreateObjectCommand<TEntity>, TEntity> where TEntity : class
    {
        private readonly IRepositoryAdd<TEntity> _dataRepository;



        public CreateObjectHandler(IRepositoryAdd<TEntity> dataRepository)
        {

            _dataRepository = dataRepository;


        }

        public Task<TEntity> Handle(CreateObjectCommand<TEntity> request, CancellationToken cancellationToken)
        {
            var result = _dataRepository.AddObject(request.entity);

            return Task.FromResult(result);
        }
    }
}


