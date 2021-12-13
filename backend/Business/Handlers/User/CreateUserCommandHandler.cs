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
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, GenericCommandResult>
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<User> _repository;

        public CreateUserCommandHandler(IMediator mediator, IGenericRepository<User> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<GenericCommandResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
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

            var user = new User(request.Id, request.Name, request.Password, request.Role);

            try
            {
                await _repository.Create(user);

                return new GenericCommandResult(true, "Successfully created", user);
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification
                { Exception = ex.Message, StackError = ex.StackTrace },
                CancellationToken.None);

                return new GenericCommandResult(false, "Fail on create ", user);
            }
        }
    }
}