using MediatR;

namespace RegisterLoginAPI.Business.Notifications.RegisterLogin
{
    public class LoginTypeDeletedNotification : INotification
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}