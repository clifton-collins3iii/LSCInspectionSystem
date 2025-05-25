-- =============================================
-- Author:		Trendsic, cgc3
-- Create date: 2022-01-05
-- Description:	Return uniqueidentifer or 
-- =============================================
CREATE Function [dbo].[GetMMDDYYYY]
(
	@datespecified datetime	--	 if NULL passed, replace with GetDate()
) 
Returns varchar(8)
As 
Begin
	Declare @MMDDYYYY as varchar(8)
	If Len(@datespecified) < 8 Or @datespecified Is Null Begin
		Set @datespecified = GetDate()
	End
	Set @MMDDYYYY = Format(@datespecified, 'MM') + Format(@datespecified, 'dd') + Format(@datespecified, 'yyyy')
    Return @MMDDYYYY
End