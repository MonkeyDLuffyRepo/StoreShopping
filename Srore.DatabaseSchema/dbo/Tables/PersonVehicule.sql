CREATE TABLE [dbo].[PersonVehicule] (
    [PersonId]   INT NOT NULL,
    [VehiculeId] INT NOT NULL,
    [RoleId]     INT NOT NULL,
    CONSTRAINT [PK_PersonVehicule] PRIMARY KEY CLUSTERED ([PersonId] ASC, [VehiculeId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_PersonVehicule_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id]),
    CONSTRAINT [FK_PersonVehicule_PersonRole] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[PersonRole] ([Id]),
    CONSTRAINT [FK_PersonVehicule_Vehicule] FOREIGN KEY ([VehiculeId]) REFERENCES [dbo].[Vehicule] ([Id])
);



