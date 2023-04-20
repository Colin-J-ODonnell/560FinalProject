CREATE PROCEDURE MovieOperations.CreateTheater
   @Name NVARCHAR(128),
   @Address NVARCHAR(128),
   @TheaterID INT OUTPUT
AS

INSERT MovieOperations.Theater([Name], [Address])
VALUES(@Name, @Address);

SET @TheaterId = SCOPE_IDENTITY();
GO
