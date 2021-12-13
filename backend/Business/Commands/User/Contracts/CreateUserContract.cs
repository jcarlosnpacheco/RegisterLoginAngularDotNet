using Flunt.Validations;
using RegisterLoginAPI.Business.Commands.User;

namespace Business.Commands.User.Contracts
{
    public class CreateUserContract : Contract<CreateUserCommand>
    {
        public CreateUserContract(CreateUserCommand command)
        {
            Requires()
                .IsNotNull(command.Name, "Name", "Name required")
                .IsNotNull(command.Password, "Password")
                .IsNotNull(command.Role, "Role");
        }
    }
}