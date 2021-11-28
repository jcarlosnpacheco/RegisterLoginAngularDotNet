using MediatR;
using System;

namespace RegisterLoginAPI.Business.Notifications
{
    public class RegisterLoginUpdatedNotification : INotification
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public bool IsEdited { get; set; }
    }
}