CREATE OR ALTER PROCEDURE MovieOperations.CreateRoom
    @RoomNumber INT,
    @Capacity INT,
    @RoomID INT OUTPUT,
    @TheaterID INT OUTPUT
AS

-- ADD CODE HERE FOR REMOVING A ROOM --