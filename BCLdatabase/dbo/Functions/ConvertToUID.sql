-- =============================================
-- Author:		Trendsic, cgc3
-- Create date: 2022-01-05
-- Description:	Return uniqueidentifer or 
-- =============================================
CREATE Function [dbo].[ConvertToUID]
(
	@stringDotNetGUID varchar(50) = '00000000000000000000000000000000'	--	 if NULL passed, replace
) 
Returns uniqueidentifier 
As 
Begin
	If Len(@stringDotNetGUID) < 32 Or @stringDotNetGUID Is Null Begin
		Set @stringDotNetGUID = '00000000000000000000000000000000'
	End
		-- just in case it came in with 0x prefix or dashes...
		Set @stringDotNetGUID = replace(replace(@stringDotNetGUID,'0x',''),'-','')	-- 
		-- inject dashes in the right places
		Set @stringDotNetGUID = stuff(stuff(stuff(stuff(@stringDotNetGUID, 21, 0, '-'), 17, 0, '-'), 13, 0, '-'), 9, 0, '-')
    Return Cast(@stringDotNetGUID as uniqueidentifier)
End