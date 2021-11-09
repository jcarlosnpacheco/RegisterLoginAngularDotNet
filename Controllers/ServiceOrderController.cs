using MediatR;
using ServiceOrderAPI.Application.Commands;
using ServiceOrderAPI.Application.Models;
using ServiceOrderAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ServiceOrderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceOrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRepository<ServiceOrder> _repository;

        public ServiceOrderController(IMediator mediator, IRepository<ServiceOrder> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _repository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddServiceOrderCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(EditServiceOrderCommand command)
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