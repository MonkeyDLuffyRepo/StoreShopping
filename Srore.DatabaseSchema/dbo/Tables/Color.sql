CREATE TABLE [dbo].[Color] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (30) NOT NULL,
    CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED ([Id] ASC)
);

