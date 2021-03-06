USE [Database]
GO
/****** Object:  StoredProcedure [dbo].[sp_UserExists]    Script Date: 4/14/2022 9:30:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UserExists]
	@UserName VARCHAR(100)
AS
BEGIN
	DECLARE @UserExists BIT 
	SET @UserExists = 0

	IF EXISTS(SELECT * FROM t_User WHERE UserName = @UserName)
		SET @UserExists = 1

	SELECT @UserExists
END
GO
