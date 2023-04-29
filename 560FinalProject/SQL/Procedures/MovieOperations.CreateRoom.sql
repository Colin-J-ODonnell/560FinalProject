CREATE OR ALTER PROCEDURE MovieOperations.CreateRoom
    @RoomNumber INT,
    @Capacity INT,
    @TheaterID INT,
    @RoomID INT OUTPUT
AS

INSERT MovieOperations.Room(RoomNumber, Capacity, TheaterID)
VALUES(@RoomNumber, @Capacity, @TheaterID);

SET @RoomID = SCOPE_IDENTITY();
GO