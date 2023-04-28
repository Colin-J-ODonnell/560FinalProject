CREATE OR ALTER PROCEDURE MovieOperations.UpdateRoom
   @RoomNumber INT NOT NULL,
   @Capacity INT NOT NULL,
   @RoomID INT
AS

UPDATE MovieOperations.Room
SET RoomNumber = @RoomNumber, Capacity = @Capacity
WHERE RoomID = @RoomID
GO