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
    public class DeleteServiceOrderCommandHandler : IRequestHandler<DeleteServiceOrderCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<ServiceOrder> _repository;

        public DeleteServiceOrderCommandHandler(IMediator mediator, IRepository<ServiceOrder> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(DeleteServiceOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.Delete(request.Id);

                await _mediator.Publish(new ServiceOrderDeletedNotification { Id = request.Id, IsDeleted = true });

                return await Task.FromResult("Service Order successfully deleted");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ServiceOrderDeletedNotification { Id = request.Id, IsDeleted = false });
                await _mediator.Publish(new ErrorNotification { Exception = ex.Message, StackError = ex.StackTrace });
                return await Task.FromResult("Fail on delete Service Order");
            }
        }
    }
}