using FluentMigrator;

using System;

namespace EntityFrameworkBites.Migrations.Structure
{
    [Migration(201502231850)]
    public class Product:Migration
    {
        public override void Down()
        {
            Delete.Table("Product");
        }

        public override void Up()
        {
            Create.Table("Product")
               .WithColumn("Id").AsInt32().Identity().PrimaryKey("PK_Product_Id")
               .WithColumn("Name").AsString(100).WithColumnDescription("Product Name");
        }
    }
    [Migration(201503071000)]
    public class ProducAddCategory : Migration
    {

        public override void Down()
        {
            Delete.ForeignKey("").OnTable("Product");
            Delete.Column("ProductCategoryId").FromTable("Product");
           
        }

        public override void Up()
        {
            Alter.Table("Product")
                .AddColumn("ProductCategoryId")
                .AsInt32()
                .ForeignKey("FK_Product_ProductCategory","ProductCategory","Id");
        }
    }
}
