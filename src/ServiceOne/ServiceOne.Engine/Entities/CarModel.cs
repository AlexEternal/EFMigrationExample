using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceOne.Engine.Entities
{
    [Table("CarModels", Schema = "ServiceOne")]
    public class CarModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(40)]
        public string Name { get; set; }
    }
}