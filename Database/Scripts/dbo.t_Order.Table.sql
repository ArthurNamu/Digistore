USE [Database]
GO
/****** Object:  Table [dbo].[t_Order]    Script Date: 4/14/2022 9:30:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[Customer] [varchar](200) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[TotalValue] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[t_Order]  WITH CHECK ADD  CONSTRAINT [FK_t_Order_t_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[t_Order] ([OrderID])
GO
ALTER TABLE [dbo].[t_Order] CHECK CONSTRAINT [FK_t_Order_t_Order]
GO
