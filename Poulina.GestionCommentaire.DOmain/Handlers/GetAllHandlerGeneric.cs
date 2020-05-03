using MediatR;
using Poulina.GestionCommentaire.Domain.Interfaces;
using Poulina.GestionCommentaire.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Poulina.GestionCommentaire.Domain.Handlers
{
    public class GetAllHandlerGeneric<TEntity> : IRequestHandler<GetAllQueryGeneric<TEntity>, List<TEntity>> where TEntity : class
    {
        private readonly IRepositoryGeneric<TEntity> _dataRepository;

        public GetAllHandlerGeneric(IRepositoryGeneric<TEntity> dataRepository)
        {


            _dataRepository = dataRepository;

        }

        public Task<List<TEntity>> Handle(GetAllQueryGeneric<TEntity> request, CancellationToken cancellationToken)
        {
            var entity = _dataRepository.GetAll();
            return Task.FromResult(entity);
        }
    }
}
