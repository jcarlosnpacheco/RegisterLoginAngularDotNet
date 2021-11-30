using Business.Models;
using MediatR;

namespace RegisterLoginAPI.Business.Notifications.RegisterLogin
{
    public class RegisterLoginUpdatedNotification : INotification
    {
        public int Id { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public string Observation { get; set; }

        public int LoginTypeId { get; set; }

        public bool IsEdited { get; set; }
    }
}