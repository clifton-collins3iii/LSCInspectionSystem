-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BCL_Contacts_CREATE]
	@Request	varchar(2048)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare
		@PK_Contacts_Id As Integer = Null,	-- JSON_VALUE(@Request, '$.PK_Building_Id'),
		@Contacts_Name As varchar(32) =JSON_VALUE(@Request, '$.Name_Short'),
		@ContactsDescription as varchar(512) = JSON_VALUE(@Request, '$.Description'),
		@AddressStreet as varchar(64) = JSON_VALUE(@Request, '$.AddressStreet'),
		@AddressUnit as varchar(32) = JSON_VALUE(@Request, '$.AddressUnit'),
		@AddressCity as varchar(36) = JSON_VALUE(@Request, '$.AddressCity'),
		@AddressState as varchar(2) = JSON_VALUE(@Request, '$.AddressState'),
		@AddressZip as varchar(10) = JSON_VALUE(@Request, '$.AddressZip'),
		@IsActive as bit = JSON_VALUE(@Request, '$.IsActive'),
		@IsDeleted as bit = JSON_VALUE(@Request, '$.IsDeleted'),
		@MobilePhoneNumber as varchar(10) = JSON_VALUE(@Request, '$.MobilePhoneNumber'),
		@EmailAddress as varchar(64) = JSON_VALUE(@Request, '$.EmailAddress')

	Insert Into BCL_Contacts (Contacts_Name, ContactsDescription, AddressStreet, AddressUnit, AddressCity, AddressState, AddressZip, IsActive, IsDeleted, MobilePhoneNumber, EmailAddress)
	Values (@Contacts_Name, @ContactsDescription, @AddressStreet, @AddressUnit, @AddressCity, @AddressState, @AddressZip, @IsActive, @IsDeleted, @MobilePhoneNumber, @EmailAddress)
	Set @PK_Contacts_Id = @@IDENTITY

	Select *
	From BCL_Contacts
	Where PK_Contacts_Id = @PK_Contacts_Id

END