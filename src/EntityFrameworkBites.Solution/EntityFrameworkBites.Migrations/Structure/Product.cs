﻿using FluentMigrator;
using System;

namespace EntityFrameworkBites.Migrations.Structure
{
    public class Product:Migration
    {
        public override void Down()
        {
            Delete.Table("Product");
        }

        public override void Up()
        {
            Create.Table("Product")
               .WithColumn("Id").AsInt32().PrimaryKey("PK_Product_Id")
               .WithColumn("Name").AsString(100).WithColumnDescription("Product Name");
        }
    }
}
