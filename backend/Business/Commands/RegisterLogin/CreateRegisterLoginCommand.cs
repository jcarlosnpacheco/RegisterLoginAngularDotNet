using Business.Commands.Generics;
using Business.Commands.RegisterLogin.Contracts;
using Flunt.Notifications;
using MediatR;

namespace RegisterLoginAPI.Business.Commands
{
    public class CreateRegisterLoginCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
    {
        public int Id { get; protected set; }

        public string LoginName { get; protected set; }

        public string Password { get; protected set; }

        public string Observation { get; protected set; }

        public int LoginTypeId { get; protected set; }

        #region Methods

        public CreateRegisterLoginCommand(
            int id,
            string loginName,
            string password,
            string observation,
            int loginTypeId)
        {
            Id = id;
            LoginName = loginName;
            Password = password;
            Observation = observation;
            LoginTypeId = loginTypeId;
        }

        public void Validate()
        {
            AddNotifications(new CreateRegisterLoginContract(this));
        }

        #endregion Methods
    }
}