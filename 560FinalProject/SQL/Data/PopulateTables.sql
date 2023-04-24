TRUNCATE TABLE MovieOperations.Movie

BULK
INSERT MovieOperations.Movie
FROM 'E:\CIS 560\560FinalProject\Excel Files\movies.csv'
WITH
(
FIRSTROW = 2,
FIELDTERMINATOR = ',',
ROWTERMINATOR = '\n'
)
GO
SELECT *
FROM MovieOperations.Movie

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

TRUNCATE TABLE MovieOperations.Actor
BULK
INSERT MovieOperations.Actor
FROM 'E:\CIS 560\560FinalProject\Excel Files\actors.csv'
WITH
(
FIRSTROW = 1,
FIELDTERMINATOR = ',',
ROWTERMINATOR = '\n'
)
GO
SELECT *
FROM MovieOperations.Actor
 