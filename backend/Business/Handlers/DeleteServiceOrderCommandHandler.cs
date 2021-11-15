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
    public class DeleteServiceOrderCommandHandler : IRequestHandler<DeleteServiceOrderCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<ServiceOrderModel> _repository;

        public DeleteServiceOrderCommandHandler(IMediator mediator, IGenericRepository<ServiceOrderModel> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(DeleteServiceOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _repository.Delete(request.Id);

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