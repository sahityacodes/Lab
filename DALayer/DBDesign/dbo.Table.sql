CREATE TABLE [dbo].[Customer] (
    [Id]            INT IDENTITY NOT NULL ,
    [Name]          CHAR (20)     NOT NULL,
    [Phone]         NCHAR (10)    NULL,
    [VAT]           NVARCHAR (16) NOT NULL,
    [Address]       NVARCHAR (50) NULL,
    [City]          NCHAR (16)    NULL,
    [AnnualRevenue] DECIMAL (18)  NULL,
    PRIMARY KEY  NONCLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([VAT] ASC)
);


GO
CREATE CLUSTERED INDEX [IX_Vat]
    ON [dbo].[Customer]([VAT] ASC);