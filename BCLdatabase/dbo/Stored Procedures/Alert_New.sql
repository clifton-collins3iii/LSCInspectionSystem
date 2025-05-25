-- =============================================
-- Author:		Trendsic, cgc3
-- Create date: 03/13/2021
-- Description:	insert new alert record
-- =============================================
CREATE PROCEDURE [dbo].[Alert_New]
	--@AlertId int,
	@isActive bit,
	@Rank int,
	@AlertCategory nvarchar(50),
	@dateStart date,
	@dateend date,
	@DealerId uniqueidentifier,
	@AlertText varchar(200)
AS
BEGIN
	
	SET NOCOUNT ON;
	Insert Into AlertManagement
	(
		isActive,
		[Rank],
		AlertCategory,
		dateStart,
		dateEnd,
		DealerId,
		AlertText
	)
	Values
	(
		@isActive,
		@Rank,
		@AlertCategory,
		@dateStart,
		@dateend,
		@DealerId,
		@AlertText
	)
	Select AlertId, isActive, [Rank], AlertCategory, dateStart, dateEnd, DealerId, AlertText
	From AlertManagement
	Where AlertId = @@IDENTITY
END