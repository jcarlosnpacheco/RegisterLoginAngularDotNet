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
    public class DeleteRegisterLoginCommandHandler : IRequestHandler<DeleteRegisterLoginCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<RegisterLoginModel> _repository;

        public DeleteRegisterLoginCommandHandler(IMediator mediator, IGenericRepository<RegisterLoginModel> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<string> Handle(DeleteRegisterLoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _repository.Delete(request.Id);

                await _mediator.Publish(new RegisterLoginDeletedNotification { Id = request.Id, IsDeleted = true });

                return await Task.FromResult("Register Login successfully deleted");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new RegisterLoginDeletedNotification { Id = request.Id, IsDeleted = false });
                await _mediator.Publish(new ErrorNotification { Exception = ex.Message, StackError = ex.StackTrace });
                return await Task.FromResult("Fail on delete Register Login");
            }
        }
    }
}