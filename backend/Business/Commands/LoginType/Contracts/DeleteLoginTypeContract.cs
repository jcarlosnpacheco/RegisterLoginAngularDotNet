using Flunt.Validations;
using RegisterLoginAPI.Business.Commands;

namespace Business.Commands.LoginType.Contracts
{
    public class DeleteLoginTypeContract : Contract<DeleteLoginTypeCommand>
    {
        public DeleteLoginTypeContract(DeleteLoginTypeCommand command)
        {
            Requires()
                .IsNotNull(command.Id, "Id", "Id required")
                .IsGreaterThan(0, command.Id, "Id", "Id must be greater than 0");
        }
    }
}