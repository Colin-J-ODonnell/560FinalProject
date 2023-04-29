CREATE OR ALTER PROCEDURE MovieOperations.RemoveShowtime
   @RoomID INT
AS
DELETE FROM MovieOperations.MovieShowtime
WHERE RoomID = @RoomID