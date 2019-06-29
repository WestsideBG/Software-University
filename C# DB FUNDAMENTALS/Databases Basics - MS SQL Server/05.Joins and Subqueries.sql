--Problem 1.	Employee Address
--Write a query that selects:
--•	EmployeeId
--•	JobTitle
--•	AddressId
--•	AddressText
--Return the first 5 rows sorted by AddressId in ascending order.
SELECT TOP (5) emp.EmployeeID, 
               emp.JobTitle, 
               adr.AddressID, 
               adr.AddressText
FROM Employees AS emp
     JOIN Addresses AS adr ON adr.AddressID = emp.AddressID
ORDER BY emp.AddressID;

--Problem 2.	Addresses with Towns
--Write a query that selects:
--•	FirstName
--•	LastName
--•	Town
--•	AddressText
--Sorted by FirstName in ascending order then by LastName. Select first 50 employees.
SELECT TOP (50) emp.FirstName, 
                emp.LastName, 
                t.[Name], 
                adr.AddressText
FROM Employees AS emp
     JOIN Addresses AS adr ON adr.AddressID = emp.AddressID
     JOIN Towns AS t ON t.TownID = adr.TownID
ORDER BY emp.FirstName, 
         emp.LastName;

--Problem 3.	Sales Employee
--Write a query that selects:
--•	EmployeeID
--•	FirstName
--•	LastName
--•	DepartmentName
--Sorted by EmployeeID in ascending order. Select only employees from “Sales” department.
SELECT emp.EmployeeID, 
       emp.FirstName, 
       emp.LastName, 
       dept.[Name]
FROM Employees AS emp
     JOIN Departments AS dept ON dept.DepartmentID = emp.DepartmentID
WHERE dept.[Name] = 'Sales'
ORDER BY emp.EmployeeID;

--Problem 4.	Employee Departments
--Write a query that selects:
--•	EmployeeID
--•	FirstName
--•	Salary
--•	DepartmentName
--Filter only employees with salary higher than 15000. Return the first 5 rows sorted by DepartmentID in ascending order.
SELECT TOP (5) EmployeeID, 
               FirstName, 
               Salary, 
               dept.[Name]
FROM Employees AS emp
     JOIN Departments AS dept ON dept.DepartmentID = emp.DepartmentID
WHERE Salary > 15000
ORDER BY dept.DepartmentID;

--Problem 5.	Employees Without Project
--Write a query that selects:
--•	EmployeeID
--•	FirstName
--Filter only employees without a project. Return the first 3 rows sorted by EmployeeID in ascending order.
SELECT TOP (3) e.EmployeeID, 
               e.FirstName
FROM Employees AS e
     FULL JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
WHERE ep.EmployeeID IS NULL;

--Problem 6.	Employees Hired After
--Write a query that selects:
--•	FirstName
--•	LastName
--•	HireDate
--•	DeptName
--Filter only employees hired after 1.1.1999 and are from either "Sales" or "Finance" departments, sorted by HireDate (ascending).
SELECT FirstName, 
       LastName, 
       HireDate, 
       dept.[Name]
FROM Employees AS emp
     JOIN Departments AS dept ON dept.DepartmentID = emp.DepartmentID
WHERE HireDate > '01.01.1999'
      AND dept.[Name] = 'Sales'
      OR dept.[Name] = 'Finance'
ORDER BY HireDate;

--Problem 7.	Employees with Project
--Write a query that selects:
--•	EmployeeID
--•	FirstName
--•	ProjectName
--Filter only employees with a project which has started after 13.08.2002 and it is still ongoing (no end date). Return the first 5 rows sorted by EmployeeID in ascending order.
SELECT TOP 5 e.EmployeeID, 
             e.FirstName, 
             p.Name
FROM Employees AS e
     JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
     JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE p.StartDate > CONVERT(DATE, '13.08.2002', 104)
      AND p.EndDate IS NULL
ORDER BY e.EmployeeID;

--Problem 8.	Employee 24
--Write a query that selects:
--•	EmployeeID
--•	FirstName
--•	ProjectName
--Filter all the projects of employee with Id 24. If the project has started during or after 2005 the returned value should be NULL.
SELECT e.EmployeeID, 
       FirstName,
       CASE
           WHEN YEAR(p.StartDate) >= '2005'
           THEN NULL
           ELSE p.Name
       END AS [ProjectName]
FROM Employees AS e
     JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
     JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE ep.EmployeeID = 24;

--Problem 9.	Employee Manager
--Write a query that selects:
--•	EmployeeID
--•	FirstName
--•	ManagerID
--•	ManagerName
--Filter all employees with a manager who has ID equals to 3 or 7. Return all the rows, sorted by EmployeeID in ascending order.
SELECT e.EmployeeID, 
       e.FirstName, 
       e.ManagerID, 
       m.FirstName
FROM Employees AS e
     JOIN Employees AS m ON e.ManagerID = m.EmployeeID
WHERE m.EmployeeID IN(3, 7)
ORDER BY e.EmployeeID;

--Problem 10.	Employee Summary
--Write a query that selects:
--•	EmployeeID
--•	EmployeeName
--•	ManagerName
--•	DepartmentName
--Show first 50 employees with their managers and the departments they are in (show the departments of the employees). Order by EmployeeID.
SELECT TOP 50 e.EmployeeID, 
              e.FirstName + ' ' + e.LastName AS EmployeeName, 
              m.FirstName + ' ' + m.LastName AS ManagerName, 
              d.Name
FROM Employees AS e
     JOIN Employees AS m ON e.ManagerID = m.EmployeeID
     JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID;

--Problem 11.	Min Average Salary
--Write a query that returns the value of the lowest average salary of all departments.
SELECT MIN(t.AVGSALARY) AS MinAverageSalary
FROM
(
    SELECT AVG(Salary) AS AVGSALARY
    FROM Employees AS emp
    GROUP BY DepartmentID
) AS t;

--Problem 12.	Highest Peaks in Bulgaria
--Write a query that selects:
--•	CountryCode
--•	MountainRange
--•	PeakName
--•	Elevation
--Filter all peaks in Bulgaria with elevation over 2835. Return all the rows sorted by elevation in descending order.
SELECT c.CountryCode, 
       m.MountainRange, 
       p.PeakName, 
       p.Elevation
FROM Countries AS c
     JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
     JOIN Mountains AS m ON mc.MountainId = m.Id
     JOIN Peaks AS p ON m.Id = p.MountainId
WHERE p.Elevation > 2835
      AND c.CountryCode = 'BG'
ORDER BY p.Elevation DESC;

--Problem 13.	Count Mountain Ranges
--Write a query that selects:
--•	CountryCode
--•	MountainRanges
--Filter the count of the mountain ranges in the United States, Russia and Bulgaria.
SELECT CountryCode, 
       COUNT(*) AS [Range]
FROM Mountains AS m
     JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
WHERE CountryCode IN('BG', 'RU', 'US')
GROUP BY CountryCode;

--Problem 14.	Countries with Rivers
--Write a query that selects:
--•	CountryName
--•	RiverName
--Find the first 5 countries with or without rivers in Africa. Sort them by CountryName in ascending order.
SELECT TOP 5 CountryName, 
             r.RiverName
FROM Countries AS c
     LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
     LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
WHERE ContinentCode = 'AF'
ORDER BY CountryName;

--Problem 15.	*Continents and Currencies
--Write a query that selects:
--•	ContinentCode
--•	CurrencyCode
--•	CurrencyUsage
--Find all continents and their most used currency. Filter any currency that is used in only one country. Sort your results by ContinentCode.
SELECT k.ContinentCode, 
       k.CurrencyCode, 
       k.CurrencyUsage
FROM
(
    SELECT c.ContinentCode, 
           c.CurrencyCode, 
           COUNT(c.CurrencyCode) AS CurrencyUsage, 
           DENSE_RANK() OVER(PARTITION BY c.ContinentCode
           ORDER BY COUNT(c.CurrencyCode) DESC) AS CurrencyRank
    FROM Countries AS c
    GROUP BY c.ContinentCode, 
             c.CurrencyCode
    HAVING COUNT(c.CurrencyCode) > 1
) AS k
WHERE k.CurrencyRank = 1
ORDER BY k.ContinentCode;

--Problem 16.	Countries without any Mountains
--Write a query that selects CountryCode. Find all the count of all countries, which don’t have a mountain.
SELECT COUNT(*) AS CountryCode
FROM
(
    SELECT m.Id
    FROM Countries AS c
         LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
         LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
    WHERE m.Id IS NULL
) AS k;

--Problem 17.	Highest Peak and Longest River by Country
--For each country, find the elevation of the highest peak and the length of the longest river, sorted by the highest peak elevation (from highest to lowest),
-- then by the longest river length (from longest to smallest), 
-- then by country name (alphabetically). 
--Display NULL when no data is available in some of the columns. Limit only the first 5 rows.
SELECT TOP 5 c.CountryName, 
             MAX(p.Elevation) AS HighestPeakElevation, 
             MAX(r.Length) AS LongestRiverLength
FROM Countries AS c
     JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
     JOIN Rivers AS r ON r.Id = cr.RiverId
     JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
     JOIN Mountains AS m ON m.Id = mc.MountainId
     JOIN Peaks AS p ON p.MountainId = m.Id
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, 
         LongestRiverLength DESC, 
         c.CountryName;

--Problem 18.	*Highest Peak Name and Elevation by Country
--For each country, find the name and elevation of the highest peak, along with its mountain.
--When no peaks are available in some country, display elevation 0, "(no highest peak)" as peak name and "(no mountain)" as mountain name.
--When multiple peaks in some country have the same elevation, display all of them. 
--Sort the results by country name alphabetically, then by highest peak name alphabetically. Limit only the first 5 rows.
SELECT TOP 5 k.CountryName, 
             ISNULL(k.[Highest Peak Name], '(no highest peak)'), 
             ISNULL(k.[Highest Peak Elevation], 0), 
             ISNULL(k.Mountain, '(no mountain)')
FROM
(
    SELECT c.CountryName, 
           p.PeakName [Highest Peak Name], 
           MAX(p.Elevation) [Highest Peak Elevation], 
           m.MountainRange Mountain, 
           DENSE_RANK() OVER(PARTITION BY c.CountryName
           ORDER BY MAX(p.Elevation) DESC) AS [Rank]
    FROM Countries AS c
         LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
         LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
         LEFT JOIN Peaks AS p ON p.MountainId = m.Id
    GROUP BY c.CountryName, 
             p.PeakName, 
             m.MountainRange
) AS k
WHERE k.Rank = 1
ORDER BY k.CountryName, 
         k.[Highest Peak Name];