CREATE TABLE [dbo].[BCL_Source] (
    [PK_Source_Id]       INT           IDENTITY (1, 1) NOT NULL,
    [CreatedDate]        DATETIME      CONSTRAINT [DF_BCL_Source_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [EffectiveDate]      DATETIME      CONSTRAINT [DF_BCL_Source_EffectiveDate] DEFAULT (getdate()) NOT NULL,
    [TerminationDate]    DATETIME      CONSTRAINT [DF_BCL_Source_TerminationDate] DEFAULT ('2099-12-31 00:00:00.000') NOT NULL,
    [IsActive]           BIT           CONSTRAINT [DF_BCL_Source_IsActive] DEFAULT ((1)) NOT NULL,
    [IsDeleted]          BIT           CONSTRAINT [DF_BCL_Source_IsDeleted] DEFAULT ((0)) NOT NULL,
    [Source_Name]        VARCHAR (32)  NOT NULL,
    [SourceDescription]  VARCHAR (512) NULL,
    [AddressStreet]      VARCHAR (64)  NOT NULL,
    [AddressUnit]        VARCHAR (32)  NULL,
    [AddressCity]        VARCHAR (36)  NOT NULL,
    [AddressState]       CHAR (2)      NOT NULL,
    [AddressZip]         VARCHAR (10)  NOT NULL,
    [OfficePhoneNumber]  VARCHAR (10)  NULL,
    [OfficeEmailAddress] VARCHAR (64)  NULL,
    CONSTRAINT [PK_Source_Id] PRIMARY KEY CLUSTERED ([PK_Source_Id] ASC)
);

