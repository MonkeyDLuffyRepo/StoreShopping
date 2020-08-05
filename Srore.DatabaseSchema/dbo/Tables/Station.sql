CREATE TABLE [dbo].[Station] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [CreationDate]     DATETIME       NOT NULL,
    [ModificationDate] DATETIME       NULL,
    [Name]             NVARCHAR (100) NULL,
    [AddressId]        INT            NULL,
    [Description]      NVARCHAR (150) NULL,
    CONSTRAINT [PK_Station] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Station_Address] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id])
);

