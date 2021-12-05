using Flunt.Validations;
using RegisterLoginAPI.Business.Commands;

namespace Business.Commands.RegisterLogin.Contracts
{
    public class UpdateRegisterLoginContract : Contract<UpdateRegisterLoginCommand>
    {
        public UpdateRegisterLoginContract(UpdateRegisterLoginCommand command)
        {
            Requires()
                .IsGreaterThan(command.Id, 0, "Id must be greater 0 (zero)")
                .IsNotNull(command.LoginName, "LoginName", "LoginName required")
                .IsNotNull(command.Password, "Password", "Password required")
                .IsNotNull(command.LoginTypeId, "LoginTypeId", "LoginTypeId required")
                .IsTrue(command.LoginTypeId > 0, "LoginTypeId", "LoginTypeId must be greater 0 (zero)");

            if (command.LoginName is not null)
                Requires().IsLowerOrEqualsThan(command.LoginName, 50, "LoginName", "LoginName must be until 50 characters");
        }
    }
}