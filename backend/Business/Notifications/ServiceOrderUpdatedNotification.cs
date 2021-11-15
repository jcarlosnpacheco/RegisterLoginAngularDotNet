using MediatR;
using System;

namespace ServiceOrderAPI.Business.Notifications
{
    public class ServiceOrderUpdatedNotification : INotification
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public bool IsEdited { get; set; }
    }
}