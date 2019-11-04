/*
* Holds a collection of factories.
* Has one to many relationship with factories.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("root")]
    public class Root
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }
        [Column(TypeName = "varchar(30)")]
        [StringLength(30)]
        public string Label { get; set; }
        public List<Factory> Factories { get; set; }
    }
}