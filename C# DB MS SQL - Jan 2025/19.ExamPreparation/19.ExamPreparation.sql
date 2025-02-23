-- Create the database
CREATE DATABASE ShoesApplicationDatabase;
GO

-- Use the created database
USE ShoesApplicationDatabase;
GO

-- Create Users table
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY, 
    Username NVARCHAR(50) UNIQUE NOT NULL, 
    FullName NVARCHAR(100) NOT NULL, 
    PhoneNumber NVARCHAR(15) NULL, 
    Email NVARCHAR(100) UNIQUE NOT NULL
)

-- Create Brands table
CREATE TABLE Brands (
    Id INT IDENTITY(1,1) PRIMARY KEY, 
    Name NVARCHAR(50) UNIQUE NOT NULL
)

-- Create Sizes table
CREATE TABLE Sizes (
    [Id] INT IDENTITY(1,1) PRIMARY KEY, 
    [EU] DECIMAL(5,2) NOT NULL, 
    [US] DECIMAL(5,2) NOT NULL, 
    [UK] DECIMAL(5,2) NOT NULL, 
    [CM] DECIMAL(5,2) NOT NULL, 
    [IN] DECIMAL(5,2) NOT NULL
)

-- Create Shoes table
CREATE TABLE Shoes (
    Id INT IDENTITY(1,1) PRIMARY KEY, 
    Model NVARCHAR(30) NOT NULL, 
    Price DECIMAL(10,2) NOT NULL, 
    BrandId INT NOT NULL, 
    FOREIGN KEY (BrandId) REFERENCES Brands(Id)
)

-- Create Orders table
CREATE TABLE Orders (
    Id INT IDENTITY(1,1) PRIMARY KEY, 
    ShoeId INT NOT NULL, 
    SizeId INT NOT NULL, 
    UserId INT NOT NULL, 
    FOREIGN KEY (ShoeId) REFERENCES Shoes(Id), 
    FOREIGN KEY (SizeId) REFERENCES Sizes(Id), 
    FOREIGN KEY (UserId) REFERENCES Users(Id)
)

-- Create ShoesSizes table (many-to-many relationship between Shoes and Sizes)
CREATE TABLE ShoesSizes (
    ShoeId INT NOT NULL, 
    SizeId INT NOT NULL, 
    PRIMARY KEY (ShoeId, SizeId), 
    FOREIGN KEY (ShoeId) REFERENCES Shoes(Id), 
    FOREIGN KEY (SizeId) REFERENCES Sizes(Id)
)

-- 02 Insert
INSERT INTO Brands
VALUES 
('Timberland'),
('Birkenstock')

INSERT INTO Shoes (Model, Price, BrandId) 
VALUES
('Reaxion Pro', 150.00, 12),
('Laurel Cort Lace-Up', 160.00, 12),
('Perkins Row Sandal', 170.00, 12),
('Arizona', 80.00, 13),
('Ben Mid Dip', 85.00, 13),
('Gizeh', 90.00, 13);

INSERT INTO ShoesSizes (ShoeId, SizeId)
VALUES
(70, 1), (70, 2), (70, 3), (71, 2), (71, 3), (71, 4), (72, 4), (72, 5), (72, 6),
(73, 1), (73, 3), (73, 5), (74, 2), (74, 4), (74, 6), (75, 1), (75, 2), (75, 3)

INSERT INTO Orders (ShoeId, SizeId, UserId)
VALUES
(70, 2, 15),
(71, 3, 17),
(72, 6, 18),
(73, 5, 4),
(74, 4, 7),
(75, 1, 11)

-- 03 Update
UPDATE Shoes
SET Price *= 1.15
WHERE BrandId = (SELECT Id FROM Brands WHERE Name = 'Nike')

-- 04 Delete
-- Delete from ShoesSizes first (to avoid FK constraint issues)
DELETE FROM ShoesSizes
WHERE ShoeId = (SELECT Id FROM Shoes WHERE Model = 'Joyride Run Flyknit');

-- Delete from Orders next
DELETE FROM Orders
WHERE ShoeId = (SELECT Id FROM Shoes WHERE Model = 'Joyride Run Flyknit');

-- Finally, delete the shoe model from Shoes
DELETE FROM Shoes
WHERE Model = 'Joyride Run Flyknit';

-- 05. Orders By Size of the Shoe
  SELECT 
         s.[Model]
      AS [ShoeModel], 
         s.[Price]
    FROM [Orders] 
      AS o
    JOIN [Shoes] 
      AS s 
      ON o.[ShoeId] = s.[Id]
ORDER BY s.[Price] DESC, s.[Model] ASC

-- 06. Shoes With Their Brand
  SELECT 
         b.[Name]
      AS [BrandName], 
         s.[Model]
      AS [ShoeModel]
    FROM [Shoes] 
      AS s
    JOIN [Brands] 
      AS b 
      ON s.[BrandId] = b.[Id]
ORDER BY b.[Name] ASC, s.[Model] ASC


-- 07. Top 10 Users By Total Money Spent
SELECT TOP 10 
           u.[Id]
        AS [UserId], 
           u.[FullName], 
           SUM(s.[Price]) 
        AS [TotalSpent]
      FROM [Orders]
        AS o
      JOIN [Users] 
        AS u 
        ON o.[UserId] = u.[Id]
      JOIN [Shoes] 
        AS s 
        ON o.[ShoeId] = s.[Id]
  GROUP BY u.[Id], u.[FullName]
  ORDER BY [TotalSpent] DESC, u.[FullName] ASC

  -- 08. Average Price Of Orders

  SELECT 
         u.[Username], 
         u.[Email], 
         CAST(ROUND(AVG(s.[Price]), 2) AS DECIMAL(10, 2))
      AS [AvgPrice]
    FROM [Orders] 
      AS o
    JOIN [Users] 
      AS u 
      ON o.[UserId] = u.[Id]
    JOIN [Shoes] 
      AS s 
      ON o.[ShoeId] = s.[Id]
GROUP BY u.[Id], u.[Username], u.[Email]
  HAVING COUNT(o.[Id]) > 2
ORDER BY [AvgPrice] DESC

-- 09. Running Shoes
  SELECT 
         s.[Model], 
         COUNT(DISTINCT sz.[Id]) 
      AS [CountOfSizes], 
         b.[Name]
      AS [BrandName]
    FROM [Shoes] 
      AS s
    JOIN [Brands] 
      AS b ON
         s.[BrandId] = b.[Id]
    JOIN [ShoesSizes] 
      AS ss 
      ON s.[Id] = ss.[ShoeId]
    JOIN [Sizes] 
      AS sz 
      ON ss.[SizeId] = sz.[Id]
   WHERE b.[Name] = 'Nike'
     AND s.[Model] LIKE '%Run%'
GROUP BY s.[Model], b.[Name]
  HAVING COUNT(DISTINCT sz.[Id]) > 5
ORDER BY s.[Model] DESC;

-- 10. Phone Including Digits 345
 SELECT 
        u.[FullName], 
        u.[PhoneNumber], 
        s.[Price]
     AS [OrderPrice], 
        o.[ShoeId], 
        s.[BrandId], 
        CONCAT(sz.[EU], 'EU/', sz.[US], 'US/', sz.[UK], 'UK') 
      AS [ShoeSize]
    FROM [Orders] AS o
    JOIN [Users] AS u ON o.[UserId] = u.[Id]
    JOIN [Shoes] AS s ON o.[ShoeId] = s.[Id]
    JOIN [Sizes] AS sz ON o.[SizeId] = sz.[Id]
   WHERE u.[PhoneNumber] LIKE '%345%'
ORDER BY s.[Model] ASC

-- 11. Orders By Email
CREATE FUNCTION dbo.udf_OrdersByEmail(@email NVARCHAR(100))
RETURNS INT
AS
BEGIN
    DECLARE @orderCount INT;
    
    -- Изчисляваме броя на поръчките на потребителя с дадения имейл
    SELECT @orderCount = COUNT(*)
    FROM [Users] AS u
    JOIN [Orders] AS o ON u.[Id] = o.[UserId]
    WHERE u.[Email] = @email;
    
    -- Връщаме броя на поръчките
    RETURN @orderCount;
END

--12. Shoe Details By Size
CREATE PROCEDURE usp_SearchByShoeSize 
@shoeSize DECIMAL(5,2)
AS
BEGIN
      SELECT 
             s.[Model] 
          AS [ModelName],
             u.[FullName]
          AS [UserFullName],
        CASE 
            WHEN s.[Price] < 100 THEN 'Low'
            WHEN s.[Price] BETWEEN 100 AND 200 THEN 'Medium'
            WHEN s.[Price] > 200 THEN 'High'
         END 
          AS [PriceLevel],
             b.[Name] 
          AS [BrandName],
             sz.[EU]
          AS [SizeEU]
        FROM [Orders] AS o
        JOIN [Shoes] AS s ON o.[ShoeId] = s.[Id]
        JOIN [Users] AS u ON o.[UserId] = u.[Id]
        JOIN [Brands] AS b ON s.[BrandId] = b.[Id]
        JOIN [Sizes] AS sz ON o.[SizeId] = sz.[Id]
       WHERE sz.[EU] = @shoeSize
    ORDER BY b.[Name], u.[FullName];
END