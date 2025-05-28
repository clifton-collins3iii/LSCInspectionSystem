-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BCL_Contact_Update]
	@Request	varchar(2048)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare
		@PK_Contact_Id As Integer = Null,	-- JSON_VALUE(@Request, '$.PK_Building_Id'),
		@Name_First As varchar(32) =JSON_VALUE(@Request, '$.Name_First'),
		@Name_Middle As varchar(32) =JSON_VALUE(@Request, '$.Name_Middle'),
		@Name_Second As varchar(64) = JSON_VALUE(@Request, '$.Name_Second'),
		@Description as varchar(512) = JSON_VALUE(@Request, '$.Description'),
		@AddressStreet as varchar(64) = JSON_VALUE(@Request, '$.AddressStreet'),
		@AddressUnit as varchar(32) = JSON_VALUE(@Request, '$.AddressUnit'),
		@AddressCity as varchar(36) = JSON_VALUE(@Request, '$.AddressCity'),
		@AddressState as varchar(2) = JSON_VALUE(@Request, '$.AddressState'),
		@AddressZip as varchar(10) = JSON_VALUE(@Request, '$.AddressZip'),
		@IsActive as bit = JSON_VALUE(@Request, '$.IsActive'),
		@IsDeleted as bit = JSON_VALUE(@Request, '$.IsDeleted')

	Update BCL_Contact
	Set Name_First = @Name_First, Name_Middle = @Name_Middle, Name_Second = @Name_Second, Description = @Description, AddressStreet = @AddressStreet,
		AddressUnit = @AddressUnit, AddressCity = @AddressCity, AddressState = @AddressState, AddressZip = @AddressZip,
		IsActive = @IsActive, IsDeleted = @IsDeleted
	Where PK_Contact_Id = @PK_Contact_Id

	Select *
	From BCL_Contact
	Where PK_Contact_Id = @PK_Contact_Id

END