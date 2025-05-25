CREATE TABLE [dbo].[UserProfile] (
    [Id]           INT              IDENTITY (1, 1) NOT NULL,
    [UserId]       UNIQUEIDENTIFIER NULL,
    [CellPhone]    NVARCHAR (50)    NULL,
    [CompanyName]  NVARCHAR (100)   NULL,
    [DpsUsername]  NVARCHAR (50)    NULL,
    [DpsPassword]  VARBINARY (128)  NULL,
    [CustomerGuid] UNIQUEIDENTIFIER NULL,
    [FirstName]    NVARCHAR (50)    NULL,
    [LastName]     NVARCHAR (50)    NULL,
    [Position]     NVARCHAR (50)    CONSTRAINT [DF_UserProfile_Position] DEFAULT (N'Title Clerk') NULL,
    CONSTRAINT [PK_UserProfile] PRIMARY KEY CLUSTERED ([Id] ASC)
);

