IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Currency] (
    [Id] int NOT NULL,
    [Name] nvarchar(10) NULL,
    CONSTRAINT [PK_Currency] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Location] (
    [Id] nchar(10) NULL
);

GO

CREATE TABLE [PersonType] (
    [Id] int NOT NULL,
    [Name] nvarchar(50) NULL,
    CONSTRAINT [PK_PersonType] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ProductType] (
    [Id] int NOT NULL,
    [Name] nvarchar(100) NULL,
    CONSTRAINT [PK_ProductType] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Role] (
    [Id] int NOT NULL,
    [Name] nvarchar(50) NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Person] (
    [Id] bigint NOT NULL,
    [Email] nvarchar(100) NULL,
    [Password] varbinary(max) NULL,
    [PhoneNumber] nvarchar(50) NULL,
    [FirstName] nvarchar(50) NULL,
    [LastName] nvarchar(50) NULL,
    [DiplayName] nvarchar(100) NULL,
    [PersonTypeId] int NULL,
    [CreationDate] datetime NULL,
    [ModificationDate] datetime NULL,
    [StoragePath] nvarchar(100) NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Person_PersonType] FOREIGN KEY ([PersonTypeId]) REFERENCES [PersonType] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Addresse] (
    [Id] bigint NOT NULL,
    [Country] nvarchar(50) NULL,
    [City] nvarchar(50) NULL,
    [ZipCode] nvarchar(10) NULL,
    [StreetOne] varchar(100) NULL,
    [StreetTwo] nvarchar(100) NULL,
    [PersonId] bigint NULL,
    [CreationDate] datetime NULL,
    [ModificationDate] datetime NULL,
    CONSTRAINT [PK_Addresse] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Addresse_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [PersonRole] (
    [PersonId] bigint NOT NULL,
    [RoleId] int NOT NULL,
    [CreationDate] datetime NULL,
    [ModiicationDate] datetime NULL,
    [Active] bit NULL,
    CONSTRAINT [PK_PersonRole] PRIMARY KEY ([PersonId], [RoleId]),
    CONSTRAINT [FK_PersonRole_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_PersonRole_Role] FOREIGN KEY ([RoleId]) REFERENCES [Role] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Product] (
    [Id] bigint NOT NULL,
    [Name] nvarchar(50) NULL,
    [CreationDate] datetime NULL,
    [ModiicationDate] datetime NULL,
    [ProductTypeId] int NULL,
    [Quality] int NULL,
    [StoragePath] nvarchar(100) NULL,
    [OwnerId] bigint NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Product_Person] FOREIGN KEY ([OwnerId]) REFERENCES [Person] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Product_ProductType] FOREIGN KEY ([ProductTypeId]) REFERENCES [ProductType] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Price] (
    [Id] bigint NOT NULL,
    [CreationDate] datetime NULL,
    [Amount] float NULL,
    [CurrencyId] int NULL,
    [ProductId] bigint NULL,
    CONSTRAINT [PK_Price] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Price_Currency] FOREIGN KEY ([CurrencyId]) REFERENCES [Currency] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Price_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Addresse_PersonId] ON [Addresse] ([PersonId]);

GO

CREATE INDEX [IX_Person_PersonTypeId] ON [Person] ([PersonTypeId]);

GO

CREATE INDEX [IX_PersonRole_RoleId] ON [PersonRole] ([RoleId]);

GO

CREATE INDEX [IX_Price_CurrencyId] ON [Price] ([CurrencyId]);

GO

CREATE INDEX [IX_Price_ProductId] ON [Price] ([ProductId]);

GO

CREATE INDEX [IX_Product_OwnerId] ON [Product] ([OwnerId]);

GO

CREATE INDEX [IX_Product_ProductTypeId] ON [Product] ([ProductTypeId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200721220643_InitialMigration', N'3.1.6');

GO

