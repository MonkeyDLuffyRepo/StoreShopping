CREATE TABLE [dbo].[Taste] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (30) NOT NULL,
    CONSTRAINT [PK_Taste] PRIMARY KEY CLUSTERED ([Id] ASC)
);

