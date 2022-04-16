USE [Database]
GO
/****** Object:  StoredProcedure [dbo].[sp_RegisterUser]    Script Date: 4/14/2022 9:30:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_RegisterUser]
	@UserName VARCHAR(100),
	@Password VARCHAR(200)
AS
BEGIN
	Insert into t_User (UserName, Password) Values ( @UserName , @Password)
	select 1;

END
GO
