using Business.Commands.Generics;
using Business.Commands.LoginType.Contracts;
using Flunt.Notifications;
using MediatR;

namespace RegisterLoginAPI.Business.Commands
{
    public class DeleteLoginTypeCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
    {
        public int Id { get; set; }

        #region Methods

        public DeleteLoginTypeCommand(int id)
        {
            Id = id;
        }

        public void Validate()
        {
            AddNotifications(new DeleteLoginTypeContract(this));
        }

        #endregion Methods
    }
}