CREATE TABLE [dbo].[Product] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50)  NULL,
    [Mine]         SMALLINT       NULL,
    [MineDes]      NVARCHAR (50)  NULL,
    [ProductLink]  NVARCHAR (250) NULL,
    [Image]        NVARCHAR (MAX) NULL,
    [State]        SMALLINT       NULL,
    [BuingPrice]   FLOAT (53)     NULL,
    [SellingPrice] FLOAT (53)     NULL,
    [Quantity]     INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

