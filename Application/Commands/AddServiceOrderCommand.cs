using MediatR;
using System;

namespace ServiceOrderAPI.Application.Commands
{
    public class AddServiceOrderCommand : IRequest<string>
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
    }
}