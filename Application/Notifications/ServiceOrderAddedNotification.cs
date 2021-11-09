using MediatR;
using System;

namespace ServiceOrderAPI.Application.Notifications
{
    public class ServiceOrderAddedNotification : INotification
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
    }
}