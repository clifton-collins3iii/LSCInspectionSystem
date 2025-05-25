-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BCL_BuildingRoomResident_Delete]
	@Request	varchar(2048)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare
		@PK_RoomResident_Id As Integer = JSON_VALUE(@Request, '$.PK_RoomResident_Id')

	Delete BCL_RoomResident
	Where PK_RoomResident_Id = @PK_RoomResident_Id
	
	Select @@ROWCOUNT;
END