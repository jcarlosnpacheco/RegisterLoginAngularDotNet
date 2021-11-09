using MediatR;
using System;

namespace ServiceOrderAPI.Application.Notifications
{
    public class ServiceOrderEditedNotification : INotification
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public bool IsEdited { get; set; }
    }
}