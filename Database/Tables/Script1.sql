

Create PROCEDURE [dbo].[sp_CreateOrder]
	@Customer varchar(100),  @TotalValue decimal
AS
BEGIN
	INSERT INTO [dbo].[t_Order]
			([Customer]
           ,OrderDate
           ,[TotalValue])
     VALUES
	 (@Customer, GETDATE(), @TotalValue)

	 select SCOPE_IDENTITY()
END