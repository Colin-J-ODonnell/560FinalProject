CREATE OR ALTER PROCEDURE MovieOperations.UpdateShowtime
   @ShowtimeID INT,
   @RoomID INT,
   @MovieID INT,
   @StartDateTime DATETIME
AS

UPDATE MovieOperations.MovieShowtime
SET RoomID = @RoomID, MovieID = @MovieID, Showtime = @StartDateTime
WHERE ShowtimeID = @ShowtimeID
GO

