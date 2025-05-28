CREATE TABLE [dbo].[LSC_InspectionItems] (
    [PK_InspectionItems_Id] INT           IDENTITY (1, 1) NOT NULL,
    [CreatedDate]           DATETIME      CONSTRAINT [DF_LSC_InspectionItems_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [EffectiveDate]         DATETIME      CONSTRAINT [DF_LSC_InspectionItems_EffectiveDate] DEFAULT (getdate()) NOT NULL,
    [TerminationDate]       DATETIME      CONSTRAINT [DF_LSC_InspectionItems_TerminationDate] DEFAULT ('2099-12-31 00:00:00.000') NOT NULL,
    [IsActive]              BIT           CONSTRAINT [DF_LSC_InspectionItems_IsActive] DEFAULT ((1)) NOT NULL,
    [IsDeleted]             BIT           CONSTRAINT [DF_LSC_InspectionItems_IsDeleted] DEFAULT ((0)) NOT NULL,
    [Name_Short]            VARCHAR (32)  NOT NULL,
    [Name_Long]             VARCHAR (64)  NULL,
    [Description]           VARCHAR (512) NULL,
    [IsYesNo]               BIT           CONSTRAINT [DF_LSC_InspectionItems_IsYesNo] DEFAULT ((0)) NULL,
    [IsCheckBox]            BIT           CONSTRAINT [DF_LSC_InspectionItems_IsCheckBox] DEFAULT ((0)) NULL,
    [IncludeActionTaken]    BIT           CONSTRAINT [DF_LSC_InspectionItems_IncludeActionTaken] DEFAULT ((0)) NULL,
    [IncludeFollowUpNeeded] BIT           CONSTRAINT [DF_LSC_InspectionItems_IncludeFollowUpNeeded] DEFAULT ((0)) NULL,
    [IncludePhoto]          BIT           CONSTRAINT [DF_LSC_InspectionItems_IncludePhoto] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_LSC_InspectionItems] PRIMARY KEY CLUSTERED ([PK_InspectionItems_Id] ASC)
);

