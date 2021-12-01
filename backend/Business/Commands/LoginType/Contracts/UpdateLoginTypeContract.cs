using Flunt.Validations;
using RegisterLoginAPI.Business.Commands;

namespace Business.Commands.LoginType.Contracts
{
    public class UpdateLoginTypeContract : Contract<UpdateLoginTypeCommand>
    {
        public UpdateLoginTypeContract(UpdateLoginTypeCommand command)
        {
            Requires()
                .IsNotNull(command.Id, "Id", "Id required")
                .IsNotNull(command.Name, "Name", "Name required")
                .IsLowerOrEqualsThan(50, command.Name.Length, "Name", "Name must be less or equals 50 characters");
        }
    }
}