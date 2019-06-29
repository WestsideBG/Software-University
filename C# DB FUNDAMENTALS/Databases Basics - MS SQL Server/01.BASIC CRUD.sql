-- 02
--Write a SQL query to find all available information about the Departments. Submit your query statements as Prepare DB & run queries.
SELECT *
FROM Departments;

-- 03
--Write SQL query to find all Department names. Submit your query statements as Prepare DB & run queries.
SELECT Name
FROM Departments;

-- 04
--Write SQL query to find the first name, last name and salary of each employee. 
--Submit your query statements as Prepare DB & run queries.
SELECT FirstName, 
       LastName, 
       Salary
FROM Employees;

--05
--Write SQL query to find the first, middle and last name of each employee. 
--Submit your query statements as Prepare DB & run queries.

SELECT FirstName, 
       MiddleName, 
       LastName
FROM Employees;

--06
--Write a SQL query to find the email address of each employee. 
--(by his first and last name). 
--Consider that the email domain is softuni.bg. 
--Emails should look like “John.Doe@softuni.bg". 
--The produced column should be named "Full Email Address". 
--Submit your query statements as Prepare DB & run queries.

SELECT FirstName + '.' + LastName + '@softuni.bg' AS [Full Email Address]
FROM Employees;

--07
--Write a SQL query to find all different employee’s salaries. 
--Show only the salaries. Submit your query statements as Prepare DB & run queries.
SELECT DISTINCT 
       Salary
FROM Employees;

--08
--Write a SQL query to find all information about the employees whose job title is “Sales Representative”. 
--Submit your query statements as Prepare DB & run queries.
SELECT *
FROM Employees
WHERE JobTitle = 'Sales Representative';

--09
--Write a SQL query to find the first name, last name and job title of all employees whose salary is in the range [20000, 30000]. 
--Submit your query statements as Prepare DB & run queries.

SELECT FirstName, 
       LastName, 
       JobTitle
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000;

--10
--Write a SQL query to find the full name of all employees whose salary is 25000, 14000, 12500 or 23600. 
--Full Name is combination of first, middle and last name (separated with single space) and they should be in one column called “Full Name”. 
--Submit your query statements as Prepare DB & run queries.
SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name]
FROM Employees
WHERE Salary IN(25000, 14000, 12500, 23600);

--11
--Write a SQL query to find first and last names about those employees that does not have a manager. 
--Submit your query statements as Prepare DB & run queries.
SELECT FirstName, 
       LastName
FROM Employees
WHERE ManagerID IS NULL;

--12
--Write a SQL query to find first name, last name and salary of those employees who has salary more than 50000. 
--Order them in decreasing order by salary. Submit your query statements as Prepare DB & run queries.
SELECT FirstName, 
       LastName, 
       Salary
FROM Employees
WHERE Salary > 50000
ORDER BY SALARY DESC;

--13
--Write SQL query to find first and last names about 5 best paid Employees ordered descending by their salary. 
--Submit your query statements as Prepare DB & run queries.
SELECT TOP (5) FirstName, 
               LastName
FROM Employees
ORDER BY SALARY DESC;

--14
--Write a SQL query to find the first and last names of all employees whose department ID is different from 4. 
--Submit your query statements as Prepare DB & run queries.
SELECT FirstName, 
       LastName
FROM Employees
WHERE NOT DepartmentID = 4;

--15
--Write a SQL query to sort all records in the Employees table by the following criteria: 
--•	First by salary in decreasing order
--•	Then by first name alphabetically
--•	Then by last name descending
--•	Then by middle name alphabetically
--Submit your query statements as Prepare DB & run queries.

SELECT *
FROM Employees
ORDER BY Salary DESC, 
         FirstName, 
         LastName DESC, 
         MiddleName;

--16
--Write a SQL query to create a view V_EmployeesSalaries with first name, last name and salary for each employee. 
--Submit your query statements as Run skeleton, run queries & check DB.

CREATE VIEW V_EmployeesSalaries
AS
     SELECT FirstName, 
            LastName, 
            Salary
     FROM Employees;

--17
--Write a SQL query to create view V_EmployeeNameJobTitle with full employee name and job title. 
--When middle name is NULL replace it with empty string (‘’). 
--Submit your query statements as Run skeleton, run queries & check DB.

CREATE VIEW V_EmployeeNameJobTitle
AS
     SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS [Full Name], 
            JobTitle
     FROM Employees;

--18
--Write a SQL query to find all distinct job titles. 
--Submit your query statements as Prepare DB & run queries.
SELECT DISTINCT 
       JobTitle
FROM Employees;

--19
--Write a SQL query to find first 10 started projects. 
--Select all information about them and sort them by start date, then by name. 
--Submit your query statements as Prepare DB & run queries.

SELECT TOP (10) *
FROM Projects
ORDER BY StartDate, 
         [Name];

--20
--Write a SQL query to find last 7 hired employees. 
--Select their first, last name and their hire date. 
--Submit your query statements as Prepare DB & run queries.

SELECT TOP (7) FirstName, 
               LastName, 
               HireDate
FROM Employees
ORDER BY HireDate DESC;

--21
--Write a SQL query to increase salaries of all employees that are in the Engineering, Tool Design, Marketing or Information Services department by 12%. 
--Then select Salaries column from the Employees table. 
--After that exercise restore your database to revert those changes. 
--Submit your query statements as Prepare DB & run queries.

UPDATE Employees
  SET 
      Salary*=1.12
WHERE DepartmentID IN(1, 2, 4, 11);
SELECT Salary
FROM Employees;

--22
--Display all mountain peaks in alphabetical order. 
--Submit your query statements as Prepare DB & run queries.
SELECT PeakName
FROM Peaks
ORDER BY PeakName;

--23
--Find the 30 biggest countries by population from Europe. 
--Display the country name and population. 
--Sort the results by population (from biggest to smallest), then by country alphabetically. 
--Submit your query statements as Prepare DB & run queries.

SELECT TOP (30) CountryName, 
                Population
FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY Population DESC;

--24
--Find all countries along with information about their currency. 
--Display the country code, country name and information about its currency: either "Euro" or "Not Euro". 
--Sort the results by country name alphabetically. 
--Submit your query statements as Prepare DB & run queries.

SELECT CountryName, 
       CountryCode,
       CASE
           WHEN CurrencyCode = 'EUR'
           THEN 'Euro'
           ELSE 'Not Euro'
       END AS Currency
FROM Countries
ORDER BY CountryName;

--25
--Display all characters in alphabetical order. 
--Submit your query statements as Prepare DB & run queries.
SELECT [Name]
FROM Characters
ORDER BY [NAME];