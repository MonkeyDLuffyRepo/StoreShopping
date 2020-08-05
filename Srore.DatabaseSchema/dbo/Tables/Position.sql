CREATE TABLE [dbo].[Position] (
    [CreationDate] DATETIME         NOT NULL,
    [VehiculeId]   INT              NOT NULL,
    [Longitude]    DECIMAL (15, 10) NOT NULL,
    [Latitude]     DECIMAL (15, 10) NOT NULL,
    [Speed]        DECIMAL (8, 4)   NULL,
    CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED ([CreationDate] ASC, [VehiculeId] ASC),
    CONSTRAINT [FK_Position_Vehicule] FOREIGN KEY ([VehiculeId]) REFERENCES [dbo].[Vehicule] ([Id])
);

