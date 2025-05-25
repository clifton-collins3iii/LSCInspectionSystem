/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 Update the database version here for each release.  
 The best practice would be to modify the version when a new branch is made for the release.
 Run the sql statement at the end of the release, after the dealer portal and dealer service updates
--------------------------------------------------------------------------------------
*/
Insert Into AppVersion
(created_date, versionstring, isenabled, effective_date, terminationdate)
Values (GetDate(), '1.0.0.0', 1, GETDATE(), Null);