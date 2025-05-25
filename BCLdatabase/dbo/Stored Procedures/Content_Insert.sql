-- =============================================
-- Author:		Trendsic, cgc3
-- Create date: 12/30/2019
-- Description:	Create a new record for the specified category and content
-- =============================================
CREATE PROCEDURE [dbo].[Content_Insert]
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
	@contentpageSlug varchar(50)
	--@contentId int Out
	
AS
BEGIN
	SET NOCOUNT ON;
	Insert Into ContentManagement
	(isActive, [Rank], contentCategory, dateStart, dateEnd, versionStart, versionEnd, DealerId, Information, [Subject], pageSlug)
	Values(@isActive, @Rank, @contentCategory, @dateStart, @dateEnd, @versionStart, @versionEnd, @DealerId, @Information, @Subject, @contentpageSlug)

	--Set @contentId = @@IDENTITY
END