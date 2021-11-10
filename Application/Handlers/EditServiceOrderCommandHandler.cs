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
    public class EditServiceOrderCommandHandler : IRequestHandler<EditServiceOrderCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<ServiceOrder> _repository;

        public EditServiceOrderCommandHandler(IMediator mediator, IRepository<ServiceOrder> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(EditServiceOrderCommand request, CancellationToken cancellationToken)
        {
            var serviceOrder = new ServiceOrder { Id = request.Id, Description = request.Description, Date = request.Date, Value = request.Value };

            try
            {
                await _repository.Edit(serviceOrder);

                await _mediator.Publish(new ServiceOrderEditedNotification { Id = serviceOrder.Id, Description = serviceOrder.Description, Date = serviceOrder.Date, Value = serviceOrder.Value, IsEdited = true });

                return await Task.FromResult("Service Order successfully modified");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ServiceOrderEditedNotification { Id = serviceOrder.Id, Description = serviceOrder.Description, Date = serviceOrder.Date, Value = serviceOrder.Value, IsEdited = false });
                await _mediator.Publish(new ErrorNotification { Exception = ex.Message, StackError = ex.StackTrace });
                return await Task.FromResult("Fail on edit Service Order");
            }
        }
    }
}