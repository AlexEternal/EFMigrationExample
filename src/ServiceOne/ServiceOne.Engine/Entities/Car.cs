using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceOne.Engine.Entities
{
    [Table("Cars", Schema = "ServiceOne")]
    public class Car
    {
        [Key]
        public Guid Id { get; set; }

        public CarModel Type { get; set; }
    }
}