-- =============================================
-- Author:		Trendsic, cgc3
-- Create date: 03/13/2021
-- Description:	update alert record
-- =============================================
CREATE PROCEDURE [dbo].[Alert_SetById]
	@AlertId int,
	@isActive bit,
	@Rank int,
	@AlertCategory nvarchar(50),
	@dateStart date,
	@dateEnd date,
	@DealerId uniqueidentifier,
	@AlertText varchar(200)
AS
BEGIN
	
	SET NOCOUNT ON;
	Update AlertManagement
	Set 
		isActive = @isActive,
		[Rank] = @Rank,
		AlertCategory = @AlertCategory,
		dateStart = @dateStart,
		dateEnd = @dateEnd,
		DealerId = @DealerId,
		AlertText = @AlertText
	Where AlertId = @AlertId

	Select AlertId, isActive, [Rank], AlertCategory, dateStart, dateEnd, DealerId, AlertText
	From AlertManagement
	Where AlertId = @AlertId
END