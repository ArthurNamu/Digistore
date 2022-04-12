CREATE PROCEDURE [dbo].[sp_AllGetProducts]
AS
BEGIN
	
SELECT [ProductID]
      ,[ProductName]
      ,[ProductDescription]
      ,[ImagePath]
      ,[CategoryID]
	  ,[ProductPrice]
  FROM [dbo].[t_Product]

END
