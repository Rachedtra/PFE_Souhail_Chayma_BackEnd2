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
    public class SousCategoriesController : ControllerBase
    {
        private readonly GestionCommContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public SousCategoriesController(GestionCommContext context , IMediator mediator  , IMapper mapper)
        {
            _context = context;
            _mediator = mediator; 
            _mapper=mapper; 
        }

        // GET: api/SousCategories
        [HttpGet]
        public async Task<ActionResult<SousCategorieDTO>> Get()
        {
            var query = new GetAllQueryGeneric<SousCategorie>(null, includes: z => z.Include(b => b.Categories));
            var result = await _mediator.Send(query);
            var dto = _mapper.Map<List<SousCategorieDTO>>(result);
            return Ok(dto);
        }
        // GET: api/GetActiveListSousCategories
        [Route("GetActiveListSousCategories")]
        [HttpGet]
        public async Task<ActionResult<SousCategorieDTO>> GetActiveList()
        {
            var query = new GetAllQueryGeneric<SousCategorie>(condition: x => x.IsActiveSousCat == true, includes: z => z.Include(b => b.Categories));
            var result = await _mediator.Send(query);
            var dto = _mapper.Map<List<SousCategorieDTO>>(result);
            return Ok(dto);
        }
        // GET: api/SousCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SousCategorie>> Get(Guid id)
        {
            var query = new GetIdQueryGeneric<SousCategorie>(id);
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        // PUT: api/SousCategories/5
        [HttpPut]
        public async Task<ActionResult<string>> Put(SousCategorie cat)
        {
            var comm = new UpdateCommandGeneric<SousCategorie>(cat);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }
        // POST: api/SousCategories
        [HttpPost]
        public async Task<ActionResult<string>> Post(SousCategorie cat)
        {
            var comm = new CreateCommandGeneric<SousCategorie>(cat);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }

        // DELETE: api/SousCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(Guid Id)
        {
            var comm = new DeleteCommandGeneric<SousCategorie>(Id);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }

    
    }
}
