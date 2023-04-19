GO

IF SCHEMA_ID(N'MovieOpperations') IS NULL
	EXEC(N'CREATE SCHEMA [MovieOpperations];');
GO


   CREATE TABLE MovieOpperations.Movie
   (
      MovieId INT NOT NULL IDENTITY(1, 1),
      Title NVARCHAR(128) NOT NULL,
      ReleaseYear INT NOT NULL,
	  Duration INT NOT NULL,
      Revenue DECIMAL(5, 2),

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

	LOAD DATA LOCAL INFILE "E:\CIS 560\560FinalProject\movies.csv" INTO TABLE MovieOpperations.Movie
	FIELDS TERMINATED BY ','
	LINES TERMINATED BY '\n' 
	IGNORE 1 LINES
	(Title, ReleaseYear, Duration, Revenue)