using Business.Commands.Generics;
using MediatR;

namespace RegisterLoginAPI.Business.Commands
{
    public class UpdateLoginTypeCommand : IRequest<GenericCommandResult>
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }

        #region Methods

        public UpdateLoginTypeCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }

        #endregion Methods
    }
}