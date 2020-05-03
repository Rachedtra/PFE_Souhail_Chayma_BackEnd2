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
    public class VoteController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VoteController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/Vote
        [HttpGet]
        public async Task<ActionResult<Vote>> Get()
        {
            var query = new GetAllQueryGeneric<Vote>();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/Vote/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vote>> Get(Guid id)
        {
            var query = new GetIdQueryGeneric<Vote>(id);
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        // POST: api/Vote
        [HttpPost]
        public async Task<ActionResult<string>> Post(Vote cv)
        {
            var comm = new CreateCommandGeneric<Vote>(cv);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }

        // PUT: api/Vote/5
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Put(Vote cv)
        {
            var comm = new UpdateCommandGeneric<Vote>(cv);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(Guid Id)
        {
            var comm = new DeleteCommandGeneric<Vote>(Id);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }
    }
}
