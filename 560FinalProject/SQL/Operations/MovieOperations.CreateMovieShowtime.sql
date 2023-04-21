CREATE OR ALTER PROCEDURE MovieOperations.CreateMovieShowtime
    @Showtime DateTime,
    @ShowtimeID INT OUTPUT,
    @MovieID INT OUTPUT,
    @RoomID INT OUTPUT
AS

INSERT MovieOperations.MovieShowtime(Showtime)
VALUES(@Showtime);

SET @ShowtimeID = SCOPE_IDENTITY();
SET @MovieID = SCOPE_IDENTITY();
SET @RoomID = SCOPE_IDENTITY();
GO