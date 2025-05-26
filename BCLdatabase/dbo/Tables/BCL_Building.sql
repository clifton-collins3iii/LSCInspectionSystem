CREATE TABLE [dbo].[BCL_Building] (
    [PK_Building_Id]  INT           IDENTITY (1, 1) NOT NULL,
    [FK_Campus_Id]    INT           NULL,
    [CreatedDate]     DATETIME      CONSTRAINT [DF_BCL_Building_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [EffectiveDate]   DATETIME      CONSTRAINT [DF_BCL_Building_EffectiveDate] DEFAULT (getdate()) NOT NULL,
    [TerminationDate] DATETIME      CONSTRAINT [DF_BCL_Building_TerminationDate] DEFAULT ('2099-12-31 00:00:00.000') NOT NULL,
    [IsActive]        BIT           CONSTRAINT [DF_BCL_Building_IsActive] DEFAULT ((1)) NOT NULL,
    [IsDeleted]       BIT           CONSTRAINT [DF_BCL_Building_IsDeleted] DEFAULT ((0)) NOT NULL,
    [Name_Short]      VARCHAR (32)  NOT NULL,
    [Name_Long]       VARCHAR (64)  NULL,
    [Description]     VARCHAR (512) NULL,
    [AddressStreet]   VARCHAR (64)  NOT NULL,
    [AddressUnit]     VARCHAR (32)  NULL,
    [AddressCity]     VARCHAR (36)  NOT NULL,
    [AddressState]    CHAR (2)      NOT NULL,
    [AddressZip]      VARCHAR (10)  NOT NULL,
    CONSTRAINT [PK_Building_Id] PRIMARY KEY CLUSTERED ([PK_Building_Id] ASC)
);

