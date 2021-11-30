using Business.Commands.Generics;
using MediatR;
using RegisterLoginAPI.Business.Commands;
using RegisterLoginAPI.Business.Interfaces.Repositories;
using RegisterLoginAPI.Business.Models;
using RegisterLoginAPI.Business.Notifications;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RegisterLoginAPI.Business.Handlers
{
    public class CreateRegisterLoginCommandHandler : IRequestHandler<CreateRegisterLoginCommand, GenericCommandResult>
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<RegisterLoginModel> _repository;

        public CreateRegisterLoginCommandHandler(IMediator mediator, IGenericRepository<RegisterLoginModel> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<GenericCommandResult> Handle(CreateRegisterLoginCommand request, CancellationToken cancellationToken)
        {
            //TODO - criar um entity ao invés de model
            var registerLogin = new RegisterLoginModel
            {
                LoginName = request.LoginName,
                Password = request.Password,
                Observation = request.Observation,
                LoginType = request.LoginType
            };

            try
            {
                await _repository.Create(registerLogin);

                await _mediator.Publish(new RegisterLoginCreatedNotification
                {
                    LoginName = request.LoginName,
                    Password = request.Password,
                    Observation = request.Observation,
                    LoginType = request.LoginType
                });

                return new GenericCommandResult(true, "Register Login successfully created", registerLogin);
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new RegisterLoginCreatedNotification
                {
                    Id = request.Id,
                    LoginName = request.LoginName,
                    Password = request.Password,
                    Observation = request.Observation,
                    LoginType = request.LoginType
                });
                await _mediator.Publish(new ErrorNotification { Exception = ex.Message, StackError = ex.StackTrace });

                return new GenericCommandResult(false, "Fail on create Register Login", null);
            }
        }
    }
}