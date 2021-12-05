using Flunt.Validations;
using RegisterLoginAPI.Business.Commands;

namespace Business.Commands.LoginType.Contracts
{
    public class UpdateLoginTypeContract : Contract<UpdateLoginTypeCommand>
    {
        public UpdateLoginTypeContract(UpdateLoginTypeCommand command)
        {
            Requires()
                .IsNotNull(command.Name, "Name", "Name required")
                .IsGreaterThan(command.Id, 0, "Id need be greater than 0 (zero)");

            if (command.Name is not null)
                Requires().IsLowerOrEqualsThan(command.Name.Length, 50, "Name", "Name must be less or equals 50 characters");
        }
    }
}