-- SELECT
--     FirstName AS "Първо име"
--     ,LastName
--     ,JobTitle
-- FROM Employees
-- WHERE DepartmentID = 1;

-- SELECT * FROM Employees

-- !!! при конкатенация с + имаме проблем понякога
-- SELECT
--     FirstName + ' ' + LastName AS [Full Name]
--     ,JobTitle AS [Job Title]
--     ,Salary
-- FROM Employees

-- !!! CONCAT_WS !!! ако имаме празна клетка с NULL така не гърми и нямя двоен спейс, това е правилния начин на конкатенация
-- SELECT
--     CONCAT_WS(' ', FirstName, MiddleName, LastName) AS [Full Name]
--     ,JobTitle AS [Job Title]
--     ,Salary
-- FROM Employees

-- !!! Distinct използва се елеминиране на дупликации

-- SELECT DISTINCT DepartmentID FROM Employees

-- !!! WHERE филтриране
SELECT
    LastName
    , DepartmentID
FROM Employees
WHERE DepartmentID = 1

SELECT
    LastName
    , DepartmentID
FROM Employees
WHERE Salary <= 20000

-- NOT, OR, AND and Brackets ()
SELECT
    LastName
FROM Employees
WHERE NOT (ManagerID = 3 OR ManagerID = 4)

-- Between
SELECT
    LastName
    , DepartmentID
    , Salary
FROM Employees
WHERE
    LastName BETWEEN 'Mun' AND 'ung'
-- DepartmentID BETWEEN 2 AND 5

-- IN/NOT IN
SELECT
    LastName
    , DepartmentID
    , Salary
FROM Employees
WHERE
    -- DepartmentID IN  (2, 5)
    DepartmentID NOT IN  (2, 5, 7)

-- NULL is not NULL or 0 or Blank space
-- !!! use IS NULL instead = NULL


-- ORDER BY - ASC or DESC

SELECT TOP 1
    *
FROM Employees
ORDER BY Salary DESC

SELECT *
FROM Employees
ORDER BY Salary DESC

SELECT *
FROM Employees
ORDER BY Salary, FirstName

-- VIEW

CREATE VIEW v_EmployeesProjection
AS
    SELECT
        CONCAT_WS(' ', FirstName, LastName) AS [Full Name]
    , Salary
    FROM Employees

SELECT *
FROM v_EmployeesProjection


USE [Geography]
GO

CREATE VIEW v_HighestPeak
AS
    SELECT TOP 1
        *
    FROM Peaks
    ORDER BY Elevation DESC

SELECT *
FROM v_HighestPeak

-- Insert

USE SoftUni
GO

SET IDENTITY_INSERT Towns ON;
GO

INSERT INTO Towns
    (TownID, [Name])
VALUES
    (33, 'Paris')
GO

SET IDENTITY_INSERT Towns OFF;
GO

-- това е правилно - без да му даваме идентити, то го слага само
INSERT INTO Towns
    ([Name])
VALUES
    ('Plovdiv')

-- bulk insert
INSERT INTO [Projects]
    ([Name],[StartDate])
VALUES
    ('Reflective Jacket', GETDATE()),
    ('Hoover board', GETDATE()),
    ('Flying saucer', GETDATE())

-- вложена заявка
INSERT INTO [Projects]
    ([Name],[StartDate])
SELECT 'Restructuring of' + [Name], GETDATE()
FROM Departments

DELETE FROM Projects WHERE ProjectID > 130

-- create new table copy of current
SELECT
    FirstName
    , LastName
    , Salary
INTO EmployeesSalary
FROM Employees

-- delete table
DROP TABLE EmployeesSalary

-- counter
CREATE SEQUENCE seq_Custumers_CustumerID
    AS INT
    Start WITH 1
    INCREMENT BY 1
-- da dowyrsha 2:50


-- UPDATE
UPDATE Employees SET 
    FirstName = 'Peter'
    ,LastName = 'Petrov'
WHERE EmployeeID = 1


UPDATE Projects SET
    EndDate = GETDATE()
WHERE EndDate IS NULL

     
