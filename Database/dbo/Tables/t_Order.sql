CREATE TABLE [dbo].[t_Order] (
    [OrderID]    INT             IDENTITY (1, 1) NOT NULL,
    [Customer]   VARCHAR (200)   NOT NULL,
    [OrderDate]  DATETIME        NOT NULL,
    [TotalValue] DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([OrderID] ASC)
);

