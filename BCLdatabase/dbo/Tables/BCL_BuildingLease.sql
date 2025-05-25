CREATE TABLE [dbo].[BCL_BuildingLease] (
    [PK_BuildingLease_Id]   INT          IDENTITY (1, 1) NOT NULL,
    [FK_Building_Id]        INT          NOT NULL,
    [FK_BuildingOwner_Id]   INT          NOT NULL,
    [CreatedDate]           DATETIME     CONSTRAINT [DF_BCL_BuildingLease_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [EffectiveDate]         DATETIME     CONSTRAINT [DF_BCL_BuildingLease_EffectiveDate] DEFAULT (getdate()) NOT NULL,
    [TerminationDate]       DATETIME     CONSTRAINT [DF_BCL_BuildingLease_TerminationDate] DEFAULT ('2099-12-31 00:00:00.000') NOT NULL,
    [IsActive]              BIT          CONSTRAINT [DF_BCL_BuildingLease_IsActive] DEFAULT ((1)) NOT NULL,
    [IsDeleted]             BIT          CONSTRAINT [DF_BCL_BuildingLease_IsDeleted] DEFAULT ((0)) NOT NULL,
    [LeasePaymentFrequency] VARCHAR (35) CONSTRAINT [DF_BCL_BuildingLease_LeasePaymentFrequency] DEFAULT ('Monthly') NOT NULL,
    [LeasePaymentAmount]    MONEY        CONSTRAINT [DF_BCL_BuildingLease_LeasePaymentAmount] DEFAULT ((0.00)) NOT NULL,
    [LeasePaymentDateNext]  DATE         NULL,
    CONSTRAINT [PK_BCL_BuildingLease] PRIMARY KEY CLUSTERED ([PK_BuildingLease_Id] ASC)
);

