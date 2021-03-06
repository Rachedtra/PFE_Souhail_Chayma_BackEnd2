﻿using System;
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
    public class SousCategorieController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SousCategorieController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/SousCategorie
        [HttpGet]
        public async Task<ActionResult<SousCategorie>> Get()
        {
            var query = new GetAllQueryGeneric<SousCategorie>();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/SousCategorie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SousCategorie>> Get(Guid id)
        {
            var query = new GetIdQueryGeneric<SousCategorie>(id);
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        // POST: api/SousCategorie
        [HttpPost]
        public async Task<ActionResult<string>> Post(SousCategorie sc)
        {
            var comm = new CreateCommandGeneric<SousCategorie>(sc);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }

        // PUT: api/Vote/5
        [HttpPut]
        public async Task<ActionResult<string>> Put(SousCategorie sc)
        {
            var comm = new UpdateCommandGeneric<SousCategorie>(sc);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(Guid Id)
        {
            var comm = new DeleteCommandGeneric<SousCategorie>(Id);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }
    }
}
