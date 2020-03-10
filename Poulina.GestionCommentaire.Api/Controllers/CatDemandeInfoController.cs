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
    public class CatDemandeInfoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CatDemandeInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/CatDemandeInfo
        [HttpGet]
        public async Task<ActionResult<CatDemandeInfo>> Get()
        {
            var query = new GetAllQueryGeneric<CatDemandeInfo>();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/CatDemandeInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatDemandeInfo>> Get(Guid id)
        {
            var query = new GetIdQueryGeneric<CatDemandeInfo>(id);
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        // POST: api/CatDemandeInfo
        [HttpPost]
        public async Task<ActionResult<string>> Post(CatDemandeInfo de)
        {
            var comm = new CreateCommandGeneric<CatDemandeInfo>(de);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }

        // PUT: api/CatDemandeInfo/5
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Put(CatDemandeInfo de)
        {
            var comm = new UpdateCommandGeneric<CatDemandeInfo>(de);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(Guid Id)
        {
            var comm = new DeleteCommandGeneric<CatDemandeInfo>(Id);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }
    }
}
