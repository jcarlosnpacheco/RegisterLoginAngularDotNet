using Business.Commands.Generics;
using MediatR;

namespace RegisterLoginAPI.Business.Commands
{
    public class DeleteRegisterLoginCommand : IRequest<GenericCommandResult>
    {
        public int Id { get; protected set; }

        #region Methods

        public DeleteRegisterLoginCommand(int id)
        {
            Id = id;
        }

        #endregion Methods
    }
}