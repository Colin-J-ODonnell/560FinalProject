CREATE OR ALTER PROCEDURE MovieOperations.RemoveMovieShowtime
    @ShowtimeID INT
AS

DELETE FROM MovieOperations.MovieShowtime
WHERE ShowtimeID = @ShowtimeID