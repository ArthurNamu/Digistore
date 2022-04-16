CREATE TABLE [dbo].[t_OrderList] (
    [OrderListID]    INT             IDENTITY (1, 1) NOT NULL,
    [OrderID]        INT             NOT NULL,
    [ProductID]      INT             NOT NULL,
    [Quantity]       INT             NOT NULL,
    [ProductPrice]   DECIMAL (18, 2) NOT NULL,
    [TotalItemPrice] DECIMAL (18, 2) NULL,
    PRIMARY KEY CLUSTERED ([OrderListID] ASC),
    CONSTRAINT [FK_t_OrderList_t_Order] FOREIGN KEY ([OrderListID]) REFERENCES [dbo].[t_Order] ([OrderID]),
    CONSTRAINT [FK_t_OrderList_t_Product] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[t_Product] ([ProductID])
);

