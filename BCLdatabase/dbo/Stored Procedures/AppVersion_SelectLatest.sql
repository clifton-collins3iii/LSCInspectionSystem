CREATE PROCEDURE [dbo].[AppVersion_SelectLatest]
AS
BEGIN
   SET NOCOUNT OFF;
SELECT TOP(1) pk_id, created_date, versionstring, isenabled, effective_date, terminationdate, @@SERVERNAME As SQLServerName, DB_NAME() As DBName, @@VERSION As SQLSVRversion
FROM [AppVersion]
Where isenabled = 1
And GetDate() >= effective_date
Order By effective_date Desc, versionstring Desc
 
END