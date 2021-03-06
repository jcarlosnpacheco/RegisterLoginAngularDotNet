using MediatR;
using RegisterLoginAPI.Business.Notifications;
using RegisterLoginAPI.Business.Notifications.RegisterLogin;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RegisterLoginAPI.Business.EventHandlers
{
    public class LogEventHandler :
                                INotificationHandler<RegisterLoginCreatedNotification>,
                                INotificationHandler<RegisterLoginUpdatedNotification>,
                                INotificationHandler<RegisterLoginDeletedNotification>,
                                INotificationHandler<ErrorNotification>
    {
        public Task Handle(RegisterLoginCreatedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CREATED: '{notification.Id} - {notification.LoginName} - {notification.Observation} '");
            });
        }

        public Task Handle(RegisterLoginUpdatedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"EDITED: '{notification.Id} - {notification.LoginName} - {notification.Observation} - {notification.IsEdited}'");
            });
        }

        public Task Handle(RegisterLoginDeletedNotification notification, CancellationToken cancellationToken)
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