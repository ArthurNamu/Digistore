CREATE PROCEDURE [dbo].[sp_RegisterUser]
	@UserName VARCHAR(100),
	@Password VARCHAR(200)
AS
BEGIN
	Insert into t_User (UserName, Password) Values ( @UserName , @Password)
	select 1;

END