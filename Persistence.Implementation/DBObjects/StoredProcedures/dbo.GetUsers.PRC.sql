SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

IF exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetUsers]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[GetUsers]

GO

/* 	 

exec GetUsers @PageIndex=1,@PageSize=2,@FilterData=N'',@SortColumn=N'',@SortOrder=N'',@UserId=2,@Active=2
exec GetUsers @PageIndex=2,@PageSize=2,@FilterData=N'',@SortColumn=N'',@SortOrder=N'',@UserId=2,@Active=2
exec GetUsers @PageIndex=3,@PageSize=2,@FilterData=N'',@SortColumn=N'',@SortOrder=N'',@UserId=2,@Active=2
exec GetUsers @PageIndex=1,@PageSize=200,@FilterData=N' firstName like ''%FD%'' and lastName like ''%LD%''',@SortColumn=N'',@SortOrder=N'',@UserId=2,@Active=2
exec GetUsers @PageIndex=1,@PageSize=200,@FilterData=N' firstName like ''%F%''',@SortColumn=N'',@SortOrder=N'',@UserId=2,@Active=2

*/

CREATE PROCEDURE GetUsers 
(
	@PageIndex int = 1,        
	@PageSize int  = 20,
	@FilterData NVARCHAR(1000) = '',	
	@SortColumn NVARCHAR(100) = ''	,
	@SortOrder	NVARCHAR(20) = '',	
	@UserId	int = 2,
	@Active int = 2
)
AS
BEGIN

	Declare @pageStartRow INT,
			@pageEndRow INT, @instanceid int
	     
	 if(@PageIndex is not null AND  @PageSize is not null)    
	 BEGIN    
		 SET @pageStartRow = ((@PageIndex - 1) * @PageSize)+1;        
		 IF (@pageStartRow < 0)
		 BEGIN
			SET @pageStartRow = 0;
		 END
		 SET @pageEndRow = (@PageIndex) * @PageSize;       
	 END    
	 ELSE    
	 BEGIN    
		--IF calling code does not support page, use defaults
		SET @pageStartRow = 1;    
		SET @pageEndRow = 20;           
	 END  

	--select @pageStartRow, @pageEndRow

	DECLARE @Query NVARCHAR(max),
			@UserALL_CTE  NVARCHAR(max),
			@User_CTE NVARCHAR(max),			
			@User_Sel nvarchar(max)
			
	IF (@SortColumn = '')
		SET @SortColumn = 'firstName'
	if (@SortOrder = '')
		SET @SortOrder = 'ASC'
	
	SET @UserALL_CTE = ';with UserALL_CTE (            
			uid,
			firstName,
			lastName
		 ) as '
	
	SET @User_CTE = ', User_CTE (
			RowNumber,
			uid,
			firstName,
			lastName)
		AS (SELECT ROW_NUMBER() OVER (ORDER BY '+ @SortColumn +' '+@SortOrder+') AS RowNumber,* FROM UserALL_CTE) 
		 select * into #Result from User_CTE WHERE RowNumber between '+ cast(@pageStartRow as nvarchar(5)) + ' and '+ cast(@pageEndRow as nvarchar(5)) +' option (maxdop 2) '
	
	--if(@UserRole <> 'SADMN' AND @UserRole <> 'RADMIN')
	--BEGIN
		
	--END
	
	set @Query = @UserALL_CTE +  ' (select distinct
			uid,
			firstName,
			lastName
		from
			[dbo].[user]'	
					
	--if(@Active != 2)
	--	SET @Query = @Query + ' and rc.isactive ='+cast(@Active as nvarchar(10))
	
	--if(@UserRole = 'RADMIN')
	--	SET @Query = @Query + ' and rc.RetailPartyId in (select parentpartyid from partylink where childpartyid = ' + cast(@UserId as varchar(10)) + ' and partylinktypecode=''RADMIN'')'
		
	if(@FilterData <> '')
	begin
		if(charindex('firstName',@FilterData)>0)
			set @FilterData = REPLACE(@FilterData,'<Name>','p.FullName')			
			
		SET @Query = @Query + ' where ' + @FilterData
	end
					
	SET @Query = @Query + ')' 
				+ @User_CTE 
				+ ' select * from #Result'
	PRINT @Query
	EXEC (@Query)	
	--end	
END
Go