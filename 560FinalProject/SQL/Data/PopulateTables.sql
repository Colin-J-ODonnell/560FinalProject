IF(NOT EXISTS(SELECT 1 FROM MovieOperations.Movie))
BEGIN
	BULK
	INSERT MovieOperations.Movie
	FROM 'C:\Users\odonn\CIS 560\560FinalProject\Excel Files\movies.csv'
	WITH
	(
	FIRSTROW = 2,
	FIELDTERMINATOR = ',',
	ROWTERMINATOR = '\n'
	)
END;

IF(NOT EXISTS(SELECT 1 FROM MovieOperations.Genre))
BEGIN
	BULK
	INSERT MovieOperations.Genre
	FROM 'C:\Users\odonn\CIS 560\560FinalProject\Excel Files\genres.csv'
	WITH
	(
	FIRSTROW = 2,
	FIELDTERMINATOR = ',',
	ROWTERMINATOR = '\n'
	)
END;

IF(NOT EXISTS(SELECT 1 FROM MovieOperations.Actor))
BEGIN
	BULK
	INSERT MovieOperations.Actor
	FROM 'C:\Users\odonn\CIS 560\560FinalProject\Excel Files\actors.csv'
	WITH
	(
	FIRSTROW = 1,
	FIELDTERMINATOR = ',',
	ROWTERMINATOR = '\n'
	)
END;

IF(NOT EXISTS(SELECT 1 FROM MovieOperations.Theater))
BEGIN
	BULK
	INSERT MovieOperations.Theater
	FROM 'E:\CIS 560\560FinalProject\Excel Files\theaters.csv'
	WITH
	(
	FIRSTROW = 1,
	FIELDTERMINATOR = ',',
	ROWTERMINATOR = '\n'
	)
END;

IF(NOT EXISTS(SELECT 1 FROM MovieOperations.MovieGenres))
BEGIN
	BULK
	INSERT MovieOperations.MovieGenres
	FROM 'E:\CIS 560\560FinalProject\Excel Files\genretemp.csv'
	WITH
	(
	FIELDTERMINATOR = ',',
	ROWTERMINATOR = '\n'
	)
END;
 