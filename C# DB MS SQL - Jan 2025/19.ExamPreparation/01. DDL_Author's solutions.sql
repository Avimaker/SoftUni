01.------
CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY(1,1),
Username NVARCHAR(50) NOT NULL UNIQUE,
FullName NVARCHAR(100) NOT NULL,
PhoneNumber NVARCHAR(15) NULL,
Email NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Brands(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Sizes(
Id INT PRIMARY KEY IDENTITY(1,1),
EU DECIMAL(5,2) NOT NULL,
US DECIMAL(5,2) NOT NULL,
UK DECIMAL(5,2) NOT NULL,
CM DECIMAL(5,2) NOT NULL,
[IN] DECIMAL(5,2) NOT NULL
);

CREATE TABLE Shoes(
Id INT PRIMARY KEY IDENTITY(1,1),
Model NVARCHAR(30) NOT NULL,
Price DECIMAL(10,2) NOT NULL,
BrandId INT NOT NULL,
FOREIGN KEY (BrandId) REFERENCES Brands(Id)
);

CREATE TABLE ShoesSizes(
ShoeId INT NOT NULL,
SizeId INT NOT NULL,
PRIMARY KEY (ShoeId, SizeId),
FOREIGN KEY (ShoeId) REFERENCES Shoes(Id),
FOREIGN KEY (SizeId) REFERENCES Sizes(Id)
);

CREATE TABLE Orders(
Id INT PRIMARY KEY IDENTITY(1,1),
ShoeId INT NOT NULL,
SizeId INT NOT NULL,
UserId INT NOT NULL,
FOREIGN KEY (ShoeId) REFERENCES Shoes(Id),
FOREIGN KEY (SizeId) REFERENCES Sizes(Id),
FOREIGN KEY (UserId) REFERENCES Users(Id)
);

02.------
INSERT INTO Brands ([Name]) VALUES
('Timberland'),
('Birkenstock');

INSERT INTO Shoes (Model, Price, BrandId) VALUES
('Pro Reaxion', 150.00, 12),
('Laurel Cort Lace-Up', 160.00, 12),
('Perkins Row Sandal', 170.00, 12),
('Arizona', 80.00, 13),
('Ben Mid Dip', 85.00, 13),
('Gizeh', 90.00, 13);

INSERT INTO ShoesSizes (ShoeId, SizeId) VALUES
(70, 1), (70, 2), (70, 3),
(71, 2), (71, 3), (71, 4),
(72, 4), (72, 5), (72, 6),
(73, 1), (73, 3), (73, 5),
(74, 2), (74, 4), (74, 6),
(75, 1), (75, 2), (75, 3);

INSERT INTO Orders (ShoeId, SizeId, UserId) VALUES
(70, 2, 15),
(71, 3, 17),
(72, 6, 18),
(73, 5, 4),
(74, 4, 7),
(75, 1, 11);

03.------
UPDATE Shoes
SET Price = Price * 1.15
WHERE BrandId = (SELECT Id FROM Brands WHERE Name = 'Nike');

04.------
DELETE FROM Orders WHERE ShoeId = (SELECT Id FROM Shoes WHERE Model = 'Joyride Run Flyknit');

DELETE FROM ShoesSizes WHERE ShoeId = (SELECT Id FROM Shoes WHERE Model = 'Joyride Run Flyknit');

DELETE FROM Shoes WHERE Model = 'Joyride Run Flyknit';

05.------
SELECT s.Model AS ShoeModel, 
       s.Price 
FROM Orders o
JOIN Shoes s ON o.ShoeId = s.Id
ORDER BY s.Price DESC, s.Model ASC;

06.------
SELECT B.Name AS BrandName, S.Model AS ShoeModel
FROM Shoes AS S
INNER JOIN Brands AS B ON S.BrandId = B.Id
ORDER BY B.Name ASC, S.Model ASC;

07.------
SELECT TOP 10 
       u.Id AS UserId,
       u.FullName,
       SUM(s.Price) AS TotalSpent
FROM Orders o
JOIN Users u ON o.UserId = u.Id
JOIN Shoes s ON o.ShoeId = s.Id
GROUP BY u.Id, u.FullName
ORDER BY TotalSpent DESC, u.FullName ASC;

08.------
SELECT 
	u.Username, 
	u.Email, 
	CAST(ROUND(AVG(s.Price), 2) AS DECIMAL(10, 2))
FROM Orders AS o
JOIN Users AS u ON o.UserId = u.Id
JOIN Shoes AS s ON s.Id = o.ShoeId
GROUP BY u.Username, u.Email
HAVING COUNT(o.Id) > 2
ORDER BY AVG(s.Price) DESC

09.------
SELECT 
       s.Model,
       COUNT(ss.SizeId) AS CountOfSizes,
       b.Name AS BrandName
FROM Shoes s
JOIN ShoesSizes ss ON s.Id = ss.ShoeId
JOIN Brands b ON s.BrandId = b.Id
WHERE s.Model LIKE '%Run%'
AND b.Name = 'Nike'
GROUP BY s.Model, b.Name
HAVING COUNT(ss.SizeId) > 5
ORDER BY s.Model DESC;

10.------
SELECT 
       u.FullName,
       u.PhoneNumber,
       s.Price AS OrderPrice,
       s.Id AS ShoeId,
       b.Id AS BrandId,
       CONCAT(sz.EU, 'EU/', sz.US, 'US/', sz.UK, 'UK') AS ShoeSize
FROM Orders o
JOIN Users u ON o.UserId = u.Id
JOIN Shoes s ON o.ShoeId = s.Id
JOIN Brands b ON s.BrandId = b.Id
JOIN Sizes sz ON o.SizeId = sz.Id
WHERE u.PhoneNumber LIKE '%345%'
ORDER BY s.Model ASC;

11.------
CREATE FUNCTION udf_OrdersByEmail (@Email NVARCHAR(100))
RETURNS INT
AS
BEGIN
    DECLARE @OrderCount INT;
    
    SELECT @OrderCount = COUNT(*)
    FROM Orders o
    JOIN Users u ON o.UserId = u.Id
    WHERE u.Email = @Email;
    
    RETURN @OrderCount;
END;

12.------
CREATE PROCEDURE usp_SearchByShoeSize
    @SizeEU DECIMAL(5,2)
AS
BEGIN
    SELECT 
        s.Model AS ModelName,
        u.FullName AS UserFullName,
        CASE 
            WHEN s.Price < 100 THEN 'Low'
            WHEN s.Price BETWEEN 100 AND 200 THEN 'Medium'
            ELSE 'High'
        END AS PriceLevel,
        b.Name AS BrandName,
        sz.EU AS SizeEU
    FROM Shoes s
    JOIN Orders o ON s.Id = o.ShoeId
    JOIN Users u ON o.UserId = u.Id
    JOIN Brands b ON s.BrandId = b.Id
    JOIN Sizes sz ON o.SizeId = sz.Id
    WHERE sz.EU = @SizeEU
    ORDER BY b.Name, u.FullName;
END;