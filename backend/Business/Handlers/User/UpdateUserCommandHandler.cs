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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, GenericCommandResult>
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<User> _repository;

        public UpdateUserCommandHandler(
            IMediator mediator,
            IGenericRepository<User> repository
            )
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<GenericCommandResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
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

            var user = await _repository.Get(request.Id);

            if (user is not null)
            {
                try
                {
                    user.SetUser(request);

                    await _repository.Update(user);

                    return new GenericCommandResult(true, "Successfully updated", user);
                }
                catch (Exception ex)
                {
                    await _mediator.Publish(new ErrorNotification
                    { Exception = ex.Message, StackError = ex.StackTrace }, CancellationToken.None);

                    return new GenericCommandResult(true, "Fail on update", user);
                }
            }
            else
            {
                return new GenericCommandResult(true, "Login Type not found", user);
            }
        }
    }
}