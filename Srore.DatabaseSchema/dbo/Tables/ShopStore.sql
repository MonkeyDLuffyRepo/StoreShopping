CREATE TABLE [dbo].[ShopStore] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (100) NULL,
    [Email]   NVARCHAR (100) NULL,
    [Phone]   NVARCHAR (20)  NULL,
    [Address] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED ([Id] ASC)
);

