CREATE TABLE [dbo].[PanierProduct] (
    [ProductId]        INT             NOT NULL,
    [PanierId]         INT             NOT NULL,
    [CreationDate]     DATETIME        NOT NULL,
    [UnitPrice]        DECIMAL (10, 4) NOT NULL,
    [Quantity]         INT             NOT NULL,
    [ModificationDate] DATETIME        NULL,
    CONSTRAINT [PK_PanierProduct] PRIMARY KEY CLUSTERED ([ProductId] ASC, [PanierId] ASC, [CreationDate] ASC),
    CONSTRAINT [FK_PanierProduct_Panier] FOREIGN KEY ([PanierId]) REFERENCES [dbo].[Panier] ([Id]),
    CONSTRAINT [FK_PanierProduct_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id])
);

