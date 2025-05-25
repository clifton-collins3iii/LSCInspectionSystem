-- =============================================
-- Author:		Trendsic, cgc3
-- Create date: 03/12/2021
--	Decription:  Get active alerts
--
--	To be included in the recordset:
--			isActive = True or 1
--		and
--			(Dealer = null or Dealer = guid.empty)  this done in app or Dealer = SelectedDealer
--		and
--			dateStart =< Today/Now >= endDate
--	Sorting is by:
--		Rank (0 first, 9 last), then by dateStart
--		last sorting is by AlertId
-- =============================================
CREATE PROCEDURE [dbo].[Alert_GetByAlertActive]
	
AS
BEGIN
	SET NOCOUNT ON;
	Declare
		@CurrentDate as DateTime
		
	SELECT @CurrentDate = GETDATE()
	
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
	Where 
	IsActive = 1
	--And (Dealer Is Null Or Dealer = N'')
	And (dateStart <= @CurrentDate And (dateEnd Is Null Or DATEADD(ss,86399,DATEDIFF(d,0,dateEnd)) >= @CurrentDate))
	--And @CurrentDate Between dateStart And dateEnd
	Order By
		[Rank] Asc, 
		dateStart Desc,
		AlertId Asc
END