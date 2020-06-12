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
    public class CommVoteController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CommVoteController(IMediator mediator , IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        // GET: api/CommVote
        [HttpGet]
        public async Task<ActionResult<CommVoteDTO>> Get()
        {
            var query = new GetAllQueryGeneric<CommVote>(null, includes: z => z.Include(b => b.commentaires).Include(x => x.votes));
            var result = await _mediator.Send(query);
            var dto = _mapper.Map<List<CommVoteDTO>>(result);

            return Ok(dto);
        }

        // GET: api/GetActiveListCommVote
        [Route("GetActiveListCommVote")]
        [HttpGet]
        public async Task<ActionResult<CommVoteDTO>> GetActiveList()
        {
            var query = new GetAllQueryGeneric<CommVote>(condition: x => x.IsActiveCommVote == true, includes: z => z.Include(b => b.commentaires).Include(x => x.votes));
            var result = await _mediator.Send(query);
            var dto = _mapper.Map<List<CommVoteDTO>>(result);
            return Ok(dto);
        }
        // GET: api/CommVote/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommVote>> Get(Guid id)
        {
            var query = new GetIdQueryGeneric<CommVote>(id);
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        // POST: api/CommVote
        [HttpPost]
        public async Task<ActionResult<string>> Post(CommVote cv)
        {
            var comm = new CreateCommandGeneric<CommVote>(cv);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }


        // PUT: api/CommVote/5
        [HttpPut]
        public async Task<ActionResult<string>> Put(CommVote cv)
        {
            var comm = new UpdateCommandGeneric<CommVote>(cv);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(Guid Id)
        {
            var comm = new DeleteCommandGeneric<CommVote>(Id);
            var result = await _mediator.Send(comm);
            return Ok(result);

        }
    }
}
