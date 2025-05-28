CREATE TABLE [dbo].[LSC_InspectionTemplateItems] (
    [PK_InspectionTemplateItems_Id] INT      IDENTITY (1, 1) NOT NULL,
    [FK_InspectionTemplate_Id]      INT      NOT NULL,
    [FK_InspectionItems_Id]         INT      NOT NULL,
    [CreatedDate]                   DATETIME CONSTRAINT [DF_LSC_InspectionTemplateItems_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [EffectiveDate]                 DATETIME CONSTRAINT [DF_LSC_InspectionTemplateItems_EffectiveDate] DEFAULT (getdate()) NOT NULL,
    [TerminationDate]               DATETIME CONSTRAINT [DF_LSC_InspectionTemplateItems_TerminationDate] DEFAULT ('2099-12-31 00:00:00.000') NOT NULL,
    [IsActive]                      BIT      CONSTRAINT [DF_LSC_InspectionTemplateItems_IsActive] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                     BIT      CONSTRAINT [DF_LSC_InspectionTemplateItems_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_LSC_InspectionTemplateItems] PRIMARY KEY CLUSTERED ([PK_InspectionTemplateItems_Id] ASC)
);

