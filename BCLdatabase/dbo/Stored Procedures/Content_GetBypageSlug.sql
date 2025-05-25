-- =============================================
-- Author:		Trendsic, cgc3
-- Create date: 12/30/2019
-- Description:	Return all columns for the specified contentId record
--			typical usage is for content editor
-- =============================================
CREATE PROCEDURE [dbo].[Content_GetBypageSlug]
	@pageslug as varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	Select
		contentId,
		isActive,
		[Rank],
		contentCategory,
		pageSlug,
		Information,
		Subject,
		DealerId,
		dateStart,
		dateEnd,
		versionStart,
		versionEnd
	From ContentManagement
	Where pageSlug = @pageslug
END