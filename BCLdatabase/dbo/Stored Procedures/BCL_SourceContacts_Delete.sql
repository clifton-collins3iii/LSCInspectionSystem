-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BCL_SourceContacts_Delete]
	@Request	varchar(2048)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare
		@PK_SourceContacts_Id As Integer = JSON_VALUE(@Request, '$.PK_SourceContacts_Id')

	Delete BCL_SourceContacts
	Where PK_SourceContacts_Id = @PK_SourceContacts_Id
	
	Select @@ROWCOUNT;
END