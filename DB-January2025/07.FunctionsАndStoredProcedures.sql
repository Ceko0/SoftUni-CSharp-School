--1.Employees with Salary Above 35000

CREATE PROCEDURE [usp_GetEmployeesSalaryAbove35000]
			  AS
		   BEGIN
  SET NOCOUNT ON;
		  SELECT 
                 [FirstName], 
                 [LastName]
            FROM [Employees]
           WHERE [Salary] > 35000;
             END

--2.Employees with Salary Above Number

CREATE PROCEDURE [usp_GetEmployeesSalaryAboveNumber]
                 @SalaryThreshold DECIMAL(18,4)
              AS
           BEGIN
  SET NOCOUNT ON;
          SELECT 
                 [FirstName], 
                 [LastName]
            FROM [Employees]
           WHERE [Salary] >= @SalaryThreshold;
             END

--3.Town Names Starting With

CREATE PROCEDURE [usp_GetTownsStartingWith]
                 @Prefix NVARCHAR(100)
              AS
           BEGIN
  SET NOCOUNT ON;
          SELECT [Name]
            FROM [Towns]
           WHERE [Name] LIKE @Prefix + '%';
             END

--4.Employees from Town

CREATE PROCEDURE [usp_GetEmployeesFromTown]
                 @TownName NVARCHAR(100)
             AS
          BEGIN
         SELECT 
                [FirstName], 
                [LastName]
           FROM [Employees] AS e
     INNER JOIN [Addresses] AS a on e.[AddressID] = a.[AddressID]
     INNER JOIN [Towns] AS t ON a.[TownID] = t.[TownID]
          WHERE t.[Name] = @TownName;
            END

--5.Salary Level Function

     CREATE FUNCTION [ufn_GetSalaryLevel] (@salary DECIMAL(18,4))
RETURNS NVARCHAR(10)
                  AS
               BEGIN
             DECLARE @SalaryLevel NVARCHAR(10);
                  IF @salary < 30000
                 SET @SalaryLevel = 'Low';
             ELSE IF @salary BETWEEN 30000 AND 50000
                 SET @SalaryLevel = 'Average';
            ELSE SET @SalaryLevel = 'High';
              RETURN @SalaryLevel;
                 END
				 
--6.Employees by Salary Level

CREATE PROCEDURE [usp_EmployeesBySalaryLevel]
                 @SalaryLevel NVARCHAR(10)
              AS
           BEGIN
          SELECT 
                 [FirstName], 
                 [LastName]
            FROM [Employees]
           WHERE [dbo].[ufn_GetSalaryLevel]([Salary]) = @SalaryLevel;
             END
 
--7.Define Function

CREATE FUNCTION [ufn_IsWordComprised] 
                (
                    @setOfLetters NVARCHAR(100), 
                    @word NVARCHAR(100)
                )
    RETURNS BIT
             AS
          BEGIN
                DECLARE @i INT = 1, @char NVARCHAR(1)
          WHILE @i <= LEN(@word)
          BEGIN
            SET @char = SUBSTRING(@word, @i, 1)
             IF CHARINDEX(@char, @setOfLetters) = 0
         RETURN 0;
            SET @i += 1
            END
         RETURN 1
            END

--8.Delete Employees and Departments

      CREATE 
          OR 
       ALTER 
   PROCEDURE usp_DeleteEmployeesFromDepartment
             @departmentId INT
          AS
       BEGIN
 ALTER TABLE [Departments]
ALTER COLUMN [ManagerID] INT NULL

 DELETE FROM [EmployeesProjects]
       WHERE [EmployeeID] IN 
                            (
                           	  SELECT [EmployeeID] 
                           	    FROM [Employees]
                           	   WHERE [DepartmentID] = @departmentId
                            )
	   UPDATE [Employees]
	      SET [ManagerID] = NULL
		WHERE [ManagerID] IN 
							(
							  SELECT [EmployeeID] 
                           	    FROM [Employees]
                           	   WHERE [DepartmentID] = @departmentId
							)
       UPDATE [Departments]
	      SET [ManagerID] = NULL
		WHERE [ManagerID] IN 
							(
							  SELECT [EmployeeID] 
                           	    FROM [Employees]
                           	   WHERE [DepartmentID] = @departmentId
							)
						
 DELETE FROM [Employees]
       WHERE [DepartmentID] = @departmentId;

 DELETE FROM [Departments]
       WHERE [DepartmentID] = @departmentId
 
      SELECT COUNT(*) 
          AS [RemainingEmployees]
        FROM [Employees]
       WHERE [DepartmentID] = @departmentId

 ALTER TABLE [Departments]
ALTER COLUMN [ManagerID] INT NOT NULL
         END

--9.Find Full Name

CREATE PROCEDURE [usp_GetHoldersFullName]
              AS
           BEGIN
          SELECT [FirstName] + ' ' + [LastName] AS [FullName]
            FROM [AccountHolders];
             END

--10.People with Balance Higher Than

CREATE PROCEDURE [usp_GetHoldersWithBalanceHigherThan]
                 @balance DECIMAL(18,4)
              AS
           BEGIN
          SELECT [FirstName], 
                 [LastName]
            FROM [AccountHolders] AH
            JOIN [Accounts] A ON AH.[Id] = A.[AccountHolderId]
        GROUP BY AH.[FirstName], AH.[LastName]
          HAVING SUM(A.[Balance]) > @balance
        ORDER BY AH.[FirstName], AH.[LastName];
             END

--11.Future Value Function

CREATE PROCEDURE [usp_GetHoldersWithBalanceHigherThan]
                 @balance DECIMAL(18, 4)
              AS
           BEGIN
          SELECT AH.[FirstName], 
                 AH.[LastName]
            FROM [AccountHolders] AH
            JOIN [Accounts] A ON AH.[Id] = A.[AccountHolderId]
        GROUP BY AH.[FirstName], AH.[LastName]
          HAVING SUM(A.[Balance]) > @balance
        ORDER BY AH.[FirstName], AH.[LastName];
             END

--12.Calculating Interest

CREATE PROCEDURE [usp_CalculateFutureValueForAccount]
                 @AccountId INT,
                 @InterestRate FLOAT
              AS
           BEGIN
          SELECT 
                 A.[Id]
			  AS [Account Id],
                 AH.[FirstName]
			  AS [First Name],
                 AH.[LastName] 
			  AS [Last Name],
                 A.[Balance]
			  AS [Current Balance],
                 dbo.ufn_CalculateFutureValue(A.[Balance], @InterestRate, 5) 
			  AS [Balance in 5 years]
            FROM [Accounts] A
            JOIN [AccountHolders] AH ON A.[AccountHolderId] = AH.[Id]
           WHERE A.[Id] = @AccountId
END

--13.*Scalar Function: Cash in User Games Odd Rows

CREATE FUNCTION dbo.ufn_CashInUsersGames (@gameName NVARCHAR(255))
RETURNS DECIMAL(18, 2)
             AS
          BEGIN
        DECLARE @sumCash DECIMAL(18, 2);
    
         SELECT @sumCash = SUM([Cash])
           FROM (
                  SELECT [Cash], ROW_NUMBER() OVER (ORDER BY [Cash] DESC)
				      AS [RowNum]
                    FROM [UsersGames] UG
                    JOIN [Games] G ON UG.[GameID] = G.[ID]
                   WHERE G.[Name] = @gameName
                 ) 
	          AS [OddRows]
           WHERE [RowNum] % 2 = 1; 
    
          RETURN @sumCash;
             END

DROP FUNCTION [dbo].[ufn_CashInUsersGames]

SELECT * FROM [ufn_CashInUsersGames]('Love in a mist')

CREATE FUNCTION [ufn_CashInUsersGames] (@gameName NVARCHAR(255))
        RETURNS @Result TABLE (SumCash DECIMAL(18,2))
             AS
          BEGIN
    INSERT INTO @Result (SumCash)
         SELECT SUM([Cash])
           FROM (
                  SELECT [Cash], ROW_NUMBER() OVER (ORDER BY [Cash] DESC) AS [RowNum]
                  FROM [UsersGames] UG
                  JOIN [Games] G ON UG.[GameID] = G.[ID]
                  WHERE G.[Name] = @gameName
                )
			 AS [OddRows]
          WHERE [RowNum] % 2 = 1

         RETURN
            END

