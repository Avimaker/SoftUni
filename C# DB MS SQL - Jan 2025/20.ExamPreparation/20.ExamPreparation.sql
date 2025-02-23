CREATE DATABASE RailwaysDb
GO

USE RailwaysDb
GO

-- Таблица Passengers
CREATE TABLE Passengers (
    Id INT IDENTITY(1,1) PRIMARY KEY,  -- Unique table identification
    Name NVARCHAR(80) NOT NULL  -- Name of the passenger, Unicode, cannot be null
);
GO

-- Таблица Towns
CREATE TABLE Towns (
    Id INT IDENTITY(1,1) PRIMARY KEY,  -- Unique table identification
    Name NVARCHAR(30) NOT NULL  -- Name of the town, cannot be null
);
GO

-- Таблица RailwayStations
CREATE TABLE RailwayStations (
    Id INT IDENTITY(1,1) PRIMARY KEY,  -- Unique table identification
    Name NVARCHAR(50) NOT NULL,  -- Name of the railway station, cannot be null
    TownId INT NOT NULL,  -- Relationship with the Towns table
    CONSTRAINT FK_RailwayStations_Towns FOREIGN KEY (TownId) REFERENCES Towns(Id)  -- Foreign key constraint
);
GO

-- Таблица Trains
CREATE TABLE Trains (
    Id INT IDENTITY(1,1) PRIMARY KEY,  -- Unique table identification
    HourOfDeparture NVARCHAR(5) NOT NULL,  -- Time of departure, cannot be null
    HourOfArrival NVARCHAR(5) NOT NULL,  -- Time of arrival, cannot be null
    DepartureTownId INT NOT NULL,  -- Relationship with the Towns table for departure town
    ArrivalTownId INT NOT NULL,  -- Relationship with the Towns table for arrival town
    CONSTRAINT FK_Trains_DepartureTown FOREIGN KEY (DepartureTownId) REFERENCES Towns(Id),  -- Foreign key constraint for departure town
    CONSTRAINT FK_Trains_ArrivalTown FOREIGN KEY (ArrivalTownId) REFERENCES Towns(Id)  -- Foreign key constraint for arrival town
);
GO

-- Таблица TrainsRailwayStations
CREATE TABLE TrainsRailwayStations (
    TrainId INT NOT NULL,  -- Relationship with the Trains table
    RailwayStationId INT NOT NULL,  -- Relationship with the RailwayStations table
    PRIMARY KEY (TrainId, RailwayStationId),  -- Composite primary key
    CONSTRAINT FK_TrainsRailwayStations_Trains FOREIGN KEY (TrainId) REFERENCES Trains(Id),  -- Foreign key constraint for trains
    CONSTRAINT FK_TrainsRailwayStations_RailwayStations FOREIGN KEY (RailwayStationId) REFERENCES RailwayStations(Id)  -- Foreign key constraint for railway stations
);
GO

-- Таблица MaintenanceRecords
CREATE TABLE MaintenanceRecords (
    Id INT IDENTITY(1,1) PRIMARY KEY,  -- Unique table identification
    DateOfMaintenance DATE NOT NULL,  -- Date of maintenance, cannot be null
    Details NVARCHAR(2000) NOT NULL,  -- Maintenance details, cannot be null
    TrainId INT NOT NULL,  -- Relationship with the Trains table
    CONSTRAINT FK_MaintenanceRecords_Trains FOREIGN KEY (TrainId) REFERENCES Trains(Id)  -- Foreign key constraint for trains
);
GO

-- Таблица Tickets
CREATE TABLE Tickets (
    Id INT IDENTITY(1,1) PRIMARY KEY,  -- Unique table identification
    Price DECIMAL(18, 2) NOT NULL,  -- Ticket price with two decimal places, cannot be null
    DateOfDeparture DATE NOT NULL,  -- Date of departure, cannot be null
    DateOfArrival DATE NOT NULL,  -- Date of arrival, cannot be null
    TrainId INT NOT NULL,  -- Relationship with the Trains table
    PassengerId INT NOT NULL,  -- Relationship with the Passengers table
    CONSTRAINT FK_Tickets_Trains FOREIGN KEY (TrainId) REFERENCES Trains(Id),  -- Foreign key constraint for trains
    CONSTRAINT FK_Tickets_Passengers FOREIGN KEY (PassengerId) REFERENCES Passengers(Id)  -- Foreign key constraint for passengers
)


-- 02. Insert
INSERT INTO Trains (HourOfDeparture, HourOfArrival, DepartureTownId, ArrivalTownId)
VALUES
('07:00', '19:00', 1, 3),
('08:30', '20:30', 5, 6),
('09:00', '21:00', 4, 8),
('06:45', '03:55', 27, 7),
('10:15', '12:15', 15, 5);

INSERT INTO TrainsRailwayStations (TrainId, RailwayStationId)
VALUES
(36, 1),
(37, 60),
(39, 3),
(36, 4),
(37, 16),
(39, 31),
(36, 31),
(38, 10),
(39, 19),
(36, 57),
(38, 50),
(40, 41),
(36, 7),
(38, 52),
(40, 7),
(37, 13),
(38, 22),
(40, 52),
(37, 54),
(39, 68),
(40, 13);

INSERT INTO Tickets (Price, DateOfDeparture, DateOfArrival, TrainId, PassengerId)
VALUES
(90.00, '2023-12-01', '2023-12-01', 36, 1),
(115.00, '2023-08-02', '2023-08-02', 37, 2),
(160.00, '2023-08-03', '2023-08-03', 38, 3),
(255.00, '2023-09-01', '2023-09-02', 39, 21),
(95.00, '2023-09-02', '2023-09-03', 40, 22);

-- 03. Update
UPDATE Tickets
   SET 
       DateOfDeparture = DATEADD(DAY, 7, DateOfDeparture),
       DateOfArrival = DATEADD(DAY, 7, DateOfArrival)
 WHERE 
       DateOfDeparture > '2023-10-31';


-- 04. Delete
DELETE FROM MaintenanceRecords
WHERE TrainId IN (
    SELECT Id
    FROM Trains
    WHERE DepartureTownId = (SELECT Id FROM Towns WHERE Name = 'Berlin')
);


DELETE FROM Tickets
WHERE TrainId IN (
    SELECT Id
    FROM Trains
    WHERE DepartureTownId = (SELECT Id FROM Towns WHERE Name = 'Berlin')
);

DELETE FROM TrainsRailwayStations
WHERE TrainId IN (
    SELECT Id
    FROM Trains
    WHERE DepartureTownId = (SELECT Id FROM Towns WHERE Name = 'Berlin')
);

DELETE FROM Trains
WHERE DepartureTownId = (SELECT Id FROM Towns WHERE Name = 'Berlin');




-- 05. Tickets by Price and Date Departure
  SELECT DateOfDeparture, 
         Price 
      AS TicketPrice
    FROM 
         Tickets
ORDER BY 
         Price,  -- Подреждане по цена (възходящо)
         DateOfDeparture DESC  -- Подреждане по дата на заминаване (низходящо)

-- 06. Passengers with their Tickets

SELECT 
         p.Name AS PassengerName,  -- Името на пътника
         t.Price AS TicketPrice,  -- Цена на билета
         t.DateOfDeparture,  -- Дата на заминаване
         t.TrainId  -- Идентификатор на влака
    FROM 
         Tickets t
    JOIN 
         Passengers p 
      ON t.PassengerId = p.Id  -- Свързване на таблиците Tickets и Passengers по идентификатор на пътника
ORDER BY 
         t.Price DESC,  -- Подреждане по цена на билета (възходящо)
         p.Name  -- Ако цените са еднакви, подреждаме по името на пътника (азбучно)


-- 07. Railway Stations without Passing Trains

   SELECT 
          t.Name 
       AS Town,  -- Името на града
          rs.Name 
       AS RailwayStation  -- Името на железопътната станция
     FROM 
          RailwayStations rs
LEFT JOIN 
          TrainsRailwayStations trs ON rs.Id = trs.RailwayStationId  -- Ляво свързване със станциите, през които преминават влакове
     JOIN 
          Towns t ON rs.TownId = t.Id  -- Свързване със таблицата Towns за да получим името на града
    WHERE 
          trs.TrainId IS NULL  -- Избиране само на тези станции, които нямат свързани влакове
 ORDER BY 
          t.Name,  -- Подреждане по името на града (възходящо)
          rs.Name  -- Подреждане по името на станцията (възходящо)


-- 08. First 3 Trains Between 08:00 and 08:59


SELECT TOP 3
         t.Id AS TrainId,  -- Идентификатор на влака
         t.HourOfDeparture,  -- Час на заминаване
         ti.Price AS TicketPrice,  -- Цена на билета
         a.Name AS Destination  -- Името на дестинацията (пристигналия град)
    FROM 
         Trains t
    JOIN 
         Tickets ti ON t.Id = ti.TrainId  -- Свързване на влаковете с билетите
    JOIN 
         Towns a ON t.ArrivalTownId = a.Id  -- Свързване с града на пристигане (за дестинацията)
   WHERE 
         t.HourOfDeparture BETWEEN '08:00' AND '08:59'  -- Час на заминаване между 08:00 и 08:59
     AND ti.Price > 50.00  -- Цена на билета над 50 евро
ORDER BY 
         ti.Price ASC;  -- Подреждаме по цена на билета (възходящо)
          

-- 09. Count of Passengers Paid More Than Average

  SELECT 
         t.Name AS TownName,  -- Името на града на пристигане
         COUNT(ti.PassengerId) AS PassengersCount  -- Броя на пътниците, които са платили повече от 76.99
    FROM 
         Tickets ti
    JOIN 
         Passengers p ON ti.PassengerId = p.Id  -- Свързваме билетите със съответния пътник
    JOIN 
         Trains tr ON ti.TrainId = tr.Id  -- Свързваме билетите с влаковете
    JOIN 
         Towns t ON tr.ArrivalTownId = t.Id  -- Свързваме влаковете с пристигащия град
   WHERE 
         ti.Price > 76.99  -- Избиране на тези билети, които са над средната цена
GROUP BY 
         t.Name  -- Групиране по името на града на пристигане
ORDER BY 
         TownName  -- Подреждане по името на града в възходящ ред

-- 10. Maintenance Inspection with Town and Station
  SELECT 
         tr.Id AS TrainID,  -- Идентификатор на влака
         dep.Name AS DepartureTown,  -- Името на града на отпътуване
         mr.Details  -- Описание на поддръжката, което включва думата "inspection"
    FROM 
         MaintenanceRecords mr
    JOIN 
         Trains tr ON mr.TrainId = tr.Id  -- Свързваме записи на поддръжка с влаковете
    JOIN 
         Towns dep ON tr.DepartureTownId = dep.Id  -- Свързваме влаковете с техния град на отпътуване
   WHERE 
         mr.Details LIKE '%inspection%'  -- Филтрираме само записи, които съдържат думата "inspection"
ORDER BY 
         tr.Id  -- Подреждаме по идентификатор на влака


-- 11. Towns with Trains

CREATE FUNCTION dbo.udf_TownsWithTrains(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
    DECLARE @trainCount INT;

    -- Изчисляваме броя на влаковете, които тръгват или пристигат в града
    SELECT @trainCount = COUNT(*)
      FROM Trains t
      JOIN Towns dep ON t.DepartureTownId = dep.Id  -- Свързваме влаковете с града на отпътуване
      JOIN Towns arr ON t.ArrivalTownId = arr.Id   -- Свързваме влаковете с града на пристигане
     WHERE dep.Name = @name OR arr.Name = @name;  -- Търсим влаковете, които имат даден град

    RETURN @trainCount;
END

SELECT dbo.udf_TownsWithTrains('Paris')


CREATE FUNCTION dbo.udf_TownsWithTrains(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
    DECLARE @trainCount INT;

    SELECT @trainCount = COUNT(*)
      FROM Trains t
      JOIN Towns dep 
        ON t.DepartureTownId = dep.Id  
      JOIN Towns arr 
        ON t.ArrivalTownId = arr.Id   
     WHERE dep.Name = @name 
        OR arr.Name = @name;  

    RETURN @trainCount;
END


-- 12. Search Passengers travelling to Specific Town

CREATE PROCEDURE usp_SearchByTown (@townName NVARCHAR(30))
AS
BEGIN
      SELECT 
             p.Name AS PassengerName,  -- Име на пътника
             ti.DateOfDeparture,  -- Дата на отпътуване
             tr.HourOfDeparture  -- Час на отпътуване
        FROM 
             Tickets ti
        JOIN 
             Passengers p ON ti.PassengerId = p.Id  -- Свързваме билетите с пътниците
        JOIN 
             Trains tr ON ti.TrainId = tr.Id  -- Свързваме билетите с влаковете
        JOIN 
             Towns t ON tr.ArrivalTownId = t.Id  -- Свързваме влаковете с техния пристигащ град
       WHERE 
             t.Name = @townName  -- Филтрираме по името на града
    ORDER BY 
             ti.DateOfDeparture DESC,  -- Подреждаме по дата на отпътуване (низходящо)
             p.Name ASC;  -- Подреждаме по име на пътника (възходящо)
END

EXEC usp_SearchByTown 'Berlin'