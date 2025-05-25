-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BCL_BuildingRoom_Delete]
	@Request	varchar(2048)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare
		@PK_BuildingRoom_Id As Integer = JSON_VALUE(@Request, '$.PK_BuildingRoom_Id')

	Delete BCL_BuildingRoom
	Where PK_BuildingRoom_Id = @PK_BuildingRoom_Id
	
	Select @@ROWCOUNT;
END