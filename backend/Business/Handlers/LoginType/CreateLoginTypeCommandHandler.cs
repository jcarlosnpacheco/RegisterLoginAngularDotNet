using Business.Models;
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
    public class CreateLoginTypeCommandHandler : IRequestHandler<CreateLoginTypeCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<LoginTypeModel> _repository;

        public CreateLoginTypeCommandHandler(IMediator mediator, IGenericRepository<LoginTypeModel> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(CreateLoginTypeCommand request, CancellationToken cancellationToken)
        {
            var loginType = new LoginTypeModel
            {
                //Id = request.Id,
                //Name = request.Name
            };

            try
            {
                await _repository.Create(loginType);

                await _mediator.Publish(new RegisterLoginCreatedNotification
                {
                    //Id = request.Id,
                    //Name = request.Name
                });

                return await Task.FromResult("Login Type successfully created");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new RegisterLoginCreatedNotification
                {
                    //Id = request.Id,
                    //Name = request.Name
                });
                await _mediator.Publish(new ErrorNotification { Exception = ex.Message, StackError = ex.StackTrace });
                return await Task.FromResult("Fail on create Login Type");
            }
        }
    }
}