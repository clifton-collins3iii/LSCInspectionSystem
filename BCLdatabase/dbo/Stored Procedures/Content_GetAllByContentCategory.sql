-- =============================================
-- Author:		Trendsic, cgc3
-- Create date: 10/18/2021
-- Description:	Return all columns for a contentCategory
--			typical usage is for management/edit
--
-- =============================================
CREATE PROCEDURE [dbo].[Content_GetAllByContentCategory]
	@contentCategory varchar(25)
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
	Where contentCategory = @contentCategory
	Order By [Rank] Asc, dateStart Desc
END