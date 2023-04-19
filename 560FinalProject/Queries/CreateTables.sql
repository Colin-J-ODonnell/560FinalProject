IF SCHEMA_ID(N'MovieOperations') IS NULL
	EXEC(N'CREATE SCHEMA [MovieOperations];');
GO

DROP TABLE IF EXISTS MovieOperations.Movie

   CREATE TABLE MovieOperations.Movie
   (
      MovieId INT NOT NULL IDENTITY(1, 1),
      Title NVARCHAR(128) NOT NULL,
      Director NVARCHAR(128) NOT NULL,
      ReleaseYear INT NOT NULL,
	  Duration INT NOT NULL,
      Revenue NVARCHAR(128) NULL,
      Rating FLOAT NOT NULL

      CONSTRAINT [PK_MovieOperations_Movie_MovieId] PRIMARY KEY CLUSTERED
      (
         MovieId ASC
      )
   );

	CREATE TABLE MovieOperations.MovieCast
	(
		CastID INT NOT NULL IDENTITY(1,1),
		MovieID INT NOT NULL,
		ActorID INT NOT NULL,

		CONSTRAINT [PK_MovieOperations_MovieCast_CastId] PRIMARY KEY CLUSTERED
      (
         CastID ASC
      )
	);

    CREATE TABLE MovieOperations.Theater
    (
        TheaterID INT NOT NULL IDENTITY(1,1),
        [Name] NVARCHAR(128) NOT NULL,
        [Address] NVARCHAR(128) NOT NULL,

        CONSTRAINT [PK_MovieOperations_Theater_TheaterID] PRIMARY KEY CLUSTERED ( TheaterID ASC )
    );

    CREATE TABLE MovieOperations.Room
    (
        RoomID INT NOT NULL,
        TheaterID INT NOT NULL,
        RoomNumber INT NOT NULL,
        RoomCapacity INT NOT NULL

         CONSTRAINT [PK_MovieOperations_Room_RoomID] PRIMARY KEY CLUSTERED ( RoomID ASC )
    );

    CREATE TABLE MovieOperations.MovieShowtime
    (
        ShowtimeID INT NOT NULL,
        RoomID INT NOT NULL,
        MovieID INT NOT NULL,
        Showtime DateTime NOT NULL

         CONSTRAINT [PK_MovieOperations_MovieShowtime_ShowtimeID] PRIMARY KEY CLUSTERED ( ShowtimeID ASC )
    );

    CREATE TABLE MovieOperations.Seat
    (
        SeatID INT NOT NULL,
        RoomID INT NOT NULL,
        -- SeatResID INT NOT NULL,
        SeatNumber INT NOT NULL

         CONSTRAINT [PK_MovieOperations_Seat_SeatID] PRIMARY KEY CLUSTERED ( SeatID ASC )
    );



	