using Business.Commands.Generics;
using MediatR;

namespace RegisterLoginAPI.Business.Commands
{
    public class DeleteLoginTypeCommand : IRequest<GenericCommandResult>
    {
        public int Id { get; protected set; }

        #region Methods

        public DeleteLoginTypeCommand(int id)
        {
            Id = id;
        }

        #endregion Methods
    }
}