CREATE TABLE [dbo].[List_US_State] (
    [State]     VARCHAR (50) NOT NULL,
    [StateAbbr] VARCHAR (2)  NOT NULL,
    [Region]    VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_List_US_State] PRIMARY KEY CLUSTERED ([StateAbbr] ASC)
);

