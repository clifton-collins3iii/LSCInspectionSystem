﻿-- =============================================
-- Author:		Trendsic, cgc3
-- Create date: 2021-03-13
-- Description:	Retrieve alert recordset for editing
-- =============================================
CREATE PROCEDURE Alert_GetAll
AS
BEGIN
	SET NOCOUNT ON;
	Select AlertId, isActive, [Rank], AlertCategory, dateStart, dateEnd, DealerId, AlertText
	From AlertManagement
END