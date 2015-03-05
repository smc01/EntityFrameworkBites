using FluentMigrator;

namespace EntityFrameworkBites.Migrations.Structure
{
    [Migration(201502231851)]
    public class ProductCategoryMigration: Migration
    {
        public override void Down()
        {
            Delete.Table("ProductCategory");
        }

        public override void Up()
        {
            Create.Table("ProductCategory")
                .WithColumn("Id").AsInt32().PrimaryKey("PK_ProductCategory_Id")
                .WithColumn("Name").AsString(100).WithColumnDescription("Product Category");
        }
    }
}
