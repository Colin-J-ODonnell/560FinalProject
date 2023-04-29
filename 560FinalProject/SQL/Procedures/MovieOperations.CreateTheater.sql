CREATE OR ALTER PROCEDURE MovieOperations.CreateTheater
   @TheaterName NVARCHAR(128),
   @TheaterAddress NVARCHAR(128),
   @RoomCount INT,
   @TheaterID INT OUTPUT
AS

INSERT MovieOperations.Theater(TheaterName, TheaterAddress, RoomCount)
VALUES(@TheaterName, @TheaterAddress, @RoomCount);

SET @TheaterId = SCOPE_IDENTITY();
GO
