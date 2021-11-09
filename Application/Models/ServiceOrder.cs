using System;

namespace ServiceOrderAPI.Application.Models
{
    public class ServiceOrder
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
    }
}