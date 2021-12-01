using Flunt.Validations;
using RegisterLoginAPI.Business.Commands;

namespace Business.Commands.RegisterLogin.Contracts
{
    public class DeleteRegisterLoginContract : Contract<DeleteRegisterLoginCommand>
    {
        public DeleteRegisterLoginContract(DeleteRegisterLoginCommand command)
        {
            Requires()
                .IsNotNull(command.Id, "Id", "Id required")
                .IsTrue(command.Id > 0, "Id", "Id must be greater 0");
        }
    }
}