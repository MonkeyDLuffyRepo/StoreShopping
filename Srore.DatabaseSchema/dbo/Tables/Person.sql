CREATE TABLE [dbo].[Person] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [CreationDate]     DATETIME       NOT NULL,
    [ModificationDate] DATETIME       NULL,
    [FirstName]        NVARCHAR (50)  NOT NULL,
    [LastName]         NVARCHAR (50)  NOT NULL,
    [DisplayName]      NVARCHAR (100) NULL,
    [UserName]         NVARCHAR (50)  NOT NULL,
    [StatusId]         INT            NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Person_PersonStatus] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[PersonStatus] ([Id])
);

