using Business.Commands.Generics;
using MediatR;
using RegisterLoginAPI.Business.Commands;
using RegisterLoginAPI.Business.Entity;
using RegisterLoginAPI.Business.Interfaces.Queries;
using RegisterLoginAPI.Business.Interfaces.Repositories;
using RegisterLoginAPI.Business.Notifications;
using RegisterLoginAPI.Business.Notifications.RegisterLogin;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RegisterLoginAPI.Business.Handlers
{
    public class CreateRegisterLoginCommandHandler : IRequestHandler<CreateRegisterLoginCommand, GenericCommandResult>
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<RegisterLogin> _repository;
        private readonly ILoginTypeQueries _loginType;

        public CreateRegisterLoginCommandHandler(
            IMediator mediator,
            IGenericRepository<RegisterLogin> repository,
            ILoginTypeQueries loginType)
        {
            _mediator = mediator;
            _repository = repository;
            _loginType = loginType;
        }

        public async Task<GenericCommandResult> Handle(CreateRegisterLoginCommand request, CancellationToken cancellationToken)
        {
            // TODO - create flund validation

            var loginType = await _loginType.GetByIdAsync(request.LoginTypeId);

            if (loginType is not null)
            {
                var registerLogin = new RegisterLogin
                {
                    LoginName = request.LoginName,
                    Password = request.Password,
                    Observation = request.Observation,
                    LoginType = loginType
                };

                try
                {
                    await _repository.Create(registerLogin);

                    await _mediator.Publish(new RegisterLoginCreatedNotification
                    {
                        LoginName = request.LoginName,
                        Observation = request.Observation,
                        LoginTypeId = request.LoginTypeId
                    });

                    return new GenericCommandResult(true, "Successfully created", registerLogin);
                }
                catch (Exception ex)
                {
                    await _mediator.Publish(new RegisterLoginCreatedNotification
                    {
                        LoginName = request.LoginName,
                        Observation = request.Observation,
                        LoginTypeId = request.LoginTypeId
                    });

                    await _mediator.Publish(new ErrorNotification { Exception = ex.Message, StackError = ex.StackTrace });

                    return new GenericCommandResult(false, "Fail on create", null);
                }
            }
            else
            {
                return new GenericCommandResult(false, "Login Type not defined!", null);
            }
        }
    }
}