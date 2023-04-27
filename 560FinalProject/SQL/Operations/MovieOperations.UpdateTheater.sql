﻿CREATE OR ALTER PROCEDURE MovieOperations.UpdateTheater
   @Name NVARCHAR(128),
   @Address NVARCHAR(128),
   @TheaterID INT
AS

UPDATE MovieOperations.Theater
SET [Name] = @Name, [Address] = @Address
WHERE TheaterID = @TheaterID
GO

