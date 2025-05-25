-- =============================================
-- Author:		Trendsic, cgc3
-- Create date: 12/30/2019
-- Description:	Update an existing record
-- =============================================
CREATE PROCEDURE [dbo].[Content_Update]
	@isActive bit,
	@Rank int,
	@contentCategory varchar(50),
	@dateStart date,
	@dateEnd date = Null,
	@versionStart varchar(25) = Null,
	@versionEnd varchar(25) = Null,
	@DealerId uniqueidentifier,
	@Information varchar(max),
	@Subject varchar(200),
	@contentId int,
	@contentpageSlug varchar(50)
	
AS
BEGIN
	SET NOCOUNT ON;
	Update ContentManagement
	Set 
		isActive = @isActive, 
		[Rank] =@Rank, 
		contentCategory =@contentCategory, 
		dateStart = @dateStart, 
		dateEnd = @dateEnd, 
		versionStart = @versionStart, 
		versionEnd = @versionEnd, 
		DealerId = @DealerId, 
		Information = @Information, 
		[Subject] = @Subject,
		pageSlug = @contentpageSlug
	Where
		contentId = @contentId
END