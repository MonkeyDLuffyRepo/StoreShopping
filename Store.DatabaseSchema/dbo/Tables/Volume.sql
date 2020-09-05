CREATE TABLE [dbo].[Volume] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (30) NOT NULL,
    CONSTRAINT [PK_Volume] PRIMARY KEY CLUSTERED ([Id] ASC)
);

