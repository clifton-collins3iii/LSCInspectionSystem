CREATE TABLE [dbo].[BCL_BuildingRoom] (
    [PK_BuildingRoom_Id]   INT           IDENTITY (1, 1) NOT NULL,
    [FK_Building_Id]       INT           NOT NULL,
    [CreatedDate]          DATETIME      CONSTRAINT [DF_BCL_BuildingRoom_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [EffectiveDate]        DATETIME      CONSTRAINT [DF_BCL_BuildingRoom_EffectiveDate] DEFAULT (getdate()) NOT NULL,
    [TerminationDate]      DATETIME      CONSTRAINT [DF_BCL_BuildingRoom_TerminationDate] DEFAULT ('2099-12-31 00:00:00.000') NOT NULL,
    [IsActive]             BIT           CONSTRAINT [DF_BCL_BuildingRoom_IsActive] DEFAULT ((1)) NOT NULL,
    [IsDeleted]            BIT           CONSTRAINT [DF_BCL_BuildingRoom_IsDeleted] DEFAULT ((0)) NOT NULL,
    [Name_Short]           VARCHAR (32)  NOT NULL,
    [Name_Long]            VARCHAR (64)  NULL,
    [Description]          VARCHAR (512) NULL,
    [RentPaymentFrequency] VARCHAR (35)  CONSTRAINT [DF_Table_1_LeasePaymentFrequency] DEFAULT ('Weekly') NOT NULL,
    [RentPaymentAmount]    MONEY         CONSTRAINT [DF_Table_1_LeasePaymentAmount] DEFAULT ((0.00)) NOT NULL,
    CONSTRAINT [PK_BuildingRoom_Id] PRIMARY KEY CLUSTERED ([PK_BuildingRoom_Id] ASC)
);

