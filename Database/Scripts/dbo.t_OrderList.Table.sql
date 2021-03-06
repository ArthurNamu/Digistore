USE [Database]
GO
/****** Object:  Table [dbo].[t_OrderList]    Script Date: 4/14/2022 9:30:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
ALTER TABLE [dbo].[t_OrderList]  WITH CHECK ADD  CONSTRAINT [FK_t_OrderList_t_Order] FOREIGN KEY([OrderListID])
REFERENCES [dbo].[t_Order] ([OrderID])
GO
ALTER TABLE [dbo].[t_OrderList] CHECK CONSTRAINT [FK_t_OrderList_t_Order]
GO
ALTER TABLE [dbo].[t_OrderList]  WITH CHECK ADD  CONSTRAINT [FK_t_OrderList_t_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[t_Product] ([ProductID])
GO
ALTER TABLE [dbo].[t_OrderList] CHECK CONSTRAINT [FK_t_OrderList_t_Product]
GO
