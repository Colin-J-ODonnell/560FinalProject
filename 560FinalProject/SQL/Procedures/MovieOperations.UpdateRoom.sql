CREATE OR ALTER PROCEDURE MovieOperations.UpdateRoom
   @RoomNumber INT,
   @Capacity INT,
   @RoomID INT
AS

UPDATE MovieOperations.Room
SET RoomNumber = @RoomNumber, Capacity = @Capacity
WHERE RoomID = @RoomID
GO