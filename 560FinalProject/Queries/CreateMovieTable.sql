IF OBJECT_ID(N'MovieOperations.Movie') IS NULL
BEGIN
   CREATE TABLE MovieOperations.Movie
   (
      MovieId INT NOT NULL IDENTITY(1, 1),
      Title NVARCHAR(128) NOT NULL,
      Duration INT NOT NULL,
      ReleaseYear INT NOT NULL,
      Revenue DECIMAL(5, 2) NOT NULL,

      CONSTRAINT [PK_MovieOperations_Movie_MovieId] PRIMARY KEY CLUSTERED
      (
         MovieId ASC
      )
   );
END;

GO

IF SCHEMA_ID(N'MovieOpperations') IS NULL
	EXEC(N'CREATE SCHEMA [MovieOpperations];');
GO

    DROP TABLE IF EXISTS MovieOpperations.Movie

   CREATE TABLE MovieOpperations.Movie
   (
      MovieId INT NOT NULL IDENTITY(1, 1),
      Title NVARCHAR(128) NOT NULL,
      ReleaseYear INT NOT NULL,
	  Duration INT NOT NULL,
      Revenue NVARCHAR(128) NULL

      CONSTRAINT [PK_MovieOperations_Movie_MovieId] PRIMARY KEY CLUSTERED
      (
         MovieId ASC
      )
   );

	CREATE TABLE MovieOpperations.MovieCast
	(
		CastID INT NOT NULL IDENTITY(1,1),
		MovieID INT NOT NULL,
		ActorID INT NOT NULL,

		CONSTRAINT [PK_MovieOperations_MovieCast_CastId] PRIMARY KEY CLUSTERED
      (
         CastID ASC
      )
	);

	BULK
    INSERT MovieOpperations.Movie
    FROM 'E:\CIS 560\560FinalProject\movies.csv'
    WITH
    (
    FIRSTROW = 2,
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n'
    )
    GO
    SELECT *
    FROM MovieOpperations.Movie

    BULK
    INSERT MovieOpperations.MovieCast
    FROM 'E:\CIS 560\560FinalProject\'