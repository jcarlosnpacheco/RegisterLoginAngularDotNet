using Business.Commands.Generics;
using Business.Commands.User.Contracts;
using Flunt.Notifications;
using MediatR;

namespace RegisterLoginAPI.Business.Commands.User
{
    public class CreateUserCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        #region Methods

        public CreateUserCommand(string name, string password, string role)
        {
            Name = name;
            Password = password;
            Role = role;
        }

        public void Validate()
        {
            AddNotifications(new CreateUserContract(this));
        }

        #endregion Methods
    }
}