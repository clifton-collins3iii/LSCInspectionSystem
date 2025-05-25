-- =============================================
-- Author:		Trendsic, cgc3
-- Create date: 2021-03-13
-- Description:	Retrieve alert recordset for editing
-- =============================================
CREATE PROCEDURE [dbo].[Alert_GetByID]
	@AlertId as int
AS
BEGIN
	SET NOCOUNT ON;
	Select AlertId, isActive, [Rank], AlertCategory, dateStart, dateEnd, DealerId, AlertText
	From AlertManagement
	Where AlertId = @AlertId
END