using Flunt.Validations;
using RegisterLoginAPI.Business.Commands;

namespace Business.Commands.RegisterLogin.Contracts
{
    public class CreateRegisterLoginContract : Contract<CreateRegisterLoginCommand>
    {
        public CreateRegisterLoginContract(CreateRegisterLoginCommand command)
        {
            Requires()
                .IsNotNull(command.LoginName, "LoginName", "LoginName required")
                .IsNotNull(command.Password, "Password", "Password required")
                .IsTrue(command.LoginTypeId > 0, "LoginTypeId", "LoginTypeId required");

            if (command.LoginName is not null)
                Requires().IsLowerOrEqualsThan(command.LoginName, 50, "LoginName", "LoginName must be until 50 characters");
        }
    }
}