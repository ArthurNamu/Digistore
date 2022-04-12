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