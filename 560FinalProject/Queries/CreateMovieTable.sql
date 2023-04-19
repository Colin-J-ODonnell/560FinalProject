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