CREATE OR ALTER PROCEDURE MovieOperations.RemoveRoom
    @RoomID INT
AS
DELETE FROM MovieOperations.Room 
WHERE RoomID = @RoomID;