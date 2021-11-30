using MediatR;
using RegisterLoginAPI.Business.Commands;
using RegisterLoginAPI.Business.Models;
using RegisterLoginAPI.Business.Notifications;
using RegisterLoginAPI.Business.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using Business.Models;

namespace RegisterLoginAPI.Business.Handlers
{
    public class DeleteLoginTypeCommandHandler : IRequestHandler<DeleteLoginTypeCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<LoginTypeModel> _repository;

        public DeleteLoginTypeCommandHandler(IMediator mediator, IGenericRepository<LoginTypeModel> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(DeleteLoginTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _repository.Delete(request.Id);

                //TODO: Create notification to DeleteLoginTypeCommandHandler
                await _mediator.Publish(new RegisterLoginDeletedNotification { Id = request.Id, IsDeleted = true });

                return await Task.FromResult("Login Type successfully deleted");
            }
            catch (Exception ex)
            {
                //TODO: Create notification to DeleteLoginTypeCommandHandler
                await _mediator.Publish(new RegisterLoginDeletedNotification { Id = request.Id, IsDeleted = false });
                await _mediator.Publish(new ErrorNotification { Exception = ex.Message, StackError = ex.StackTrace });
                return await Task.FromResult("Fail on delete Login Type");
            }
        }
    }
}