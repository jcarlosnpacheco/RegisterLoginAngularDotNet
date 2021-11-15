using MediatR;
using ServiceOrderAPI.Business.Commands;
using ServiceOrderAPI.Business.Models;
using ServiceOrderAPI.Business.Notifications;
using ServiceOrderAPI.Business.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceOrderAPI.Business.Handlers
{
    public class CreateServiceOrderCommandHandler : IRequestHandler<CreateServiceOrderCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<ServiceOrderModel> _repository;

        public CreateServiceOrderCommandHandler(IMediator mediator, IGenericRepository<ServiceOrderModel> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(CreateServiceOrderCommand request, CancellationToken cancellationToken)
        {
            var serviceOrder = new ServiceOrderModel { Description = request.Description, Date = request.Date, Value = request.Value };

            try
            {
                await _repository.Create(serviceOrder);

                await _mediator.Publish(new ServiceOrderCreatedNotification { Id = serviceOrder.Id, Description = serviceOrder.Description, Date = serviceOrder.Date, Value = serviceOrder.Value });

                return await Task.FromResult("Service Order successfully created");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ServiceOrderCreatedNotification { Id = serviceOrder.Id, Description = serviceOrder.Description, Date = serviceOrder.Date, Value = serviceOrder.Value });
                await _mediator.Publish(new ErrorNotification { Exception = ex.Message, StackError = ex.StackTrace });
                return await Task.FromResult("Fail on create Service Order");
            }
        }
    }
}