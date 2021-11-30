using Business.Commands.Generics;
using Business.Models;
using MediatR;
using RegisterLoginAPI.Business.Commands;
using RegisterLoginAPI.Business.Interfaces.Repositories;
using RegisterLoginAPI.Business.Notifications;
using RegisterLoginAPI.Business.Notifications.RegisterLogin;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RegisterLoginAPI.Business.Handlers
{
    public class DeleteLoginTypeCommandHandler : IRequestHandler<DeleteLoginTypeCommand, GenericCommandResult>
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<LoginTypeModel> _repository;

        public DeleteLoginTypeCommandHandler(IMediator mediator, IGenericRepository<LoginTypeModel> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<GenericCommandResult> Handle(DeleteLoginTypeCommand request, CancellationToken cancellationToken)
        {
            //TODO - create flunt validation

            try
            {
                _repository.Delete(request.Id);

                await _mediator.Publish(new LoginTypeDeletedNotification { Id = request.Id, IsDeleted = true });

                return new GenericCommandResult(true, "Successfully deleted", request);
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new LoginTypeDeletedNotification { Id = request.Id, IsDeleted = false });
                await _mediator.Publish(new ErrorNotification { Exception = ex.Message, StackError = ex.StackTrace });

                return new GenericCommandResult(false, "Fail on delete", request);
            }
        }
    }
}