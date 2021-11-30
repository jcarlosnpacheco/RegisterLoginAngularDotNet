using MediatR;

namespace RegisterLoginAPI.Business.Commands
{
    public class DeleteLoginTypeCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}