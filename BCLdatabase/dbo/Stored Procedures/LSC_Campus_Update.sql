-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LSC_Campus_Update]
	@Request	varchar(2048)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare
		@PK_Campus_Id As Integer = JSON_VALUE(@Request, '$.PK_Campus_Id'),
		@Name_Short As varchar(32) =JSON_VALUE(@Request, '$.Name_Short'),
		@Name_Long As varchar(64) = JSON_VALUE(@Request, '$.Name_Long'),
		@Description as varchar(512) = JSON_VALUE(@Request, '$.Description'),
		@AddressStreet as varchar(64) = JSON_VALUE(@Request, '$.AddressStreet'),
		@AddressUnit as varchar(32) = JSON_VALUE(@Request, '$.AddressUnit'),
		@AddressCity as varchar(36) = JSON_VALUE(@Request, '$.AddressCity'),
		@AddressState as varchar(2) = JSON_VALUE(@Request, '$.AddressState'),
		@AddressZip as varchar(10) = JSON_VALUE(@Request, '$.AddressZip'),
		@IsActive as bit = JSON_VALUE(@Request, '$.IsActive'),
		@IsDeleted as bit = JSON_VALUE(@Request, '$.IsDeleted')

	Update LSC_Campus
	Set Name_Short = @Name_Short, Name_Long = @Name_Long, Description = @Description, AddressStreet = @AddressStreet,
		AddressUnit = @AddressUnit, AddressCity = @AddressCity, AddressState = @AddressState, AddressZip = @AddressZip,
		IsActive = @IsActive, IsDeleted = @IsDeleted
	Where PK_Campus_Id = @PK_Campus_Id

	Select *
	From LSC_Campus
	Where PK_Campus_Id = @PK_Campus_Id

END