
-- =============================================
-- Author:		Trendsic, cgc3
-- Create date: 12/30/2019
-- Description:	Remove the specified record
--
--	Parameters: contentId
-- =============================================
CREATE PROCEDURE Content_Delete
@_contentId Integer
AS
BEGIN
	SET NOCOUNT ON;
	Delete ContentManagement
	Where contentId = @_contentId
END