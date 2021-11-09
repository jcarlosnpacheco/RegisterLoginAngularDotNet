using MediatR;

namespace ServiceOrderAPI.Application.Notifications
{
    public class ErrorNotification : INotification
    {
        public string Exception { get; set; }
        public string StackError { get; set; }
    }
}