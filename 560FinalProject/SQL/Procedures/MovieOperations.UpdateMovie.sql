CREATE OR ALTER PROCEDURE MovieOperations.UpdateMovie
    @Title NVARCHAR(128),
    @ReleaseYear INT,
	@Duration INT,
    @Gross NVARCHAR(128),
    @Rating FLOAT,
    @MovieId INT
AS

UPDATE MovieOperations.Movie
SET Title = @Title, ReleaseYear = @ReleaseYear, Duration = @Duration, Gross = @Gross, Rating = @Rating
WHERE MovieID = @MovieId;
GO