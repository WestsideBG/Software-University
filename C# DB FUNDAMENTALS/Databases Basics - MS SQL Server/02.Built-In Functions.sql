--01
--Write a SQL query to find first and last names of all employees whose first name starts with “SA”. 

SELECT FirstName, 
       LastName
FROM Employees
WHERE FirstName LIKE 'sa%';

--02
--Write a SQL query to find first and last names of all employees whose last name contains “ei”. 

SELECT FirstName, 
       LastName
FROM Employees
WHERE LastName LIKE '%ei%';

--03
--Write a SQL query to find the first names of all employees in the departments with ID 3 or 10 and whose hire year is between 1995 and 2005 inclusive.
SELECT FirstName
FROM Employees
WHERE DepartmentID = 3
      OR DepartmentID = 10
      AND HireDate BETWEEN '1995-01-01' AND '2005-12-31';

--04
--Write a SQL query to find the first and last names of all employees whose job titles does not contain “engineer”. 

SELECT FirstName, 
       LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%';

--05
--Write a SQL query to find town names that are 5 or 6 symbols long and order them alphabetically by town name.

SELECT [Name]
FROM Towns
WHERE LEN([Name]) = 5
      OR LEN([Name]) = 6
ORDER BY [Name];

--06
--Write a SQL query to find all towns that start with letters M, K, B or E. Order them alphabetically by town name

SELECT TownID, 
       [Name]
FROM Towns
WHERE [Name] LIKE 'M%'
      OR [Name] LIKE 'B%'
      OR [Name] LIKE 'K%'
      OR [Name] LIKE 'E%'
ORDER BY [Name];

--07
--Write a SQL query to find all towns that does not start with letters R, B or D. Order them alphabetically by name. 

SELECT TownID, 
       [Name]
FROM Towns
WHERE [Name] NOT LIKE 'R%'
      AND [Name] NOT LIKE 'B%'
      AND [Name] NOT LIKE 'D%'
ORDER BY [Name];

--08
--Write a SQL query to create view V_EmployeesHiredAfter2000 with first and last name to all employees hired after 2000 year. 

CREATE VIEW V_EmployeesHiredAfter2000
AS
     SELECT FirstName, 
            LastName
     FROM Employees
     WHERE YEAR(HireDate) > 2000;

--09
--Write a SQL query to find the names of all employees whose last name is exactly 5 characters long.

SELECT FirstName, 
       LastName
FROM Employees
WHERE LEN(LastName) = 5;

--10
--Find all countries that holds the letter 'A' in their name at least 3 times (case insensitively), sorted by ISO code. Display the country name and ISO code. 

SELECT CountryName, 
       IsoCode
FROM Countries
WHERE CountryName LIKE '%A%A%A%'
ORDER BY IsoCode;

--11
--Combine all peak names with all river names, so that the last letter of each peak name is the same as the first letter of its corresponding river name. 
--Display the peak names, river names, and the obtained mix (mix should be in lowercase). 
--Sort the results by the obtained mix.

SELECT PeakName, 
       RiverName, 
       LOWER(CONCAT(LEFT(PeakName, LEN(PeakName) - 1), RiverName)) AS Mix
FROM Peaks, 
     Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix;

--12
--Find the top 50 games ordered by start date, then by name of the game. 
--Display only games from 2011 and 2012 year. 
--Display start date in the format “yyyy-MM-dd”. 

SELECT TOP (50) Name, 
                FORMAT(Start, 'yyyy-MM-dd') AS Start
FROM Games
WHERE Start >= '2011-01-01'
      AND Start <= '2012-12-31'
ORDER BY Start, 
         Name;

--13
--Find all users along with information about their email providers. 
--Display the username and email provider. 
--Sort the results by email provider alphabetically, then by username. 

SELECT Username, 
       SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider]
FROM Users
ORDER BY [Email Provider], 
         Username;

--14
--Find all users along with their IP addresses sorted by username alphabetically. 
--Display only rows that IP address matches the pattern: “***.1^.^.***”. 
--Legend: * - one symbol, ^ - one or more symbols

SELECT Username, 
       IpAddress
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username;

--15
--Find all games with part of the day and duration sorted by game name alphabetically then by duration (alphabetically, not by the timespan) and part of the day (all ascending). 
--Parts of the day should be
-- Morning (time is >= 0 and < 12),
-- Afternoon (time is >= 12 and < 18),
-- Evening (time is >= 18 and < 24). 
--Duration should be
-- Extra Short (smaller or equal to 3),
-- Short (between 4 and 6 including),
-- Long (greater than 6) and Extra Long (without duration). 

SELECT [Name] AS Game,
       CASE
           WHEN DATEPART(HOUR, Start) >= 0
                AND DATEPART(HOUR, Start) < 12
           THEN 'Morning'
           WHEN DATEPART(HOUR, Start) >= 12
                AND DATEPART(HOUR, Start) < 18
           THEN 'Afternoon'
           WHEN DATEPART(HOUR, Start) >= 18
                AND DATEPART(HOUR, Start) < 24
           THEN 'Evening'
       END AS [Part of the day],
       CASE
           WHEN Duration <= 3
           THEN 'Extra Short'
           WHEN Duration BETWEEN 4 AND 6
           THEN 'Short'
           WHEN Duration > 6
           THEN 'Long'
           ELSE 'Extra Long'
       END AS [Duration]
FROM Games
ORDER BY [Name], 
         [Duration], 
         [Part of the day];

--16
--You are given a table Orders(Id, ProductName, OrderDate) filled with data. 
--Consider that the payment for that order must be accomplished within 3 days after the order date. 
--Also the delivery date is up to 1 month. 
--Write a query to show each product’s name, order date, pay and deliver due dates. 

SELECT ProductName, 
       OrderDate, 
       DATEADD(DAY, 3, OrderDate) AS [Pay Due], 
       DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders;