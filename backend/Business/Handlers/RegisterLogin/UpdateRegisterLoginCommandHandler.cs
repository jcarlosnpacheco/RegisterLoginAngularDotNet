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
    public class UpdateRegisterLoginCommandHandler : IRequestHandler<UpdateRegisterLoginCommand, GenericCommandResult>
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<RegisterLogin> _repository;
        private readonly IRegisterLoginQueries _registerLogin;

        public UpdateRegisterLoginCommandHandler(
            IMediator mediator,
            IGenericRepository<RegisterLogin> repository,
            IRegisterLoginQueries registerLoginQueries)
        {
            _mediator = mediator;
            _repository = repository;
            _registerLogin = registerLoginQueries;
        }

        public async Task<GenericCommandResult> Handle(UpdateRegisterLoginCommand request, CancellationToken cancellationToken)
        {
            //TODO - create flunt validation

            var registerLogin = await _registerLogin.GetByIdAsync(request.Id);

            if (registerLogin is not null)
            {
                try
                {
                    await _repository.Update(registerLogin);

                    await _mediator.Publish(new RegisterLoginUpdatedNotification
                    {
                        Id = request.Id,
                        LoginName = request.LoginName,
                        Observation = request.Observation,
                        LoginTypeId = request.LoginTypeId,
                        IsEdited = true
                    });

                    return new GenericCommandResult(true, "Successfully modified", registerLogin);
                }
                catch (Exception ex)
                {
                    await _mediator.Publish(new RegisterLoginUpdatedNotification
                    {
                        Id = request.Id,
                        LoginName = request.LoginName,
                        Observation = request.Observation,
                        LoginTypeId = request.LoginTypeId,
                        IsEdited = false
                    });
                    await _mediator.Publish(new ErrorNotification { Exception = ex.Message, StackError = ex.StackTrace });

                    return new GenericCommandResult(false, "Fail on", registerLogin);
                }
            }
            else
            {
                return new GenericCommandResult(false, "Register login not found", registerLogin);
            }
        }
    }
}