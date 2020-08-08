﻿CREATE TABLE [dbo].[Product] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [Reference]        NVARCHAR (15)   NULL,
    [Name]             NVARCHAR (50)   NOT NULL,
    [Designation]      NVARCHAR (50)   NULL,
    [Description]      NVARCHAR (150)  NULL,
    [CategoryId]       INT             NOT NULL,
    [CreationDate]     DATETIME        NOT NULL,
    [ModificationDate] DATETIME        NULL,
    [Price]            DECIMAL (10, 4) NULL,
    [AvailableStock]   INT             NULL,
    [PicturesPath]     NVARCHAR (150)  NULL,
    [ColorId]          INT             NULL,
    [VintageId]        INT             NULL,
    [OriginalityId]    INT             NULL,
    [RegionId]         INT             NULL,
    [CountryId]        INT             NULL,
    [VolumeId]         INT             NULL,
    [TasteId]          INT             NULL,
    [ConservationId]   INT             NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Product_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id]),
    CONSTRAINT [FK_Product_Color] FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Color] ([Id]),
    CONSTRAINT [FK_Product_Conservation] FOREIGN KEY ([ConservationId]) REFERENCES [dbo].[Conservation] ([Id]),
    CONSTRAINT [FK_Product_Country] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Country] ([Id]),
    CONSTRAINT [FK_Product_Originality] FOREIGN KEY ([OriginalityId]) REFERENCES [dbo].[Originality] ([Id]),
    CONSTRAINT [FK_Product_Region] FOREIGN KEY ([RegionId]) REFERENCES [dbo].[Region] ([Id]),
    CONSTRAINT [FK_Product_Taste] FOREIGN KEY ([TasteId]) REFERENCES [dbo].[Taste] ([Id]),
    CONSTRAINT [FK_Product_Vintage] FOREIGN KEY ([VintageId]) REFERENCES [dbo].[Vintage] ([Id]),
    CONSTRAINT [FK_Product_Volume] FOREIGN KEY ([VolumeId]) REFERENCES [dbo].[Volume] ([Id])
);



