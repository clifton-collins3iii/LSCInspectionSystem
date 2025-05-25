CREATE TABLE [dbo].[AppVersion] (
    [pk_id]           INT          IDENTITY (1, 1) NOT NULL,
    [created_date]    DATE         CONSTRAINT [DF_AppVersion_created_date] DEFAULT (getdate()) NOT NULL,
    [versionstring]   VARCHAR (50) NULL,
    [isenabled]       BIT          CONSTRAINT [DF_AppVersion_Enabled] DEFAULT ((0)) NOT NULL,
    [effective_date]  DATETIME     NULL,
    [terminationdate] DATETIME     NULL,
    CONSTRAINT [PK_AppVersion] PRIMARY KEY CLUSTERED ([pk_id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'The date and time for the version to go into action for users', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AppVersion', @level2type = N'COLUMN', @level2name = N'effective_date';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Optional termination date of this version', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AppVersion', @level2type = N'COLUMN', @level2name = N'terminationdate';

