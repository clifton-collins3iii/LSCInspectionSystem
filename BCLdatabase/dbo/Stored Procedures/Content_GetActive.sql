-- =============================================
-- Author:		Trendsic, cgc3
-- Create date: 12/29/2019
-- Description:	Return desired records from ContentManagement
--	To be included in the recordset:
--			isActive = True or 1
--		and
--			(Dealer = null or Dealer = guid.empty)  this done in app or Dealer = SelectedDealer
--		and
--			dateStart =< Today/Now >= endDate
--		and
--			versionStart =< CurrentReleaseVersion >= versionEnd
--	Sorting is by:
--		Rank (0 first, 9 last)
-- =============================================
CREATE PROCEDURE [dbo].[Content_GetActive]
AS
BEGIN
	SET NOCOUNT ON;
	Declare
		@CurrentDate as Date,
		@CurrentVersion as varchar(25)
		
	SELECT TOP(1) @CurrentVersion = versionstring, @CurrentDate = GetDate()
	FROM [AppVersion]
	Where isenabled = 1 And GetDate() >= effective_date
	Order By effective_date Desc, versionstring Desc

	SELECT contentId, [Rank], contentCategory, Information, [Subject], DealerId, pageSlug
	From ContentManagement
	Where isActive = 1
	--And (Dealer Is Null Or Dealer = N'')
	And (dateStart <= @CurrentDate And (dateEnd Is Null Or @CurrentDate <= dateEnd))
	And ((versionStart Is Null Or versionStart >= @CurrentVersion) Or (versionEnd Is Null Or versionEnd Is Null))
	Order By contentCategory Asc, [Rank] Asc, dateStart Desc
END