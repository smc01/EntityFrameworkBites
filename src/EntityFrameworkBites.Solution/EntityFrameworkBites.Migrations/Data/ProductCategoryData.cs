using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace EntityFrameworkBites.Migrations.Data
{
    [Migration(201506251851)]
    public class ProductCategoryData: Migration
    {
        public override void Up()
        {
            Insert.IntoTable("ProductCategory").Row(new {Name = "Categorie1"});
            Insert.IntoTable("ProductCategory").Row(new { Name = "Categorie2" });
        }

        public override void Down()
        {
            Delete.FromTable("ProductCategory");
        }
    }
}
