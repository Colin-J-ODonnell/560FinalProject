CREATE OR ALTER PROCEDURE MovieOperations.RemoveActor
	@ActorID int
AS

DELETE FROM MovieOperations.Actor
WHERE ActorID = @ActorID