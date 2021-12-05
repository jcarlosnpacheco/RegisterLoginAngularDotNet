using Flunt.Validations;
using RegisterLoginAPI.Business.Commands;

namespace Business.Commands.LoginType.Contracts
{
    public class CreateLoginTypeContract : Contract<CreateLoginTypeCommand>
    {
        public CreateLoginTypeContract(CreateLoginTypeCommand command)
        {
            Requires()
                .IsNotNull(command.Name, "Name", "Name required");

            if (command.Name is not null)
                Requires().IsLowerOrEqualsThan(command.Name.Length, 50, "Name", "Name must be less or equals 50 characters");
        }
    }
}