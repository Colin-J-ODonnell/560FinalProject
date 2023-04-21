CREATE OR ALTER PROCEDURE MovieOperations.CreateActor
    @FirstName NVARCHAR(128), 
    @LastName NVARCHAR(128),
    @ActorID INT OUTPUT
AS

INSERT MovieOperations.Actor(FirstName, LastName)
VALUES(@FirstName, @LastName);

SET @ActorID = SCOPE_IDENTITY();
GO