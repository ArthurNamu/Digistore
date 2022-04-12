CREATE PROCEDURE [dbo].[sp_CreateProduct]
	@ProductName NVARCHAR(200),
           @ProductDescription  NVARCHAR(2000),
           @ImagePath  NVARCHAR(500), 
           @CategoryID  NVARCHAR(100),
           @ProductPrice DECIMAL(18,2)
AS
BEGIN

INSERT INTO [dbo].[t_Product]
           ([ProductName]
           ,[ProductDescription]
           ,[ImagePath]
           ,[CategoryID]
           ,[ProductPrice])
     VALUES
           (@ProductName,
           @ProductDescription,
           @ImagePath, 
           @CategoryID,
           @ProductPrice)

 SELECT SCOPE_IDENTITY()
END