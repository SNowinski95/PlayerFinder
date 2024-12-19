using Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlayerAPI.Commands;
using PlayerAPI.Models;
using PlayerAPI.Queries;

namespace PlayerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlayerController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet("~/{id}")]
        public async Task<ActionResult<PlayerDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetPlayerQuery(id), cancellationToken);
            if (result.RequestResult != RequestResult.Success)
            {
                throw new Exception(result.Message);
            }
            return result.Value!;
        }
        //[HttpGet]
        //public async Task<ActionResult<List<PlayerDto>>> Search([FromBody]SearchPlayerDto item ,CancellationToken cancellationToken)
        //{
        //    var result = await _mediator.Send(new SearchPlayerQuery(item), cancellationToken);
        //    if (result.RequestResult != RequestResult.Success)
        //    {
        //        throw new Exception(result.Message);
        //    }
        //    return result.Value!;
        //}
        //[HttpPost]
        //public async Task<IActionResult> Post(PlayerCreateDto item, CancellationToken cancellationToken)
        //{
        //    var result = await _mediator.Send(new CreatePlayerCommand(item), cancellationToken);
        //    return Ok(result);
        //}
        //[HttpDelete]
        //public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        //{
        //    var result = await _mediator.Send(new RemovePlayerCommand(id), cancellationToken);
        //    return Ok(result);
        //}
    }
}
