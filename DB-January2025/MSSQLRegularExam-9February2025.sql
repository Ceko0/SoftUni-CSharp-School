CREATE DATABASE EuroLeagues

GO

USE EuroLeagues

GO
--1.Database design

CREATE TABLE Leagues (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Teams (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL UNIQUE,
    City NVARCHAR(50) NOT NULL,
    LeagueId INT NOT NULL,
    FOREIGN KEY (LeagueId) REFERENCES Leagues(Id) ON DELETE NO ACTION
)

CREATE TABLE Players (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Position NVARCHAR(20) NOT NULL
)

CREATE TABLE Matches (
    Id INT PRIMARY KEY IDENTITY(1,1),
    HomeTeamId INT NOT NULL,
    AwayTeamId INT NOT NULL,
    MatchDate DATETIME2 NOT NULL,
    HomeTeamGoals INT NOT NULL DEFAULT 0,
    AwayTeamGoals INT NOT NULL DEFAULT 0,
    LeagueId INT NOT NULL,
    FOREIGN KEY (HomeTeamId) REFERENCES Teams(Id) ON DELETE NO ACTION,
    FOREIGN KEY (AwayTeamId) REFERENCES Teams(Id) ON DELETE NO ACTION,
    FOREIGN KEY (LeagueId) REFERENCES Leagues(Id) ON DELETE NO ACTION
)

CREATE TABLE PlayersTeams (
    PlayerId INT NOT NULL,
    TeamId INT NOT NULL,
    PRIMARY KEY (PlayerId, TeamId),
    FOREIGN KEY (PlayerId) REFERENCES Players(Id) ON DELETE NO ACTION,
    FOREIGN KEY (TeamId) REFERENCES Teams(Id) ON DELETE NO ACTION
)

CREATE TABLE PlayerStats (
    PlayerId INT PRIMARY KEY,
    Goals INT NOT NULL DEFAULT 0,
    Assists INT NOT NULL DEFAULT 0,
    FOREIGN KEY (PlayerId) REFERENCES Players(Id) ON DELETE NO ACTION
)

CREATE TABLE TeamStats (
    TeamId INT PRIMARY KEY,
    Wins INT NOT NULL DEFAULT 0,
    Draws INT NOT NULL DEFAULT 0,
    Losses INT NOT NULL DEFAULT 0,
    FOREIGN KEY (TeamId) REFERENCES Teams(Id) ON DELETE NO ACTION
)

--2.Insert

INSERT INTO Leagues ([Name]) 
     VALUES ('Eredivisie')

INSERT INTO Teams ([Name], City, LeagueId)
     VALUES ('PSV', 'Eindhoven', 6),
            ('Ajax', 'Amsterdam', 6)

INSERT INTO Players ([Name] , Position)
     VALUES ('Luuk de Jong','Forward'),
            ('Josip Sutalo','Defender')

INSERT INTO Matches (HomeTeamId,AwayTeamId,MatchDate,HomeTeamGoals,AwayTeamGoals,LeagueId)
     VALUES (98,97,'2024-11-02 20:45:00',3,2,6)

INSERT INTO PlayersTeams (PlayerId, TeamId) 
     VALUES (2305, 97),
            (2306, 98)

INSERT INTO PlayerStats (PlayerId, Goals, Assists) 
     VALUES (2305, 2, 0),
            (2306, 2, 0)

INSERT INTO TeamStats (TeamId, Wins, Draws, Losses) 
     VALUES (97, 15, 1, 3),
            (98, 14, 3, 2)


--3.Update

UPDATE ps
   SET ps.Goals = ps.Goals + 1
  FROM PlayerStats ps
  JOIN Players p ON ps.PlayerId = p.Id
  JOIN PlayersTeams pt ON pt.PlayerId = p.Id
  JOIN Teams t ON pt.TeamId = t.Id
  JOIN Leagues l ON t.LeagueId = l.Id
 WHERE p.Position = 'Forward' 
   AND l.Name = 'La Liga'

--4.Delete

DELETE FROM PlayersTeams
WHERE PlayerId IN (
    SELECT p.Id
    FROM Players p
    JOIN Teams t ON PlayersTeams.TeamId = t.Id
    JOIN Leagues l ON t.LeagueId = l.Id
    WHERE (p.Name = 'Luuk de Jong' OR p.Name = 'Josip Sutalo')
    AND l.Name = 'Eredivisie'
)

DELETE FROM PlayerStats
WHERE PlayerId IN (
    SELECT p.Id
    FROM Players p
	JOIN PlayersTeams pt ON PlayerId = p.Id
    JOIN Teams t ON pt.TeamId = t.Id
    JOIN Leagues l ON t.LeagueId = l.Id
    WHERE (p.Name = 'Luuk de Jong' OR p.Name = 'Josip Sutalo')
    AND l.Name = 'Eredivisie'
)

DELETE FROM Players
WHERE (Name = 'Luuk de Jong' OR Name = 'Josip Sutalo')
AND Id IN (
    SELECT p.Id
    FROM Players p
	JOIN PlayersTeams pt ON PlayerId =p.Id
    JOIN Teams t ON pt.TeamId = t.Id
    JOIN Leagues l ON t.LeagueId = l.Id
    WHERE l.Name = 'Eredivisie'
)

--5.Matches by Goals and Date

  SELECT 
         CONVERT(VARCHAR(10), MatchDate, 23) AS FormattedDate,
         HomeTeamGoals,
         AwayTeamGoals,
         (HomeTeamGoals + AwayTeamGoals) AS TotalGoals
    FROM Matches
   WHERE (HomeTeamGoals + AwayTeamGoals) >= 5
ORDER BY TotalGoals DESC,
         MatchDate

--6.Players with Common Part in Their Names

  SELECT 
         p.Name, 
         t.City
    FROM Players p
    JOIN PlayersTeams pt ON p.Id = pt.PlayerId
    JOIN Teams t ON pt.TeamId = t.Id
   WHERE p.Name LIKE '%Aaron%'
ORDER BY p.Name ASC

--7.Players in Teams Situated in London

  SELECT 
         p.Id,
  	   p.Name,
  	   p.Position
    FROM Players p
    JOIN PlayersTeams pt ON pt.PlayerId = p.Id
    JOIN Teams t ON t.Id = pt.TeamId
   WHERE City = 'London'
ORDER BY p.Name

--8.First 10 Matches in Early September

  SELECT
     TOP 10
         ht.Name AS HomeTeamName,
         t.Name AS AwayTeamName,
         l.Name AS LeagueName,
         CONVERT(VARCHAR(10), m.MatchDate, 23) AS MatchDate
    FROM Matches m
    JOIN Teams ht ON m.HomeTeamId = ht.Id
    JOIN Teams t ON m.AwayTeamId = t.Id
    JOIN Leagues l ON m.LeagueId = l.Id
   WHERE m.MatchDate BETWEEN '2024-09-01' AND '2024-09-15'
     AND l.Id % 2 = 0 
ORDER BY m.MatchDate ASC, ht.Name ASC

--9.Best Guest Teams

  SELECT 
         t.Id,
  	     t.Name,
         SUM(m.AwayTeamGoals) AS TotalAwayGoals
    FROM Teams t
    JOIN Matches M ON AwayTeamId = t.Id
GROUP BY t.Id, t.Name
  HAVING SUM(m.AwayTeamGoals) >= 6
ORDER BY TotalAwayGoals DESC, t.Name ASC

--10.Average Scoring Rate

  SELECT 
         l.Name AS LeagueName,
         ROUND(CAST(SUM(m.HomeTeamGoals + m.AwayTeamGoals) AS FLOAT) / COUNT(m.Id), 2) AS AvgScoringRate
    FROM Leagues l
    JOIN Matches m ON m.LeagueId = l.Id
GROUP BY l.Name
ORDER BY AvgScoringRate DESC

--11.League Top Scorrer

CREATE FUNCTION dbo.udf_LeagueTopScorer (@LeagueName NVARCHAR(50))
RETURNS @Result TABLE
(
    PlayerName NVARCHAR(100),
    TotalGoals INT
)
AS
BEGIN
    ;WITH Scorers AS (
        SELECT 
            p.Id AS PlayerId,
            p.Name AS PlayerName,
            SUM(ps.Goals) AS TotalGoals
        FROM Players p
        JOIN PlayersTeams pt ON pt.PlayerId = p.Id
        JOIN Teams t ON pt.TeamId = t.Id
        JOIN Leagues l ON t.LeagueId = l.Id
        LEFT JOIN PlayerStats ps ON p.Id = ps.PlayerId
        WHERE l.Name = @LeagueName
        GROUP BY p.Id, p.Name
    ),
    MaxGoals AS (
        SELECT MAX(TotalGoals) AS MaxGoals
        FROM Scorers
    )
    INSERT INTO @Result
    SELECT 
        s.PlayerName,
        s.TotalGoals
    FROM Scorers s
    JOIN MaxGoals m ON s.TotalGoals = m.MaxGoals
    ORDER BY s.PlayerId;

    RETURN
END

--12.Search for Teams from a Specific City

CREATE PROCEDURE usp_SearchTeamsByCity
                 @CityName NVARCHAR(100)
              AS
           BEGIN
          SELECT 
                 t.Name AS TeamName,
                 l.Name AS LeagueName,
                 t.City
            FROM Teams t
            JOIN Leagues l ON t.LeagueId = l.Id
           WHERE t.City = @CityName
        ORDER BY t.Name ASC;
             END
