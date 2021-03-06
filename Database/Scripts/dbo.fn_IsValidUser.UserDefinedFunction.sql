USE [Database]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_IsValidUser]    Script Date: 4/14/2022 9:30:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_IsValidUser]
(
	@UserName VARCHAR(100),
	@Password VARCHAR(200)
)
RETURNS BIT
AS
BEGIN
	DECLARE @ValidUser BIT 
	SET @ValidUser = 0

	IF EXISTS(SELECT * FROM t_User WHERE UserName = @UserName AND Password = @Password)
		SET @ValidUser = 1

	RETURN @ValidUser

END
GO
