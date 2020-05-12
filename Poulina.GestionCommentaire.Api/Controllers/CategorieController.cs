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
    public class CategorieController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategorieController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/Categorie
        [HttpGet]
        public async Task<ActionResult<Categorie>> Get()
        {
            var query = new GetAllQueryGeneric<Categorie>();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        // GET: api/GetActiveListCategorie
        [Route("GetActiveListCategorie")]
        [HttpGet]
        public async Task<ActionResult<Categorie>> GetActiveList()
        {
            var query = new GetAllQueryGeneric<Categorie>(condition: x => x.IsActiveCat == true, null);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/Categorie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categorie>> Get(Guid id)
        {
            var query = new GetIdQueryGeneric<Categorie>(id);
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        // POST: api/Categorie
        [HttpPost]
        public async Task<ActionResult<string>> Post(Categorie cat)
        {
            var comm = new CreateCommandGeneric<Categorie>(cat);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }

        // PUT: api/Categorie/5
        [HttpPut]
        public async Task<ActionResult<string>> Put(Categorie cat)
        {
            var comm = new UpdateCommandGeneric<Categorie>(cat);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(Guid Id)
        {
            var comm = new DeleteCommandGeneric<Categorie>(Id);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }
    }
}
