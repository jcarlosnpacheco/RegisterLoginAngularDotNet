using MediatR;
using Microsoft.AspNetCore.Mvc;
using RegisterLoginAPI.Business.Commands.User;
using RegisterLoginAPI.Business.Interfaces.Queries;
using System.Threading.Tasks;

namespace RegisterLoginAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator, IUserQueries userQueries)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var obj = new DeleteUserCommand(id);
            var result = await _mediator.Send(obj);
            return Ok(result);
        }
    }
}