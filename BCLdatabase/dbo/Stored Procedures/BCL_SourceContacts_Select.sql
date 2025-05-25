-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BCL_SourceContacts_Select]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	Select bsc.PK_SourceContacts_Id,
		bcls.PK_Source_Id, bcls.Source_Name, bcls.SourceDescription, bcls.OfficePhoneNumber, bcls.OfficeEmailAddress,
		bclc.PK_Contacts_Id, bclc.Contacts_Name, bclc.ContactsDescription, bclc.MobilePhoneNumber, bclc.EmailAddress
	From BCL_SourceContacts bsc
	Inner Join BCL_Source bcls On bcls.PK_Source_Id = bsc.FK_Source_Id
	Inner Join BCL_Contacts bclc on bclc.PK_Contacts_Id = bsc.FK_Contacts_Id

END