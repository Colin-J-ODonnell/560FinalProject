CREATE OR ALTER PROCEDURE MovieOperations.RemoveMovie
    @MovieID INT
AS

DELETE FROM MovieOperations.Movie
WHERE MovieID = @MovieID