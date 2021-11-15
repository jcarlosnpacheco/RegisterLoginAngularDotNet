using MediatR;
using ServiceOrderAPI.Business.Notifications;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceOrderAPI.Business.EventHandlers
{
    public class LogEventHandler :
                                INotificationHandler<ServiceOrderCreatedNotification>,
                                INotificationHandler<ServiceOrderUpdatedNotification>,
                                INotificationHandler<ServiceOrderDeletedNotification>,
                                INotificationHandler<ErrorNotification>
    {
        public Task Handle(ServiceOrderCreatedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CREATED: '{notification.Id} - {notification.Description} - {notification.Date} - {notification.Value}'");
            });
        }

        public Task Handle(ServiceOrderUpdatedNotification notification, CancellationToken cancellationToken)
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