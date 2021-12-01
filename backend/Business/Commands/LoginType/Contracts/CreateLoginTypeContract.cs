using Flunt.Validations;
using RegisterLoginAPI.Business.Commands;

namespace Business.Commands.LoginType.Contracts
{
    public class CreateLoginTypeContract : Contract<CreateLoginTypeCommand>
    {
        public CreateLoginTypeContract(CreateLoginTypeCommand command)
        {
            Requires()
                .IsNotNull(command.Name, "Name", "Name required")
                .IsLowerOrEqualsThan(50, command.Name.Length, "Name", "Name must be less or equals 50 characters");
        }
    }
}