IF NOT EXISTS
   (
      SELECT *
      FROM sys.schemas s
      WHERE s.[name] = N'MovieOperations'
   )
BEGIN
   EXEC(N'CREATE SCHEMA [MovieOperations] AUTHORIZATION [dbo]');
END;