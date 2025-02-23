USE [Gringotts]
GO

-- 01. Брой на записите

  SELECT 
         Count(MagicWandSize)
      AS Count
    FROM WizzardDeposits

-- 02. Longest Magic Wand

  SELECT 
         MAX(MagicWandSize)
      AS LongestMagicWand
    FROM WizzardDeposits


-- 03. Longest Magic Wand per Deposit Groups

  SELECT 
         DepositGroup,
         MAX(MagicWandSize)
      AS LongestMagicWand
    FROM WizzardDeposits
GROUP BY [DepositGroup]

-- 4. Smallest Deposit Group Per Magic Wand Size

  SELECT TOP 2
         DepositGroup,
         AVG(MagicWandSize)
      AS LongestMagicWand
    FROM WizzardDeposits
GROUP BY [DepositGroup]
ORDER BY LongestMagicWand


-- 5. Deposits Sum

  SELECT 
         DepositGroup,
         SUM(DepositAmount)
      AS TotalSum
    FROM WizzardDeposits
GROUP BY [DepositGroup]


-- 6. Deposits Sum for Ollivander Family

  SELECT 
         DepositGroup,
         SUM(DepositAmount)
      AS TotalSum
    FROM WizzardDeposits
   WHERE [MagicWandCreator] = 'Ollivander Family'
GROUP BY [DepositGroup]


-- 7. Deposits Filter

  SELECT 
         DepositGroup,
         SUM(DepositAmount)
      AS TotalSum
    FROM WizzardDeposits
   WHERE [MagicWandCreator] = 'Ollivander Family'
GROUP BY [DepositGroup]
  HAVING SUM([DepositAmount]) < 150000
ORDER BY [TotalSum] DESC


-- 8.  Deposit Charge

  SELECT DepositGroup,
         MagicWandCreator,
         MIN(DepositCharge)
      AS MinDepositCharge  
    FROM WizzardDeposits
GROUP BY DepositGroup,
         MagicWandCreator
ORDER BY MagicWandCreator,
         DepositGroup


-- 9. Age Groups

  SELECT [AgeGroup],
         COUNT(*)
      AS [WizzardCount]
    FROM
            (SELECT *,
                    CASE
                        WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]' 
                        WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
                        WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]' 
                        WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]' 
                        WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]' 
                        WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
                        WHEN [Age] > 60 THEN '[61+]'
                    END
                AS [AgeGroup]
                FROM [WizzardDeposits]
            )
      AS [AgeGroupTempTable]
GROUP BY [AgeGroup]

-- 11. Average Interest 

SELECT 
    DepositGroup,
    IsDepositExpired,
    AVG(DepositInterest) AS AverageInterest
FROM 
    WizzardDeposits
WHERE 
    DepositStartDate > '1985-01-01' -- Филтрираме депозитите със стартова дата след 01/01/1985
GROUP BY 
    DepositGroup,
    IsDepositExpired -- Групираме по депозитна група и флаг за изтекъл депозит
ORDER BY 
    DepositGroup DESC, -- Подреждаме по депозитна група в намаляващ ред
    IsDepositExpired ASC; -- Подреждаме по флаг за изтекъл депозит във възходящ ред


  SELECT 
         DepositGroup,
         IsDepositExpired,
         AVG(DepositInterest) 
      AS AverageInterest
    FROM 
         WizzardDeposits
   WHERE 
         DepositStartDate > '1985-01-01' 
GROUP BY 
         DepositGroup,
         IsDepositExpired 
ORDER BY 
         DepositGroup DESC, 
         IsDepositExpired



--Part II – Queries for SoftUni Database
USE [SoftUni]
GO

-- 13. Departments Total Salaries

  SELECT 
         DepartmentID,
         SUM(Salary)
      AS TotalSalary
    FROM 
         Employees
GROUP BY 
         DepartmentID
ORDER BY 
         DepartmentID

-- 14. Employees Minimum Salaries


  SELECT 
         DepartmentID,
         MIN(Salary) AS MinimumSalary
    FROM 
         Employees
   WHERE 
         DepartmentID IN (2, 5, 7)
     AND HireDate > '2000-01-01'
GROUP BY 
         DepartmentID
ORDER BY 
         DepartmentID


-- 15. Employees Average Salaries

  SELECT *
    INTO EmployeesOver30000
    FROM Employees
   WHERE Salary > 30000

  DELETE 
    FROM EmployeesOver30000
   WHERE ManagerID = 42

  UPDATE EmployeesOver30000
     SET Salary += 5000
   WHERE DepartmentID = 1

  SELECT DepartmentID,
         AVG(Salary)
      AS AverageSalary
    FROM EmployeesOver30000
GROUP BY DepartmentID


-- 16. Employees Maximum Salaries

  SELECT [DepartmentID],
         MAX([Salary])
      AS [MaxSalary]
    FROM [Employees]
GROUP BY [DepartmentID]
  HAVING MAX([Salary]) NOT BETWEEN 30000 AND 70000


-- 17. Employees Count Salaries

  SELECT 
         COUNT(*) 
      AS Count
    FROM Employees
   WHERE 
         ManagerID IS NULL