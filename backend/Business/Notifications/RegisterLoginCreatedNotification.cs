using Business.Models;
using MediatR;
using System;

namespace RegisterLoginAPI.Business.Notifications
{
    public class RegisterLoginCreatedNotification : INotification
    {
        public int Id { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public string Observation { get; set; }

        public LoginTypeModel LoginType { get; set; }
    }
}