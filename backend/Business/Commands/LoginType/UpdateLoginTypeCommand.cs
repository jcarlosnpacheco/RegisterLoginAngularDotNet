using Business.Models;
using MediatR;

namespace RegisterLoginAPI.Business.Commands
{
    public class UpdateLoginTypeCommand : IRequest<string>
    {
        public LoginTypeModel LoginType { get; set; }
    }
}