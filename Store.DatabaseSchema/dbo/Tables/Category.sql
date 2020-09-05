CREATE TABLE [dbo].[Category] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50)  NOT NULL,
    [Description]  NVARCHAR (150) NULL,
    [CreationDate] DATETIME       NOT NULL,
    [HasSubCategory] BIT NOT NULL, 
    [ParentId] INT NOT NULL, 
    [Enable] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([Id] ASC)
);

