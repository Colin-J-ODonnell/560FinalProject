CREATE OR ALTER PROCEDURE MovieOperations.CreateTheater
   @Name NVARCHAR(128),
   @Address NVARCHAR(128),
   @RoomCount INT,
   @TheaterID INT OUTPUT
AS

INSERT MovieOperations.Theater([Name], [Address], RoomCount)
VALUES(@Name, @Address, @RoomCount);

SET @TheaterId = SCOPE_IDENTITY();
GO
