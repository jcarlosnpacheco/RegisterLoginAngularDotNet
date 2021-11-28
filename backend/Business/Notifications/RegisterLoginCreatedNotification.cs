using MediatR;
using System;

namespace RegisterLoginAPI.Business.Notifications
{
    public class RegisterLoginCreatedNotification : INotification
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
    }
}