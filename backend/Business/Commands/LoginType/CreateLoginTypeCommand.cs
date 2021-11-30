using Business.Models;
using MediatR;

namespace RegisterLoginAPI.Business.Commands
{
    public class CreateLoginTypeCommand : IRequest<string>
    {
        //TODO: Verify this property, how will be
        public LoginTypeModel LoginType { get; set; }
    }
}