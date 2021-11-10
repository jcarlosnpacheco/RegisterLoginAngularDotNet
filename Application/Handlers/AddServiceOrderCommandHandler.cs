using MediatR;
using ServiceOrderAPI.Application.Commands;
using ServiceOrderAPI.Application.Models;
using ServiceOrderAPI.Application.Notifications;
using ServiceOrderAPI.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceOrderAPI.Application.Handlers
{
    public class AddServiceOrderCommandHandler : IRequestHandler<AddServiceOrderCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<ServiceOrder> _repository;

        public AddServiceOrderCommandHandler(IMediator mediator, IRepository<ServiceOrder> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(AddServiceOrderCommand request, CancellationToken cancellationToken)
        {
            var serviceOrder = new ServiceOrder { Description = request.Description, Date = request.Date, Value = request.Value };

            try
            {
                await _repository.Add(serviceOrder);

                await _mediator.Publish(new ServiceOrderAddedNotification { Id = serviceOrder.Id, Description = serviceOrder.Description, Date = serviceOrder.Date, Value = serviceOrder.Value });

                return await Task.FromResult("Service Order successfully created");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ServiceOrderAddedNotification { Id = serviceOrder.Id, Description = serviceOrder.Description, Date = serviceOrder.Date, Value = serviceOrder.Value });
                await _mediator.Publish(new ErrorNotification { Exception = ex.Message, StackError = ex.StackTrace });
                return await Task.FromResult("Fail on create Service Order");
            }
        }
    }
}