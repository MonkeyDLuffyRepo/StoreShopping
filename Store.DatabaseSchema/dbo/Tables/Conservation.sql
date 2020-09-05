CREATE TABLE [dbo].[Conservation] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (30) NOT NULL,
    CONSTRAINT [PK_Conservation] PRIMARY KEY CLUSTERED ([Id] ASC)
);

