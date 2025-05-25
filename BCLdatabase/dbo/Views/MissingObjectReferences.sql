

create view dbo.MissingObjectReferences
as 
/*
modified version of script from https://michaeljswart.com/2009/12/find-missing-sql-dependencies/
Added columns for object types &amp; generated refresh module command...
filter out user-define types: http://stackoverflow.com/questions/2330521/find-broken-objects-in-sql-server
*/
 
SELECT TOP (100) PERCENT
    QuoteName(OBJECT_SCHEMA_NAME(referencing_id)) + '.' + QuoteName(OBJECT_NAME(referencing_id)) AS [this Object...],
        o.type_desc,
    ISNULL(QuoteName(referenced_server_name) + '.', '')
    + ISNULL(QuoteName(referenced_database_name) + '.', '')
    + ISNULL(QuoteName(referenced_schema_name) + '.', '')
    + QuoteName(referenced_entity_name) AS [... depends ON this missing entity name]
    ,sed.referenced_class_desc
    ,case when o.type_desc in( 'SQL_STORED_PROCEDURE' ,'SQL_SCALAR_FUNCTION' ,'SQL_TRIGGER' ,'VIEW')
		  then 'EXEC sys.sp_refreshsqlmodule ''' + QuoteName(OBJECT_SCHEMA_NAME(referencing_id)) + '.' + QuoteName(OBJECT_NAME(referencing_id)) + ''';'
		  else null
	   end as [Refresh SQL Module command]
FROM sys.sql_expression_dependencies as sed
LEFT JOIN sys.objects o
            ON sed.referencing_id=o.object_id
WHERE (is_ambiguous = 0)
    AND (OBJECT_ID(ISNULL(QuoteName(referenced_server_name) + '.', '')
    + ISNULL(QuoteName(referenced_database_name) + '.', '')
    + ISNULL(QuoteName(referenced_schema_name) + '.', '')
    + QuoteName(referenced_entity_name)) IS NULL)
    AND NOT EXISTS
	   (SELECT * 
	    FROM sys.types 
	    WHERE types.name = referenced_entity_name 
	    AND types.schema_id = ISNULL(SCHEMA_ID(referenced_schema_name), SCHEMA_ID('dbo'))
	   )
ORDER BY [this Object...],
[... depends ON this missing entity name]