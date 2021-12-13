using Flunt.Validations;
using RegisterLoginAPI.Business.Commands.User;

namespace Business.Commands.User.Contracts
{
    public class UpdateUserContract : Contract<UpdateUserCommand>
    {
        public UpdateUserContract(UpdateUserCommand command)
        {
            Requires()
                .IsNotNull(command.Name, "Name", "Name required")
                .IsGreaterThan(command.Id, 0, "Id need be greater than 0 (zero)");
        }
    }
}