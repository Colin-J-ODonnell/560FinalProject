CREATE OR ALTER PROCEDURE MovieOperations.RemoveTheater
   @TheaterID INT
AS
DELETE ST FROM MovieOperations.MovieShowtime ST
	INNER JOIN MovieOperations.Room R ON R.RoomID = ST.RoomID
	INNER JOIN MovieOperations.Theater T ON T.TheaterID = R.TheaterID
WHERE R.TheaterID = @TheaterID

DELETE R FROM MovieOperations.Room R
	INNER JOIN MovieOperations.Theater T ON T.TheaterID = R.TheaterID
WHERE R.TheaterID = @TheaterID

DELETE FROM MovieOperations.Theater WHERE TheaterID = @TheaterID