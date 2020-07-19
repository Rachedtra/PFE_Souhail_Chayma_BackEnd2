using MediatR;
using Poulina.GestionCommentaire.Domain.Commandes;
using Poulina.GestionCommentaire.Domain.Interfaces;
using Poulina.GestionCommentaire.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Poulina.GestionCommentaire.Domain.Handlers
{
   public  class CreateInfoHandler<DemandeInformation> : IRequestHandler<CreateInfoCommand<DemandeInformation>, DemandeInformation>
    {
        private readonly IRpositoryInfo<DemandeInformation> _dataRepository;



        public CreateInfoHandler(IRpositoryInfo<DemandeInformation> dataRepository)
        {

            _dataRepository = dataRepository;


        }

        public Task<DemandeInformation> Handle(CreateInfoCommand<DemandeInformation> request, CancellationToken cancellationToken)
        {
            var result = _dataRepository.AddInfo(request.entity, request.id, request.idUser);

            return Task.FromResult(result);
        }
    }
}
