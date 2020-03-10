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
    public class DemandeInformationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DemandeInformationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/DemandeInformation
        [HttpGet]
        public async Task<ActionResult<DemandeInformation>> Get()
        {
            var query = new GetAllQueryGeneric<DemandeInformation>();
            var result = await _mediator.Send(query);
            return Ok(result);
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

        // PUT: api/DemandeInformation/5
        [HttpPut("{id}")]
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
    }
}
