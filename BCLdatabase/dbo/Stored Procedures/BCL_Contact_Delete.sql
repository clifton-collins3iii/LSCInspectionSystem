-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BCL_Contact_Delete]
	@Request	varchar(2048)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare
		@PK_Contact_Id As Integer = JSON_VALUE(@Request, '$.PK_Contact_Id')

	Delete BCL_Contact
	Where PK_Contact_Id = @PK_Contact_Id
	
	Select @@ROWCOUNT;
END