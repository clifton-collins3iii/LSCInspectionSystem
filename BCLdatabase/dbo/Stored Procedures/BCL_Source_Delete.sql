-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BCL_Source_Delete]
	@Request	varchar(2048)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare
		@PK_Source_Id As Integer = JSON_VALUE(@Request, '$.PK_Source_Id')

	Delete BCL_Source
	Where PK_Source_Id = @PK_Source_Id
	
	Select @@ROWCOUNT;
END