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

        public CommentairesController(IMediator mediator , IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper; 
        }
        // GET: api/Commentaires
        [HttpGet]
        public async Task<ActionResult<CommentairesDTO>> Get()
        {
            var query = new GetAllQueryGeneric<Commentaires>(null, includes: z => z.Include(b => b.demandeInformation));
            var result = await _mediator.Send(query);
            var dto = _mapper.Map<List<CommentairesDTO>>(result);

            return Ok(dto);
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
        public async Task<ActionResult<string>> PostedCommMs(Commentaires cat)
        {
            var comm = new CreateObjectCommand<Commentaires>(cat);
            var result = await _mediator.Send(comm);
            return Ok(result.IdComm);

        }

        [Route("PostedComm")]
        [HttpPost]
        public Task<Commentaires> PostedComm(Commentaires cm, Guid idDemande)
        {
            var comm = new CreateComm<Commentaires>(cm, idDemande);
            var result = _mediator.Send(comm);
            return (result);
        }
        // GET: api/Commentaires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categorie>> Get(Guid id)
        {
            var query = new GetIdQueryGeneric<Categorie>(id);
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
    }
}
