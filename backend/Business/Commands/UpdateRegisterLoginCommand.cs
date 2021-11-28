using MediatR;
using System;

namespace RegisterLoginAPI.Business.Commands
{
    public class UpdateRegisterLoginCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
    }
}