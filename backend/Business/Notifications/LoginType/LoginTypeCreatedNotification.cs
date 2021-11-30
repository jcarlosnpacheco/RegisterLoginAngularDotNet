using MediatR;

namespace RegisterLoginAPI.Business.Notifications.RegisterLogin
{
    public class LoginTypeCreatedNotification : INotification
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}