using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Poulina.GestionCommentaire.Data.Context;
using Poulina.GestionCommentaire.Data.Repository;
using Poulina.GestionCommentaire.Domain.Commandes;
using Poulina.GestionCommentaire.Domain.DTO;
using Poulina.GestionCommentaire.Domain.Models;
using Poulina.GestionCommentaire.Domain.Queries;

namespace Poulina.GestionCommentaire.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentairesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly RepositoryDomaine _repo;
        private readonly RepositoryUser _repositoryUser; 


        public CommentairesController(IMediator mediator, IMapper mapper, RepositoryDomaine repo,
            RepositoryUser repositoryUser)
        {
            _mediator = mediator;
            _mapper = mapper;
            _repo = repo;
            _repositoryUser = repositoryUser; 
        }
        // GET: api/Commentaires
        [HttpGet]
        //public List<DemandeInformationDTO> Get()
        //{
        //    var tab = _repo.GetDomaine().Result.ToList();
        //    var query = new GetAllQueryGeneric<DemandeInformation>(condition: null, includes: null);
        //    var result = _mediator.Send(query).Result;

        //    var dto = _mapper.Map<List<DemandeInformationDTO>>(result);

        //    var resultDTO = new List<DemandeInformationDTO>();

        //    foreach (var item in dto)
        //    {
        //        item.DomaineNom = tab.Find(x => x.IdDomain.Equals(item.IdDomain)).Nom;
        //        resultDTO.Add(item);
        //    }
        //    return resultDTO;

        //}

        public List<CommentairesDTO> Get()
        {
            var listUser = _repositoryUser.GetUsers().Result.ToList(); 
            var tab = _repo.GetMs().Result.ToList();
            var query = new GetAllQueryGeneric<Commentaires>(condition: null, includes: z => z.Include(b => b.demandeInformation));
            var result = _mediator.Send(query).Result;

            var dto = _mapper.Map<List<CommentairesDTO>>(result);
            var resultUsersDTO = new List<CommentairesDTO>();

            foreach (var item in dto)
            {
                if (item.FkUser != null)
                {
                    item.FirstName = listUser.Find(x => x.UserID.Equals(item.FkUser)).FirstName;
                    item.LastName = listUser.Find(x => x.UserID.Equals(item.FkUser)).LastName;

                    resultUsersDTO.Add(item);


                }
                else { resultUsersDTO.Add(item); }


            }
            var resultDTO = new List<CommentairesDTO>();

            foreach (var item in resultUsersDTO)
            {
                if (item.FkMs != null)
                {
                    item.LabelMs = tab.Find(x => x.IdMs.Equals(item.FkMs)).Label;
                    resultDTO.Add(item);


                }
                else { resultDTO.Add(item); }


            }
            return resultDTO;
        }

        // GET: api/GetActiveListComm
        [Route("GetActiveListComm")]
        [HttpGet]
        public async Task<ActionResult<Commentaires>> GetActiveList()
        {
            var query = new GetAllQueryGeneric<Commentaires>(condition: x => x.IsActiveComm == true, null);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Route("PostedCommMs")]
        [HttpPost]
        public Task<Commentaires> PostedCommMs(Commentaires cat, Guid idMs)
        {
            var comm = new CreateCommMs<Commentaires>(cat, idMs);
            var result = _mediator.Send(comm);
            return (result);

        }

        [Route("PostedComm")]
        [HttpPost]
        public Task<Commentaires> PostedComm(Commentaires cm, Guid idDemande, Guid idUser)
        {
            var comm = new CreateComm<Commentaires>(cm, idDemande, idUser);
            var result = _mediator.Send(comm);
            return (result);
        }
        // GET: api/Commentaires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Commentaires>> Get(Guid id)
        {
            var query = new GetIdQueryGeneric<Commentaires>(id);
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        // POST: api/Commentaires
        [HttpPost]
        public async Task<ActionResult<string>> Post(Commentaires cat)
        {
            var comm = new CreateCommandGeneric<Commentaires>(cat);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }

        // PUT: api/Commentaires/5
        [HttpPut]
        public async Task<ActionResult<string>> Put(Commentaires cat)
        {
            var comm = new UpdateCommandGeneric<Commentaires>(cat);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(Guid Id)
        {
            var comm = new DeleteCommandGeneric<Commentaires>(Id);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }


        [Route("GetMs")]
        [HttpGet]
        public async Task<IEnumerable<Ms>> GetMs()
        {
            return await _repo.GetMs();

        }
        [Route("GetUsers")]
        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _repositoryUser.GetUsers();

        }

    }
}
