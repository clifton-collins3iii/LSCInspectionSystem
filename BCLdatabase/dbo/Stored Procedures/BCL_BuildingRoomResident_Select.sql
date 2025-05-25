-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BCL_BuildingRoomResident_Select]
	@FK_Building_Id	int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select
		Coalesce(brr.PK_RoomResident_Id, 0) As PK_RoomResident_Id, 
		Coalesce(FK_BuildingRoom_Id, bbr.PK_BuildingRoom_Id) As FK_BuildingRoom_Id,
		Coalesce(FK_Resident_Id, 0) As FK_Resident_Id,
		Coalesce(brr.RentPaymentFrequency, bbr.RentPaymentFrequency) As RentPaymentFrequency, 
		Coalesce(brr.RentPaymentAmount, bbr.RentPaymentAmount) As RentPaymentAmount, 
		Coalesce(brr.EffectiveDate, GetDate()) As EffectiveDate, 
		Coalesce(brr.TerminationDate, '2099-12-31') As TerminationDate,
		Coalesce(brr.IsActive, bbr.IsActive) As IsActive, 
		Coalesce(brr.IsDeleted, bbr.IsDeleted) as IsDeleted
	From 
		BCL_Building bb
		Inner Join BCL_BuildingRoom bbr on bbr.FK_Building_Id = bb.PK_Building_Id
		Left Join BCL_RoomResident brr on brr.FK_BuildingRoom_Id = bbr.PK_BuildingRoom_Id
		Left Join BCL_Resident br on br.PK_Resident_Id = brr.FK_Resident_Id
	Where 
		Coalesce(brr.IsActive, bbr.IsActive) = 1 
		And Coalesce(brr.IsDeleted, bbr.IsDeleted) = 0
		And
		bbr.FK_Building_Id = @FK_Building_Id
END