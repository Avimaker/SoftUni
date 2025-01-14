USE [SoftUni]
GO

-- 02. Find All the Information About Departments
-- * <=> All Columns in the Table

-- SQL River Style конвенция (tool apex sql - платен вече)
SELECT * 
  FROM [Departments]

-- 03. Find all Department Names
SELECT [Name] 
  FROM [Departments]

-- 04. Find Salary of Each Employee
SELECT [FirstName],
       [LastName],
       [Salary] 
  FROM [Employees]


-- 05. Find Full Name of Each Employee
SELECT [FirstName],
       [MiddleName],
       [LastName]
  FROM [Employees]


-- 06. Find Email Address of Each Employee
-- конкатениране с + или с CONCAT
SELECT [FirstName]+'.'+[LastName]+'@softuni.bg'
    AS [Full Email Address]
  FROM [Employees] 


SELECT CONCAT(
       [FirstName],
       '.',
       [LastName],
       '@softuni.bg')
    AS [Full Email Address] -- елиас allays
  FROM [Employees] 


-- 07. Find All Different Employee’s Salaries
SELECT DISTINCT [Salary] -- DISTINCT избира само уникалните стойности
  FROM [Employees]


-- 08. Find all Information About Employees
-- WHERE is SQL Command for applaying filters
-- WHERES is Always written AFTER "FROM" and BEFORE "ORDER BY"!!!
-- Also keep in mind: The order of writing doens not matc the order of execution!!!
SELECT *
  FROM [Employees]
 WHERE [Jobtitle] = 'Sales Representative'

-- 09. Find Names of All Employees by Salary in Range
-- BETWEEN operator is inclusive!!!
SELECT [FirstName],
       [LastName],
       [Jobtitle] 
  FROM [Employees]
 WHERE [Salary] BETWEEN 20000 AND 30000 

-- GENERAL BASED SOLUTION !!!
SELECT [FirstName],
       [LastName],
       [Jobtitle] 
  FROM [Employees]
 WHERE [Salary] >= 20000 
       AND
       [Salary] <= 30000


-- 10. Find Names of All Employees whose salary is exactly 25000, 14000, 12500 or 23600
SELECT CONCAT(
       [FirstName],
       ' ',
       [MiddleName],
       ' ',
       [LastName])
    AS [Full Name] -- елиас allays
  FROM [Employees]
 WHERE [Salary] IN (25000, 14000, 12500, 23600)

-- concat with separator,  слагаме първо '' сепаратор и после вси§ко е със запетайки
SELECT CONCAT_WS(' '
      ,[FirstName]
      ,[MiddleName]
      ,[LastName])
    AS [Full Name] 
  FROM [Employees]
 WHERE [Salary] IN (25000, 14000, 12500, 23600)




-- 11. Find All Employees Without Manager
-- NULL not check with =
-- NULL is check with IS NULL or IS NOT NULL
SELECT [FirstName],
       [LastName]
  FROM [Employees]
 WHERE [ManagerId] IS NULL


-- 12. Find All Employees with Salary More Than
SELECT [FirstName],
       [LastName],
       [Salary] 
  FROM [Employees]
WHERE [Salary] > 50000 ORDER BY [SALARY] DESC

-- 13. Find 5 Best Paid Employees
SELECT TOP 5 [FirstName],
             [LastName]
        FROM [Employees]
    ORDER BY [SALARY] DESC

-- SELECT TOP 5 [FirstName],
--              [LastName]
--         FROM [Employees]
--        WHERE [Salary] > 50000 ORDER BY [SALARY] DESC



-- 14. Find All Employees Except Marketing
SELECT [FirstName],
       [LastName]
  FROM [Employees]
--  WHERE [DepartmentID] != 4
 WHERE [DepartmentID] <> 4


-- 15. Sort Employees Table
  SELECT * 
    FROM [Employees] 
ORDER BY [Salary] DESC,
         [FirstName],
         [LastName] DESC,
         [MiddleName]

-- 16. Create View Employees with Salaries
CREATE VIEW [V_EmployeesSalaries] 
    AS
SELECT [FirstName],
       [LastName],
       [Salary]
  FROM [Employees]

SELECT * FROM [V_EmployeesSalaries]


-- 17. Create View Employees with Job Titles
-- това е за джъдж
CREATE 
  VIEW [V_EmployeeNameJobTitle] 
    AS ( 
SELECT CONCAT(
       [FirstName],
       ' ',
       [MiddleName],
       ' ',
       [LastName])
    AS [Full Name], [Jobtitle]
    AS [Job Title]
  FROM [Employees]
)

-- това е правилното конкатениране
CREATE VIEW [V_EmployeeNameJobTitle] 
    AS 
SELECT CONCAT_WS(' '
      ,[FirstName]
      ,[MiddleName]
      ,[LastName])
    AS [Full Name], [Jobtitle]
    AS [Job Title]
  FROM [Employees]

SELECT * FROM [V_EmployeeNameJobTitle]
WHERE [Job Title] = 'Engineering Manager'







-- да изтрия 
-- DROP VIEW [dbo].[V_EmployeeNameJobTitle]


-- 18. Distinct Job Titles
SELECT DISTINCT [JobTitle] -- DISTINCT избира само уникалните стойности
           FROM [Employees]

-- 19. Find First 10 Started Projects
SELECT TOP 10 *
FROM [Projects]
ORDER BY [StartDate] ASC, [Name] ASC


-- 20. Last 7 Hired Employees
SELECT TOP 7 [FirstName], [LastName], [HireDate]
        FROM [Employees]
    ORDER BY [HireDate] DESC;

-- 21. Increase Salaries
--    SET [Salary] = [Salary] + (0.12 * [Salary]) -- Increase by 12% 
--    SET [Salary] += (0.12 * [Salary]) -- Increase by 12% 

SELECT *
  FROM [Departments]

UPDATE [Employees]
   SET [Salary] *= 1.12
 WHERE [DepartmentID] IN (1, 2, 4, 11)   

SELECT [Salary]
  FROM [Employees]

-- 22. All Mountain Peaks
USE [Geography]
GO

  SELECT [PeakName]
    FROM [Peaks]
ORDER BY [PeakName]


-- 23. Biggest Countries by Population
SELECT TOP 30 [CountryName], [Population]
      FROM [Countries]
     WHERE [ContinentCode] = 'EU'
  ORDER BY [Population] DESC, [CountryName] ASC;



-- 24. *Countries and Currency (Euro / Not Euro)
 SELECT [CountryName],
        [CountryCode],
        CASE
            WHEN [CurrencyCode] = 'EUR' THEN 'Euro'
            ELSE 'Not Euro'
        END
     AS [Currency]  
    FROM [Countries]
ORDER BY [CountryName]


-- 25. All Diablo Characters
USE [Diablo]
GO

  SELECT [Name]
    FROM [Characters]
ORDER BY [Name]




-- Additional
USE [SoftUni]
GO

-- NEVER forget the WHERE clause to the DELETE FROM SQL Command
DELETE
  FROM [Employees]
 WHERE [ManagerID] IS NULL

SELECT *
  FROM [Employees]
 WHERE [ManagerID] IN (109, 291, 292, 293)

 UPDATE [Employee]
    SET [ManagerID] = 110
  WHERE [ManagerID] IN (109, 291, 292, 293)

 UPDATE [Departments]
    SET [ManagerID] = 110
  WHERE [ManagerID] IN (109, 291, 292, 293)
