using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceOrderAPI.Business.Models
{
    //DataAnnotations comments because we'll use Mapping (Data class library) from EF
    //[Table("service")]
    public class ServiceOrderModel
    {
        //[Key]
        //[Column("id")]
        public int Id { get; set; }
        //[Column("description")]
        public string Description { get; set; }
        //[Column("date_service")]
        public DateTime Date { get; set; }
        //[Column("value_service")]
        public double Value { get; set; }
    }
}