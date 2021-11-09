using MediatR;

namespace ServiceOrderAPI.Application.Commands
{
    public class DeleteServiceOrderCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}