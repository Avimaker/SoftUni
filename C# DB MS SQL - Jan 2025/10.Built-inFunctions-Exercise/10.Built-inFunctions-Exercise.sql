USE [SoftUni]
GO

-- 01. Find Names of All Employees by First Name
-- 1st way Use LEFT() Built-In function
-- 2nd way Use Wild Card
-- % нула или повече
SELECT [FirstName]
      ,[LastName]
  FROM [Employees]
 WHERE [FirstName] LIKE 'Sa%'


-- 02. Find Names of All Employees by Last Name
-- 1st way Use CHARINDEX() Built-In function
-- 2nd way Use Wild Card
SELECT [FirstName]
      ,[LastName]
  FROM [Employees]
 WHERE [LastName] LIKE '%ei%'


-- 03. Find First Names of All Employees
-- SELECT *
SELECT [FirstName]
  FROM [Employees]
 WHERE [DepartmentID] IN (3, 10)
 AND YEAR([HireDate]) BETWEEN 1995 AND 2005;


-- 04. Find All Employees Except Engineers
-- 1st way Use CHARINDEX() Built-In function
-- 2nd way Use Wild Card

SELECT [FirstName]
      ,[LastName]
  FROM [Employees]
 WHERE [JobTitle] NOT LIKE '%engineer%'
--  WHERE CHARINDEX('engineer', [JobTitle]) = 0


-- 05. Find Towns with Name Length
  SELECT [Name]
    FROM [Towns]
   WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name]


-- 06. Find Towns Starting With
  SELECT [TownID],
         [Name]
    FROM [Towns]
   WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name]

  SELECT [TownID],
         [Name]
    FROM [Towns]
   WHERE [Name] LIKE 'M%' 
      OR [Name] LIKE 'K%' 
      OR [Name] LIKE 'B%' 
      OR [Name] LIKE 'E%'
ORDER BY [Name]

  SELECT [TownID], [Name]
    FROM [Towns]
   WHERE [Name] LIKE '[MKEB]%'
ORDER BY [Name];


-- 07. Find Towns Not Starting With
  SELECT [TownID], [Name]
    FROM [Towns]
   WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY [Name];

-- 08. Create View Employees Hired After 2000 Year
CREATE VIEW [V_EmployeesHiredAfter2000]
    AS (
          SELECT [FirstName],
                 [LastName]
            FROM [Employees]
           WHERE YEAR([HireDate]) > 2000
         )

SELECT [FirstName],
       [LastName]
  FROM [Employees]
 WHERE YEAR([HireDate]) > 2000


-- 09. Length of Last Name
SELECT [FirstName],
       [LastName]
  FROM [Employees]
 WHERE LEN([LastName]) = 5




-- 10. Rank Employees by Salary

  SELECT [EmployeeID],
         [FirstName],
         [LastName],
         [Salary],
         DENSE_RANK() OVER(PARTITION BY [Salary] ORDER BY [EmployeeID])
      AS [Rank]
    FROM [Employees]
   WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC


-- 11. Find All Employees with Rank 2 (

  SELECT *
    FROM (
          SELECT [EmployeeID],
                 [FirstName],
                 [LastName],
                 [Salary],
                 DENSE_RANK() OVER(PARTITION BY [Salary] ORDER BY [EmployeeID])
              AS [Rank]
            FROM [Employees]
           WHERE [Salary] BETWEEN 10000 AND 50000
         )     
      AS [Temp]
   WHERE [Rank] = 2
ORDER BY [Salary] Desc


-- Part II – Queries for Geography Database
-- 12.	Countries Holding 'A' 3 or More Times
USE [Geography]
GO

SELECT 
       CountryName AS [Country Name], 
       IsoCode AS [ISO Code]
  FROM 
       Countries
 WHERE 
       LEN(REPLACE(LOWER([CountryName]), 'a', '')) <= LEN([CountryName]) - 3
ORDER BY 
       IsoCode







-- 13. Mix of Peak and River Names
-- 1st way - Use multiple SELECT statement
-- 2nd way - Use Join


-- 1st way - Use multiple SELECT statement
SELECT [p].[PeakName],
       [r].[RiverName],
       LOWER(CONCAT(SUBSTRING([p].[PeakName], 1, LEN([p].[PeakName]) - 1), [r].[RiverName]))
    AS [Mix]
  FROM [Peaks]
    AS [p],
       [Rivers]
    AS [r]
 WHERE RIGHT([p].[PeakName], 1) = LEFT([r].[RiverName], 1)
 ORDER BY [Mix]


-- 2nd way - Use Join
  SELECT [p].[PeakName],
         [r].[RiverName],
         LOWER(CONCAT(SUBSTRING([p].[PeakName], 1, LEN([p].[PeakName]) - 1), [r].[RiverName]))
      AS [Mix]
    FROM [Peaks]
      AS [p]
    JOIN [Rivers]  
      AS [r]
      ON RIGHT([p].[PeakName], 1) = LEFT([r].[RiverName], 1)
ORDER BY [MIX]

-- 14. Games From 2011 and 2012 Year
USE [Diablo]
GO

SELECT TOP 50 
           [Name], 
           CONVERT(varchar(10), [Start], 120) 
        AS [Start]
      FROM [Games]
     WHERE YEAR([Start]) IN (2011, 2012)
  ORDER BY [Start], [Name]

-- SELECT CONVERT(varchar(10), '2014-06-07 23:19:14.000', 120);
-- 2014-06-07

-- 15. User Email Providers

  SELECT [Username],
         SUBSTRING([Email], CHARINDEX('@', [Email]) + 1, LEN([Email]) - CHARINDEX('@', [Email]))
      AS [Email Provider]
    FROM [Users]
ORDER BY [Email Provider], [Username]


-- 16. Get Users with IP Address Like Pattern

  SELECT 
         Username, 
         IpAddress
    FROM Users
   WHERE IpAddress LIKE '___.1%.___' 
ORDER BY Username ASC


-- 17. Show All Games with Duration & Part of the Day

  SELECT 
         g.[Name]
      AS [Game],
         CASE
              WHEN DATEPART(HOUR, g.[Start]) BETWEEN 0 AND 11 THEN 'Morning'
              WHEN DATEPART(HOUR, g.[Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
              ELSE 'Evening'
         END 
      AS [Part Of The Day],
         CASE
              WHEN g.Duration <= 3 THEN 'Extra Short'
              WHEN g.Duration BETWEEN 4 AND 6 THEN 'Short'
              WHEN g.Duration > 6 THEN 'Long'
              ELSE 'Extra Long'
          END 
      AS [Duration]
    FROM [Games]
      AS g
ORDER BY g.[Name],[Duration]


-- 18. Orders Table
  SELECT 
         [ProductName],
         [OrderDate],
         DATEADD(DAY, 3, [OrderDate]) 
      AS [Pay Due],
         DATEADD(MONTH, 1, [OrderDate]) 
      AS [Deliver Due]
    FROM [Orders]
