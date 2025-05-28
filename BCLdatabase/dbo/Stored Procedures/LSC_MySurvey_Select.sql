-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LSC_MySurvey_Select]
	@UserId uniqueidentifier = Null

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Select *
	From LSC_InspectionSurvey
	Where FK_aspnetUsers_UserId = @UserId

END