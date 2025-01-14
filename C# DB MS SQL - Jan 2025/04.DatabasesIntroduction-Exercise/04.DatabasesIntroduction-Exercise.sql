-- 01. Create Database
CREATE DATABASE [Minions]
GO

USE [Minions]
GO

-- 02. Create Tables
CREATE TABLE [Minions](
    -- [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL
    [Id] INT PRIMARY KEY NOT NULL,
    [Name] NVARCHAR(50) NOT NULL,
    [Age] INT
)

CREATE TABLE [Towns](
    [Id] INT PRIMARY KEY NOT NULL,
    [Name] NVARCHAR(85) NOT NULL
)

-- 03. Alter Minions Table (CHANGE)
-- Alter is command to update STRUKTURE and CONSTRAINTS of the Table 
ALTER TABLE [Minions]
ADD [TownId] INT 

-- Foreign Key сочи към Primary Key - (реферира по колона)
ALTER TABLE [Minions]
ADD CONSTRAINT [FK_Minions_Towns_Id]
FOREIGN KEY([TownId]) REFERENCES [Towns]([Id]) 

-- 04. Insert Records in Both Tables
-- Within INSERT Statement () means a single row
INSERT INTO [Towns]([Id], [Name])
VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO [Minions]([Id], [Name], [Age], [TownId])
VALUES
(1,	'Kevin', 22, 1),
(2,	'Bob', 15, 3),
(3,	'Steward',	NULL, 2)

-- 05. Truncate Table Minions
-- TRUNCATE = Factory reset = Delete All Data
TRUNCATE TABLE[Minions]

-- 06. Drop All Tables
DROP TABLE [Minions]
DROP TABLE [Towns]

-- 07. Create Table People
CREATE TABLE [People](
    [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
    [Name] NVARCHAR(200) NOT NULL,
    [Picture] VARBINARY(MAX) NULL,
    CONSTRAINT [CK_PictureSize] CHECK (DATALENGTH(Picture) <= 2097152),
    [Height] DECIMAL(5, 2) NULL,
    [Weight] DECIMAL(6, 2) NULL,
    [Gender] BIT NOT NULL,
    [Birthdate] DATE NOT NULL,
    [Biography] NVARCHAR(MAX) NULL
)

INSERT INTO [People]([Name], [Picture], [Height], [Weight], [Gender], [Birthdate], [Biography])
VALUES
('Pesho Ivanov', NULL, 1.75, 82.00, 1, '1980-10-15', NULL),
('Gosho Malinov', NULL, 1.55, 79.00, 1, '1990-10-25', 'Тъпак'),
('Dragan Petrowov', NULL, 1.75, 82.00, 1, '1980-10-15', NULL),
('Maria Ivanova', NULL, 1.55, 42.00, 0, '1999-12-30', NULL),
('Мария Кирилова', NULL, 1.85, 62.00, 0, '2000-10-15', NULL)

DROP TABLE [People]

-- 8. Create Table Users
CREATE TABLE [Users](
    [Id] BIGINT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
    [Username] VARCHAR(30) UNIQUE NOT NULL,
    [Password] VARCHAR(26) NOT NULL,
    -- [ProfilePicture] VARCHAR(MAX) - слагаме url в реалността
    [ProfilePicture] VARBINARY(MAX),
    [LastLoginTime] DATETIME2,
    [IsDeleted] BIT
)

INSERT INTO [Users]([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
VALUES
('Pesho', '123456', NULL, GETDATE(), NULL),
('Gosho', '12345678', NULL, GETUTCDATE(), 0),
('Ivan', '1234', NULL, NULL, 1),
('Dragan', '123456789', NULL, NULL, 0),
('Maria', '123', NULL, GETDATE(), 1)

-- 9. Change Primary Key
ALTER TABLE [dbo].[Users] 
DROP CONSTRAINT [PK__Users__3214EC078AADAB5A] WITH ( ONLINE = OFF )
GO

ALTER TABLE [dbo].[Users] 
ADD CONSTRAINT [PK_Composite_Id_Username]
PRIMARY KEY([Id], [Username])

--10. Add Check Constraint
ALTER TABLE [Users]
ADD CONSTRAINT [CK_Password_Min_Length_3]
CHECK(LEN(Password) >= 3)

-- 11. Set Default Value of a Field
-- Important for Default Constraint - Set Defaukt value if column value is no spec during insertion
-- Setting NULL while insert sets NULL
ALTER TABLE [Users]
ADD CONSTRAINT [DF_LastLoginTime_Current_Time]
DEFAULT GETDATE() FOR [LastLoginTime]

INSERT INTO [Users]([Username], [Password], [ProfilePicture], [IsDeleted])
VALUES
('Pesho2', '123456', NULL, NULL)


-- 13. Movies Database
-- Step 1: Create the Movies database
CREATE DATABASE [Movies]
GO

USE [Movies]
GO

-- Step 2: Create the tables
-- Table: Directors
CREATE TABLE [Directors] (
    [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
    [DirectorName] NVARCHAR(100) NOT NULL,
    [Notes] NVARCHAR(MAX) 
)

-- Table: Genres
CREATE TABLE [Genres] (
    [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
    [GenreName] NVARCHAR(50) NOT NULL,
    [Notes] NVARCHAR(MAX) 
)

-- Table: Categories
CREATE TABLE [Categories] (
    [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
    [CategoryName] NVARCHAR(50) NOT NULL,
    [Notes] NVARCHAR(MAX) 
)

-- Table: Movies
CREATE TABLE [Movies] (
    [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
    [Title] NVARCHAR(200) NOT NULL,
    [DirectorId] INT FOREIGN KEY REFERENCES[Directors]([Id]) NOT NULL,
    [CopyrightYear] INT NOT NULL,
    [Length] INT NOT NULL,
    [GenreId] INT FOREIGN KEY REFERENCES[Genres]([Id]) NOT NULL,
    [CategoryId] INT FOREIGN KEY REFERENCES[Categories]([Id]) NOT NULL,
    [Rating] DECIMAL(3,1) NOT NULL,
    [Notes] NVARCHAR(MAX)
)


-- Step 3: Insert records into Directors
INSERT INTO [Directors] ([DirectorName], [Notes])
VALUES 
('Steven Spielberg', 'Famous for adventure and sci-fi movies'),
('Christopher Nolan', 'Known for complex narratives'),
('Quentin Tarantino', 'Stylized and dialogue-heavy films'),
('Sofia Coppola', 'Critically acclaimed for drama films'),
('Hayao Miyazaki', 'Renowned for animated films')

-- Step 4: Insert records into Genres
INSERT INTO [Genres] ([GenreName], [Notes])
VALUES 
('Adventure', 'Movies with exciting journeys'),
('Drama', 'Focused on realistic storytelling'),
('Comedy', 'Humorous and entertaining'),
('Sci-Fi', 'Explores futuristic concepts'),
('Animation', 'Animated or cartoon-based films')

-- Step 5: Insert records into Categories
INSERT INTO [Categories] ([CategoryName], [Notes])
VALUES 
('Feature Film', 'Full-length movies'),
('Short Film', 'Shorter movies, often under 40 minutes'),
('Documentary', 'Based on real-life events'),
('Series', 'Multiple episodes or seasons'),
('Special', 'One-time productions')

-- Step 6: Insert records into Movies
INSERT INTO [Movies] ([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId], [Rating], [Notes])
VALUES 
('Jurassic Park', 1, 1993, 127, 1, 1, 8.1, 'One of Spielberg''s classics'),
('Inception', 2, 2010, 148, 4, 1, 8.8, 'A mind-bending thriller'),
('Pulp Fiction', 3, 1994, 154, 2, 1, 8.9, 'Cult classic'),
('Lost in Translation', 4, 2003, 102, 2, 1, 7.7, 'A quiet drama'),
('Spirited Away', 5, 2001, 125, 5, 1, 8.6, 'Miyazaki''s masterpiece')




-- 14. Car Rental Database
-- Step 1: Create the  database
CREATE DATABASE [CarRental]
GO

USE [CarRental]
GO

-- Step 2: Create the tables
-- Table: Categories
CREATE TABLE [Categories] (
    [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
    [CategoryName] NVARCHAR(50) NOT NULL,
    [DailyRate] DECIMAL(10,2) NOT NULL,
    [WeeklyRate] DECIMAL(10,2) NOT NULL,  
    [MonthlyRate] DECIMAL(10,2) NOT NULL,  
    [WeekendRate] DECIMAL(10,2) NOT NULL,  
)

-- Table: Cars
CREATE TABLE [Cars] (
    [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
    [PlateNumber] NVARCHAR(20) NOT NULL,
    [Manufacturer] NVARCHAR(50) NOT NULL,
    [Model] NVARCHAR(50) NOT NULL,
    [CarYear] INT NOT NULL,
    [CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
    [Doors] INT NOT NULL,
    [Picture] VARBINARY(MAX),
    [Condition] NVARCHAR(50) NOT NULL,
    [Available] BIT NOT NULL  
)

-- Table: Employees
CREATE TABLE [Employees] (
    [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName] NVARCHAR(50) NOT NULL,
    [Title] NVARCHAR(50) NOT NULL,
    [Notes] NVARCHAR(MAX)
)

-- Table: Customers
CREATE TABLE [Customers] (
    [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
    [DriverLicenceNumber] NVARCHAR(20) NOT NULL,
    [FullName] NVARCHAR(100) NOT NULL,
    [Address] NVARCHAR(200) NOT NULL,
    [City] NVARCHAR(50) NOT NULL,
    [ZIPCode] NVARCHAR(10) NOT NULL,
    [Notes] NVARCHAR(MAX)
)

-- Table: RentalOrders
CREATE TABLE [RentalOrders] (
    [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
    [EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
    [CustomerId] INT FOREIGN KEY REFERENCES [Customers]([Id]) NOT NULL,
    [CarId] INT FOREIGN KEY REFERENCES [Cars]([Id]) NOT NULL,
    [TankLevel] DECIMAL(5,2) NOT NULL,
    [KilometrageStart] INT NOT NULL,
    [KilometrageEnd] INT NOT NULL,
    -- [TotalKilometrage] INT NOT NULL,
    [TotalKilometrage] AS (KilometrageEnd - KilometrageStart) PERSISTED,
    [StartDate] DATE NOT NULL,
    [EndDate] DATE NOT NULL,
    -- [TotalDays] INT NOT NULL,
    [TotalDays] AS (DATEDIFF(DAY, StartDate, EndDate)) PERSISTED,
    [RateApplied] DECIMAL(10, 2) NOT NULL,
    [TaxRate] DECIMAL(5, 2) NOT NULL,
    [OrderStatus] NVARCHAR(50) NOT NULL,
    [Notes] NVARCHAR(MAX)
)

-- Step 3: Insert records into Categories
INSERT INTO [Categories] ([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate])
VALUES 
('Economy', 30.00, 180.00, 600.00, 50.00),
('SUV', 50.00, 300.00, 1000.00, 80.00),
('Luxury', 100.00, 600.00, 2000.00, 150.00);

-- Step 4: Insert records into Cars
INSERT INTO [Cars] ([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Picture], [Condition], [Available])
VALUES 
('CA1223AB', 'Toyota', 'Corolla', 2020, 1, 4, NULL, 'Good', 1),
('PB4562HA', 'BMW', 'X5', 2021, 2, 5, NULL, 'Excellent', 1),
('EA7289BA', 'Mercedes', 'S-Class', 2022, 3, 4, NULL, 'New', 1)

-- Step 5: Insert records into Employees
INSERT INTO [Employees] ([FirstName], [LastName], [Title], [Notes])
VALUES 
('Иван', 'Иванов', 'Manager', 'Works full-time'),
('Софка', 'Петрова', 'Clerk', 'Part-time employee'),
('Гошо', 'Тодоров', 'Assistant', 'New hire')

-- Step 6: Insert records into Customers
INSERT INTO [Customers] ([DriverLicenceNumber], [FullName], [Address], [City], [ZIPCode], [Notes])
VALUES 
('DL123456', 'Michael Johnson', '123 Main St', 'Los Angeles', '90001', 'VIP Customer'),
('DL789012', 'Sarah Williams', '456 Elm St', 'San Francisco', '94102', 'Regular Customer'),
('DL345678', 'David Brown', '789 Pine St', 'San Diego', '92103', 'New Customer')

-- Step 7: Insert records into RentalOrders
INSERT INTO [RentalOrders] ([EmployeeId], [CustomerId], [CarId], [TankLevel], [KilometrageStart], [KilometrageEnd], [StartDate], [EndDate], [RateApplied], [TaxRate], [OrderStatus], [Notes])
VALUES 
(1, 1, 1, 0.8, 10000, 10100, '2025-01-01', '2025-01-07', 30.00, 0.07, 'Completed', 'No issues'),
(2, 2, 2, 0.5, 5000, 5200, '2025-01-05', '2025-01-10', 50.00, 0.07, 'Completed', 'Minor scratches'),
(3, 3, 3, 1.0, 200, 500, '2025-01-10', '2025-01-15', 100.00, 0.07, 'Ongoing', '')


-- 15. Hotel Database

CREATE DATABASE [Hotel];
GO

USE [Hotel];
GO

-- Create Employees table
CREATE TABLE [Employees] (
    [Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
    [FirstName] NVARCHAR(100) NOT NULL,
    [LastName] NVARCHAR(100) NOT NULL,
    [Title] NVARCHAR(50) NOT NULL,
    [Notes] NVARCHAR(MAX)
)
GO

-- Insert records into Employees table
INSERT INTO [Employees] ([FirstName], [LastName], [Title], [Notes]) 
VALUES 
(N'John', N'Doe', N'Manager', N'Supervises the daily operations of the hotel'),
(N'Jane', N'Smith', N'Receptionist', N'Handles guest check-ins and check-outs'),
(N'Emily', N'Johnson', N'Housekeeper', N'Ensures the rooms are cleaned and well-maintained');
GO


-- Create Customers table
CREATE TABLE [Customers] (
    [AccountNumber] INT PRIMARY KEY NOT NULL,
    [FirstName] NVARCHAR(100) NOT NULL,
    [LastName] NVARCHAR(100) NOT NULL,
    [PhoneNumber] NVARCHAR(20) NOT NULL,
    [EmergencyName] NVARCHAR(100) NOT NULL,
    [EmergencyNumber] NVARCHAR(20) NOT NULL,
    [Notes] NVARCHAR(255)
)
GO

-- Insert records into Customers table
INSERT INTO [Customers] ([AccountNumber], [FirstName], [LastName], [PhoneNumber], [EmergencyName], [EmergencyNumber], [Notes]) 
VALUES 
(1001, N'Anna', N'Williams', N'123-456-7890', N'John Williams', N'987-654-3210', N'First-time guest'),
(1002, N'Jack', N'Brown', N'234-567-8901', N'Lisa Brown', N'876-543-2109', N'VIP guest'),
(1003, N'Susan', N'White', N'345-678-9012', N'George White', N'765-432-1098', N'Frequent visitor');
GO


-- Create RoomStatus table
CREATE TABLE [RoomStatus] (
    [RoomStatus] NVARCHAR(50) PRIMARY KEY,
    [Notes] NVARCHAR(255)
)
GO

-- Insert records into RoomStatus table
INSERT INTO [RoomStatus] ([RoomStatus], [Notes]) 
VALUES 
(N'Available', N'Room is available for booking'),
(N'Occupied', N'Room is currently occupied by a guest'),
(N'Maintenance', N'Room is under maintenance and unavailable')
GO

-- Create RoomTypes table
CREATE TABLE [RoomTypes] (
    [RoomType] NVARCHAR(50) PRIMARY KEY,
    [Notes] NVARCHAR(255)
)
GO

-- Insert records into RoomTypes table
INSERT INTO [RoomTypes] ([RoomType], [Notes]) 
VALUES 
(N'Single', N'Room with one bed for a single guest'),
(N'Double', N'Room with two beds for two guests'),
(N'Suite', N'Luxurious room with multiple rooms and amenities')
GO

-- Create BedTypes table
CREATE TABLE [BedTypes] (
    [BedType] NVARCHAR(50) PRIMARY KEY,
    [Notes] NVARCHAR(255)
)
GO

-- Insert records into BedTypes table
INSERT INTO [BedTypes] ([BedType], [Notes]) 
VALUES 
(N'Single', N'Single bed for one person'),
(N'King', N'Large bed for two people'),
(N'Queen', N'Medium-sized bed for two people')
GO


-- Create Rooms table
CREATE TABLE [Rooms] (
    [RoomNumber] INT PRIMARY KEY,
    [RoomType] NVARCHAR(50) FOREIGN KEY REFERENCES [RoomTypes]([RoomType]),
    [BedType] NVARCHAR(50) FOREIGN KEY REFERENCES [BedTypes]([BedType]),
    [Rate] DECIMAL(10, 2),
    [RoomStatus] NVARCHAR(50) FOREIGN KEY REFERENCES [RoomStatus]([RoomStatus]),
    [Notes] NVARCHAR(255)
)
GO

-- Insert records into Rooms table
INSERT INTO [Rooms] ([RoomNumber], [RoomType], [BedType], [Rate], [RoomStatus], [Notes]) 
VALUES 
(101, N'Single', N'Single', 50.00, N'Available', N'Located on the first floor'),
(102, N'Double', N'King', 100.00, N'Occupied', N'Located on the second floor'),
(103, N'Suite', N'Queen', 200.00, N'Maintenance', N'Located on the top floor, currently under maintenance');
GO


-- Create Payments table
CREATE TABLE [Payments] (
    [Id] INT PRIMARY KEY,
    [EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]),
    [PaymentDate] DATETIME,
    [AccountNumber] INT FOREIGN KEY REFERENCES [Customers]([AccountNumber]),
    [FirstDateOccupied] DATETIME,
    [LastDateOccupied] DATETIME,
    [TotalDays] INT,
    [AmountCharged] DECIMAL(10, 2),
    [TaxRate] DECIMAL(5, 2),
    [TaxAmount] DECIMAL(10, 2),
    [PaymentTotal] DECIMAL(10, 2),
    [Notes] NVARCHAR(255),
)
GO

-- Insert records into Payments table
INSERT INTO [Payments] ([Id], [EmployeeId], [PaymentDate], [AccountNumber], [FirstDateOccupied], [LastDateOccupied], [TotalDays], [AmountCharged], [TaxRate], [TaxAmount], [PaymentTotal], [Notes]) 
VALUES 
(1, 1, '2025-01-10', 1001, '2025-01-01', '2025-01-05', 4, 200.00, 5.00, 10.00, 210.00, N'Paid in full by credit card'),
(2, 2, '2025-01-11', 1002, '2025-01-02', '2025-01-06', 4, 400.00, 5.00, 20.00, 420.00, N'Paid in cash'),
(3, 3, '2025-01-12', 1003, '2025-01-03', '2025-01-07', 4, 150.00, 5.00, 7.50, 157.50, N'Paid via bank transfer');
GO


-- Create Occupancies table
CREATE TABLE [Occupancies] (
    [Id] INT PRIMARY KEY,
    [EmployeeId] INT,
    [DateOccupied] DATETIME,
    [AccountNumber] INT,
    [RoomNumber] INT,
    [RateApplied] DECIMAL(10, 2),
    [PhoneCharge] DECIMAL(10, 2),
    [Notes] NVARCHAR(255),
    FOREIGN KEY ([EmployeeId]) REFERENCES [Employees]([Id]),
    FOREIGN KEY ([AccountNumber]) REFERENCES [Customers]([AccountNumber]),
    FOREIGN KEY ([RoomNumber]) REFERENCES [Rooms]([RoomNumber])
)
GO

-- Insert records into Occupancies table
INSERT INTO [Occupancies] ([Id], [EmployeeId], [DateOccupied], [AccountNumber], [RoomNumber], [RateApplied], [PhoneCharge], [Notes]) 
VALUES 
(1, 1, '2025-01-01', 1001, 101, 50.00, 5.00, N'Stayed for 4 days'),
(2, 2, '2025-01-02', 1002, 102, 100.00, 10.00, N'Stayed for 4 days, VIP guest'),
(3, 3, '2025-01-03', 1003, 103, 200.00, 15.00, N'Stayed for 4 days, under maintenance');



-- 16. Create SoftUni Database
CREATE DATABASE [SoftUni1st]
GO

USE [SoftUni1st]
GO

CREATE TABLE [Towns](
    [Id] INT PRIMARY KEY IDENTITY NOT NULL,
    [Name] NVARCHAR(85) NOT NULL
)

CREATE TABLE [Addresses](
    [Id] INT PRIMARY KEY IDENTITY NOT NULL,
    [AddressText] NVARCHAR(147) NOT NULL,
    [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id])
)

CREATE TABLE [Departments](
    [Id] INT PRIMARY KEY IDENTITY NOT NULL,
    [Name] NVARCHAR(70) NOT NULL
)

CREATE TABLE [Employees](
    [Id] INT PRIMARY KEY IDENTITY NOT NULL,
    [FirstName] NVARCHAR(36) NOT NULL,
    [MiddleName] NVARCHAR(36),
    [LastName] NVARCHAR(36) NOT NULL,
    [JobTitle] NVARCHAR(40) NOT NULL,
    [DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id]) NOT NULL,
    [HireDate] DATE NOT NULL DEFAULT(GETDATE()),
    [Salary] DECIMAL(18, 2) NOT NULL,
    [AddressId] INT FOREIGN KEY REFERENCES [Addresses]([Id])
)

-- 18. Basic Insert

INSERT INTO [Towns]
VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO [Departments]
VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO [Employees]([FirstName], [MiddleName], [LastName], [JobTitle], [DepartmentId], [HireDate], [Salary])
VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer',	4,	'02/01/2013', 3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '03/02/2004', 4000.00),
('Maria', 'Petrova', 'Ivanova',	'Intern', 5, '08/28/2016', 525.25),
('Georgi', 'Teziev', 'Ivanov', 'CEO Sales', 2, '12/09/2007', 3000.00),
('Peter', 'Pan', 'Pan', 'Intern', 3, '08/28/2016', 599.88)


-- 19. Basic Select All Fields
SELECT * FROM [Towns]
SELECT * FROM [Departments]
SELECT * FROM [Employees]

-- 20. Basic Select All Fields and Order Them
SELECT * FROM [Towns] ORDER BY Name
SELECT * FROM [Departments] ORDER BY Name
SELECT * FROM [Employees] ORDER BY Salary DESC

-- 21. Basic Select Some Fields
SELECT [Name] FROM [Towns] ORDER BY Name
SELECT [Name] FROM [Departments] ORDER BY Name
SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM [Employees] ORDER BY Salary DESC

-- 22. Increase Employees Salary
-- Increase salary of all employees by 10%
UPDATE [Employees]
SET [Salary] = [Salary] * 1.10
-- Select only the Salary column from the Employees table
SELECT [Salary] FROM [Employees]

-- 23. Decrease Tax Rate
USE Hotel
GO
-- Decrease tax rate by 3% for all payments
UPDATE [Payments]
SET [TaxRate] = [TaxRate] * 0.97;
-- Select only the TaxRate column from the Payments table
SELECT [TaxRate] FROM [Payments];


-- 24. Delete All Records
-- Delete all records from the Occupancies table
DELETE FROM [Occupancies]; 
