using MediatR;
using System;

namespace ServiceOrderAPI.Business.Commands
{
    public class UpdateServiceOrderCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
    }
}