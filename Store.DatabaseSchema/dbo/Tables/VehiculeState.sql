CREATE TABLE [dbo].[VehiculeState] (
    [Id]           INT              IDENTITY (1, 1) NOT NULL,
    [CreationDate] DATETIME         NOT NULL,
    [VehiculeId]   INT              NOT NULL,
    [OccupedSeat]  INT              NULL,
    [CapasitySeat] INT              NULL,
    [Longitude]    DECIMAL (15, 10) NULL,
    [Latitude]     DECIMAL (15, 10) NULL,
    CONSTRAINT [PK_VehiculeState] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_VehiculeState_Vehicule] FOREIGN KEY ([VehiculeId]) REFERENCES [dbo].[Vehicule] ([Id])
);

