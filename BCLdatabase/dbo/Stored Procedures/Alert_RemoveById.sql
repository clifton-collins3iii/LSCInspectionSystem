-- =============================================
-- Author:		Trendsic, cgc3
-- Create date: 03/13/2021
-- Description:	remove alert record
-- =============================================
CREATE PROCEDURE [dbo].[Alert_RemoveById]
	@AlertId int
AS
BEGIN
	
	SET NOCOUNT ON;
	Delete AlertManagement
	Where AlertId = @AlertId

	Select AlertId, isActive, [Rank], AlertCategory, dateStart, dateEnd, DealerId, AlertText
	From AlertManagement
	Where AlertId = @AlertId
END