CREATE DATABASE TouristAgency
GO

USE TouristAgency
GO

-- Създаване на таблица Countries
CREATE TABLE Countries (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);
GO

-- Създаване на таблица Destinations
CREATE TABLE Destinations (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    CountryId INT NOT NULL,
    CONSTRAINT FK_Destinations_Countries FOREIGN KEY (CountryId) REFERENCES Countries(Id)
);
GO

-- Създаване на таблица Rooms
CREATE TABLE Rooms (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Type VARCHAR(40) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    BedCount INT NOT NULL CHECK (BedCount > 0 AND BedCount <= 10)
);
GO

-- Създаване на таблица Hotels
CREATE TABLE Hotels (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    DestinationId INT NOT NULL FOREIGN KEY REFERENCES Destinations(Id)
);
GO

-- Създаване на таблица Tourists
CREATE TABLE Tourists (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(80) NOT NULL,
    PhoneNumber VARCHAR(20) NOT NULL,
    Email VARCHAR(80) NULL,
    CountryId INT NOT NULL FOREIGN KEY REFERENCES Countries(Id)
);
GO

-- Създаване на таблица Bookings
CREATE TABLE Bookings (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ArrivalDate DATETIME2 NOT NULL,
    DepartureDate DATETIME2 NOT NULL,
    AdultsCount INT NOT NULL CHECK (AdultsCount >= 1 AND AdultsCount <= 10),
    ChildrenCount INT NOT NULL CHECK (ChildrenCount >= 0 AND ChildrenCount <= 9),
    TouristId INT NOT NULL FOREIGN KEY REFERENCES Tourists(Id),
    HotelId INT NOT NULL FOREIGN KEY REFERENCES Hotels(Id),
    RoomId INT NOT NULL FOREIGN KEY REFERENCES Rooms(Id)
);
GO

-- Създаване на таблица HotelsRooms
CREATE TABLE HotelsRooms (
    HotelId INT NOT NULL,
    RoomId INT NOT NULL,
    CONSTRAINT PK_HotelsRooms PRIMARY KEY (HotelId, RoomId),
    CONSTRAINT FK_HotelsRooms_Hotels FOREIGN KEY (HotelId) REFERENCES Hotels(Id),
    CONSTRAINT FK_HotelsRooms_Rooms FOREIGN KEY (RoomId) REFERENCES Rooms(Id)
);
GO

-- 02. Insert

INSERT INTO Tourists (Name, PhoneNumber, Email, CountryId)
VALUES
    ('John Rivers', '653-551-1555', 'john.rivers@example.com', 6),
    ('Adeline Aglaé', '122-654-8726', 'adeline.aglae@example.com', 2),
    ('Sergio Ramirez', '233-465-2876', 's.ramirez@example.com', 3),
    ('Johan Müller', '322-876-9826', 'j.muller@example.com', 7),
    ('Eden Smith', '551-874-2234', 'eden.smith@example.com', 6);

INSERT INTO Bookings (ArrivalDate, DepartureDate, AdultsCount, ChildrenCount, TouristId, HotelId, RoomId)
VALUES
    ('2024-03-01', '2024-03-11', 1, 0, 21, 3, 5),
    ('2023-12-28', '2024-01-06', 2, 1, 22, 13, 3),
    ('2023-11-15', '2023-11-20', 1, 2, 23, 19, 7),
    ('2023-12-05', '2023-12-09', 4, 0, 24, 6, 4),
    ('2024-05-01', '2024-05-07', 6, 0, 25, 14, 6);


-- 03. Update

UPDATE Bookings
SET DepartureDate = DATEADD(day, 1, DepartureDate) -- Добавяме 1 ден към DepartureDate
WHERE ArrivalDate >= '2023-12-01' AND ArrivalDate < '2024-01-01'; -- Филтрираме резервациите през декември 2023

UPDATE Tourists
SET Email = NULL -- Задаваме имейла на NULL
WHERE Name LIKE '%MA%'; -- Филтрираме туристите, чиито имена съдържат "MA"


-- 04. Delete

DELETE FROM Bookings
WHERE TouristId IN (
    SELECT Id FROM Tourists WHERE Name LIKE '%Smith%'
);

DELETE FROM Tourists
WHERE Name LIKE '%Smith%';


-- 05. Bookings by Price of Room and Arrival Date

SELECT
    FORMAT(b.ArrivalDate, 'yyyy-MM-dd') AS ArrivalDate,
    b.AdultsCount,
    b.ChildrenCount
FROM
    Bookings b
JOIN
    Rooms r ON b.RoomId = r.Id
ORDER BY
    r.Price DESC, -- Сортиране по цена на стаята (низходящо)
    b.ArrivalDate ASC; -- Сортиране по дата на пристигане (възходящо)


-- 06. Hotels by Count of Bookings
  SELECT
         h.Id,
         h.Name
    FROM
         Hotels h
    JOIN
         HotelsRooms hr ON h.Id = hr.HotelId
    JOIN
         Rooms r ON hr.RoomId = r.Id
    JOIN
         Bookings b ON h.Id = b.HotelId
   WHERE
         r.Type = 'VIP Apartment'
GROUP BY
         h.Id, h.Name
ORDER BY
         COUNT(b.id) DESC

-- 07. Tourists without Bookings
   SELECT
          t.Id,
          t.Name,
          t.PhoneNumber
     FROM
          Tourists t
LEFT JOIN
          Bookings b ON t.Id = b.TouristId -- Свързваме туристите с резервациите
    WHERE
          b.TouristId IS NULL -- Филтрираме туристите без резервации
 ORDER BY
          t.Name ASC; -- Сортиране по име (възходящо)


-- 08. First 10 Bookings
  SELECT TOP 10
         h.Name AS HotelName,
         d.Name AS DestinationName,
         c.Name AS CountryName
    FROM
         Bookings b
    JOIN
         Hotels h ON b.HotelId = h.Id -- Свързваме резервациите с хотелите
    JOIN
         Destinations d ON h.DestinationId = d.Id -- Свързваме хотелите с дестинациите
    JOIN
         Countries c ON d.CountryId = c.Id -- Свързваме дестинациите с държавите
   WHERE
         b.ArrivalDate < '2023-12-31' -- Филтрираме резервациите, които пристигат преди 31 декември 2023
     AND h.Id % 2 = 1 -- Филтрираме хотелите с нечетни ID
ORDER BY
         c.Name ASC, -- Сортиране по име на държава (възходящо)
         b.ArrivalDate ASC; -- Сортиране по дата на пристигане (възходящо)


-- 09. Tourists booked in Hotels
SELECT
    h.Name AS HotelName,
    r.Price AS RoomPrice
FROM
    Tourists t
JOIN
    Bookings b ON t.Id = b.TouristId -- Свързваме туристите с резервациите
JOIN
    Hotels h ON b.HotelId = h.Id -- Свързваме резервациите с хотелите
JOIN
    Rooms r ON b.RoomId = r.Id -- Свързваме резервациите със стаите
WHERE
    t.Name NOT LIKE '%EZ' -- Филтрираме туристите, чиито имена не завършват на "EZ"
ORDER BY
    r.Price DESC; -- Сортиране по цена на стаята (низходящо)


-- 10. Hotels Revenue
SELECT
    h.Name AS HotelName,
    SUM(r.Price * DATEDIFF(day, b.ArrivalDate, b.DepartureDate)) AS TotalRevenue
FROM
    Bookings b
JOIN
    Hotels h ON b.HotelId = h.Id -- Свързваме резервациите с хотелите
JOIN
    Rooms r ON b.RoomId = r.Id -- Свързваме резервациите със стаите
GROUP BY
    h.Name -- Групираме по име на хотел
ORDER BY
    TotalRevenue DESC; -- Сортиране по общи приходи (низходящо)




-- 11. Rooms with Tourists
CREATE FUNCTION udf_RoomsWithTourists(@name VARCHAR(40))
RETURNS INT
AS
BEGIN
    DECLARE @totalTourists INT;

    SELECT
        @totalTourists = SUM(b.AdultsCount + b.ChildrenCount) -- Сумираме броя на възрастните и децата
    FROM
        Bookings b
    JOIN
        Rooms r ON b.RoomId = r.Id -- Свързваме резервациите със стаите
    WHERE
        r.Type = @name; -- Филтрираме само резервациите за конкретния тип стая

    RETURN ISNULL(@totalTourists, 0); -- Ако няма резервации, връщаме 0
END;


-- 12. Search for Tourists from a Specific Country
CREATE PROCEDURE usp_SearchByCountry
    @country NVARCHAR(50)
AS
BEGIN
    SELECT
        t.Name,
        t.PhoneNumber,
        t.Email,
        COUNT(b.Id) AS CountOfBookings -- Брой резервации за всеки турист
    FROM
        Tourists t
    JOIN
        Countries c ON t.CountryId = c.Id -- Свързваме туристите с държавите
    LEFT JOIN
        Bookings b ON t.Id = b.TouristId -- Свързваме туристите с резервациите
    WHERE
        c.Name = @country -- Филтрираме туристите от дадената държава
    GROUP BY
        t.Name, t.PhoneNumber, t.Email
    ORDER BY
        t.Name ASC, -- Сортиране по име (възходящо)
        CountOfBookings DESC; -- Сортиране по брой резервации (низходящо)
END;
