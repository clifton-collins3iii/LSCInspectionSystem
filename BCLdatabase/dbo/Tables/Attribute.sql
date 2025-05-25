CREATE TABLE [dbo].[Attribute] (
    [Attribute_PK]        INT           IDENTITY (1, 1) NOT NULL,
    [AttributeKey]        VARCHAR (255) NULL,
    [AttributeData]       VARCHAR (255) NOT NULL,
    [AttributeCategoryId] INT           NULL,
    [AttributeDataTypeId] INT           NULL,
    [IsDeleted]           BIT           CONSTRAINT [DF_Attribute_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Attribute] PRIMARY KEY CLUSTERED ([Attribute_PK] ASC),
    CONSTRAINT [FK_Attribute_AttributeCategory] FOREIGN KEY ([AttributeCategoryId]) REFERENCES [dbo].[AttributeCategory] ([Id]),
    CONSTRAINT [FK_AttributeAttributeDataType] FOREIGN KEY ([AttributeDataTypeId]) REFERENCES [dbo].[AttributeDataType] ([Id])
);

