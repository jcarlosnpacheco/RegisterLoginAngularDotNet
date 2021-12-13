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
    public class CreateRegisterLoginCommandHandler : IRequestHandler<CreateRegisterLoginCommand, GenericCommandResult>
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<RegisterLogin> _repositoryRegisterLogin;
        private readonly IGenericRepository<LoginType> _repositoryLoginType;

        public CreateRegisterLoginCommandHandler(
            IMediator mediator,
            IGenericRepository<RegisterLogin> repositoryRegisterLogin,
            IGenericRepository<LoginType> repositoryLoginType)
        {
            _mediator = mediator;
            _repositoryRegisterLogin = repositoryRegisterLogin;
            _repositoryLoginType = repositoryLoginType;
        }

        public async Task<GenericCommandResult> Handle(CreateRegisterLoginCommand request, CancellationToken cancellationToken)
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

            var loginType = await _repositoryLoginType.Get(request.LoginTypeId);

            if (loginType is not null)
            {
                try
                {
                    var registerLogin = new RegisterLogin(
                        request.LoginName,
                        request.Password,
                        request.Observation,
                        request.LoginTypeId
                        );

                    registerLogin.SetEncryptPassword(request.Password, request.LoginName);

                    await _repositoryRegisterLogin.Create(registerLogin);

                    await _mediator.Publish(new RegisterLoginCreatedNotification
                    {
                        LoginName = request.LoginName,
                        Observation = request.Observation,
                        LoginTypeId = request.LoginTypeId
                    }, CancellationToken.None);

                    request.Password = null;

                    return new GenericCommandResult(true, "Successfully created", request);
                }
                catch (Exception ex)
                {
                    await _mediator.Publish(new RegisterLoginCreatedNotification
                    {
                        LoginName = request.LoginName,
                        Observation = request.Observation,
                        LoginTypeId = request.LoginTypeId
                    }, CancellationToken.None);

                    await _mediator.Publish(new ErrorNotification
                    { Exception = ex.Message, StackError = ex.StackTrace }, CancellationToken.None);

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