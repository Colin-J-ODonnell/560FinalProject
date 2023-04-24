CREATE OR ALTER PROCEDURE MovieOperations.RemoveTheater
   @TheaterID INT
AS

DELETE FROM MovieOperations.Theater
WHERE TheaterID = @TheaterID