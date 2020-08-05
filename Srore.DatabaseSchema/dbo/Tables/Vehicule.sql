CREATE TABLE [dbo].[Vehicule] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [CreationDate]     DATETIME       NOT NULL,
    [ModificationDate] DATETIME       NULL,
    [Name]             NVARCHAR (50)  NOT NULL,
    [CapacitySeat]     INT            NOT NULL,
    [AvailableSeat]    INT            NULL,
    [PersonId]         INT            NULL,
    [TypeId]           INT            NULL,
    [Model]            NVARCHAR (50)  NULL,
    [Mark]             NVARCHAR (50)  NULL,
    [ReleaseYear]      DATE           NULL,
    [ConsumptionRate]  DECIMAL (8, 4) NULL,
    [Description]      NVARCHAR (150) NULL,
    CONSTRAINT [PK_Vehicule] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Vehicule_VehiculeType] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[VehiculeType] ([Id])
);

