CREATE OR ALTER PROCEDURE MovieOperations.CreateActor
    @FirstName NVARCHAR(128), 
    @LastName NVARCHAR(256),
    @MovieList NVARCHAR(512),
    @ActorID INT OUTPUT
AS

INSERT MovieOperations.Actor(FirstName, LastName, MovieList)
VALUES(@FirstName, @LastName, @MovieList);

SET @ActorID = SCOPE_IDENTITY();
GO