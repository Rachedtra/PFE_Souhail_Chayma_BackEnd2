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
    public class CommDemandeInfoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommDemandeInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/CommDemandeInfo
        [HttpGet]
        public async Task<ActionResult<CommDemandeInfo>> Get()
        {
            var query = new GetAllQueryGeneric<CommDemandeInfo>();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/CommDemandeInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommDemandeInfo>> Get(Guid id)
        {
            var query = new GetIdQueryGeneric<CommDemandeInfo>(id);
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        // POST: api/CommDemandeInfo
        [HttpPost]
        public async Task<ActionResult<string>> Post(CommDemandeInfo de)
        {
            var comm = new CreateCommandGeneric<CommDemandeInfo>(de);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }

        // PUT: api/CommDemandeInfo/5
        [HttpPut]
        public async Task<ActionResult<string>> Put(CommDemandeInfo de)
        {
            var comm = new UpdateCommandGeneric<CommDemandeInfo>(de);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(Guid Id)
        {
            var comm = new DeleteCommandGeneric<CommDemandeInfo>(Id);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }
    }
}
