using Business.Commands.Generics;
using MediatR;

namespace RegisterLoginAPI.Business.Commands
{
    public class DeleteRegisterLoginCommand : IRequest<GenericCommandResult>
    {
        public int Id { get; set; }
    }
}