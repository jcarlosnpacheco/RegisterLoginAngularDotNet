using MediatR;

namespace RegisterLoginAPI.Business.Commands
{
    public class DeleteRegisterLoginCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}