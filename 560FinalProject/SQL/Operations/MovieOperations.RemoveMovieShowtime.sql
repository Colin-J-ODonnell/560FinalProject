CREATE OR ALTER PROCEDURE MovieOperations.RemoveMovieShowtime
    @Showtime DateTime,
    @ShowtimeID INT OUTPUT,
    @MovieID INT OUTPUT,
    @RoomID INT OUTPUT
AS

-- ADD CODE HERE FOR REMOVIING A MOVIESHOWTIME --