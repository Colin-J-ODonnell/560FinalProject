CREATE OR ALTER PROCEDURE MovieOperations.CreateMovieCast
   @MovieID INT,
   @ActorID INT,
   @CastID INT OUTPUT
AS

INSERT MovieOperations.MovieCast(MovieID, ActorID)
VALUES(@MovieID, @ActorID);

SET @CastID = SCOPE_IDENTITY();
GO