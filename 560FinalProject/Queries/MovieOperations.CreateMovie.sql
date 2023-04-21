CREATE OR ALTER PROCEDURE MovieOperations.CreateMovie
    @Title NVARCHAR(128), 
    @ReleaseYear INT,
	@Duration INT,
    @Gross NVARCHAR(128),
    @Rating FLOAT,
    @MovieID INT OUTPUT,
    @DirectorID INT OUTPUT
AS

INSERT MovieOperations.Movie(Title, Duration, ReleaseYear, Gross, Rating)
VALUES(@Title, @Duration, @ReleaseYear, @Gross, @Rating);

SET @MovieID = SCOPE_IDENTITY();
SET @DirectorID = SCOPE_IDENTITY();
GO