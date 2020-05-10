using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Poulina.GestionCommentaire.Domain.Commandes;
using Poulina.GestionCommentaire.Domain.DTO;
using Poulina.GestionCommentaire.Domain.Models;
using Poulina.GestionCommentaire.Domain.Queries;

namespace Poulina.GestionCommentaire.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatDemandeInfoController : ControllerBase

    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CatDemandeInfoController(IMediator mediator , IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper; 
        }
        // GET: api/CatDemandeInfo
        [HttpGet]
        public async Task<ActionResult<CatDemandeInfoDTO>> Get()
        {
            var query = new GetAllQueryGeneric<CatDemandeInfo>(null, includes: z => z.Include(b => b.categories).Include(x=>x.demandeInformations));
            var result = await _mediator.Send(query);
            var dto = _mapper.Map<List<CatDemandeInfoDTO>>(result);
            return Ok(dto);
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
        [HttpPut]
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
