CREATE TABLE [dbo].[BCL_SourceContacts] (
    [PK_SourceContacts_Id] INT      IDENTITY (1, 1) NOT NULL,
    [FK_Source_Id]         INT      NOT NULL,
    [FK_Contacts_Id]       INT      NOT NULL,
    [CreatedDate]          DATETIME CONSTRAINT [DF_BCL_SourceContacts_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [EffectiveDate]        DATETIME CONSTRAINT [DF_BCL_SourceContacts_EffectiveDate] DEFAULT (getdate()) NOT NULL,
    [TerminationDate]      DATETIME CONSTRAINT [DF_BCL_SourceContacts_TerminationDate] DEFAULT ('2099-12-31 00:00:00.000') NOT NULL,
    [IsActive]             BIT      CONSTRAINT [DF_BCL_SourceContacts_IsActive] DEFAULT ((1)) NOT NULL,
    [IsDeleted]            BIT      CONSTRAINT [DF_BCL_SourceContacts_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_SourceContacts_Id] PRIMARY KEY CLUSTERED ([PK_SourceContacts_Id] ASC)
);

