USE [Database]
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateOrderListing]    Script Date: 4/14/2022 9:30:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CreateOrderListing]
	@OrderID INT, @ProductID int, @Quantity INT, @ProductPrice decimal, @TotalItemPrice decimal
AS
BEGIN
	INSERT INTO [dbo].[t_OrderList]
			(OrderID
           ,[ProductID]
           ,[Quantity]
           ,[ProductPrice]
		   ,TotalItemPrice)
     VALUES
	 (@OrderID, @ProductID, @Quantity,@ProductPrice,@TotalItemPrice)

	 select @OrderID
END
GO
