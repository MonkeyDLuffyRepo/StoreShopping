CREATE TABLE [dbo].[Address] (
    [Id]           INT              IDENTITY (1, 1) NOT NULL,
    [CityName]     NVARCHAR (50)    NOT NULL,
    [CountryName]  NVARCHAR (50)    NOT NULL,
    [PostCode]     NVARCHAR (10)    NOT NULL,
    [State]        NVARCHAR (50)    NULL,
    [StreetName]   NVARCHAR (50)    NULL,
    [StreetNumber] NVARCHAR (50)    NULL,
    [Longitude]    DECIMAL (15, 10) NOT NULL,
    [Latitude]     DECIMAL (15, 10) NOT NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([Id] ASC)
);

