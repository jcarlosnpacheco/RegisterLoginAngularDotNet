using Microsoft.AspNetCore.DataProtection;
using RegisterLoginAPI.Business.Commands;

namespace RegisterLoginAPI.Business.Entity
{
    public class RegisterLogin
    {
        public int Id { get; protected set; }

        public string LoginName { get; protected set; }

        public string Password { get; protected set; }

        public string Observation { get; protected set; }

        public int LoginTypeId { get; protected set; }

        public RegisterLogin()
        { }

        public RegisterLogin(

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

        public void SetUpdateRegisterLogin(UpdateRegisterLoginCommand command)
        {
            Id = command.Id;
            LoginName = command.LoginName;
            Password = command.Password;
            Observation = command.Observation;
            LoginTypeId = command.LoginTypeId;
        }
    }
}