-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BCL_Source_CREATE]
	@Request	varchar(2048)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare
		@PK_Source_Id As Integer = Null,	-- JSON_VALUE(@Request, '$.PK_Building_Id'),
		@Source_Name As varchar(32) =JSON_VALUE(@Request, '$.Name_Short'),
		@SourceDescription as varchar(512) = JSON_VALUE(@Request, '$.Description'),
		@AddressStreet as varchar(64) = JSON_VALUE(@Request, '$.AddressStreet'),
		@AddressUnit as varchar(32) = JSON_VALUE(@Request, '$.AddressUnit'),
		@AddressCity as varchar(36) = JSON_VALUE(@Request, '$.AddressCity'),
		@AddressState as varchar(2) = JSON_VALUE(@Request, '$.AddressState'),
		@AddressZip as varchar(10) = JSON_VALUE(@Request, '$.AddressZip'),
		@IsActive as bit = JSON_VALUE(@Request, '$.IsActive'),
		@IsDeleted as bit = JSON_VALUE(@Request, '$.IsDeleted'),
		@OfficePhoneNumber as varchar(10) = JSON_VALUE(@Request, '$.OfficePhoneNumber'),
		@OfficeEmailAddress as varchar(64) = JSON_VALUE(@Request, '$.OfficeEmailAddress')

	Insert Into BCL_Source (Source_Name, SourceDescription, AddressStreet, AddressUnit, AddressCity, AddressState, AddressZip, IsActive, IsDeleted, OfficePhoneNumber, OfficeEmailAddress)
	Values (@Source_Name, @SourceDescription, @AddressStreet, @AddressUnit, @AddressCity, @AddressState, @AddressZip, @IsActive, @IsDeleted, @OfficePhoneNumber, @OfficeEmailAddress)
	Set @PK_Source_Id = @@IDENTITY

	Select *
	From BCL_Source
	Where PK_Source_Id = @PK_Source_Id

END