using Business.Commands.Generics;
using Business.Commands.User.Contracts;
using Flunt.Notifications;
using MediatR;

namespace RegisterLoginAPI.Business.Commands.User
{
    public class DeleteUserCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
    {
        public int Id { get; set; }

        #region Methods

        public DeleteUserCommand(int id)
        {
            Id = id;
        }

        public void Validate()
        {
            AddNotifications(new DeleteUserContract(this));
        }

        #endregion Methods
    }
}