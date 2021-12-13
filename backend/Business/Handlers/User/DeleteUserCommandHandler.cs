using Business.Commands.Generics;
using Business.Entity;
using MediatR;
using RegisterLoginAPI.Business.Commands.User;
using RegisterLoginAPI.Business.Interfaces.Repositories;
using RegisterLoginAPI.Business.Notifications;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RegisterLoginAPI.Business.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, GenericCommandResult>
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<User> _repository;

        public DeleteUserCommandHandler(IMediator mediator, IGenericRepository<User> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<GenericCommandResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
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

                return new GenericCommandResult(true, "Successfully deleted", request);
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification
                { Exception = ex.Message, StackError = ex.StackTrace }, CancellationToken.None);

                return new GenericCommandResult(false, "Fail on delete", request);
            }
        }
    }
}