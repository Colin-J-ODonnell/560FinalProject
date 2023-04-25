IF(NOT EXISTS(SELECT 1 FROM MovieOperations.Movie))
BEGIN
	BULK
	INSERT MovieOperations.Movie
	FROM 'C:\Users\rosen\source\repos\560FinalProject\Excel Files\movies.csv'
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
	FROM 'C:\Users\rosen\source\repos\560FinalProject\Excel Files\genres.csv'
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
	FROM 'C:\Users\rosen\source\repos\560FinalProject\Excel Files\actors.csv'
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
	FROM 'C:\Users\rosen\source\repos\560FinalProject\Excel Files\theaters.csv'
	WITH
	(
	FIRSTROW = 1,
	FIELDTERMINATOR = ',',
	ROWTERMINATOR = '\n'
	)
END;
 