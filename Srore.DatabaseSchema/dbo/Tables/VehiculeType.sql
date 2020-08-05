CREATE TABLE [dbo].[VehiculeType] (
    [Id]          INT            NOT NULL,
    [Name]        NVARCHAR (50)  NULL,
    [Description] NVARCHAR (150) NULL,
    CONSTRAINT [PK_VehiculeType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

