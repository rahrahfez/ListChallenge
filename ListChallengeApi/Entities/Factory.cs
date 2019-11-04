/*
* Holds a collection of child values(up to 15).
* Each child holds a randomly generated value.
* When created, the ranges of randomly generated values are set by the user.
* Has one to many relationship with child.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("factory")]
    public class Factory
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }
        public Guid RootId { get; set; }
        public int RangeLow { get; set; }
        public int RangeHigh { get; set; }
        [Column(TypeName = "varchar(30)")]
        [StringLength(30)]
        public string Label { get; set; }
        public IEnumerable<Child> Childs { get; set; }
    }
}