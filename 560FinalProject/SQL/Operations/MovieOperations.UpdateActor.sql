CREATE OR ALTER PROCEDURE MovieOperations.UpdateActor
   @FirstName NVARCHAR(128) NOT NULL,
   @LastName NVARCHAR(256) NULL,
   @MovieList NVARCHAR(512) NOT NULL,
   @ActorID INT
AS

UPDATE MovieOperations.Actor
SET FirstName = @FirstName, LastName = @LastName, MovieList = @MovieList
WHERE ActorID = @ActorID
GO