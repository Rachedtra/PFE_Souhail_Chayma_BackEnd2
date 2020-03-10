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
    public class GetIdHandlerGeneric<TEntity> : IRequestHandler<GetIdQueryGeneric<TEntity>, TEntity> where TEntity : class
    {
        private readonly IRepositoryGeneric<TEntity> _dataRepository;

        public GetIdHandlerGeneric(IRepositoryGeneric<TEntity> dataRepository)
        {

            _dataRepository = dataRepository;

        }

        public Task<TEntity> Handle(GetIdQueryGeneric<TEntity> request, CancellationToken cancellationToken)
        {
            var res = _dataRepository.Get(request.Id);
            return Task.FromResult(res);
        }
    }
}
