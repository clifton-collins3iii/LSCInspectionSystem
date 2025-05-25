CREATE TABLE [dbo].[AttributeDataType] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (255) NOT NULL,
    [IsDeleted]   BIT            DEFAULT ((0)) NULL,
    CONSTRAINT [PK_AttributeDataType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

