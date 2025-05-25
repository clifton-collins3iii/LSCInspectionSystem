-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BCL_BuildingRoomResident_Update]
	@Request	varchar(2048)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare
		@PK_RoomResident_Id As Integer = JSON_VALUE(@Request, '$.PK_RoomResident_Id'),
		@FK_Resident_Id as Integer = JSON_VALUE(@Request, '$.FK_Resident_Id'),
		@FK_BuildingRoom_Id as Integer = JSON_VALUE(@Request, '$.FK_BuildingRoom_Id'),
		@Name_Short As varchar(32) =JSON_VALUE(@Request, '$.Name_Short'),
		@Name_Long As varchar(64) = JSON_VALUE(@Request, '$.Name_Long'),
		@Description as varchar(512) = JSON_VALUE(@Request, '$.Description'),
		@RentPaymentFrequency as varchar(64) = JSON_VALUE(@Request, '$.RentPaymentFrequency'),
		@RentPaymentAmount as money = JSON_VALUE(@Request, '$.RentPaymentAmount'),
		@IsActive as bit = JSON_VALUE(@Request, '$.IsActive'),
		@IsDeleted as bit = JSON_VALUE(@Request, '$.IsDeleted')

	If @PK_RoomResident_Id = 0 Or @PK_RoomResident_Id Is Null Begin
			Insert Into BCL_RoomResident (FK_Resident_Id, FK_BuildingRoom_Id, RentPaymentFrequency, RentPaymentAmount, IsActive, IsDeleted)
			Values (@FK_Resident_Id, @FK_BuildingRoom_Id, @RentPaymentFrequency, @RentPaymentAmount, @IsActive, @IsDeleted)
			Set @PK_RoomResident_Id = @@IDENTITY
	End Else Begin
	Update BCL_RoomResident
		Set FK_Resident_Id = @FK_Resident_Id, FK_BuildingRoom_Id = @FK_BuildingRoom_Id, RentPaymentFrequency = @RentPaymentFrequency, RentPaymentAmount = @RentPaymentAmount,
			IsActive = @IsActive, IsDeleted = @IsDeleted
		Where PK_RoomResident_Id = @PK_RoomResident_Id
	End
	-- return row
	Select brr.PK_RoomResident_Id, FK_BuildingRoom_Id, FK_Resident_Id, bbr.RentPaymentFrequency, bbr.RentPaymentAmount, bbr.IsActive, bbr.IsDeleted
	From BCL_BuildingRoom bbr
	Inner Join BCL_RoomResident brr on brr.FK_BuildingRoom_Id = bbr.PK_BuildingRoom_Id
	Inner Join BCL_Resident br on br.PK_Resident_Id = brr.FK_Resident_Id
	Where PK_RoomResident_Id = @PK_RoomResident_Id

END