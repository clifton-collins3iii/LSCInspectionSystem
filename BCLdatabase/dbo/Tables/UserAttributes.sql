CREATE TABLE [dbo].[UserAttributes] (
    [Id]                       INT              IDENTITY (1, 1) NOT NULL,
    [UserId]                   UNIQUEIDENTIFIER NULL,
    [ChangePasswordFirstLogin] BIT              CONSTRAINT [DF_UserAttributes_ChangePasswordFirstLogin] DEFAULT ((1)) NULL,
    [MfaActive]                BIT              DEFAULT ((0)) NULL,
    [PlateRemovalProcessedBy]  VARCHAR (64)     NULL,
    [SMSPhoneNumber]           NVARCHAR (20)    NULL,
    [VerifiedEmailStatus]      BIT              DEFAULT ((0)) NOT NULL,
    [VerifiedCellPhoneStatus]  BIT              DEFAULT ((0)) NOT NULL,
    [RequireMFA]               BIT              DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_UserAttributes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

