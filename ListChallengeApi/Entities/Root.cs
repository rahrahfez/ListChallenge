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
        public List<Factory> Factories { get; set; }
    }
}