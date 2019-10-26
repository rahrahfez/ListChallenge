/*
* Holds a value of a randomly generated number set between the ranges
* of the factory parent.
*/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("child")]
    public class ChildModel
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }
        [ForeignKey("FactoryId")]
        public Guid FactoryId { get; set; }
        public FactoryModel Factory { get; set; }
        public int Value { get; set; }
    }
}