CREATE TABLE [dbo].[BCL_Contacts] (
    [PK_Contacts_Id]      INT           IDENTITY (1, 1) NOT NULL,
    [CreatedDate]         DATETIME      CONSTRAINT [DF_BCL_Contacts_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [EffectiveDate]       DATETIME      CONSTRAINT [DF_BCL_Contacts_EffectiveDate] DEFAULT (getdate()) NOT NULL,
    [TerminationDate]     DATETIME      CONSTRAINT [DF_BCL_Contacts_TerminationDate] DEFAULT ('2099-12-31 00:00:00.000') NOT NULL,
    [IsActive]            BIT           CONSTRAINT [DF_BCL_Contacts_IsActive] DEFAULT ((1)) NOT NULL,
    [IsDeleted]           BIT           CONSTRAINT [DF_BCL_Contacts_IsDeleted] DEFAULT ((0)) NOT NULL,
    [Contacts_Name]       VARCHAR (32)  NOT NULL,
    [ContactsDescription] VARCHAR (512) NULL,
    [AddressStreet]       VARCHAR (64)  NOT NULL,
    [AddressUnit]         VARCHAR (32)  NULL,
    [AddressCity]         VARCHAR (36)  NOT NULL,
    [AddressState]        CHAR (2)      NOT NULL,
    [AddressZip]          VARCHAR (10)  NOT NULL,
    [MobilePhoneNumber]   VARCHAR (10)  NULL,
    [EmailAddress]        VARCHAR (128) NULL,
    CONSTRAINT [PK_Contacts_Id] PRIMARY KEY CLUSTERED ([PK_Contacts_Id] ASC)
);

