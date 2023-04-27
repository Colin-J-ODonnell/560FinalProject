CREATE OR ALTER PROCEDURE MovieOperations.UpdateTheater
   @TheaterName NVARCHAR(128),
   @TheaterAddress NVARCHAR(128),
   @TheaterID INT
AS

UPDATE MovieOperations.Theater
SET TheaterName = @TheaterName, TheaterAddress = @TheaterAddress
WHERE TheaterID = @TheaterID
GO

