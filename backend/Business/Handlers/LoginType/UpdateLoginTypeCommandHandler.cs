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
    public class UpdateLoginTypeCommandHandler : IRequestHandler<UpdateLoginTypeCommand, GenericCommandResult>
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<LoginType> _repository;
        private readonly ILoginTypeQueries _loginTypeQueries;

        public UpdateLoginTypeCommandHandler(
            IMediator mediator,
            IGenericRepository<LoginType> repository,
            ILoginTypeQueries loginTypeQueries)
        {
            _mediator = mediator;
            _repository = repository;
            _loginTypeQueries = loginTypeQueries;
        }

        public async Task<GenericCommandResult> Handle(UpdateLoginTypeCommand request, CancellationToken cancellationToken)
        {
            //TODO - create flunt validation

            var loginType = await _loginTypeQueries.GetByIdAsync(request.Id);

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
                    });

                    return new GenericCommandResult(true, "Successfully updated", loginType);
                }
                catch (Exception ex)
                {
                    await _mediator.Publish(new LoginTypeUpdatedNotification
                    {
                        Id = request.Id,
                        Name = request.Name,
                        IsEdited = false
                    });

                    await _mediator.Publish(new ErrorNotification { Exception = ex.Message, StackError = ex.StackTrace });

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