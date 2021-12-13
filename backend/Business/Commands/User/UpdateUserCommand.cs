using Business.Commands.Generics;
using Business.Commands.User.Contracts;
using Flunt.Notifications;
using MediatR;

namespace RegisterLoginAPI.Business.Commands.User
{
    public class UpdateUserCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        #region Methods

        public UpdateUserCommand(int id, string name, string password, string role)
        {
            Id = id;
            Name = name;
            Password = password;
            Role = role;
        }

        public void Validate()
        {
            AddNotifications(new UpdateUserContract(this));
        }

        #endregion Methods
    }
}