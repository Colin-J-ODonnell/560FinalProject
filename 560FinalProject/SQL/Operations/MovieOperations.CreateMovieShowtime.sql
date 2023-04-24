CREATE OR ALTER PROCEDURE MovieOperations.CreateMovieShowtime
    @Showtime DateTime,
    @MovieID INT,
    @RoomID INT,
    @ShowtimeID INT OUTPUT
AS

INSERT MovieOperations.MovieShowtime(Showtime, MovieID, RoomID)
VALUES(@Showtime, @MovieID, @RoomID);

SET @ShowtimeID = SCOPE_IDENTITY();
GO