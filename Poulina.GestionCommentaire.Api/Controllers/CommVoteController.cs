using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poulina.GestionCommentaire.Domain.Commandes;
using Poulina.GestionCommentaire.Domain.Models;
using Poulina.GestionCommentaire.Domain.Queries;

namespace Poulina.GestionCommentaire.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CommVoteController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommVoteController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/CommVote
        [HttpGet]
        public async Task<ActionResult<CommVote>> Get()
        {
            var query = new GetAllQueryGeneric<CommVote>();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/CommVote/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommVote>> Get(Guid id)
        {
            var query = new GetIdQueryGeneric<CommVote>(id);
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        // POST: api/CommVote
        [HttpPost]
        public async Task<ActionResult<string>> Post(CommVote cv)
        {
            var comm = new CreateCommandGeneric<CommVote>(cv);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }

        // PUT: api/CommVote/5
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Put(CommVote cv)
        {
            var comm = new UpdateCommandGeneric<CommVote>(cv);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(Guid Id)
        {
            var comm = new DeleteCommandGeneric<CommVote>(Id);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }
    }
}
