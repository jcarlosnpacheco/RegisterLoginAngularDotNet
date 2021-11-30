using MediatR;

namespace RegisterLoginAPI.Business.Notifications.RegisterLogin
{
    public class LoginTypeUpdatedNotification : INotification
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsEdited { get; set; }
    }
}