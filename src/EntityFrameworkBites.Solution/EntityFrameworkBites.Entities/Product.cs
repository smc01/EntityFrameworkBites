using System;
using System.ComponentModel.DataAnnotations;
using EntityFrameworkBites.Entities.Base;

namespace EntityFrameworkBites.Entities
{
    public class Product : IntEntityBase
    {
        [Key]
        public string Name { get; set; }
        public int ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
