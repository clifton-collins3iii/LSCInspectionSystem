-- =============================================
-- Author:		Trendsic, cgc3
-- Create date: 2022-01-05
-- Description:	Return audit string of username and fullname given a userid
-- =============================================
CREATE FUNCTION [dbo].[GetAuditString]
(
	@UserId As VarChar(50)
)
RETURNS VarChar(265)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @auditstring varchar(265)

		Declare
			@username varchar(65),
			@fullname varchar(200)
		Select Top 1
			@username = au.UserName,
			@fullname = up.FirstName + ' ' + up.LastName
		From
			active_Users au
			Inner Join UserProfile up on up.UserId = au.UserId
		Where
			au.UserId = dbo.ConvertToUID( @UserId)
		If @@ROWCOUNT = 1 Begin
			SELECT @auditstring = Cast(GETDATE() as varchar) + '|' + @username + '|' + @fullname + '~'
		End Else Begin
			SELECT @auditstring = Cast(GETDATE() as varchar) + '|' + 'none@auth.com' + '|' + 'Unknown User' + '~'
		End
	-- Return the result of the function
	RETURN @auditstring

END