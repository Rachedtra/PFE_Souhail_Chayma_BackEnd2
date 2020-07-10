using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Poulina.GestionCommentaire.Data.Repository;
using Poulina.GestionCommentaire.Domain.Commandes;
using Poulina.GestionCommentaire.Domain.DTO;
using Poulina.GestionCommentaire.Domain.Models;
using Poulina.GestionCommentaire.Domain.Queries;

namespace Poulina.GestionCommentaire.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DemandeInformationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly RepositoryDomaine _repo;
        private readonly IMapper _mapper;


        public DemandeInformationController(IMediator mediator, RepositoryDomaine repo , IMapper mapper)
        {
            _mapper = mapper; 
            _repo = repo;
            _mediator = mediator;
    }
    // GET: api/DemandeInformation
    [HttpGet]
        public List<DemandeInformationDTO> Get()
        {
           var tab = _repo.GetDomaine().Result.ToList();
            var query = new GetAllQueryGeneric<DemandeInformation>(condition : null, includes: null);
            var result = _mediator.Send(query).Result;
            
            var dto = _mapper.Map<List<DemandeInformationDTO>>(result);

            var resultDTO = new List<DemandeInformationDTO>();

            foreach (var item in dto)
            {
                item.DomaineNom = tab.Find(x => x.IdDomain.Equals(item.IdDomain)).Nom;
                resultDTO.Add(item);
            }
            return resultDTO;

        }
          
        



        // GET: api/GetActiveListDemandeInfo
        [Route("GetActiveListDemandeInfo")]
        [HttpGet]
        public async Task<ActionResult<DemandeInformationDTO>> GetActiveList()
        {
            var query = new GetAllQueryGeneric<DemandeInformation>(condition: x => x.IsActiveInfo == true,null);
            var result = await _mediator.Send(query);
            var dto = _mapper.Map<List<DemandeInformationDTO>>(result);
          
            return Ok(dto);
        }


        // GET: api/DemandeInformation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DemandeInformation>> Get(Guid id)
        {
            var query = new GetIdQueryGeneric<DemandeInformation>(id);
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        // POST: api/DemandeInformation
        [HttpPost]
        public async Task<ActionResult<string>> Post(DemandeInformation de)
        {
            var comm = new CreateCommandGeneric<DemandeInformation>(de);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }

        [Route("Posted")]
        [HttpPost]
        public Task<DemandeInformation> Posted(DemandeInformation de, Guid idCat)
        {
            var demande = new CreateIdCommandGeneric<DemandeInformation>(de , idCat);
            var result = _mediator.Send(demande);
            DemandeInformation demandeInformation =  _mediator.Send(new GetAllQueryGeneric<DemandeInformation>(condition: x => x.IsActiveInfo == true, null)).Result.LastOrDefault();
            var catDemande = new CatDemandeInfo();
            catDemande.IdCat = idCat;
            catDemande.IdDemandeInfo = demandeInformation.IdDemandeInfo;
            var catInfo = new CreateCommandGeneric<CatDemandeInfo>(catDemande);
            _mediator.Send(catInfo);
            return (result);        
        }
        // PUT: api/DemandeInformation/5
        [HttpPut]
        public async Task<ActionResult<string>> Put(DemandeInformation de)
        {
            var comm = new UpdateCommandGeneric<DemandeInformation>(de);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(Guid Id)
        {
            var comm = new DeleteCommandGeneric<DemandeInformation>(Id);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }

        [Route("GetDomaine")]
        [HttpGet]
        public async Task<IEnumerable<Domaine>> GetDomaine()
        {
            return await _repo.GetDomaine();

        }
    }
}
