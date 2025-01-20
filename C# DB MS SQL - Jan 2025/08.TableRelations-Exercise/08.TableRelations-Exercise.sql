USE [Master]
GO


CREATE DATABASE [EntityRelationsDemo2025]
GO

USE [EntityRelationsDemo2025]
GO

-- 01. One-To-One Relationship
CREATE TABLE [Passports]
             (
              [PassportID] INT PRIMARY KEY IDENTITY(101, 1),
              [PassportNumber] NVARCHAR(8) NOT NULL
             )

CREATE TABLE [Persons]
             (
              [PersonID] INT PRIMARY KEY IDENTITY,
              [FirstName] NVARCHAR(50) NOT NULL,
              [Salary] DECIMAL(8, 2) NOT NULL,
              [PassportID] INT FOREIGN KEY REFERENCES [Passports]([PassportID]) UNIQUE NOT NULL
             )

INSERT INTO [Passports]
     VALUES
            ('N34FG21B'),
            ('K65LO4R7'),
            ('ZE657QP2')

INSERT INTO [Persons]([FirstName], [Salary], [PassportID])
     VALUES
            ('Roberto', 43300.00, 102)
            ,('Tom', 56100.00, 103)
            ,('Yana', 60200.00,101)


-- 02. One-To-Many Relationship

CREATE TABLE [Manufacturers]
             (
              [ManufacturerID] INT PRIMARY KEY IDENTITY,
              [Name] NVARCHAR(20) NOT NULL,
              [EstablishedOn] DATE NOT NULL
             )

CREATE TABLE [Models]
             (
              [ModelID] INT PRIMARY KEY IDENTITY(101, 1),
              [Name] NVARCHAR(30) NOT NULL,
              [ManufacturerID] INT FOREIGN KEY REFERENCES [Manufacturers]([ManufacturerID]) NOT NULL
             )

INSERT INTO [Manufacturers] ([Name], [EstablishedOn])
     VALUES 
            ('BMW', '1916-07-03')
            ,('Tesla', '2003-01-01')
            ,('Lada', '1966-01-05')


INSERT INTO [Models] ([Name], [ManufacturerID])
     VALUES 
            ('X1', 1)
            ,('i6', 1)
            ,('Model S', 2)
            ,('Model X', 2)
            ,('Model 3', 2)
            ,('Nova', 3)


-- 03. Many-To-Many Relationship

CREATE TABLE [Students]
             (
              [StudentID] INT PRIMARY KEY IDENTITY,
              [Name] NVARCHAR(20) NOT NULL,
             )

CREATE TABLE [Exams]
             (
              [ExamID] INT PRIMARY KEY IDENTITY(101, 1),
              [Name] NVARCHAR(50) NOT NULL,
             )

-- CREATE TABLE [StudentsExams]
--              (
--              [StudentID] INT
--              ,[ExamID]INT
--              CONSTRAINT PK_StudentsExams
--              PRIMARY KEY(StudentID, ExamID) -- Composite PK
--              ,CONSTRAINT FK_StudentsExams_Students
--              FOREIGN KEY(StudentID) REFERENCES [Students]([StudentID])
--              ,CONSTRAINT FK_StudentsExams_Exams
--              FOREIGN KEY(ExamID) REFERENCES [Exams]([ExamID])
--              )


CREATE TABLE [StudentsExams]
             (
             [StudentID] INT FOREIGN KEY(StudentID) REFERENCES [Students]([StudentID])
             ,[ExamID] INT FOREIGN KEY(ExamID) REFERENCES [Exams]([ExamID])
             ,PRIMARY KEY([StudentID], [ExamID]) -- Composite PK
             )


INSERT INTO [Students] ([Name])
     VALUES 
            ('Mila')
            ,('Toni')
            ,('Ron')

INSERT INTO [Exams] ([Name])
     VALUES 
            ('SpringMVC')
            ,('Neo4j')
            ,('Oracle 11g')

INSERT INTO [StudentsExams] ([StudentID], [ExamID])
     VALUES 
            (1, 101)
            ,(1, 102)
            ,(2, 101)
            ,(3, 103)
            ,(2, 102)
            ,(2, 103)


-- 04. Self-Referencing
 
CREATE TABLE [Teachers]
             (
              [TeacherID] INT PRIMARY KEY IDENTITY(101, 1),
              [Name] NVARCHAR(50) NOT NULL,
              [ManagerID] INT FOREIGN KEY REFERENCES [Teachers]([TeacherID])
             )

INSERT INTO [Teachers] ([Name], [ManagerID])
     VALUES 
            ('John', NULL)
            ,('Maya', 106)
            ,('Silvia', 106)
            ,('Ted', 105)
            ,('Mark', 101)
            ,('Greta', 101)


-- 05. Online Store Database

CREATE DATABASE [OnlineStore]
GO

USE [OnlineStore]
GO

CREATE TABLE [Cities](
             [CityID] INT PRIMARY KEY IDENTITY
             ,[Name] NVARCHAR(50) NOT NULL
             )

CREATE TABLE [Customers](
             [CustomerID] INT PRIMARY KEY IDENTITY
             ,[Name] VARCHAR(50) NOT NULL             
             ,[Birthday] DATETIME2 NOT NULL
             ,[CityID] INT FOREIGN KEY REFERENCES [Cities]([CityID]) NOT NULL
             )

CREATE TABLE [Orders](
             [OrderID] INT PRIMARY KEY IDENTITY
             ,[CustomerID] INT FOREIGN KEY REFERENCES [Customers]([CustomerID]) NOT NULL
             )

CREATE TABLE [ItemTypes](
             [ItemTypeID] INT PRIMARY KEY IDENTITY
             ,[Name] NVARCHAR(50) NOT NULL
             )

CREATE TABLE [Items](
             [ItemID] INT PRIMARY KEY IDENTITY
             ,[Name] VARCHAR(50) NOT NULL             
             ,[ItemTypeID] INT FOREIGN KEY REFERENCES [ItemTypes]([ItemTypeID]) NOT NULL
             )

CREATE TABLE [OrderItems](
             [OrderID] INT FOREIGN KEY REFERENCES [Orders]([OrderID])
             ,[ItemID] INT FOREIGN KEY REFERENCES [Items]([ItemID])
             , PRIMARY KEY ([OrderID], [ItemID])
             )


-- 06. University Database

CREATE DATABASE [UniversityDatabase]
GO

USE [UniversityDatabase]
GO


CREATE TABLE [Majors](
             [MajorID] INT PRIMARY KEY IDENTITY
             ,[Name] NVARCHAR(50) NOT NULL
             )


CREATE TABLE [Subjects](
             [SubjectID] INT PRIMARY KEY IDENTITY
             ,[SubjectName] NVARCHAR(100) NOT NULL
             )


CREATE TABLE [Students](
             [StudentID] INT PRIMARY KEY IDENTITY
             ,[StudentNumber] VARCHAR(20) NOT NULL
             ,[StudentName] NVARCHAR(50) NOT NULL
             ,[MajorID] INT FOREIGN KEY REFERENCES [Majors]([MajorID]) NOT NULL
             )


CREATE TABLE [Agenda](
             [StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID])
             ,[SubjectID] INT FOREIGN KEY REFERENCES [Subjects]([SubjectID])
             , PRIMARY KEY ([StudentID], [SubjectID])
             )


CREATE TABLE [Payments](
             [PaymentID] VARCHAR(50) PRIMARY KEY NOT NULL -- GUID
             ,[PaymentDate] DATETIME2 NOT NULL
             ,[PaymmentAmount] DECIMAL(8, 2) NOT NULL
             ,[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL
             )


