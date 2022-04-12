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
