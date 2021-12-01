using Business.Commands.Generics;
using Business.Commands.LoginType.Contracts;
using Flunt.Notifications;
using MediatR;

namespace RegisterLoginAPI.Business.Commands
{
    public class UpdateLoginTypeCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }

        #region Methods

        public UpdateLoginTypeCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void Validate()
        {
            AddNotifications(new UpdateLoginTypeContract(this));
        }

        #endregion Methods
    }
}