using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Poulina.GestionCommentaire.Data.Context;
using Poulina.GestionCommentaire.Domain.Commandes;
using Poulina.GestionCommentaire.Domain.Models;
using Poulina.GestionCommentaire.Domain.Queries;

namespace Poulina.GestionCommentaire.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentairesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommentairesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/Commentaires
        [HttpGet]
        public async Task<ActionResult<Commentaires>> Get()
        {
            var query = new GetAllQueryGeneric<Commentaires>();
            var result = await _mediator.Send(query);
            return Ok(result);
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
        [HttpPut("{id}")]
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
