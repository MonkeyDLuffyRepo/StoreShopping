CREATE TABLE [dbo].[PersonRole] (
    [Id]          INT            NOT NULL,
    [Name]        NVARCHAR (50)  NULL,
    [Description] NVARCHAR (150) NULL,
    CONSTRAINT [PK_PersonRole] PRIMARY KEY CLUSTERED ([Id] ASC)
);

