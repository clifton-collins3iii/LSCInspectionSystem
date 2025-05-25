-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BCL_ResidentOptions_Select]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select PK_Resident_Id, (Name_First + ' ' + Name_Second) As ResidentName
	From 
		BCL_Resident br
	Where
		(IsActive = 1 And IsDeleted = 0)
		--And PK_Resident_Id Not In (Select FK_Resident_Id From BCL_RoomResident Where IsActive = 1 And IsDeleted = 0)
END