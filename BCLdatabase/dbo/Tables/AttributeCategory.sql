CREATE TABLE [dbo].[AttributeCategory] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (255) NOT NULL,
    [IsDeleted]   BIT            DEFAULT ((0)) NULL,
    CONSTRAINT [PK_AttributeCategory] PRIMARY KEY CLUSTERED ([Id] ASC)
);

