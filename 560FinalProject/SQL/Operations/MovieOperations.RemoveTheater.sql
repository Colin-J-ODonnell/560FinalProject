CREATE OR ALTER PROCEDURE MovieOperations.RemoveTheater
   @TheaterID INT
AS
DELETE R FROM MovieOperations.Theater T
	INNER JOIN MovieOperations.Room R ON R.TheaterID = T.TheaterID
	INNER JOIN MovieOperations.MovieShowtime ST ON ST.RoomID = R.RoomID
WHERE T.TheaterID = @TheaterID

DELETE FROM MovieOperations.Theater WHERE TheaterID = @TheaterID