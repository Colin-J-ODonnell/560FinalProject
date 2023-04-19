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

TRUNCATE TABLE MovieOperations.Genre

BULK
INSERT MovieOperations.Genre
FROM 'E:\CIS 560\560FinalProject\Excel Files\genres.csv'
WITH
(
FIRSTROW = 2,
FIELDTERMINATOR = ',',
ROWTERMINATOR = '\n'
)
GO
SELECT *
FROM MovieOperations.Genre

