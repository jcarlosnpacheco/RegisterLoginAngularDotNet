using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegisterLoginAPI.Business.Commands.LoginType;
using RegisterLoginAPI.Business.Interfaces.Queries;
using System.Threading.Tasks;

namespace RegisterLoginAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILoginTypeQueries _loginTypeQueries;

        public LoginTypeController(IMediator mediator, ILoginTypeQueries loginTypeQueries)
        {
            _mediator = mediator;
            _loginTypeQueries = loginTypeQueries;
        }

        [HttpGet]
        [Authorize(Roles = "admin, users")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _loginTypeQueries.GetAllAsync());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin, users")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _loginTypeQueries.GetByIdAsync(id));
        }

        [HttpPost]
        [Authorize(Roles = "admin, users")]
        public async Task<IActionResult> Post([FromBody] CreateLoginTypeCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "admin, users")]
        public async Task<IActionResult> Put([FromBody] UpdateLoginTypeCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin, users")]
        public async Task<IActionResult> Delete(int id)
        {
            var obj = new DeleteLoginTypeCommand(id);
            var result = await _mediator.Send(obj);
            return Ok(result);
        }
    }
}