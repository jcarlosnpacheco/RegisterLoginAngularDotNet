using Business.Commands.Generics;
using Business.Models;
using MediatR;

namespace RegisterLoginAPI.Business.Commands
{
    public class CreateRegisterLoginCommand : IRequest<GenericCommandResult>
    {
        public int Id { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public string Observation { get; set; }

        //TODO - verificar como ficará esta propriedade
        public LoginTypeModel LoginType { get; set; }
    }
}