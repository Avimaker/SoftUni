USE [Master]
GO

CREATE DATABASE EuroLeagues
GO

USE EuroLeagues
GO

-- 01.DDL

CREATE TABLE Leagues (
    Id INT IDENTITY PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Teams (
    Id INT IDENTITY(1, 1) PRIMARY KEY,
    [Name] NVARCHAR(50) UNIQUE NOT NULL,
    City NVARCHAR(50) NOT NULL,
    LeagueId INT FOREIGN KEY REFERENCES Leagues(Id) NOT NULL
)

CREATE TABLE Players (
    Id INT IDENTITY(1, 1) PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    Position NVARCHAR(20) NOT NULL
)

CREATE TABLE Matches (
    Id INT IDENTITY(1, 1) PRIMARY KEY,
    HomeTeamId INT FOREIGN KEY REFERENCES Teams(Id) NOT NULL,
    AwayTeamId INT FOREIGN KEY REFERENCES Teams(Id) NOT NULL,
    MatchDate DATETIME2 NOT NULL,
    HomeTeamGoals INT NOT NULL DEFAULT 0,
    AwayTeamGoals INT NOT NULL DEFAULT 0,
    LeagueId INT FOREIGN KEY REFERENCES Leagues(Id) NOT NULL
)

CREATE TABLE PlayersTeams (
    PlayerId INT FOREIGN KEY REFERENCES Players(Id) NOT NULL,
    TeamId INT FOREIGN KEY REFERENCES Teams(Id) NOT NULL,
    PRIMARY KEY (PlayerId, TeamId)
)

CREATE TABLE PlayerStats (
    PlayerId INT PRIMARY KEY,
    Goals INT NOT NULL DEFAULT 0,
    Assists INT NOT NULL DEFAULT 0,
    FOREIGN KEY (PlayerId) REFERENCES Players(Id)
)

CREATE TABLE TeamStats (
    TeamId INT PRIMARY KEY,
    Wins INT NOT NULL DEFAULT 0,
    Draws INT NOT NULL DEFAULT 0,
    Losses INT NOT NULL DEFAULT 0,
    FOREIGN KEY (TeamId) REFERENCES Teams(Id)
)

-- 02. Insert

INSERT INTO Leagues (Name)
VALUES 
('Eredivisie')

INSERT INTO Teams (Name, City, LeagueId)
VALUES 
('PSV', 'Eindhoven', 6),
('Ajax', 'Amsterdam', 6)

INSERT INTO Players (Name, Position)
VALUES
('Luuk de Jong', 'Forward'),
('Josip Sutalo', 'Defender')

INSERT INTO Matches (HomeTeamId, AwayTeamId, MatchDate, HomeTeamGoals, AwayTeamGoals, LeagueId)
VALUES
(98, 97, '2024-11-02 20:45:00', 3, 2, 6)

INSERT INTO PlayersTeams (PlayerId, TeamId)
VALUES
(2305, 97),
(2306, 98)

INSERT INTO PlayerStats (PlayerId, Goals, Assists)
VALUES
(2305, 2, 0),
(2306, 2, 0)

INSERT INTO TeamStats (TeamId, Wins, Draws, Losses)
VALUES
(97, 15, 1, 3),
(98, 14, 3, 2)


-- 03. Update

-- Актуализиране на статистиката на нападателите в Ла Лига
 UPDATE ps
    SET ps.Goals = ps.Goals + 1
   FROM PlayerStats ps
   JOIN Players p 
     ON ps.PlayerId = p.Id
   JOIN PlayersTeams pt 
     ON p.Id = pt.PlayerId
   JOIN Teams t 
     ON pt.TeamId = t.Id
   JOIN Leagues l 
     ON t.LeagueId = l.Id
  WHERE p.Position = 'Forward' 
    AND l.Name = 'La Liga'



-- 04. Delete

DELETE ps
  FROM PlayerStats ps
  JOIN Players p 
    ON ps.PlayerId = p.Id
  JOIN PlayersTeams pt 
    ON p.Id = pt.PlayerId
  JOIN Teams t 
    ON pt.TeamId = t.Id
  JOIN Leagues l 
    ON t.LeagueId = l.Id
 WHERE l.Name = 'Eredivisie' 
   AND p.Name IN ('Luuk de Jong', 'Josip Sutalo')
  

DELETE pt
  FROM PlayersTeams pt
  JOIN Players p 
    ON pt.PlayerId = p.Id
  JOIN Teams t 
    ON pt.TeamId = t.Id
  JOIN Leagues l 
    ON t.LeagueId = l.Id
 WHERE l.Name = 'Eredivisie' 
   AND p.Name IN ('Luuk de Jong', 'Josip Sutalo')
 

DELETE p
  FROM Players p
  JOIN Teams t 
    ON p.Id = t.Id
  JOIN Leagues l 
    ON t.LeagueId = l.Id
 WHERE l.Name = 'Eredivisie' 
   AND p.Name IN ('Luuk de Jong', 'Josip Sutalo')



-- 05. Matches by Goals and Date

  SELECT 
         FORMAT(MatchDate, 'yyyy-MM-dd')
      AS MatchDate,
         HomeTeamGoals,
         AwayTeamGoals,
         (HomeTeamGoals + AwayTeamGoals)
      AS TotalGoals
    FROM Matches
   WHERE (HomeTeamGoals + AwayTeamGoals) >= 5
ORDER BY TotalGoals DESC, MatchDate

-- 06. Players with Common Part in Their Names

  SELECT 
         p.Name,
         t.City
    FROM Players p
    JOIN PlayersTeams pt 
      ON p.Id = pt.PlayerId
    JOIN Teams t 
      ON pt.TeamId = t.Id
   WHERE p.Name LIKE '%Aaron%'
ORDER BY p.Name


-- 07. Players in Teams Situated in London

  SELECT 
         p.Id,
         p.Name,
         p.Position
    FROM Players p
    JOIN PlayersTeams pt 
      ON p.Id = pt.PlayerId
    JOIN Teams t 
      ON pt.TeamId = t.Id
   WHERE t.City = 'London'
ORDER BY p.Name


-- 08. First 10 Matches in Early September

SELECT TOP 10
         ht.Name
      AS HomeTeamName,
         at.Name
      AS AwayTeamName,
         l.Name
      AS LeagueName,
         FORMAT(m.MatchDate, 'yyyy-MM-dd') 
      AS MatchDate
    FROM Matches m
    JOIN Teams ht 
      ON m.HomeTeamId = ht.Id
    JOIN Teams at 
      ON m.AwayTeamId = at.Id
    JOIN Leagues l 
      ON m.LeagueId = l.Id
   WHERE m.MatchDate BETWEEN '2024-09-01' AND '2024-09-15'
     AND l.Id % 2 = 0
ORDER BY m.MatchDate, ht.Name


-- 09. BestGuestTeams

  SELECT 
         t.Id,
         t.Name,
         SUM(m.AwayTeamGoals) 
      AS TotalAwayGoals
    FROM Matches m
    JOIN Teams t 
      ON m.AwayTeamId = t.Id
GROUP BY t.Id, t.Name
  HAVING SUM(m.AwayTeamGoals) >= 6
ORDER BY TotalAwayGoals DESC, t.Name


-- 10. Average Scoring Rate *

  SELECT 
         l.Name 
      AS LeagueName,
         ROUND(CAST(SUM(m.HomeTeamGoals + m.AwayTeamGoals) AS FLOAT) / COUNT(m.Id), 2) 
      AS AvgScoringRate
    FROM Matches m
    JOIN Leagues l 
      ON m.LeagueId = l.Id
GROUP BY l.Name
ORDER BY AvgScoringRate DESC



-- 11. League Top Scorrer
-- ver 1

CREATE FUNCTION udf_LeagueTopScorer (@LeagueName NVARCHAR(50))
RETURNS TABLE
AS
RETURN (
           SELECT TOP 1 WITH TIES -- *
                  p.Name 
               AS PlayerName,
                  ps.Goals
               AS TotalGoals
             FROM PlayerStats ps
             JOIN Players p 
               ON ps.PlayerId = p.Id
             JOIN PlayersTeams pt 
               ON p.Id = pt.PlayerId
             JOIN Teams t 
               ON pt.TeamId = t.Id
             JOIN Leagues l 
               ON t.LeagueId = l.Id
            WHERE l.Name = @LeagueName
         ORDER BY ps.Goals DESC
)

-- * В SELECT TOP 1 WITH TIES ключовата дума WITH TIES гарантира, 
-- че ако има повече от един запис със същата стойност в колоната, 
-- по която се подрежда (ORDER BY), всички такива записи ще бъдат 
-- включени в резултата, дори ако надхвърлят лимита, зададен от TOP.



-- ver 2

CREATE FUNCTION dbo.udf_LeagueTopScorer (@LeagueName NVARCHAR(50))
RETURNS TABLE
AS
RETURN
(
    -- Извличаме играчите с най-много голове от дадената лига
      WITH TopScorer AS (
                 SELECT 
                        p.Name
                     AS PlayerName, 
                        ps.Goals
                     AS TotalGoals
                   FROM PlayerStats ps
                   JOIN Players p 
                     ON ps.PlayerId = p.Id
                   JOIN PlayersTeams pt 
                     ON p.Id = pt.PlayerId
                   JOIN Teams t 
                     ON pt.TeamId = t.Id
                   JOIN Leagues l 
                     ON t.LeagueId = l.Id
                  WHERE l.Name = @LeagueName
             )
    -- Връщаме тези играчи, които имат най-много голове
    SELECT PlayerName, TotalGoals
      FROM TopScorer
     WHERE TotalGoals = (SELECT MAX(TotalGoals) FROM TopScorer)
)


-- SELECT * FROM dbo.udf_LeagueTopScorer('Serie A')


-- 12. Search for Teams from a Specific City
CREATE PROCEDURE usp_SearchTeamsByCity 
    @City NVARCHAR(50)
AS
BEGIN
      SELECT 
             t.Name 
          AS TeamName,
             l.Name
          AS LeagueName,
             t.City
        FROM Teams t
        JOIN Leagues l 
          ON t.LeagueId = l.Id
       WHERE t.City = @City
    ORDER BY t.Name
END

-- EXEC usp_SearchTeamsByCity 'London'


