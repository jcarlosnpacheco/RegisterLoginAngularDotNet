using Business.Models;
using MediatR;
using System;

namespace RegisterLoginAPI.Business.Notifications.RegisterLogin
{
    public class RegisterLoginCreatedNotification : INotification
    {
        public int Id { get; set; }

        public string LoginName { get; set; }

        public string Observation { get; set; }

        public int LoginTypeId { get; set; }
    }
}