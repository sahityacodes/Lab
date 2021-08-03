CREATE TABLE [dbo].[Customer] (
    [Id]            INT IDENTITY NOT NULL ,
    [Name]          CHAR (20)     NOT NULL,
    [Phone]         CHAR (10)    NULL,
    [VAT]           VARCHAR (16) NOT NULL,
    [Address]       VARCHAR (50) NULL,
    [City]          CHAR (16)    NULL,
    [AnnualRevenue] DECIMAL (18)  NULL,
    PRIMARY KEY  NONCLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([VAT] ASC)
);


GO
CREATE CLUSTERED INDEX [IX_Vat]
    ON [dbo].[Customer]([VAT] ASC);