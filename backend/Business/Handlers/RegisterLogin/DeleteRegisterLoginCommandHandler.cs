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
    public class DeleteRegisterLoginCommandHandler : IRequestHandler<DeleteRegisterLoginCommand, GenericCommandResult>
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<RegisterLoginModel> _repository;

        public DeleteRegisterLoginCommandHandler(IMediator mediator, IGenericRepository<RegisterLoginModel> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<GenericCommandResult> Handle(DeleteRegisterLoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _repository.Delete(request.Id);

                await _mediator.Publish(new RegisterLoginDeletedNotification { Id = request.Id, IsDeleted = true });
                return new GenericCommandResult(true, "Register Login successfully deleted", request);
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new RegisterLoginDeletedNotification { Id = request.Id, IsDeleted = false });
                await _mediator.Publish(new ErrorNotification { Exception = ex.Message, StackError = ex.StackTrace });
                return new GenericCommandResult(false, "Fail on delete Register Login", request);
            }
        }
    }
}