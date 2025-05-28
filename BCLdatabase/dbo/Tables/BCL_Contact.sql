CREATE TABLE [dbo].[BCL_Contact] (
    [PK_Contact_Id]   INT           IDENTITY (1, 1) NOT NULL,
    [CreatedDate]     DATETIME      CONSTRAINT [DF_BCL_Contact_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [EffectiveDate]   DATETIME      CONSTRAINT [DF_BCL_Contact_EffectiveDate] DEFAULT (getdate()) NOT NULL,
    [TerminationDate] DATETIME      CONSTRAINT [DF_BCL_Contact_TerminationDate] DEFAULT ('2099-12-31 00:00:00.000') NOT NULL,
    [IsActive]        BIT           CONSTRAINT [DF_BCL_Contact_IsActive] DEFAULT ((1)) NOT NULL,
    [IsDeleted]       BIT           CONSTRAINT [DF_BCL_Contact_IsDeleted] DEFAULT ((0)) NOT NULL,
    [Name_First]      VARCHAR (35)  NOT NULL,
    [Name_Second]     VARCHAR (35)  NOT NULL,
    [Name_Middle]     VARCHAR (35)  NULL,
    [PhoneNumber]     VARCHAR (12)  NULL,
    [EmailAddress]    VARCHAR (64)  NULL,
    [Description]     VARCHAR (512) NULL,
    [AddressStreet]   VARCHAR (64)  NOT NULL,
    [AddressUnit]     VARCHAR (32)  NULL,
    [AddressCity]     VARCHAR (36)  NOT NULL,
    [AddressState]    CHAR (2)      NOT NULL,
    [AddressZip]      VARCHAR (10)  NOT NULL,
    CONSTRAINT [PK_Contact_Id] PRIMARY KEY CLUSTERED ([PK_Contact_Id] ASC)
);

