
USE [Softuni]
GO

-- 01. Employee Address
  SELECT 
     TOP (5)
         e.EmployeeID,
         e.JobTitle,
         e.AddressID,
         a.AddressText
    FROM [Employees] AS e
    JOIN [Addresses] AS a 
      ON e.AddressID = a.AddressID
ORDER BY e.AddressID


-- 02. Addresses with Towns
  SELECT 
     TOP (50)
         e.FirstName,
         e.LastName,
         t.[Name] AS Town,
         a.AddressText
    FROM [Employees] AS e
    JOIN [Addresses] AS a
      ON e.AddressID = a.AddressID
    JOIN [Towns] AS t
      ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName


-- 03. Sales Employees
  SELECT 
         e.EmployeeID,
         e.FirstName,
         e.LastName,
         d.Name AS DepartmentName
    FROM [Employees] AS e
    JOIN [Departments] AS d 
      ON e.DepartmentID = d.DepartmentID 
   WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID


-- 04. Employee Departments

  SELECT TOP (5)
         e.EmployeeID,
         e.FirstName,
         e.Salary,
         d.Name AS DepartmentName
    FROM [Employees] AS e
    JOIN [Departments] AS d 
      ON e.DepartmentID = d.DepartmentID 
   WHERE e.Salary > 15000
ORDER BY d.DepartmentID


-- 05. Employees Without Projects
   SELECT TOP (3)
          e.EmployeeID,
          e.FirstName
     FROM Employees 
       AS e
LEFT JOIN EmployeesProjects 
       AS ep
       ON e.EmployeeID = ep.EmployeeID
    WHERE ep.ProjectID IS NULL
 ORDER BY e.EmployeeID


-- 06. Employees Hired After
  SELECT 
         e.FirstName,
         e.LastName,
         e.HireDate,
         d.Name AS DeptName
    FROM [Employees] AS e
    JOIN [Departments] AS d 
      ON e.DepartmentID = d.DepartmentID 
   WHERE e.HireDate > '1999-01-01'
     AND d.Name IN ('Sales', 'Finance')
ORDER BY e.HireDate

-- 07. Employees With Project
   SELECT TOP (5)
          e.EmployeeID,
          e.FirstName,
          p.Name AS ProjectName
     FROM Employees 
       AS e
     JOIN EmployeesProjects 
       AS ep
       ON e.EmployeeID = ep.EmployeeID
     JOIN Projects
       AS p
       ON ep.ProjectID = p.ProjectID
    WHERE p.StartDate > '2002-08-13'
      AND p.EndDate IS NULL
ORDER BY e.EmployeeID

-- 08. Employee 24
   SELECT 
          e.EmployeeID,
          e.FirstName,
     CASE
          WHEN p.StartDate >= '2005-01-01' THEN NULL
          ELSE p.Name
      END
       AS ProjectName
     FROM Employees 
       AS e
     JOIN EmployeesProjects 
       AS ep
       ON e.EmployeeID = ep.EmployeeID
     JOIN Projects
       AS p
       ON ep.ProjectID = p.ProjectID
    WHERE e.EmployeeID = 24

-- 09. Employee Manager
   SELECT 
          e1.EmployeeID,
          e1.FirstName,
          e1.ManagerID,
          e2.FirstName
       AS ManagerName 
     FROM Employees
       AS e1
LEFT JOIN Employees
       AS e2
       ON e1.ManagerID = e2.EmployeeID
    WHERE e1.ManagerID IN (3, 7)
 ORDER BY e1.EmployeeID       


-- 10. Employees Summary
  SELECT TOP (50)
         e.EmployeeID,
         CONCAT_WS(' ', e.FirstName, e.LastName) AS EmployeeName,
         CONCAT_WS(' ', m.FirstName, m.LastName) AS ManagerName,
         d.[Name] AS DepartmentName
   FROM Employees
      AS e
    JOIN Departments 
      AS d
      ON e.DepartmentID = d.DepartmentID
    JOIN Employees
      AS m 
      ON e.ManagerID = m.EmployeeID   
ORDER BY e.EmployeeID


-- 11. Min Average Salary
-- standart way
SELECT TOP (1) 
          AVG(Salary) AS MinAverageSalary
     FROM Employees
 GROUP BY DepartmentID 
 ORDER BY 1
--subquerie way
   SELECT MIN(dt.MinAvgSalary) 
       AS MinAverageSalary
     FROM
           (SELECT AVG(Salary) AS MinAvgSalary
              FROM Employees
          GROUP BY DepartmentID) AS dt



-- 12. Highest Peaks in Bulgaria
USE [Geography]
GO


  SELECT 
         c.CountryCode,
         m.MountainRange,
         p.PeakName,
         p.Elevation
    FROM Countries
      AS c
    JOIN MountainsCountries
      AS mc
      ON c.CountryCode = mc.CountryCode
    JOIN Peaks
      AS p  
      ON mc.MountainId = p.MountainId
    JOIN Mountains
      AS m
      ON mc.MountainId = m.Id
   WHERE c.CountryCode = 'BG'
     AND p.Elevation > 2835
ORDER BY p.Elevation DESC


-- 13. Count Mountain Ranges
   SELECT c.CountryCode,
          COUNT(mc.MountainID)
       AS MountainRanges
     FROM Countries
       AS c
LEFT JOIN MountainsCountries
       AS mc
       ON mc.CountryCode = c.CountryCode
    WHERE c.CountryName IN ('United States', 'Russia', 'Bulgaria')
 GROUP BY c.CountryCode


-- 14. Countries With or Without Rivers


   SELECT TOP (5)
          c.CountryName,
          r.RiverName
     FROM Countries
       AS c
LEFT JOIN CountriesRivers
       AS cr
       ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers
       AS r
       ON cr.RiverId = r.Id
     JOIN Continents
       AS cnt
       ON c.ContinentCode = cnt.ContinentCode
    WHERE cnt.ContinentName = 'Africa'
 ORDER BY c.CountryName


 -- 16. Countries Without any Mountains

   SELECT 
    COUNT (cnt.CountryCode)
       AS Count
     FROM
          (
          SELECT c.CountryCode, mc.MountainId
            FROM Countries
              AS c
       LEFT JOIN MountainsCountries
              AS mc
              ON mc.CountryCode = c.CountryCode
           WHERE mc.MountainId IS NULL
          )   AS cnt
          

-- 17. Highest Peak and Longest River by Country

   SELECT TOP (5)
          c.CountryName,
          MAX(p.Elevation)
       AS HighestPeakElevation,
          MAX(r.Length)
       AS LongestRiverLength
     FROM Countries
       AS c
     JOIN MountainsCountries
       AS mc
       ON c.CountryCode = mc.CountryCode
     JOIN Peaks
       AS p  
       ON mc.MountainId = p.MountainId
     JOIN Mountains
       AS m
       ON mc.MountainId = m.Id
LEFT JOIN CountriesRivers
       AS cr
       ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers
       AS r
       ON cr.RiverId = r.Id
 GROUP BY c.CountryName
 ORDER BY
          MAX(p.Elevation) DESC,
          MAX(r.Length) DESC,
          c.CountryName ASC


   SELECT TOP (5)
          c.CountryName,
          r.RiverName
     FROM Countries
       AS c
LEFT JOIN CountriesRivers
       AS cr
       ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers
       AS r
       ON cr.RiverId = r.Id
     JOIN Continents
       AS cnt
       ON c.ContinentCode = cnt.ContinentCode
    WHERE cnt.ContinentName = 'Africa'
 ORDER BY c.CountryName