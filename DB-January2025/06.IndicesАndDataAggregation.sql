--1.Records' Count

SELECT COUNT(*) AS Count 
  FROM [WizzardDeposits]

--2.Longest Magic Wand

SELECT MAX(MagicWandSize) AS LongestMagicWand  
  FROM [WizzardDeposits]

--3.Longest Magic Wand Per Deposit Groups

  SELECT [DepositGroup], MAX(MagicWandSize) AS [LongestMagicWand]
    FROM [WizzardDeposits]  
GROUP BY [DepositGroup] 

--4.Smallest Deposit Group Per Magic Wand Size

  SELECT
     TOP 2 [DepositGroup]  
    FROM [WizzardDeposits]  
GROUP BY [DepositGroup]  
ORDER BY AVG([MagicWandSize]) ASC 

--5.Deposits Sum

  SELECT [DepositGroup], 
         SUM([DepositAmount])
	  AS [TotalSum]  
    FROM [WizzardDeposits]  
GROUP BY [DepositGroup]

--6.Deposits Sum for Ollivander Family

SELECT [DepositGroup],
       SUM([DepositAmount]) 
    AS [TotalSum]  
  FROM [WizzardDeposits]  
 WHERE [MagicWandCreator] = 'Ollivander family'  
GROUP BY [DepositGroup]

--7.Deposits Filter

  SELECT [DepositGroup],
         SUM([DepositAmount])
      AS [TotalSum]  
    FROM [WizzardDeposits]  
   WHERE [MagicWandCreator] = 'Ollivander family'  
GROUP BY [DepositGroup]  
  HAVING SUM([DepositAmount]) < 150000  
ORDER BY [TotalSum] DESC

--8. Deposit Charge

  SELECT [DepositGroup], 
         [MagicWandCreator], 
  	     MIN([DepositCharge])
	  AS [MinDepositCharge]  
    FROM [WizzardDeposits]  
GROUP BY [DepositGroup], 
         [MagicWandCreator]  
ORDER BY [MagicWandCreator] ASC,
         [DepositGroup] ASC

--9.Age Groups

  SELECT  
         CASE  
              WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]'  
              WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'  
              WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'  
              WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'  
              WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'  
              WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'  
              ELSE '[61+]'  
         END AS [AgeGroup],  
         COUNT(*) AS [WizardCount]  
    FROM [WizzardDeposits]  
GROUP BY  
         CASE  
              WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]'  
              WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'  
              WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'  
              WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'  
              WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'  
              WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'  
              ELSE '[61+]'  
         END  
ORDER BY [AgeGroup]

--10.First Letter

  SELECT LEFT([FirstName], 1) AS [FirstLetter]  
    FROM [WizzardDeposits]  
   WHERE [DepositGroup] = 'Troll Chest'  
GROUP BY LEFT([FirstName], 1)  
ORDER BY [FirstLetter] ASC

--11.Average Interest 

  SELECT [DepositGroup],  
         [IsDepositExpired],  
         AVG([DepositInterest])
	  AS [AverageInterest]  
    FROM [WizzardDeposits]  
   WHERE [DepositStartDate] > '1985-01-01'  
GROUP BY [DepositGroup],
         [IsDepositExpired]  
ORDER BY [DepositGroup] DESC,
         [IsDepositExpired] ASC 

--12.*Rich Wizard, Poor Wizard

SELECT SUM(CurrentWizard.[DepositAmount] - NextWizard.[DepositAmount])
    AS [SumDifference]
  FROM [WizzardDeposits] AS CurrentWizard
  JOIN [WizzardDeposits] AS NextWizard
    ON CurrentWizard.ID = NextWizard.ID - 1

--13.Departments Total Salaries

  SELECT [DepartmentID],
         SUM([Salary])
	  AS [TotalSalary]
    FROM [Employees]
GROUP BY [DepartmentID]
ORDER BY [DepartmentID]

--14.Employees Minimum Salaries

  SELECT [DepartmentID],
         MIN([Salary])
	  AS [MinimumSalary]
    FROM [Employees]
   WHERE [DepartmentID] IN (2, 5, 7)
     AND [HireDate] > '2000-01-01'
GROUP BY [DepartmentID]

--15.Employees Average Salaries

SELECT * 
  INTO [NewEmployeesTable]
  FROM [Employees]
 WHERE [Salary] > 30000
 
DELETE FROM [NewEmployeesTable]
      WHERE [ManagerID] = 42

UPDATE [NewEmployeesTable]
   SET [Salary] = [Salary] + 5000
 WHERE [DepartmentID] = 1

  SELECT [DepartmentID], AVG([Salary]) AS [AverageSalary]
    FROM [NewEmployeesTable]
GROUP BY [DepartmentID]

--16.Employees Maximum Salaries

 SELECT [DepartmentID],
         MAX([Salary])  
      AS [MaxSalary]
    FROM [Employees]
GROUP BY [DepartmentID]
  HAVING MAX([Salary]) NOT BETWEEN 30000 AND 70000

--17.Employees Count Salaries

SELECT COUNT(*) AS [Count]
FROM [Employees]
WHERE [ManagerID] IS NULL

--18.*3rd Highest Salary

  SELECT [DepartmentID],
         [Salary] 
	  AS [ThirdHighestSalary]
    FROM (
          SELECT 
                 [DepartmentID],
                 [Salary],
                 DENSE_RANK () OVER (PARTITION BY [DepartmentID] ORDER BY [Salary] DESC)
              AS [RowNumber]
            FROM [Employees]
         )
      AS [TempTable]
   WHERE [RowNumber] = 3
GROUP BY [DepartmentID],
         [Salary]

--19.**Salary Challenge

  SELECT 
     TOP 10
         [FirstName],
         [LastName],
         [DepartmentID]
    FROM [Employees] e
   WHERE [Salary] > (
                     SELECT AVG([Salary])
                     FROM [Employees]
                     WHERE [DepartmentID] = e.[DepartmentID]
                    )
ORDER BY [DepartmentID]
