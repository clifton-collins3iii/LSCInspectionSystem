-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BCL_SourceContacts_CREATE]
	@Request	varchar(2048)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Declare
		@PK_SourceContacts_Id As Integer = Null,	-- JSON_VALUE(@Request, '$.PK_Contacts_Id'),
		@FK_Source_Id as Integer = JSON_VALUE(@Request, '$.FK_Source_Id'),
		@FK_Contacts_Id as Integer = JSON_VALUE(@Request, '$.FK_Contacts_Id'),
		@IsActive as bit = JSON_VALUE(@Request, '$.IsActive'),
		@IsDeleted as bit = JSON_VALUE(@Request, '$.IsDeleted')

	Insert Into BCL_SourceContacts (FK_Source_Id, FK_Contacts_Id, IsActive, IsDeleted)
	Values (@FK_Source_Id, @FK_Contacts_Id, @IsActive, @IsDeleted)
	Set @PK_SourceContacts_Id = @@IDENTITY

	Select bsc.PK_SourceContacts_Id,
		bcls.PK_Source_Id, bcls.Source_Name, bcls.SourceDescription, bcls.OfficePhoneNumber, bcls.OfficeEmailAddress,
		bclc.PK_Contacts_Id, bclc.Contacts_Name, bclc.ContactsDescription, bclc.MobilePhoneNumber, bclc.EmailAddress
	From BCL_SourceContacts bsc
	Inner Join BCL_Source bcls On bcls.PK_Source_Id = bsc.FK_Source_Id
	Inner Join BCL_Contacts bclc on bclc.PK_Contacts_Id = bsc.FK_Contacts_Id
	Where PK_SourceContacts_Id = @PK_SourceContacts_Id

END