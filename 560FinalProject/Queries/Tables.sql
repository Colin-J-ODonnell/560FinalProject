IF NOT EXISTS
   (
      SELECT *
      FROM sys.schemas s
      WHERE s.[name] = N'MovieOperations'
   )
BEGIN
   EXEC(N'CREATE SCHEMA [MovieOperations] AUTHORIZATION [dbo]');
END;

USE rosen;
EXEC sp_help CreateTheater;

DROP TABLE IF EXISTS MovieOperations.SeatReservation
DROP TABLE IF EXISTS MovieOperations.Reservation
DROP TABLE IF EXISTS MovieOperations.MovieGenres
DROP TABLE IF EXISTS MovieOperations.Genre
DROP TABLE IF EXISTS MovieOperations.Seat
DROP TABLE IF EXISTS MovieOperations.MovieShowtime
DROP TABLE IF EXISTS MovieOperations.Room
DROP TABLE IF EXISTS MovieOperations.Theater
DROP TABLE IF EXISTS MovieOperations.MovieCast
DROP TABLE IF EXISTS MovieOperations.Actor
DROP TABLE IF EXISTS MovieOperations.Movie
DROP TABLE IF EXISTS MovieOperations.Director

CREATE TABLE MovieOperations.Director
(
    DirectorID INT NOT NULL,
    FirstName NVARCHAR(128) NOT NULL,
    LastName NVARCHAR(128) NOT NULL

        CONSTRAINT [PK_MovieOperations_Director_DirectorID] PRIMARY KEY CLUSTERED ( DirectorID ASC )
);

CREATE TABLE MovieOperations.Movie
(
    MovieId INT NOT NULL IDENTITY(1, 1),
    Title NVARCHAR(128) NOT NULL,
    DirectorID INT NOT NULL FOREIGN KEY
        REFERENCES MovieOperations.Director(DirectorID),
    ReleaseYear INT NOT NULL,
	Duration INT NOT NULL,
    Revenue NVARCHAR(128) NULL,
    Rating FLOAT NOT NULL

    CONSTRAINT [PK_MovieOperations_Movie_MovieId] PRIMARY KEY CLUSTERED
    (
        MovieId ASC
    )
);

CREATE TABLE MovieOperations.Actor
(
    ActorID INT NOT NULL,
    FirstName NVARCHAR(128) NOT NULL,
    LastName NVARCHAR(128) NULL

        CONSTRAINT [PK_MovieOperations_Actor_ActorID] PRIMARY KEY CLUSTERED ( ActorID ASC )
);

CREATE TABLE MovieOperations.MovieCast
(
	CastID INT NOT NULL IDENTITY(1,1),
	MovieID INT NOT NULL FOREIGN KEY
        REFERENCES MovieOperations.Movie(MovieID),
	ActorID INT NOT NULL FOREIGN KEY
        REFERENCES MovieOperations.Actor(ActorID)

	CONSTRAINT [PK_MovieOperations_MovieCast_CastId] PRIMARY KEY CLUSTERED
    (
        CastID ASC
    )
);
CREATE TABLE MovieOperations.Theater
(
    TheaterID INT NOT NULL IDENTITY(1,1),
    [Name] NVARCHAR(128) UNIQUE NOT NULL,
    [Address] NVARCHAR(128) NOT NULL

    CONSTRAINT [PK_MovieOperations_Theater_TheaterID] PRIMARY KEY CLUSTERED ( TheaterID ASC )
);
CREATE TABLE MovieOperations.Room
(
    RoomID INT NOT NULL,
    TheaterID INT UNIQUE NOT NULL FOREIGN KEY
        REFERENCES MovieOperations.Theater(TheaterID),
    RoomNumber INT UNIQUE NOT NULL,
    RoomCapacity INT NOT NULL

        CONSTRAINT [PK_MovieOperations_Room_RoomID] PRIMARY KEY CLUSTERED ( RoomID ASC )
);
CREATE TABLE MovieOperations.MovieShowtime
(
    ShowtimeID INT NOT NULL,
    RoomID INT UNIQUE NOT NULL FOREIGN KEY
        REFERENCES MovieOperations.Room(RoomID),
    MovieID INT NOT NULL
        REFERENCES MovieOperations.Movie(MovieID),
    Showtime DateTime NOT NULL

        CONSTRAINT [PK_MovieOperations_MovieShowtime_ShowtimeID] PRIMARY KEY CLUSTERED ( ShowtimeID ASC )
);
CREATE TABLE MovieOperations.Seat
(
    SeatID INT NOT NULL,
    RoomID INT NOT NULL FOREIGN KEY
        REFERENCES MovieOperations.Room(RoomID),
    SeatNumber INT NOT NULL,

        CONSTRAINT [PK_MovieOperations_Seat_SeatID] PRIMARY KEY CLUSTERED ( SeatID ASC )
);
CREATE TABLE MovieOperations.Genre
(
    GenreID INT NOT NULL,
    GenreType NVARCHAR(128) UNIQUE NOT NULL,

        CONSTRAINT [PK_MovieOperations_Genre_GenreID] PRIMARY KEY CLUSTERED ( GenreID ASC )
);

CREATE TABLE MovieOperations.MovieGenres
(
    MovieGenreID INT NOT NULL,
    MovieID INT NOT NULL
        REFERENCES MovieOperations.Movie(MovieID),
    GenreID INT NOT NULL
        REFERENCES MovieOperations.Genre(GenreID),

        CONSTRAINT [PK_MovieOperations_MovieGenres_MovieGenreID] PRIMARY KEY CLUSTERED ( MovieGenreID ASC )
);
CREATE TABLE MovieOperations.Reservation
(
	ReservationID INT NOT NULL IDENTITY(1,1),
	[Time] Time NOT NULL,
	ReservationName NVARCHAR(128) UNIQUE NOT NULL,

	CONSTRAINT [PK_MovieOperations_Reservation_ReservationID] PRIMARY KEY CLUSTERED
    (
        ReservationID ASC
    )
);

CREATE TABLE MovieOperations.SeatReservation
(
	SeatResID INT NOT NULL IDENTITY(1,1),
	ReservationID INT UNIQUE NOT NULL
        REFERENCES MovieOperations.Reservation(ReservationID),
	SeatID INT UNIQUE NOT NULL
        REFERENCES MovieOperations.Seat(SeatID),

	CONSTRAINT [PK_MovieOperations_SeatReservation_SeatResID] PRIMARY KEY CLUSTERED
    (
        SeatResID ASC
    )
);