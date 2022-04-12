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
