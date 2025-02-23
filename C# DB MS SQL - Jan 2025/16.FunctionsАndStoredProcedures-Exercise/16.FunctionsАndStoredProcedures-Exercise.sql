USE SoftUni
GO

-- 01. Employees with Salary Above 35000

CREATE OR ALTER PROC dbo.usp_GetEmployeesSalaryAbove35000
AS
     SELECT [FirstName]
         AS [First Name],
            [LastName]
         AS [Last Name]
       FROM Employees
      WHERE Salary > 35000 
GO

EXEC dbo.usp_GetEmployeesSalaryAbove35000

DROP PROC dbo.usp_GetEmployeesSalaryAbove35000

-- 02. Employees with Salary Above Number

CREATE OR ALTER PROC dbo.usp_GetEmployeesSalaryAboveNumber (@ChkSalary DECIMAL(18,4))
AS
     SELECT [FirstName]
         AS [First Name],
            [LastName]
         AS [Last Name]
       FROM Employees
      WHERE Salary >= @ChkSalary 
GO

EXEC dbo.usp_GetEmployeesSalaryAboveNumber 48100


-- 03. Town Names Starting With
CREATE OR ALTER PROC usp_GetTownsStartingWith (@ChkTown NVARCHAR(50))
AS
     SELECT [Name]
         AS [Town]
       FROM Towns
      WHERE [Name] LIKE @ChkTown + '%'
GO

EXEC usp_GetTownsStartingWith b

-- 04. Employees from Town

CREATE OR ALTER PROC usp_GetEmployeesFromTown (@ChkTown NVARCHAR(50))
AS
BEGIN
     SELECT e.[FirstName]
         AS [First Name],
            e.[LastName]
         AS [Last Name]
       FROM Employees e
  LEFT JOIN Addresses a
         ON e.AddressID = a.AddressID
  LEFT JOIN Towns t
         ON a.TownID = t.TownID  
      WHERE t.[Name] = @ChkTown 
END 

EXEC usp_GetEmployeesFromTown @ChkTown = 'Sofia'


-- 05. Salary Level Function

  CREATE 
      OR 
   ALTER
FUNCTION dbo.ufn_GetSalaryLevel (@salary DECIMAL(18,4))
 RETURNS NVARCHAR(10)     
      AS
   BEGIN    
         DECLARE @salaryLevel NVARCHAR(10) 
              IF @salary < 30000
             SET @salaryLevel = 'Low'
         ELSE IF @salary BETWEEN 30000 AND 50000
             SET @salaryLevel = 'Average'
            ELSE
             SET @salaryLevel = 'High'
          RETURN @salaryLevel
     END
     
GO


SELECT Salary,
       dbo.ufn_GetSalaryLevel(Salary)
    AS [Salary Level]  
  FROM Employees


-- 06. Employees by Salary Level

   CREATE
       OR
    ALTER 
PROCEDURE usp_EmployeesBySalaryLevel (@SalaryLevel NVARCHAR(10))
       AS
    BEGIN
   SELECT e.FirstName, e.LastName
     FROM Employees e
    WHERE dbo.ufn_GetSalaryLevel(e.Salary) = @SalaryLevel;
      END


EXEC usp_EmployeesBySalaryLevel @SalaryLevel = 'High'


-- 07. Define Function

  CREATE 
      OR 
   ALTER
FUNCTION dbo.ufn_IsWordComprised(@setOfLetters VARCHAR(100), @word VARCHAR(70)) 
 RETURNS BIT     
      AS
   BEGIN
         DECLARE @wordIndex TINYINT = 1;
         WHILE (@wordIndex <= LEN(@word))
         BEGIN
               DECLARE @currentLetter CHAR(1);
               SET @currentLetter = SUBSTRING(@word, @wordIndex, 1)

               IF (CHARINDEX(@currentLetter, @setOfLetters) = 0)
                  BEGIN
                        RETURN 0;
                  END

               SET @wordIndex += 1;
         END
         RETURN 1;
     END

SELECT dbo.ufn_IsWordComprised ('oistmiahf','Sofia')

-- 09. Find Full Name

CREATE OR ALTER PROCEDURE usp_GetHoldersFullName
AS
BEGIN
    SELECT 
        CONCAT(ah.FirstName, ' ', ah.LastName) AS [Full Name]
    FROM AccountHolders ah;
END

EXEC usp_GetHoldersFullName;


-- 10. People with Balance Higher Than

   CREATE
       OR
    ALTER 
PROCEDURE usp_GetHoldersWithBalanceHigherThan (@Amount DECIMAL(18,4))
       AS
    BEGIN
            SELECT ah.FirstName, ah.LastName
              FROM AccountHolders ah
              JOIN Accounts a ON ah.Id = a.AccountHolderId
          GROUP BY ah.FirstName, ah.LastName
            HAVING SUM(a.Balance) > @Amount
          ORDER BY ah.FirstName, ah.LastName;
      END


-- 11. Future Value Function

  CREATE 
      OR
   ALTER
FUNCTION ufn_CalculateFutureValue 
       (
         @initialSum DECIMAL(18,4), 
         @yearlyInterestRate FLOAT, 
         @years INT
       )
 RETURNS DECIMAL(18,4)
      AS
   BEGIN
         DECLARE @futureValue DECIMAL(18,4)
          -- Изчисляваме бъдещата стойност по формулата
         SET @futureValue = @initialSum * POWER(1 + @yearlyInterestRate, @years)
          -- Закръгляме до четвъртата цифра след десетичната точка
         RETURN ROUND(@futureValue, 4)
      END

-- 12. Calculating Interest

   CREATE
       OR
    ALTER 
PROCEDURE usp_CalculateFutureValueForAccount 
        (
          @AccountId INT, 
          @interestRate FLOAT
        )
       AS
    BEGIN
          -- Декларираме променливи за събиране на данни
          DECLARE @FirstName NVARCHAR(50), 
                  @LastName NVARCHAR(50), 
                  @CurrentBalance DECIMAL(18,4),
                  @FutureBalance DECIMAL(18,4)
         
          -- Извличаме данни за акаунта
          SELECT 
                 @FirstName = ah.FirstName,
                 @LastName = ah.LastName,
                 @CurrentBalance = a.Balance
            FROM Accounts a
            JOIN AccountHolders ah ON a.AccountHolderId = ah.Id
           WHERE a.Id = @AccountId
         
         -- Използваме функцията за изчисляване на бъдещата стойност (5 години)
         SET @FutureBalance = dbo.ufn_CalculateFutureValue(@CurrentBalance, @interestRate, 5)
    
        -- Връщаме резултатите
         SELECT 
                @AccountId AS [Account Id],
                @FirstName AS [First Name],
                @LastName AS [Last Name],
                @CurrentBalance AS [Current Balance],
                @FutureBalance AS [Balance in 5 years]
      END