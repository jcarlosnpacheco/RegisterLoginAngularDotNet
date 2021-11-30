using MediatR;
using Microsoft.AspNetCore.Mvc;
using RegisterLoginAPI.Business.Commands;
using RegisterLoginAPI.Business.Interfaces.Queries;
using System.Threading.Tasks;

namespace RegisterLoginAPI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginTypeControllerController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILoginTypeQueries _loginTypeQueries;

        public LoginTypeControllerController(IMediator mediator, ILoginTypeQueries loginTypeQueries)
        {
            _mediator = mediator;
            _loginTypeQueries = loginTypeQueries;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _loginTypeQueries.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _loginTypeQueries.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLoginTypeCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateLoginTypeCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var obj = new DeleteLoginTypeCommand(id);
            var result = await _mediator.Send(obj);
            return Ok(result);
        }
    }
}