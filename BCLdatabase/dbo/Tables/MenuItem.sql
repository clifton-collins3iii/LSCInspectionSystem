CREATE TABLE [dbo].[MenuItem] (
    [MenuItemId] UNIQUEIDENTIFIER CONSTRAINT [DF_MenuItem_MenuItemId] DEFAULT (newid()) NOT NULL,
    [Route]      NVARCHAR (50)    NULL,
    [Title]      NVARCHAR (50)    NULL,
    [ModuleId]   NVARCHAR (50)    NULL,
    [Nav]        BIT              NULL,
    [ElementUid] NVARCHAR (50)    NULL,
    [IconClass]  NVARCHAR (50)    NULL,
    [SortOrder]  DECIMAL (3, 1)   NULL,
    [IsHeader]   BIT              NULL,
    CONSTRAINT [PK_MenuItem] PRIMARY KEY CLUSTERED ([MenuItemId] ASC)
);

