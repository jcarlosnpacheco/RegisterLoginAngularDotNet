using Business.Commands.Generics;
using Business.Models;
using MediatR;

namespace RegisterLoginAPI.Business.Commands
{
    public class UpdateRegisterLoginCommand : IRequest<GenericCommandResult>
    {
        public int Id { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public string Observation { get; set; }

        public LoginTypeModel LoginType { get; set; }
    }
}