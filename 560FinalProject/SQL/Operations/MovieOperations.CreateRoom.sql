CREATE OR ALTER PROCEDURE MovieOperations.CreateRoom
    @RoomNumber INT,
    @Capacity INT,
    @RoomID INT OUTPUT,
    @TheaterID INT OUTPUT
AS

INSERT MovieOperations.Room(RoomNumber, Capacity)
VALUES(@RoomNumber, @Capacity);

SET @RoomID = SCOPE_IDENTITY();
SET @TheaterID = SCOPE_IDENTITY();
GO