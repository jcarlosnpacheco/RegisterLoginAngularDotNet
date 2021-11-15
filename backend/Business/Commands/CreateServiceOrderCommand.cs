using MediatR;
using System;

namespace ServiceOrderAPI.Business.Commands
{
    public class CreateServiceOrderCommand : IRequest<string>
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
    }
}