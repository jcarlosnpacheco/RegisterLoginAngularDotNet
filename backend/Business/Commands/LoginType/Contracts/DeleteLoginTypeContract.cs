using Flunt.Validations;
using RegisterLoginAPI.Business.Commands.LoginType;

namespace Business.Commands.LoginType.Contracts
{
    public class DeleteLoginTypeContract : Contract<DeleteLoginTypeCommand>
    {
        public DeleteLoginTypeContract(DeleteLoginTypeCommand command)
        {
            Requires()
                .IsNotNull(command.Id, "Id", "Id required")
                .IsGreaterThan(command.Id, 0, "Id", "Id must be greater than 0");
        }
    }
}