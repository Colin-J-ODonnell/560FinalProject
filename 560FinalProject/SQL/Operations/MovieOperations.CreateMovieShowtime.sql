CREATE OR ALTER PROCEDURE MovieOperations.CreateMovie
    @Title NVARCHAR(128),
    @ReleaseYear INT,
	@Duration INT,
    @Gross NVARCHAR(128),
    @Rating FLOAT,
    @MovieId INT OUTPUT
AS

INSERT MovieOperations.Movie(Title, ReleaseYear, Duration, Gross, Rating)
VALUES(@Title, @ReleaseYear, @Duration, @Gross, @Rating);

SET @MovieId = SCOPE_IDENTITY();
GO