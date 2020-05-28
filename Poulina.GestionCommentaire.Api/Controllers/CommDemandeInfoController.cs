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
    public class CommDemandeInfoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CommDemandeInfoController(IMediator mediator , IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        // GET: api/CommDemandeInfo
        [HttpGet]
        public async Task<ActionResult<CommDemandeInfoDTO>> Get()
        {
            var query = new GetAllQueryGeneric<CommDemandeInfo>(null, includes: z => z.Include(b => b.commentaires)
            .Include(x => x.demandeInformations));
            var result = await _mediator.Send(query);
            var dto = _mapper.Map<List<CommDemandeInfoDTO>>(result);

            return Ok(dto);
        }
        // GET: api/GetActiveListCommInfo
        [Route("GetActiveListCommInfo")]
        [HttpGet]
        public async Task<ActionResult<CommDemandeInfoDTO>> GetActiveList()
        {
            var query = new GetAllQueryGeneric<CommDemandeInfo>(condition: x => x.IsActiveCommInfo == true, includes: z => z.Include(b => b.commentaires)
            .Include(x => x.demandeInformations));
            var result = await _mediator.Send(query);
            var dto = _mapper.Map<List<CommDemandeInfoDTO>>(result);
            return Ok(dto);
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
