using Business.Commands.Generics;
using Business.Commands.RegisterLogin.Contracts;
using Flunt.Notifications;
using MediatR;

namespace RegisterLoginAPI.Business.Commands
{
    public class CreateRegisterLoginCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
    {
        public int Id { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public string Observation { get; set; }

        public int LoginTypeId { get; set; }

        #region Methods

        public CreateRegisterLoginCommand(
            string loginName,
            string password,
            string observation,
            int loginTypeId)
        {
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