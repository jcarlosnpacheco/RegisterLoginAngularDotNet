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
    public class UpdateLoginTypeCommandHandler : IRequestHandler<UpdateLoginTypeCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<RegisterLoginModel> _repository;

        public UpdateLoginTypeCommandHandler(IMediator mediator, IGenericRepository<RegisterLoginModel> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(UpdateLoginTypeCommand request, CancellationToken cancellationToken)
        {
            var loginType = new RegisterLoginModel
            {
                //Id = request.Id,
                //Name = request.Name
            };

            try
            {
                await _repository.Update(loginType);

                //TODO: Create notification to UpdateLoginTypeCommandHandler
                await _mediator.Publish(new RegisterLoginUpdatedNotification
                {
                    //Id = request.Id,
                    //Name = request.Name
                    IsEdited = true
                });

                return await Task.FromResult("Login Type successfully modified");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new RegisterLoginUpdatedNotification
                {
                    //Id = request.Id,
                    //Name = request.Name
                    IsEdited = false
                });
                await _mediator.Publish(new ErrorNotification { Exception = ex.Message, StackError = ex.StackTrace });
                return await Task.FromResult("Fail on edit Login Type");
            }
        }
    }
}