using MediatR;

namespace ServiceOrderAPI.Business.Commands
{
    public class DeleteServiceOrderCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}