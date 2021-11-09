using MediatR;

namespace ServiceOrderAPI.Application.Notifications
{
    public class ServiceOrderDeletedNotification : INotification
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}