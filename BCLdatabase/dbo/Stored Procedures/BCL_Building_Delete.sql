-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BCL_Building_Delete]
	@Request	varchar(2048)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare
		@PK_Building_Id As Integer = JSON_VALUE(@Request, '$.PK_Building_Id')

	Delete BCL_Building
	Where PK_Building_Id = @PK_Building_Id
	
	Select @@ROWCOUNT;
END