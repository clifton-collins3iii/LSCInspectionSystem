-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BCL_RoomOptions_Select]
	@PK_Building_Id As Int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select bb.PK_BuildingRoom_Id, bb.Name_Short
	From 
		BCL_BuildingRoom bb
	Where
		IsActive = 1 And IsDeleted = 0
		And bb.FK_Building_Id = @PK_Building_Id
END