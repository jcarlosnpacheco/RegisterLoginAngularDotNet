using MediatR;
using RegisterLoginAPI.Business.Commands;
using RegisterLoginAPI.Business.Models;
using RegisterLoginAPI.Business.Notifications;
using RegisterLoginAPI.Business.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RegisterLoginAPI.Business.Handlers
{
    public class UpdateRegisterLoginCommandHandler : IRequestHandler<UpdateRegisterLoginCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<RegisterLoginModel> _repository;

        public UpdateRegisterLoginCommandHandler(IMediator mediator, IGenericRepository<RegisterLoginModel> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(UpdateRegisterLoginCommand request, CancellationToken cancellationToken)
        {
            var registerLogin = new RegisterLoginModel { Id = request.Id, Description = request.Description, Date = request.Date, Value = request.Value };

            try
            {
                await _repository.Update(registerLogin);

                await _mediator.Publish(new RegisterLoginUpdatedNotification { Id = registerLogin.Id, Description = registerLogin.Description, Date = registerLogin.Date, Value = registerLogin.Value, IsEdited = true });

                return await Task.FromResult("Register Login successfully modified");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new RegisterLoginUpdatedNotification { Id = registerLogin.Id, Description = registerLogin.Description, Date = registerLogin.Date, Value = registerLogin.Value, IsEdited = false });
                await _mediator.Publish(new ErrorNotification { Exception = ex.Message, StackError = ex.StackTrace });
                return await Task.FromResult("Fail on edit Register Login");
            }
        }
    }
}