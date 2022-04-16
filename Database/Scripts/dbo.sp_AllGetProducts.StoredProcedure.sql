USE [Database]
GO
/****** Object:  StoredProcedure [dbo].[sp_AllGetProducts]    Script Date: 4/14/2022 9:30:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
