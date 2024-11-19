CREATE TABLE [dbo].[Despezas] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Desc]            NVARCHAR (250) NULL,
    [Valor]           FLOAT (53)     NULL,
    [Finalidade]      INT            NULL,
    [Finalidade_desc] NVARCHAR (50)  NULL,
    [Data]            DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

