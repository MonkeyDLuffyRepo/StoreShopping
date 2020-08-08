CREATE TABLE [dbo].[Type] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (30) NOT NULL,
    CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED ([Id] ASC)
);

