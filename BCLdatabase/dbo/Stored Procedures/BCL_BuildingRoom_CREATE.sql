-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BCL_BuildingRoom_CREATE]
	@Request	varchar(2048)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare
		@PK_BuildingRoom_Id As Integer = Null,	-- JSON_VALUE(@Request, '$.PK_BuildingRoom_Id'),
		@FK_Building_Id as Integer = JSON_VALUE(@Request, '$.FK_Building_Id'),
		@Name_Short As varchar(32) =JSON_VALUE(@Request, '$.Name_Short'),
		@Name_Long As varchar(64) = JSON_VALUE(@Request, '$.Name_Long'),
		@Description as varchar(512) = JSON_VALUE(@Request, '$.Description'),
		@RentPaymentFrequency as varchar(64) = JSON_VALUE(@Request, '$.RentPaymentFrequency'),
		@RentPaymentAmount as money = JSON_VALUE(@Request, '$.RentPaymentAmount'),
		@IsActive as bit = JSON_VALUE(@Request, '$.IsActive'),
		@IsDeleted as bit = JSON_VALUE(@Request, '$.IsDeleted')

	Insert Into BCL_BuildingRoom (FK_Building_Id, Name_Short, Name_Long, Description, RentPaymentFrequency, RentPaymentAmount, IsActive, IsDeleted)
	Values (@FK_Building_Id, @Name_Short, @Name_Long, @Description, @RentPaymentFrequency, @RentPaymentAmount, @IsActive, @IsDeleted)
	Set @PK_BuildingRoom_Id = @@IDENTITY

	Select *
	From BCL_BuildingRoom
	Where PK_BuildingRoom_Id = @PK_BuildingRoom_Id

END