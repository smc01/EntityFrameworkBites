/* Using Database SqlServer2012 and Connection String Server=.\SQL2012;Database=EfBitesDbTest;User Id=sa;Password=1234%asd */
/* 201503071000: ProducAddCategory migrating ================================= */

/* Beginning Transaction */
/* AlterTable Product */
/* No SQL statement executed. */

/* CreateColumn Product ProductCategoryId Int32 */
ALTER TABLE [dbo].[Product] ADD [ProductCategoryId] INT NOT NULL

/* CreateForeignKey FK_Product_ProductCategory Product(ProductCategoryId) ProductCategory(Id) */
ALTER TABLE [dbo].[Product] ADD CONSTRAINT [FK_Product_ProductCategory] FOREIGN KEY ([ProductCategoryId]) REFERENCES [dbo].[ProductCategory] ([Id])

INSERT INTO [dbo].[VersionInfo] ([Version], [AppliedOn], [Description]) VALUES (201503071000, '2015-07-17T12:35:09', 'ProducAddCategory')
/* Committing Transaction */
/* 201503071000: ProducAddCategory migrated */

/* Task completed. */
