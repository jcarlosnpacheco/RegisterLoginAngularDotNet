using Business.Commands.Generics;
using MediatR;
using RegisterLoginAPI.Business.Commands;
using RegisterLoginAPI.Business.Entity;
using RegisterLoginAPI.Business.Interfaces.Repositories;
using RegisterLoginAPI.Business.Notifications;
using RegisterLoginAPI.Business.Notifications.RegisterLogin;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RegisterLoginAPI.Business.Handlers
{
    public class CreateLoginTypeCommandHandler : IRequestHandler<CreateLoginTypeCommand, GenericCommandResult>
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<LoginType> _repository;

        public CreateLoginTypeCommandHandler(IMediator mediator, IGenericRepository<LoginType> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<GenericCommandResult> Handle(CreateLoginTypeCommand request, CancellationToken cancellationToken)
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

            var loginType = new LoginType(request.Id, request.Name);

            try
            {
                await _repository.Create(loginType);

                await _mediator.Publish(new LoginTypeCreatedNotification
                {
                    Id = request.Id,
                    Name = request.Name
                }, CancellationToken.None);

                return new GenericCommandResult(true, "Successfully created", loginType);
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new LoginTypeCreatedNotification
                {
                    Id = request.Id,
                    Name = request.Name
                }, CancellationToken.None);

                await _mediator.Publish(new ErrorNotification
                { Exception = ex.Message, StackError = ex.StackTrace },
                CancellationToken.None);

                return new GenericCommandResult(false, "Fail on create ", loginType);
            }
        }
    }
}