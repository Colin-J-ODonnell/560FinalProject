CREATE OR ALTER PROCEDURE MovieOperations.RemoveMovie
    @MovieID INT
AS
DELETE MC FROM MovieOperations.MovieCast MC INNER JOIN MovieOperations.Movie M ON M.MovieID = MC.MovieID
WHERE M.MovieID = @MovieID;
DELETE ST FROM MovieOperations.MovieShowtime ST INNER JOIN MovieOperations.Movie M ON M.MovieID = ST.MovieID
WHERE M.MovieID = @MovieID;
DELETE MG FROM MovieOperations.MovieGenres MG INNER JOIN MovieOperations.Movie M ON M.MovieID = MG.MovieID
WHERE MG.MovieID = @MovieID;
DELETE FROM MovieOperations.Movie
WHERE MovieID = @MovieID