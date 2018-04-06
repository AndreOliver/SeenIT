SELECT
  g.Type,
  COUNT(g.Type),
  g.Id
FROM GenreTable AS g
  JOIN MovieGenreAssociationTable AS gma ON (gma.GenreId = g.Id)
  JOIN UserMovieAssociationTable AS uma ON (uma.MovieSeriesId = gma.MovieId)
WHERE uma.UserId = 2
GROUP BY g.Type, g.Id
HAVING COUNT(g.Type) > 0