CREATE TABLE [dbo].[LSC_InspectionSurvey] (
    [PK_InspectionSurvey]   INT              IDENTITY (1, 1) NOT NULL,
    [FK_aspnetUsers_UserId] UNIQUEIDENTIFIER NOT NULL,
    [FK_Campus_Id]          INT              NOT NULL,
    [CreatedDate]           DATETIME         CONSTRAINT [DF_LSC_InspectionSurvey_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [SubmittedDate]         DATETIME         CONSTRAINT [DF_Table_1_EffectiveDate] DEFAULT (getdate()) NOT NULL,
    [ReviewedDate]          DATETIME         CONSTRAINT [DF_Table_1_TerminationDate] DEFAULT ('2099-12-31 00:00:00.000') NOT NULL,
    [IsActive]              BIT              CONSTRAINT [DF_LSC_InspectionSurvey_IsActive] DEFAULT ((1)) NOT NULL,
    [IsDeleted]             BIT              CONSTRAINT [DF_LSC_InspectionSurvey_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_LSC_InspectionSurvey] PRIMARY KEY CLUSTERED ([PK_InspectionSurvey] ASC)
);

