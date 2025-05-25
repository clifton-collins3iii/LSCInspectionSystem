CREATE TABLE [dbo].[BCL_RoomResident] (
    [PK_RoomResident_Id]   INT          IDENTITY (1, 1) NOT NULL,
    [FK_Resident_Id]       INT          NOT NULL,
    [FK_BuildingRoom_Id]   INT          NOT NULL,
    [CreatedDate]          DATETIME     CONSTRAINT [DF_BCL_RoomResident_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [EffectiveDate]        DATETIME     CONSTRAINT [DF_BCL_RoomResident_EffectiveDate] DEFAULT (getdate()) NOT NULL,
    [TerminationDate]      DATETIME     CONSTRAINT [DF_BCL_RoomResident_TerminationDate] DEFAULT ('2099-12-31 00:00:00.000') NOT NULL,
    [IsActive]             BIT          CONSTRAINT [DF_BCL_RoomResident_IsActive] DEFAULT ((1)) NOT NULL,
    [IsDeleted]            BIT          CONSTRAINT [DF_BCL_RoomResident_IsDeleted] DEFAULT ((0)) NOT NULL,
    [RentPaymentFrequency] VARCHAR (35) CONSTRAINT [DF_Table_2_LeasePaymentFrequency] DEFAULT ('Weekly') NOT NULL,
    [RentPaymentAmount]    MONEY        CONSTRAINT [DF_Table_2_LeasePaymentAmount] DEFAULT ((0.00)) NOT NULL,
    CONSTRAINT [PK_RoomResident_Id] PRIMARY KEY CLUSTERED ([PK_RoomResident_Id] ASC)
);

