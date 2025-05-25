-- =============================================
-- Author:		Trendsic, cgc3
-- Create date: 12/30/2019
-- Description:	Return all columns for a contentCategory
--			typical usage is for display/presentation
--	03/10/2020	Trendsic, cgc3
--	To be included in the recordset:
--			isActive = True or 1
--		and
--			(Dealer = null or Dealer = guid.empty)  this done in app or Dealer = SelectedDealer
--		and
--			dateStart =< Today/Now >= endDate
--	Sorting is by:
--		Rank (0 first, 9 last)
-- =============================================
CREATE PROCEDURE [dbo].[Alert_GetByAlertCategory]
	@AlertCategory varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	Declare
		@CurrentDate as DateTime
		
	SELECT @CurrentDate = GetDate()
	
	Select
		AlertId,
		isActive,
		[Rank],
		AlertCategory,
		AlertText,
		DealerId,
		dateStart,
		dateEnd
	From AlertManagement
	Where AlertCategory = @AlertCategory
	And IsActive = 1
	--And (Dealer Is Null Or Dealer = N'')
	And (dateStart <= @CurrentDate And (dateEnd Is Null Or DATEADD(ss,86399,DATEDIFF(d,0,dateEnd)) >= @CurrentDate))
	Order By [Rank] Asc, dateStart Desc
END