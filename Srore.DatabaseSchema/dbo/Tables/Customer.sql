CREATE TABLE [dbo].[Customer] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Email]            NVARCHAR (80)  NOT NULL,
    [UserName]         NVARCHAR (80)  NOT NULL,
    [Password]         NVARCHAR (150) NOT NULL,
    [FirstName]        NVARCHAR (50)  NOT NULL,
    [LastName]         NVARCHAR (50)  NOT NULL,
    [Birthday]         DATETIME       NOT NULL,
    [Phone]            NVARCHAR (20)  NOT NULL,
    [City]             NVARCHAR (50)  NOT NULL,
    [Address]          NVARCHAR (150) NOT NULL,
    [CreationDate]     DATETIME       NOT NULL,
    [ModificationDate] DATETIME       NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([Id] ASC)
);

