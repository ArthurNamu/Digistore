CREATE PROCEDURE [dbo].[sp_GetProduct]
	@ProductID NVARCHAR(100)
AS
BEGIN
	
SELECT [ProductID]
      ,[ProductName]
      ,[ProductDescription]
      ,[ImagePath]
      ,[CategoryID]
	    ,[ProductPrice]
  FROM [dbo].[t_Product]
  WHERE [ProductID] = @ProductID

END

