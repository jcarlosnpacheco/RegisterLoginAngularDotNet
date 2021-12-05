using Business.Commands.Generics;
using Business.Commands.RegisterLogin.Contracts;
using Flunt.Notifications;
using MediatR;

namespace RegisterLoginAPI.Business.Commands
{
    public class DeleteRegisterLoginCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
    {
        public int Id { get; set; }

        #region Methods

        public DeleteRegisterLoginCommand(int id)
        {
            Id = id;
        }

        public void Validate()
        {
            AddNotifications(new DeleteRegisterLoginContract(this));
        }

        #endregion Methods
    }
}