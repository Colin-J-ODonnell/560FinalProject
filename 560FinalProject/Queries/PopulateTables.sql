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