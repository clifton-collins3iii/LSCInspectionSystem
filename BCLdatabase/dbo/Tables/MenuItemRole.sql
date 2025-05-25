CREATE TABLE [dbo].[MenuItemRole] (
    [MenuItemRoleId] INT              IDENTITY (1, 1) NOT NULL,
    [MenuItemId]     UNIQUEIDENTIFIER NULL,
    [RoleId]         UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_MenuItemRole] PRIMARY KEY CLUSTERED ([MenuItemRoleId] ASC)
);

