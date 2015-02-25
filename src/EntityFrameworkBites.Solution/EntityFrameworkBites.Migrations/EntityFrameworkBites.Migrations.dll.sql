/* Using Database SqlServer2012 and Connection String Server=.\SQL2012;Database=EfBitesDb;User Id=sa;Password=1234%asd */
/* VersionMigration migrating ================================================ */

/* Beginning Transaction */
/* CreateTable VersionInfo */
CREATE TABLE [dbo].[VersionInfo] ([Version] BIGINT NOT NULL)

/* Committing Transaction */
/* VersionMigration migrated */

/* VersionUniqueMigration migrating ========================================== */

/* Beginning Transaction */
/* CreateIndex VersionInfo (Version) */
CREATE UNIQUE CLUSTERED INDEX [UC_Version] ON [dbo].[VersionInfo] ([Version] ASC)

/* AlterTable VersionInfo */
/* No SQL statement executed. */

/* CreateColumn VersionInfo AppliedOn DateTime */
ALTER TABLE [dbo].[VersionInfo] ADD [AppliedOn] DATETIME

/* Committing Transaction */
/* VersionUniqueMigration migrated */

/* VersionDescriptionMigration migrating ===================================== */

/* Beginning Transaction */
/* AlterTable VersionInfo */
/* No SQL statement executed. */

/* CreateColumn VersionInfo Description String */
ALTER TABLE [dbo].[VersionInfo] ADD [Description] NVARCHAR(1024)

/* Committing Transaction */
/* VersionDescriptionMigration migrated */

/* 201502231850: ProductCategoryMigration migrating ========================== */

/* Beginning Transaction */
/* CreateTable ProductCategory */
CREATE TABLE [dbo].[ProductCategory] ([Id] INT NOT NULL, [Name] NVARCHAR(100) NOT NULL, CONSTRAINT [PK_ProductCategory_Id] PRIMARY KEY ([Id]))
GO
EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Product Category', @level0type = N'SCHEMA', @level0name = 'dbo', @level1type = N'Table', @level1name = 'ProductCategory', @level2type = N'Column',  @level2name = 'Name'


INSERT INTO [dbo].[VersionInfo] ([Version], [AppliedOn], [Description]) VALUES (201502231850, '2015-02-25T06:10:26', 'ProductCategoryMigration')
/* Committing Transaction */
/* 201502231850: ProductCategoryMigration migrated */

/* 201502231855: Product migrating =========================================== */

/* Beginning Transaction */
/* Rolling back transaction */
