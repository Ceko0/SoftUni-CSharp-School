--1.Employee Address
  SELECT 
         [EmployeeId], 
         [JobTitle], 
         e.[AddressID] 
  	  AS [AddressId], 
         [AddressText]
    FROM [Employees] e
    JOIN [Addresses] a 
      ON e.[AddressId] = a.[AddressId]
ORDER BY e.[AddressId] ASC
OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY

--2.Addresses with Towns

  SELECT TOP 50 
         e.[FirstName], 
         e.[LastName], 
         t.[Name] AS Town, 
         a.[AddressText]
    FROM [Employees] e
    JOIN [Addresses] a ON e.[AddressId] = a.[AddressId]
    JOIN [Towns] t ON a.[TownId] = t.[TownId]
ORDER BY e.[FirstName] ASC, e.[LastName] ASC

--3.Sales Employee

  SELECT 
         e.[EmployeeID], 
         e.[FirstName], 
         e.[LastName], 
         d.[Name]
    FROM [Employees] e
    JOIN [Departments] d ON e.[DepartmentID] = d.[DepartmentID]
   WHERE d.[Name] = 'Sales'
ORDER BY e.[EmployeeID] ASC

--4.Employee Departments

  SELECT
     TOP 5 
         e.[EmployeeID], 
         e.[FirstName], 
         e.[Salary], 
         d.[Name]
    FROM [Employees] e
    JOIN [Departments] d ON e.[DepartmentID] = d.[DepartmentID]
   WHERE e.[Salary] > 15000
ORDER BY e.[DepartmentID] ASC

--5.Employees Without Project

   SELECT
      TOP 3 
          e.[EmployeeID], 
          e.[FirstName]
     FROM [Employees] e
LEFT JOIN [EmployeesProjects] ep ON e.[EmployeeID] = ep.[EmployeeID]
    WHERE ep.[ProjectID] IS NULL
 ORDER BY e.[EmployeeID] ASC
 
--6.Employees Hired After

  SELECT 
         e.[FirstName], 
         e.[LastName], 
         e.[HireDate], 
         d.[Name] AS DeptName
    FROM [Employees] e
    JOIN [Departments] d ON e.[DepartmentID] = d.[DepartmentID]
   WHERE e.[HireDate] > '1999-01-01'
     AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.[HireDate] ASC

--7.Employees with Project

  SELECT
     TOP 5 
         e.[EmployeeID], 
         e.[FirstName], 
         p.[Name]
    FROM [Employees] e
    JOIN [EmployeesProjects] ep ON e.[EmployeeID] = ep.[EmployeeID]
    JOIN [Projects] p ON ep.[ProjectID] = p.[ProjectID]
   WHERE p.[StartDate] > '2002-08-13'
     AND p.[EndDate] IS NULL
ORDER BY e.[EmployeeID] ASC

--8.Employee 24

SELECT 
       e.[EmployeeID], 
       e.[FirstName], 
       CASE 
           WHEN p.[StartDate] >= '2005-01-01' THEN NULL
           ELSE p.[Name]
       END AS [ProjectName]
  FROM [Employees] e
  JOIN [EmployeesProjects] ep ON e.[EmployeeID] = ep.[EmployeeID]
  JOIN [Projects] p ON ep.[ProjectID] = p.[ProjectID]
 WHERE e.[EmployeeID] = 24

--9.Employee Manager

  SELECT 
         e.[EmployeeID], 
         e.[FirstName], 
         e.[ManagerID], 
         m.[FirstName] AS ManagerName
    FROM [Employees] e
    JOIN [Employees] m ON e.[ManagerID] = m.[EmployeeID]
   WHERE e.[ManagerID] IN (3, 7)
ORDER BY e.[EmployeeID] ASC


--10.Employees Summary

    SELECT
       TOP 50
           e.[EmployeeID],
           e.[FirstName] + ' ' + e.[LastName] AS EmployeeName,
           m.[FirstName] + ' ' + m.[LastName] AS ManagerName,
           d.[Name]
     FROM [Employees] e
LEFT JOIN [Employees] m ON e.[ManagerID] = m.[EmployeeID]
     JOIN [Departments] d ON e.[DepartmentID] = d.[DepartmentID]
 ORDER BY e.[EmployeeID]

--11.Min Average Salary

SELECT MIN(AverageSalary) AS MinAverageSalary
  FROM (
          SELECT AVG(e.[Salary]) AS AverageSalary
            FROM [Employees] e
        GROUP BY e.[DepartmentID]
       )
    AS DepartmentAverages

--12.Highest Peaks in Bulgaria

  SELECT 
         cm.[CountryCode], 
         m.[MountainRange], 
         p.[PeakName], 
         p.[Elevation]
    FROM [Peaks] p
    JOIN [MountainsCountries] cm ON p.[MountainId] = cm.[MountainId]
    JOIN [Mountains] m ON p.[MountainId] = m.[ID]
   WHERE cm.[CountryCode] = 'BG'  
     AND p.[Elevation] > 2835
ORDER BY p.[Elevation] DESC

--13.Count Mountain Ranges

  SELECT 
         cm.[CountryCode], 
   COUNT(DISTINCT m.[MountainRange])
      AS MountainRangeCount
    FROM [MountainsCountries] cm
    JOIN [Mountains] m ON cm.[MountainId] = m.[ID]
   WHERE cm.[CountryCode] IN ('US', 'RU', 'BG')
GROUP BY cm.[CountryCode]

--14.Countries With or Without Rivers

SELECT TOP 5
    c.[CountryName], 
    r.[RiverName]
FROM [Countries] c
LEFT JOIN [CountriesRivers] cr ON c.[CountryCode] = cr.[CountryCode]
LEFT JOIN [Rivers] r ON cr.[RiverID] = r.[ID]
WHERE c.[ContinentCode] = 'AF' 
ORDER BY c.[CountryName] ASC

--15.*Continents and Currencies

WITH CurrencyCount AS (
      SELECT 
             c.[ContinentCode], 
             c.[CurrencyCode], 
             COUNT(c.[CountryCode]) AS CountryCount
        FROM [Countries] c
    GROUP BY c.[ContinentCode], c.[CurrencyCode]
      HAVING COUNT(c.[CountryCode]) > 1
),
MaxCurrencyUsage AS (
    SELECT
           [ContinentCode], 
           MAX(CountryCount) AS MaxUsage
      FROM CurrencyCount
  GROUP BY [ContinentCode]
)

  SELECT 
         cc.[ContinentCode], 
         cc.[CurrencyCode], 
         cc.CountryCount AS CurrencyUsage
    FROM CurrencyCount cc
    JOIN MaxCurrencyUsage mu ON cc.[ContinentCode] = mu.[ContinentCode] 
     AND cc.CountryCount = mu.MaxUsage
ORDER BY cc.[ContinentCode]

--16.Countries Without Any Mountains

   SELECT COUNT(*) AS Count
     FROM [Countries] c
LEFT JOIN [MountainsCountries] mc ON c.CountryCode = mc.CountryCode
    WHERE mc.MountainId IS NULL

--17.Highest Peak and Longest River by Country

   SELECT 
          c.[CountryName],
          MAX(p.[Elevation]) AS [HighestPeakElevation],
          MAX(r.[Length]) AS [LongestRiverLength]
     FROM 
          [Countries] c
LEFT JOIN 
          [MountainsCountries] mc ON c.[CountryCode] = mc.[CountryCode]
LEFT JOIN 
          [Mountains] m ON mc.[MountainId] = m.[Id]
LEFT JOIN 
          [Peaks] p ON m.[Id] = p.[MountainId]
LEFT JOIN 
          [CountriesRivers] rc ON c.[CountryCode] = rc.[CountryCode]
LEFT JOIN 
          [Rivers] r ON rc.[RiverId] = r.[Id]
 GROUP BY 
          c.[CountryName]
 ORDER BY 
          [HighestPeakElevation] DESC, 
          [LongestRiverLength] DESC, 
          c.[CountryName]
OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY

--18.Highest Peak Name and Elevation by Country

   SELECT c.[CountryName] AS [Country],
          ISNULL(p.[PeakName], '(no highest peak)') AS [Highest Peak Name],
          ISNULL(p.[Elevation], 0) AS [Highest Peak Elevation],
          ISNULL(m.[MountainRange], '(no mountain)') AS [Mountain]
     FROM [Countries] c
LEFT JOIN [MountainsCountries] mc ON c.[CountryCode] = mc.[CountryCode]
LEFT JOIN [Mountains] m ON mc.[MountainId] = m.[Id]
LEFT JOIN [Peaks] p ON m.[Id] = p.[MountainId] AND p.[Elevation] = 
           (SELECT MAX([Elevation]) 
              FROM [Peaks] 
             WHERE [MountainId] = m.[Id]
		 	)
 ORDER BY c.[CountryName] ASC, 
          [Highest Peak Name] ASC
OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY