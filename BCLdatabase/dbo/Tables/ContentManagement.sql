CREATE TABLE [dbo].[ContentManagement] (
    [contentId]       INT              IDENTITY (1, 1) NOT NULL,
    [isActive]        BIT              CONSTRAINT [DF_ContentManagement_isActive] DEFAULT ((0)) NOT NULL,
    [Rank]            INT              CONSTRAINT [DF_ContentManagement_Rank] DEFAULT ((0)) NOT NULL,
    [contentCategory] NVARCHAR (50)    CONSTRAINT [DF_ContentManagement_contentCategory] DEFAULT (N'Information') NOT NULL,
    [dateStart]       DATE             CONSTRAINT [DF_ContentManagement_dateStart] DEFAULT (getdate()) NOT NULL,
    [dateEnd]         DATE             NULL,
    [versionStart]    VARCHAR (25)     NULL,
    [versionEnd]      VARCHAR (25)     NULL,
    [DealerId]        UNIQUEIDENTIFIER NULL,
    [Information]     VARCHAR (MAX)    CONSTRAINT [DF_ContentManagement_Information] DEFAULT ('Content') NOT NULL,
    [Subject]         VARCHAR (200)    NOT NULL,
    [pageSlug]        VARCHAR (50)     NULL,
    CONSTRAINT [PK_ContentManagement] PRIMARY KEY CLUSTERED ([contentId] ASC)
);

