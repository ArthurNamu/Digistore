CREATE TABLE [dbo].[t_OrderList](
	[OrderListID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[ProductPrice] [decimal](18, 2) NOT NULL,
	[TotalItemPrice] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderListID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]