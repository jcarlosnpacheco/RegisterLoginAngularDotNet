using Flunt.Validations;
using RegisterLoginAPI.Business.Commands;

namespace Business.Commands.RegisterLogin.Contracts
{
    public class UpdateRegisterLoginContract : Contract<UpdateRegisterLoginCommand>
    {
        public UpdateRegisterLoginContract(UpdateRegisterLoginCommand command)
        {
            Requires()
                .IsNotNull(command.Id, "Id", "Id required")
                .IsNotNull(command.LoginName, "LoginName", "LoginName required")
                .IsNotNull(command.Password, "Password", "Password required")
                .IsNotNull(command.LoginTypeId, "LoginTypeId", "LoginTypeId required")
                .IsLowerOrEqualsThan(command.LoginName, 50, "LoginName", "LoginName must be until 50 characters")
                .IsTrue(command.Id > 0, "Id", "Id must be greater 0");
        }
    }
}