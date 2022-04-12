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