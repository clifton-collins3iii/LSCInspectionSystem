-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LSC_Campus_Delete]
	@Request	varchar(2048)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare
		@PK_Campus_Id As Integer = JSON_VALUE(@Request, '$.PK_Campus_Id')

	Delete LSC_Campus
	Where PK_Campus_Id = @PK_Campus_Id
	
	Select @@ROWCOUNT;
END