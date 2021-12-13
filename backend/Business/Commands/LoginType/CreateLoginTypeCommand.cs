using Business.Commands.Generics;
using Business.Commands.LoginType.Contracts;
using Flunt.Notifications;
using MediatR;

namespace RegisterLoginAPI.Business.Commands.LoginType
{
    public class CreateLoginTypeCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        #region Methods

        public CreateLoginTypeCommand(string name)
        {
            Name = name;
        }

        public void Validate()
        {
            AddNotifications(new CreateLoginTypeContract(this));
        }

        #endregion Methods
    }
}