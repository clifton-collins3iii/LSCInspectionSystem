-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BCL_ContactOptions_Select]
	@PK_Source_Id As Int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select bb.PK_SourceContacts_Id, c.Name_First + Coalesce(c.Name_Middle, '') + Coalesce(c.Name_Second, '') As ContactName
	From 
		BCL_SourceContacts bb
		Inner Join BCL_Contact c on c.PK_Contact_Id = bb.FK_Contacts_Id
	Where
		bb.IsActive = 1 And bb.IsDeleted = 0
		And bb.FK_Source_Id = @PK_Source_Id
END