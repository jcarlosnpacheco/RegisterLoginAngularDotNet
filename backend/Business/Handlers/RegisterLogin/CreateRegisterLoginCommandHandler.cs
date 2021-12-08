using Business.Commands.Generics;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
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
        private readonly IDataProtectionProvider _dataProtectionProvider;

        public CreateRegisterLoginCommandHandler(
            IMediator mediator,
            IGenericRepository<RegisterLogin> repositoryRegisterLogin,
            IGenericRepository<LoginType> repositoryLoginType,
            IDataProtectionProvider dataProtectionProvider)
        {
            _mediator = mediator;
            _repositoryRegisterLogin = repositoryRegisterLogin;
            _repositoryLoginType = repositoryLoginType;
            _dataProtectionProvider = dataProtectionProvider;
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
                    request.Password = encrypt(request.Password);

                    var registerLogin = new RegisterLogin(
                        request.LoginName,
                        request.Password,
                        request.Observation,
                        request.LoginTypeId
                        );

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

        private string encrypt(string text)
        {
            var protector = _dataProtectionProvider.CreateProtector(text);
            return protector.Protect(text);
        }
    }
}