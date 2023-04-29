CREATE OR ALTER PROCEDURE MovieOperations.RemoveRoom
    @RoomID INT
AS
DELETE ST FROM MovieOperations.MovieShowtime ST INNER JOIN MovieOperations.Room R ON R.RoomID = ST.RoomID
WHERE R.RoomID = @RoomID;
DELETE FROM MovieOperations.Room WHERE RoomId = @RoomID