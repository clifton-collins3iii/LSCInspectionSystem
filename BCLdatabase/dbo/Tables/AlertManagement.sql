CREATE TABLE [dbo].[AlertManagement] (
    [AlertId]       INT              IDENTITY (1, 1) NOT NULL,
    [isActive]      BIT              CONSTRAINT [DF_AlertManagement_isActive] DEFAULT ((0)) NOT NULL,
    [Rank]          INT              CONSTRAINT [DF_AlertManagement_Rank] DEFAULT ((0)) NOT NULL,
    [AlertCategory] NVARCHAR (50)    CONSTRAINT [DF_AlertManagement_AlertCategory] DEFAULT (N'Information') NOT NULL,
    [dateStart]     DATE             CONSTRAINT [DF_AlertManagement_dateStart] DEFAULT (getdate()) NOT NULL,
    [dateEnd]       DATE             NULL,
    [DealerId]      UNIQUEIDENTIFIER NULL,
    [AlertText]     VARCHAR (200)    NOT NULL,
    CONSTRAINT [PK_?AlertManagement] PRIMARY KEY CLUSTERED ([AlertId] ASC)
);

