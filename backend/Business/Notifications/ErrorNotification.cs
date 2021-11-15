using MediatR;

namespace ServiceOrderAPI.Business.Notifications
{
    public class ErrorNotification : INotification
    {
        public string Exception { get; set; }
        public string StackError { get; set; }
    }
}