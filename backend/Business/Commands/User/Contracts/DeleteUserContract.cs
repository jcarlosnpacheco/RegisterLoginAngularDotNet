using Flunt.Validations;
using RegisterLoginAPI.Business.Commands.User;

namespace Business.Commands.User.Contracts
{
    public class DeleteUserContract : Contract<DeleteUserCommand>
    {
        public DeleteUserContract(DeleteUserCommand command)
        {
            Requires()
                .IsNotNull(command.Id, "Id", "Id required")
                .IsGreaterThan(command.Id, 0, "Id", "Id must be greater than 0");
        }
    }
}