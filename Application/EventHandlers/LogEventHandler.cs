using MediatR;
using ServiceOrderAPI.Application.Notifications;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceOrderAPI.Application.EventHandlers
{
    public class LogEventHandler :
                                INotificationHandler<ServiceOrderAddedNotification>,
                                INotificationHandler<ServiceOrderEditedNotification>,
                                INotificationHandler<ServiceOrderDeletedNotification>,
                                INotificationHandler<ErrorNotification>
    {
        public Task Handle(ServiceOrderAddedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CREATED: '{notification.Id} - {notification.Description} - {notification.Date} - {notification.Value}'");
            });
        }

        public Task Handle(ServiceOrderEditedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"EDITED: '{notification.Id} - {notification.Description} - {notification.Date} - {notification.Value} - {notification.IsEdited}'");
            });
        }

        public Task Handle(ServiceOrderDeletedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"DELETED: '{notification.Id} - {notification.IsDeleted}'");
            });
        }

        public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ERROR: '{notification.Exception} \n {notification.StackError}'");
            });
        }
    }
}