using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceOrderAPI.Application.Models
{
    [Table("service")]
    public class ServiceOrder
    {     
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("date_service")]
        public DateTime Date { get; set; }
        [Column("value_service")]
        public double Value { get; set; }
    }
}