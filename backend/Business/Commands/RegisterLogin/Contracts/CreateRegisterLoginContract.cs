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
                .IsNotNull(command.LoginTypeId, "LoginTypeId", "LoginTypeId required")
                .IsLowerOrEqualsThan(command.LoginName, 50, "LoginName", "LoginName must be until 50 characters");
        }
    }
}