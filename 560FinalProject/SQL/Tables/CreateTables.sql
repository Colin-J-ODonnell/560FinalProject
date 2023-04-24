CREATE TABLE MovieOperations.Movie
(
    MovieId INT NOT NULL IDENTITY(1, 1),
    Title NVARCHAR(128) NOT NULL,
    ReleaseYear INT NOT NULL,
	Duration INT NOT NULL,
    Gross NVARCHAR(128) NULL,
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
    [Capacity] INT NOT NULL

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