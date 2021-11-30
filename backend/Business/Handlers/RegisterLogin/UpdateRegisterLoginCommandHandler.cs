using MediatR;
using RegisterLoginAPI.Business.Commands;
using RegisterLoginAPI.Business.Models;
using RegisterLoginAPI.Business.Notifications;
using RegisterLoginAPI.Business.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using Business.Commands.Generics;

namespace RegisterLoginAPI.Business.Handlers
{
    public class UpdateRegisterLoginCommandHandler : IRequestHandler<UpdateRegisterLoginCommand, GenericCommandResult>
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<RegisterLoginModel> _repository;

        public UpdateRegisterLoginCommandHandler(IMediator mediator, IGenericRepository<RegisterLoginModel> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<GenericCommandResult> Handle(UpdateRegisterLoginCommand request, CancellationToken cancellationToken)
        {
            var registerLogin = new RegisterLoginModel
            {
                LoginName = request.LoginName,
                Password = request.Password,
                Observation = request.Observation,
                LoginType = request.LoginType
            };

            try
            {
                await _repository.Update(registerLogin);

                await _mediator.Publish(new RegisterLoginUpdatedNotification
                {
                    Id = request.Id,
                    LoginName = request.LoginName,
                    Password = request.Password,
                    Observation = request.Observation,
                    LoginType = request.LoginType,
                    IsEdited = true
                });

                return new GenericCommandResult(true, "Register Login successfully modified", registerLogin);
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new RegisterLoginUpdatedNotification
                {
                    Id = request.Id,
                    LoginName = request.LoginName,
                    Password = request.Password,
                    Observation = request.Observation,
                    LoginType = request.LoginType,
                    IsEdited = false
                });
                await _mediator.Publish(new ErrorNotification { Exception = ex.Message, StackError = ex.StackTrace });

                return new GenericCommandResult(false, "Fail on edit Register Login", registerLogin);
            }
        }
    }
}