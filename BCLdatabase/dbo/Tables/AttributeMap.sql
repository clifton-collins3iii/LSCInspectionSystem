CREATE TABLE [dbo].[AttributeMap] (
    [AttributeMap_PK]         INT              IDENTITY (1, 1) NOT NULL,
    [Map_Attribute_PKint]     BIGINT           NOT NULL,
    [Map_Tablename]           VARCHAR (255)    NOT NULL,
    [Map_Tablename_PKint]     BIGINT           NULL,
    [Map_Tablename_PKguid]    UNIQUEIDENTIFIER NULL,
    [Attribute_CreateDate]    DATE             CONSTRAINT [DF_AttributeMap_Attribute_CreateDate] DEFAULT (getdate()) NOT NULL,
    [Attribute_DeleteDate]    DATE             NULL,
    [Attribute_ModifyDate]    DATE             CONSTRAINT [DF_AttributeMap_Attribute_ModifyDate] DEFAULT (getdate()) NOT NULL,
    [Attribute_EffectiveDate] DATE             CONSTRAINT [DF_AttributeMap_Attribute_EffectiveDate] DEFAULT (getdate()) NOT NULL,
    [Attribute_TerminateDate] DATE             CONSTRAINT [DF_AttributeMap_Attribute_TerminateDate] DEFAULT ('2099-12-31') NOT NULL,
    [Attribute_IsActive]      BIT              CONSTRAINT [DF_AttributeMap_Attribute_IsActive] DEFAULT ((1)) NOT NULL,
    [Attribute_IsDeleted]     BIT              CONSTRAINT [DF_AttributeMap_Attribute_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_AttributeMap] PRIMARY KEY CLUSTERED ([AttributeMap_PK] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'The actual SQL tablename to be used in a query', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AttributeMap', @level2type = N'COLUMN', @level2name = N'Map_Tablename';

