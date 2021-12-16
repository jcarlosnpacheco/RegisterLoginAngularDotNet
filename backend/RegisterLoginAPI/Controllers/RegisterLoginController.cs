using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegisterLoginAPI.Business.Commands;
using RegisterLoginAPI.Business.Interfaces.Queries;
using System.Threading.Tasks;

namespace RegisterLoginAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterLoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IRegisterLoginQueries _registerLoginQueries;

        public RegisterLoginController(IMediator mediator, IRegisterLoginQueries registerLoginQueries)
        {
            _mediator = mediator;
            _registerLoginQueries = registerLoginQueries;
        }

        [HttpGet]
        [Authorize(Roles = "admin, users")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _registerLoginQueries.GetAllAsync());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin, users")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _registerLoginQueries.GetByIdAsync(id));
        }

        [HttpPost]
        [Authorize(Roles = "admin, users")]
        public async Task<IActionResult> Post([FromBody] CreateRegisterLoginCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "admin, users")]
        public async Task<IActionResult> Put([FromBody] UpdateRegisterLoginCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin, users")]
        public async Task<IActionResult> Delete(int id)
        {
            var obj = new DeleteRegisterLoginCommand(id);
            var result = await _mediator.Send(obj);
            return Ok(result);
        }
    }
}