CREATE TABLE [dbo].[List_PaymentFrequency] (
    [PK_List_PaymentFrequency_Id] INT           IDENTITY (1, 1) NOT NULL,
    [CreatedDate]                 DATETIME      CONSTRAINT [DF_List_PaymentFrequency_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [EffectiveDate]               DATETIME      CONSTRAINT [DF_List_PaymentFrequency_EffectiveDate] DEFAULT (getdate()) NOT NULL,
    [TerminationDate]             DATETIME      CONSTRAINT [DF_List_PaymentFrequency_TerminationDate] DEFAULT (((2099)-(12))-(31)) NOT NULL,
    [IsActive]                    BIT           CONSTRAINT [DF_List_PaymentFrequency_IsActive] DEFAULT ((1)) NOT NULL,
    [IsDeleted]                   BIT           CONSTRAINT [DF_List_PaymentFrequency_IsDeleted] DEFAULT ((0)) NOT NULL,
    [Name_Short]                  VARCHAR (32)  NOT NULL,
    [Name_Long]                   VARCHAR (64)  NULL,
    [Description]                 VARCHAR (512) NULL,
    CONSTRAINT [PK_List_PaymentFrequency] PRIMARY KEY CLUSTERED ([PK_List_PaymentFrequency_Id] ASC)
);

