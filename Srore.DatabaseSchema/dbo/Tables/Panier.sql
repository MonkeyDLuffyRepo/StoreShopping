CREATE TABLE [dbo].[Panier] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [CustomerId]       INT             NOT NULL,
    [NbrProduct]       INT             NOT NULL,
    [TotalAmount]      DECIMAL (14, 4) NOT NULL,
    [Status]           INT             NULL,
    [CreationDate]     DATETIME        NOT NULL,
    [ModificationDate] DATETIME        NULL,
    CONSTRAINT [PK_Panier] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Panier_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id])
);

