CREATE TABLE [dbo].[Vintage] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Vintage] PRIMARY KEY CLUSTERED ([Id] ASC)
);

