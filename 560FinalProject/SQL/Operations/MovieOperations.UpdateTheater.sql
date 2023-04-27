CREATE OR ALTER PROCEDURE MovieOperations.UpdateTheater
   @Name NVARCHAR(128),
   @Address NVARCHAR(128),
   @TheaterID INT
AS

UPDATE MovieOperations.Theater
SET TheaterName = @Name, TheaterAddress = @Address
WHERE TheaterID = @TheaterID
GO

