--1
--Import the database and send the total count of records from the one and only table to Mr. Bodrog. Make sure nothing got lost.

SELECT COUNT(*)
FROM dbo.WizzardDeposits AS [Count];

--2
--Select the size of the longest magic wand. Rename the new column appropriately.

SELECT MAX(WizzardDeposits.MagicWandSize) AS LongestMagicWand
FROM dbo.WizzardDeposits;

--3
--For wizards in each deposit group show the longest magic wand. Rename the new column appropriately.

SELECT WizzardDeposits.DepositGroup, 
       MAX(WizzardDeposits.MagicWandSize) AS LongestMagicWand
FROM dbo.WizzardDeposits
GROUP BY WizzardDeposits.DepositGroup;

--4
--Select the two deposit groups with the lowest average wand size.

SELECT TOP (2) WizzardDeposits.DepositGroup
FROM dbo.WizzardDeposits
GROUP BY WizzardDeposits.DepositGroup
ORDER BY AVG(WizzardDeposits.MagicWandSize);

--5
--Select all deposit groups and their total deposit sums.

SELECT WizzardDeposits.DepositGroup, 
       SUM(WizzardDeposits.DepositAmount) AS TotalSum
FROM dbo.WizzardDeposits
GROUP BY WizzardDeposits.DepositGroup;

--6
--Select all deposit groups and their total deposit sums but only for the wizards who have their magic wands crafted by Ollivander family.

SELECT WizzardDeposits.DepositGroup, 
       SUM(WizzardDeposits.DepositAmount) AS TotalSum
FROM dbo.WizzardDeposits
GROUP BY WizzardDeposits.DepositGroup, 
         WizzardDeposits.MagicWandCreator
HAVING WizzardDeposits.MagicWandCreator = 'Ollivander family';

--7
--Select all deposit groups and their total deposit sums but only for the wizards who have their magic wands crafted by Ollivander family.
--Filter total deposit amounts lower than 150000. Order by total deposit amount in descending order.

SELECT WizzardDeposits.DepositGroup, 
       SUM(WizzardDeposits.DepositAmount) AS TotalSum
FROM dbo.WizzardDeposits
GROUP BY WizzardDeposits.DepositGroup, 
         WizzardDeposits.MagicWandCreator
HAVING WizzardDeposits.MagicWandCreator = 'Ollivander family'
       AND SUM(WizzardDeposits.DepositAmount) < 150000
ORDER BY TotalSum DESC;

--8
--Create a query that selects:
--Deposit group 
--Magic wand creator
--Minimum deposit charge for each group 
--Select the data in ascending ordered by MagicWandCreator and DepositGroup.

SELECT WizzardDeposits.DepositGroup, 
       WizzardDeposits.MagicWandCreator, 
       MIN(WizzardDeposits.DepositCharge) AS MinDepositCharge
FROM dbo.WizzardDeposits
GROUP BY WizzardDeposits.DepositGroup, 
         WizzardDeposits.MagicWandCreator
ORDER BY WizzardDeposits.MagicWandCreator, 
         WizzardDeposits.DepositGroup ASC;

--9
--Write down a query that creates 7 different groups based on their age.
--Age groups should be as follows:
--[0-10]
--[11-20]
--[21-30]
--[31-40]
--[41-50]
--[51-60]
--[61+]
--The query should return
--Age groups
--Count of wizards in it

SELECT ageGroups.AgeGroup, 
       COUNT(*)
FROM
(
    SELECT CASE
               WHEN WizzardDeposits.Age BETWEEN 0 AND 10
               THEN '[0-10]'
               WHEN WizzardDeposits.Age BETWEEN 11 AND 20
               THEN '[11-20]'
               WHEN WizzardDeposits.Age BETWEEN 21 AND 30
               THEN '[21-30]'
               WHEN WizzardDeposits.Age BETWEEN 31 AND 40
               THEN '[31-40]'
               WHEN WizzardDeposits.Age BETWEEN 41 AND 50
               THEN '[41-50]'
               WHEN WizzardDeposits.Age BETWEEN 51 AND 60
               THEN '[51-60]'
               WHEN WizzardDeposits.Age >= 61
               THEN '[61+]'
           END AS AgeGroup
    FROM dbo.WizzardDeposits
) AS ageGroups
GROUP BY ageGroups.AgeGroup;

--10
--Write a query that returns all unique wizard first letters of their first names only if they have deposit of type Troll Chest. 
--Order them alphabetically. 

SELECT LEFT(WizzardDeposits.FirstName, 1) AS FirstLetter
FROM dbo.WizzardDeposits
WHERE WizzardDeposits.DepositGroup = 'Troll Chest'
GROUP BY LEFT(WizzardDeposits.FirstName, 1)
ORDER BY LEFT(WizzardDeposits.FirstName, 1);

--11
--Mr. Bodrog is highly interested in profitability. 
--He wants to know the average interest of all deposit groups split by whether the deposit has expired or not. 
--But that’s not all. He wants you to select deposits with start date after 01/01/1985. 
--Order the data descending by Deposit Group and ascending by Expiration Flag.

SELECT WizzardDeposits.DepositGroup, 
       WizzardDeposits.IsDepositExpired, 
       AVG(WizzardDeposits.DepositInterest) AS AverageInterest
FROM dbo.WizzardDeposits
WHERE WizzardDeposits.DepositStartDate > '01/01/1985'
GROUP BY WizzardDeposits.DepositGroup, 
         WizzardDeposits.IsDepositExpired
ORDER BY WizzardDeposits.DepositGroup DESC, 
         WizzardDeposits.IsDepositExpired ASC;

--12
--Mr. Bodrog definitely likes his werewolves more than you. 
--This is your last chance to survive! Give him some data to play his favorite game Rich Wizard, Poor Wizard. 
--The rules are simple: You compare the deposits of every wizard with the wizard after him. 
--If a wizard is the last one in the database, simply ignore it. In the end you have to sum the difference between the deposits.

SELECT SUM(e.Diff) AS SumDifference
FROM
(
    SELECT DepositAmount - LEAD(DepositAmount) OVER(
           ORDER BY ID) AS Diff
    FROM WizzardDeposits
) AS e;

--13
--That’s it! You no longer work for Mr. Bodrog. You have decided to find a proper job as an analyst in SoftUni. 
--It’s not a surprise that you will use the SoftUni database. Things get more exciting here!
--Create a query that shows the total sum of salaries for each department. Order by DepartmentID.
--Your query should return:	
--	DepartmentID

SELECT DepartmentID, 
       SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID;

--14
--Select the minimum salary from the employees for departments with ID (2, 5, 7) but only for those hired after 01/01/2000.
--Your query should return:	
--•	DepartmentID

SELECT DepartmentId, 
       MIN(Salary)
FROM Employees
WHERE DepartmentID IN(2, 5, 7)
AND HireDate > '01/01/2000'
GROUP BY DepartmentID;

--15
--Select all employees who earn more than 30000 into a new table.
-- Then delete all employees who have ManagerID = 42 (in the new table). 
--Then increase the salaries of all employees with DepartmentID=1 by 5000. 
--Finally, select the average salaries in each department.

SELECT *
INTO EmployeesAverage
FROM Employees
WHERE Salary > 30000;

DELETE FROM EmployeesAverage
WHERE ManagerID = 42;
UPDATE EmployeesAverage
  SET 
      Salary+=5000
WHERE DepartmentID = 1;

SELECT DepartmentId, 
       AVG(Salary) AS AverageSalary
FROM EmployeesAverage
GROUP BY DepartmentID;


--16
--Find the max salary for each department. Filter those, which have max salaries NOT in the range 30000 – 70000.

SELECT DepartmentID, 
       MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) < 30000
       OR MAX(Salary) > 70000;

--17
--Count the salaries of all employees who don’t have a manager.

SELECT COUNT(*) AS [Count]
FROM Employees
WHERE ManagerID IS NULL;

--18
--Find the third highest salary in each department if there is such. 
SELECT DISTINCT 
       DepartmentID, 
       Salary AS ThirdHighestSalary
FROM
(
    SELECT DepartmentID, 
           Salary, 
           DENSE_RANK() OVER(PARTITION BY DepartmentID
           ORDER BY Salary DESC) AS SalaryRank
    FROM Employees
) AS e
WHERE e.SalaryRank = 3;

--19
--Write a query that returns:
--•	FirstName
--•	LastName
--•	DepartmentID
--Select all employees who have salary higher than the average salary of their respective departments. 
--Select only the first 10 rows. Order by DepartmentID.

SELECT TOP(10) FirstName, 
       LastName, 
       DepartmentID
FROM Employees AS emp
WHERE Salary > (SELECT AVG(Salary) FROM Employees WHERE DepartmentID = emp.DepartmentID)
ORDER BY DepartmentID