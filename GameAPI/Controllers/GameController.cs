using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common;
using GameAPI.Commands;
using GameAPI.Models;
using GameAPI.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace GameAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GameController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        [HttpGet("~/{id}")]
        public async Task<ActionResult<Game>> Get(ObjectId id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetGameQuery(id), cancellationToken);
            if(result.RequestResult != RequestResult.Success)
            {
                throw new Exception(result.Message);
            }
            return result.Value!;
        }
        [HttpGet]
        public async Task<ActionResult<List<GameDto>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetGamesQuery(), cancellationToken);
            if (result.RequestResult != RequestResult.Success)
            {
                throw new Exception(result.Message);
            }
            return result.Value!;
        }
        [HttpPost]
        public async Task<IActionResult> Post(GameCreate item, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new AddGameCommand(item), cancellationToken);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new RemoveGameCommand(id), cancellationToken);
            return Ok(result);
        }
    }
}
