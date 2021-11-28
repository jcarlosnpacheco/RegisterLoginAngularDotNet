using MediatR;
using System;

namespace RegisterLoginAPI.Business.Commands
{
    public class CreateRegisterLoginCommand : IRequest<string>
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
    }
}