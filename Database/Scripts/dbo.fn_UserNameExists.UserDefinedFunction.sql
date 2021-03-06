USE [Database]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_UserNameExists]    Script Date: 4/14/2022 9:30:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_UserNameExists]
(
	@UserName VARCHAR(100)
)
RETURNS BIT
AS
BEGIN
	DECLARE @UserExists BIT 
	SET @UserExists = 0

	IF EXISTS(SELECT * FROM t_User WHERE UserName = @UserName)
		SET @UserExists = 1

	RETURN @UserExists

END
GO
