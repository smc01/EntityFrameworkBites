using System;
using System.ComponentModel.DataAnnotations;
using EntityFrameworkBites.Entities.Base;

namespace EntityFrameworkBites.Entities
{
    public class Product : IntEntityBase
    {
        [Key]
        public string Name { get; set; }
    }
}
