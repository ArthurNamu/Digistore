USE [Database]
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateProduct]    Script Date: 4/14/2022 9:30:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
