CREATE OR ALTER PROCEDURE MovieOperations.RemoveFromMovieCast
    @ActorID INT
AS

DELETE FROM MovieOperations.MovieCast
WHERE ActorID = @ActorID