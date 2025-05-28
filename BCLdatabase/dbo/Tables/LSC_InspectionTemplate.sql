CREATE TABLE [dbo].[LSC_InspectionTemplate] (
    [PK_InspectionTemplate_Id] INT           IDENTITY (1, 1) NOT NULL,
    [CreatedDate]              DATETIME      CONSTRAINT [DF_LSC_InspectionTemplate_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [EffectiveDate]            DATETIME      CONSTRAINT [DF_LSC_InspectionTemplate_EffectiveDate] DEFAULT (getdate()) NOT NULL,
    [TerminationDate]          DATETIME      CONSTRAINT [DF_LSC_InspectionTemplate_TerminationDate] DEFAULT ('2099-12-31 00:00:00.000') NOT NULL,
    [IsActive]                 BIT           CONSTRAINT [DF_LSC_InspectionTemplate_IsActive] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                BIT           CONSTRAINT [DF_LSC_InspectionTemplate_IsDeleted] DEFAULT ((0)) NOT NULL,
    [Name_Short]               VARCHAR (32)  NOT NULL,
    [Name_Long]                VARCHAR (64)  NULL,
    [Description]              VARCHAR (512) NULL,
    CONSTRAINT [PK_LSC_InspectionTemplate] PRIMARY KEY CLUSTERED ([PK_InspectionTemplate_Id] ASC)
);

