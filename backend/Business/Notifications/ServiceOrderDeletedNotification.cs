using MediatR;

namespace ServiceOrderAPI.Business.Notifications
{
    public class ServiceOrderDeletedNotification : INotification
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}