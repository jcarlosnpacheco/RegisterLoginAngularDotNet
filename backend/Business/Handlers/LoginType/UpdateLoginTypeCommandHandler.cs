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
    public class UpdateLoginTypeCommandHandler : IRequestHandler<UpdateLoginTypeCommand, GenericCommandResult>
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<LoginType> _repository;

        public UpdateLoginTypeCommandHandler(
            IMediator mediator,
            IGenericRepository<LoginType> repository
            )
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<GenericCommandResult> Handle(UpdateLoginTypeCommand request, CancellationToken cancellationToken)
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

            var loginType = await _repository.Get(request.Id);

            if (loginType is not null)
            {
                try
                {
                    loginType.Name = request.Name;

                    await _repository.Update(loginType);

                    await _mediator.Publish(new LoginTypeUpdatedNotification
                    {
                        Id = request.Id,
                        Name = request.Name,
                        IsEdited = true
                    }, CancellationToken.None);

                    return new GenericCommandResult(true, "Successfully updated", loginType);
                }
                catch (Exception ex)
                {
                    await _mediator.Publish(new LoginTypeUpdatedNotification
                    {
                        Id = request.Id,
                        Name = request.Name,
                        IsEdited = false
                    }, CancellationToken.None);

                    await _mediator.Publish(new ErrorNotification
                    { Exception = ex.Message, StackError = ex.StackTrace }, CancellationToken.None);

                    return new GenericCommandResult(true, "Fail on update", loginType);
                }
            }
            else
            {
                return new GenericCommandResult(true, "Login Type not found", loginType);
            }
        }
    }
}