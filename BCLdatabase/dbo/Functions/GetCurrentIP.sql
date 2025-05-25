﻿CREATE FUNCTION [dbo].[GetCurrentIP] ()
RETURNS varchar(255)
AS
BEGIN
    DECLARE @IP_Address varchar(255);

    SELECT @IP_Address = client_net_address
    FROM sys.dm_exec_connections
    WHERE session_id = @@SPID;

    Return @IP_Address;
END