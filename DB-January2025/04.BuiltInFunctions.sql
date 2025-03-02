--1.Find Names of All Employees by First Name

SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE [FirstName] LIKE 'Sa%'

--2.Find Names of All Employees by Last Name 

SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE [LastName] LIKE '%ei%'

--3.Find First Names of All Employees

SELECT [FirstName]
  FROM [Employees]
 WHERE [DepartmentID] IN (3, 10)
       AND YEAR([HireDate]) BETWEEN 1995 AND 2005

--4.Find All Employees Except Engineers

SELECT [FirstName], [LastName]
  FROM [Employees]
 WHERE [JobTitle] NOT LIKE '%engineer%'

--5.Find Towns with Name Length

  SELECT [Name]
    FROM [Towns]
   WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name]

--6.Find Towns Starting With

  SELECT [TownID], [Name]
    FROM [Towns]
   WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name]

--7.Find Towns Not Starting With

  SELECT [TownID], [Name]
    FROM [Towns]
   WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
ORDER BY [Name]

--8.Create View Employees Hired After 2000 Year

CREATE VIEW V_EmployeesHiredAfter2000 AS
     SELECT [FirstName], [LastName]
       FROM [Employees]
      WHERE YEAR([HireDate]) > 2000

--9.Length of Last Name

SELECT [FirstName], [LastName]
FROM [Employees]
WHERE LEN([LastName]) = 5

--10.Rank Employees by Salary

  SELECT [EmployeeID], [FirstName], [LastName], [Salary], 
         DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID])
	  AS [Rank]
    FROM [Employees]
   WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC

--11.Find All Employees with Rank 2

   SELECT [EmployeeID], [FirstName], [LastName], [Salary], [Rank]
    FROM (
          SELECT [EmployeeID], [FirstName], [LastName], [Salary], 
                 DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) 
			  AS [Rank]
            FROM [Employees]
           WHERE [Salary] BETWEEN 10000 AND 50000
         ) 
      AS [RankedEmployees]
   WHERE [Rank] = 2
ORDER BY [Salary] DESC

--12.Countries Holding 'A' 3 or More Times

  SELECT [CountryName], [ISOCode]
    FROM [Countries]
   WHERE LEN(REPLACE(UPPER([CountryName]), 'A', '')) < LEN([CountryName]) - 2
ORDER BY [ISOCode]

--13.Mix of Peak and River Names

  SELECT [PeakName], [RiverName], 
         LOWER(CONCAT([PeakName], SUBSTRING([RiverName], 2, LEN([RiverName]) - 1)))
	  AS [Mix]
    FROM [Peaks] p
    JOIN [Rivers] r
      ON RIGHT([PeakName], 1) = LEFT([RiverName], 1)
ORDER BY [Mix]

--14.Games from 2011 and 2012 Year

SELECT TOP 50 [Name], 
           FORMAT([Start], 'yyyy-MM-dd') 
	    AS [Start]
      FROM [Games]
     WHERE YEAR([Start]) BETWEEN 2011 AND 2012
  ORDER BY [Start], [Name]

--15.User Email Providers

  SELECT [Username], 
         SUBSTRING([Email], CHARINDEX('@', [Email]) + 1, LEN([Email]))
      AS [Email Provider]
    FROM [Users]
   WHERE [Email] LIKE '%@%'
ORDER BY [Email Provider], [Username]

--16.Get Users with IP Address Like Pattern

  SELECT [Username], [IPAddress]
    FROM [Users]
   WHERE [IPAddress] LIKE '___%.1%._%.___%'
ORDER BY [Username]

--17.Show All Games with Duration and Part of the Day

  SELECT [Name]
      AS [Game], 
    CASE 
    WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
    WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
    WHEN DATEPART(HOUR, [Start]) >= 18 AND DATEPART(HOUR, [Start]) < 24 THEN 'Evening'
  END AS [Part of the Day],
    CASE 
    WHEN [Duration] IS NULL THEN 'Extra Long'
    WHEN [Duration] <= 3 THEN 'Extra Short'
    WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
    WHEN [Duration] > 6 THEN 'Long'
  END AS [Duration]
    FROM [Games]
ORDER BY [Game], [Duration], [Part of the Day]

--18.Orders Table

CREATE TABLE [Orders] (
                       [Id] INT PRIMARY KEY,
                       [ProductName] NVARCHAR(50) NOT NULL,
                       [OrderDate] DATETIME NOT NULL
                      )

GO

INSERT INTO [Orders] ([Id], [ProductName], [OrderDate])
     VALUES (1, 'Butter', '2016-09-19 00:00:00.000'),
            (2, 'Milk', '2016-09-30 00:00:00.000'),
            (3, 'Cheese', '2016-09-04 00:00:00.000'),
            (4, 'Bread', '2015-12-20 00:00:00.000'),
            (5, 'Tomatoes', '2015-01-01 00:00:00.000')

GO

SELECT [ProductName], [OrderDate], 
       DATEADD(DAY, 3, [OrderDate]) AS [PayDueDate],
       DATEADD(MONTH, 1, [OrderDate]) AS [DeliverDueDate]
  FROM [Orders]

--19.People Table

CREATE TABLE [People] (
                       [Id] INT PRIMARY KEY,
                       [Name] NVARCHAR(100),
                       [Birthdate] DATETIME2
                      )

GO

INSERT INTO [People] ([Id], [Name], [Birthdate])
     VALUES (1, 'Victor', '2000-12-07 00:00:00.000'),
            (2, 'Steven', '1992-09-10 00:00:00.000'),
            (3, 'Stephen', '1910-09-19 00:00:00.000'),
            (4, 'John', '2010-01-06 00:00:00.000')

GO

SELECT [Name], 
       DATEDIFF(YEAR, [Birthdate], GETDATE()) AS [Age in Years],
       DATEDIFF(MONTH, [Birthdate], GETDATE()) AS [Age in Months],
       DATEDIFF(DAY, [Birthdate], GETDATE()) AS [Age in Days],
       DATEDIFF(MINUTE, [Birthdate], GETDATE()) AS [Age in Minutes]
 FROM [People]