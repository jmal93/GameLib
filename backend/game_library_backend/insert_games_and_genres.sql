DELETE FROM Games;
DELETE FROM Genres;
DELETE FROM GameGenres;

DBCC CHECKIDENT ('Games', RESEED, 0);
DBCC CHECKIDENT ('Genres', RESEED, 0);

INSERT INTO Games (Name, Developer, ReleaseDate, Price) VALUES
('Battlefield 4', 'DICE', '2013-10-29', 39.99),
('Civilization VI', 'Firaxis Games', '2016-10-21', 59.99),
('Cyberpunk 2077', 'CD Projekt Red', '2020-12-10', 59.99),
('FIFA 23', 'EA', '2022-09-23', 69.99),
('Guitar Hero 3', 'Neversoft', '2007-10-28', 24.99),
('Hearts of Iron IV', 'Paradox', '2016-06-06', 49.99),
('Hollow Knight', 'Team Cherry', '2017-02-24', 14.99),
('Mortal Kombat 1', 'NetherRealm', '2023-09-19', 49.99),
('Portal', 'Valve', '2007-10-09', 9.99),
('Red Dead Redemption 2', 'Rockstar', '2018-10-26', 59.99),
('Sifu', 'Sloclap', '2022-02-08', 39.99),
('Silent Hill 2', 'Konami', '2001-09-21', 69.99),
('Undertale', 'Toby Fox', '2015-09-15', 9.99);

INSERT INTO Genres (Name) VALUES
('Action'),
('Adventure'),
('Fighting'),
('FPS'),
('Horror'),
('Metroidvania'),
('Music'),
('Puzzle'),
('RPG'),
('Sports'),
('Strategy');

INSERT INTO GameGenres (GameId, GenreId)
SELECT g.Id, ge.Id
FROM (VALUES
    ('Battlefield 4', 'Action'),
    ('Battlefield 4', 'FPS'),
    ('Civilization', 'Strategy'),
    ('Cyberpunk 2077', 'Action'),
    ('Cyberpunk 2077', 'FPS'),
    ('Cyberpunk 2077', 'RPG'),
    ('FIFA 23', 'Sports'),
    ('Guitar Hero 3', 'Music'),
    ('Hearts of Iron IV', 'Strategy'),
    ('Hollow Knight', 'Metroidvania'),
    ('Hollow Knight', 'Adventure'),
    ('Mortal Kombat 1', 'Fighting'),
    ('Portal', 'Puzzle'),
    ('Red Dead Redemption 2', 'Adventure'),
    ('Red Dead Redemption 2', 'Action'),
    ('Sifu', 'Fighting'),
    ('Sifu', 'Action'),
    ('Silent Hill 2', 'Horror'),
    ('Undertale', 'Adventure'),
    ('Undertale', 'Puzzle')
) AS Associations(GameName, GenreName)
CROSS APPLY (SELECT Id FROM Games WHERE Name = GameName) AS g
CROSS APPLY (SELECT Id FROM Genres WHERE Name = GenreName) AS ge;

SELECT Games.Name AS "Game", Genres.Name AS "Genres" FROM Games
JOIN GameGenres ON Games.Id = GameGenres.GameId
JOIN Genres ON Genres.Id = GameGenres.GenreId
ORDER BY Games.Name;