USE [Database]
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateOrder]    Script Date: 4/14/2022 9:30:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CreateOrder]
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
GO
