using MediatR;

namespace RegisterLoginAPI.Business.Notifications
{
    public class RegisterLoginDeletedNotification : INotification
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}