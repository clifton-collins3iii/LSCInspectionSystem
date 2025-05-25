-- =============================================
-- Author:		Trendsic, cgc3
-- Create date: 07/30/2021
-- Description:	update alert active status
-- =============================================
CREATE PROCEDURE [dbo].[Alert_SetActiveById]
	@AlertId int,
	@isActive bit
AS
BEGIN
	
	SET NOCOUNT ON;
	Update AlertManagement
	Set 
		isActive = @isActive
	Where AlertId = @AlertId

	Select AlertId, isActive, [Rank], AlertCategory, dateStart, dateEnd, DealerId, AlertText
	From AlertManagement
	Where AlertId = @AlertId
END