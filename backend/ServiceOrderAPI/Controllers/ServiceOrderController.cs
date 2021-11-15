using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServiceOrderAPI.Business.Commands;
using ServiceOrderAPI.Business.Interfaces.Queries;
using System.Threading.Tasks;

namespace ServiceOrderAPI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceOrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IServiceOrderQueries _serviceOrderQueries;

        public ServiceOrderController(IMediator mediator, IServiceOrderQueries serviceOrderQueries)
        {
            _mediator = mediator;
            _serviceOrderQueries = serviceOrderQueries;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _serviceOrderQueries.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _serviceOrderQueries.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateServiceOrderCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateServiceOrderCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var obj = new DeleteServiceOrderCommand { Id = id };
            var result = await _mediator.Send(obj);
            return Ok(result);
        }
    }
}