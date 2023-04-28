CREATE OR ALTER PROCEDURE MovieOperations.UpdateActor
   @FirstName NVARCHAR(128),
   @LastName NVARCHAR(256),
   @MovieList NVARCHAR(512),
   @ActorID INT
AS

UPDATE MovieOperations.Actor
SET FirstName = @FirstName, LastName = @LastName, MovieList = @MovieList
WHERE ActorID = @ActorID
GO