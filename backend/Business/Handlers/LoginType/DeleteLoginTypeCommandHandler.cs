using Business.Commands.Generics;
using MediatR;
using RegisterLoginAPI.Business.Commands.LoginType;
using RegisterLoginAPI.Business.Entity;
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
        private readonly IGenericRepository<LoginType> _repository;

        public DeleteLoginTypeCommandHandler(IMediator mediator, IGenericRepository<LoginType> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<GenericCommandResult> Handle(DeleteLoginTypeCommand request, CancellationToken cancellationToken)
        {
            // Fail Fast Validate
            request.Validate();

            if (!request.IsValid)
            {
                return new GenericCommandResult(
                    false,
                    "Ops! Validate's fail!",
                    request.Notifications);
            }

            try
            {
                _repository.Delete(request.Id);

                await _mediator.Publish(new LoginTypeDeletedNotification
                { Id = request.Id, IsDeleted = true }, CancellationToken.None);

                return new GenericCommandResult(true, "Successfully deleted", request);
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new LoginTypeDeletedNotification
                { Id = request.Id, IsDeleted = false }, CancellationToken.None);

                await _mediator.Publish(new ErrorNotification
                { Exception = ex.Message, StackError = ex.StackTrace }, CancellationToken.None);

                return new GenericCommandResult(false, "Fail on delete", request);
            }
        }
    }
}