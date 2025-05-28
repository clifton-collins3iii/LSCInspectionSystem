CREATE TABLE [dbo].[LSC_InspectionResults] (
    [PK_InspectionResults_Id]   INT            IDENTITY (1, 1) NOT NULL,
    [FK_InspectionSurvey_Id]    INT            NOT NULL,
    [FK_InspectionItems_Id]     INT            NOT NULL,
    [Name_Short]                VARCHAR (32)   NOT NULL,
    [Name_Long]                 VARCHAR (64)   NULL,
    [Description]               VARCHAR (512)  NULL,
    [IsYesNo]                   BIT            CONSTRAINT [DF_LSC_InspectionResults_IsYesNo] DEFAULT ((0)) NULL,
    [IsCheckBox]                BIT            CONSTRAINT [DF_LSC_InspectionResults_IsCheckBox] DEFAULT ((0)) NULL,
    [IncludeActionTaken]        BIT            CONSTRAINT [DF_LSC_InspectionResults_IncludeActionTaken] DEFAULT ((0)) NULL,
    [IncludeFollowUpNeeded]     BIT            CONSTRAINT [DF_LSC_InspectionResults_IncludeFollowUpNeeded] DEFAULT ((0)) NULL,
    [IncludePhoto]              BIT            CONSTRAINT [DF_LSC_InspectionResults_IncludePhoto] DEFAULT ((0)) NULL,
    [InspectionResults]         VARCHAR (1024) NULL,
    [InspectionActionTaken]     VARCHAR (512)  NULL,
    [InspectionFollowUpRequest] VARCHAR (512)  NULL,
    [InspectionPhotoBefore]     IMAGE          NULL,
    [InspectionPhotoAfter]      IMAGE          NULL,
    CONSTRAINT [PK_LSC_InspectionResults] PRIMARY KEY CLUSTERED ([PK_InspectionResults_Id] ASC)
);

