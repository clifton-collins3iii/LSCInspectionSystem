-- =============================================
-- Author:		Jared Bonnette
-- Create date: 1/12/15
-- Description:	Retrieves menu items by user permissions
-- =============================================
CREATE PROCEDURE [dbo].[MenuItem_SelectAllByUserId]
	@UserId uniqueidentifier = '00000000-0000-0000-0000-000000000000'
AS
BEGIN
	SET NOCOUNT ON;

	IF @UserId = '00000000-0000-0000-0000-000000000000'
		BEGIN
			SELECT DISTINCT MI.[MenuItemId]
				  ,MI.[Route]
				  ,MI.[Title]
				  ,MI.[ModuleId]
				  ,MI.[Nav]
				  ,MI.[ElementUid]
				  ,MI.[IconClass]
				  ,MI.[SortOrder]
				  ,MI.[IsHeader]
				  ,'' AS 'RoleName'
				FROM [dbo].[MenuItem] MI
				WHERE MI.[Title] = 'Login'
				ORDER BY MI.[SortOrder]
		END
	ELSE
		BEGIN
			SELECT DISTINCT MI.[MenuItemId]
			  ,MI.[Route]
			  ,MI.[Title]
			  ,MI.[ModuleId]
			  ,MI.[Nav]
			  ,MI.[ElementUid]
			  ,MI.[IconClass]
			  ,MI.[SortOrder]
			  ,MI.[IsHeader]
			  ,'Admin' AS RoleName
			FROM [dbo].[MenuItem] MI
			JOIN [dbo].[MenuItemRole] MIR ON MI.MenuItemId = MIR.MenuItemId
			--JOIN [dbo].[aspnet_UsersInRoles] UR ON UR.RoleId = MIR.RoleId
			--JOIN [dbo].[aspnet_Roles] R ON R.RoleId = MIR.RoleId
			--WHERE UR.UserId = @UserId
			ORDER BY MI.[SortOrder]
		END
END
