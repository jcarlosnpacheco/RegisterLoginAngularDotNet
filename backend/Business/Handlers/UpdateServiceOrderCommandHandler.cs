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
    public class UpdateServiceOrderCommandHandler : IRequestHandler<UpdateServiceOrderCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<ServiceOrderModel> _repository;

        public UpdateServiceOrderCommandHandler(IMediator mediator, IGenericRepository<ServiceOrderModel> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(UpdateServiceOrderCommand request, CancellationToken cancellationToken)
        {
            var serviceOrder = new ServiceOrderModel { Id = request.Id, Description = request.Description, Date = request.Date, Value = request.Value };

            try
            {
                await _repository.Update(serviceOrder);

                await _mediator.Publish(new ServiceOrderUpdatedNotification { Id = serviceOrder.Id, Description = serviceOrder.Description, Date = serviceOrder.Date, Value = serviceOrder.Value, IsEdited = true });

                return await Task.FromResult("Service Order successfully modified");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ServiceOrderUpdatedNotification { Id = serviceOrder.Id, Description = serviceOrder.Description, Date = serviceOrder.Date, Value = serviceOrder.Value, IsEdited = false });
                await _mediator.Publish(new ErrorNotification { Exception = ex.Message, StackError = ex.StackTrace });
                return await Task.FromResult("Fail on edit Service Order");
            }
        }
    }
}