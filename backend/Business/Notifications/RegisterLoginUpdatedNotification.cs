using Business.Models;
using MediatR;

namespace RegisterLoginAPI.Business.Notifications
{
    public class RegisterLoginUpdatedNotification : INotification
    {
        public int Id { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public string Observation { get; set; }

        public LoginTypeModel LoginType { get; set; }

        public bool IsEdited { get; set; }
    }
}