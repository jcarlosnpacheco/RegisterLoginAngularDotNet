using Business.Models;
using MediatR;

namespace RegisterLoginAPI.Business.Commands
{
    public class CreateRegisterLoginCommand : IRequest<string>
    {
        public int Id { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public string Observation { get; set; }

        public LoginTypeModel LoginType { get; set; }
    }
}