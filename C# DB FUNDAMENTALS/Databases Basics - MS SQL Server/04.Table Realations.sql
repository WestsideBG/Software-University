--Problem 1.	One-To-Many Relationship
--Persons												|	Passports
--PersonID	FirstName	Salary  	PassportID			|	PassportID	PassportNumber
--1  		Roberto     43300.00	102					|	101			N34FG21B
--2			Tom			56100.00	103					|	102			K65LO4R7
--3			Yana		60200.00	101					|	103			ZE657QP2
--Insert the data from the example above.				|
--Alter the customers table and make PersonID a primary key. Create a foreign key between Persons and Passports by using PassportID column.

CREATE TABLE Persons
(PersonID   INT IDENTITY NOT NULL, 
 FirstName  NVARCHAR(50) NOT NULL, 
 Salary     DECIMAL NOT NULL, 
 PassportID INT
 UNIQUE NOT NULL
);								  
CREATE TABLE Passports
(PassportID     INT IDENTITY(101, 1) NOT NULL, 
 PassportNumber NVARCHAR(MAX) NOT NULL, 
 CONSTRAINT PK_PassportID PRIMARY KEY(PassportID)
);
INSERT INTO Passports
VALUES('N34FG21B'), ('K65LO4R7'), ('ZE657QP2');
INSERT INTO Persons
(FirstName, 
 Salary, 
 PassportID
)
VALUES
('Roberto', 
 43300, 
 102
),
('Tom', 
 56100, 
 103
),
('Yana', 
 60200, 
 101
);
ALTER TABLE Persons
ADD CONSTRAINT PK_PersonID PRIMARY KEY(PersonID);
ALTER TABLE Persons
ADD CONSTRAINT FK_Persons_Passports FOREIGN KEY(PassportID) REFERENCES Passports(PassportID);

-----------------------------------------------------------------------------------
--Problem 2.	One-To-Many Relationship
--Create two tables as follows. Use appropriate data types.
--Models							|	Manufacturers
--ModelID	Name	ManufacturerID	|	ManufacturerID		Name	EstablishedOn
--101		X1			1			|	1					BMW		07/03/1916
--102		i6			1			|	2					Tesla	01/01/2003
--103		Model S		2			|	3					Lada	01/05/1966
--104		Model X		2		    |
--105		Model 3		2		    |
--106		Nova		3			|
--Insert the data from the example above. Add primary keys and foreign keys.

CREATE TABLE Manufacturers
(ManufacturerID INT IDENTITY NOT NULL, 
 [Name]         NVARCHAR(50) NOT NULL, 
 EstablishedOn  DATE NOT NULL, 
 CONSTRAINT PK_ManufacturerID PRIMARY KEY(ManufacturerID)
);
INSERT INTO Manufacturers
VALUES
('BMW', 
 CONVERT(DATE, '07/03/1916', 103)
),
('Tesla', 
 CONVERT(DATE, '01/01/2003', 103)
),
('Lada', 
 CONVERT(DATE, '01/05/1966', 103)
);
CREATE TABLE Models
(ModelID        INT IDENTITY NOT NULL, 
 [Name]         NVARCHAR(50) NOT NULL, 
 ManufacturerID INT NOT NULL, 
 CONSTRAINT PK_ModelID PRIMARY KEY(ModelID), 
 CONSTRAINT FK_Models_Manufacturers FOREIGN KEY(ManufacturerID) REFERENCES Manufacturers(ManufacturerID)
);
INSERT INTO Models
VALUES
('X1', 
 1
),
('i6', 
 1
),
('Model S', 
 2
),
('Model X', 
 2
),
('Model 3', 
 2
),
('Nova', 
 3
);

--------------------------------------------------------------------------------------
--Problem 3.	Many-To-Many Relationship
--Create three tables as follows. Use appropriate data types.
--Insert the data from the example above.
--Add primary keys and foreign keys. Have in mind that table StudentsExams should have a composite primary key.
--Students						Exams							StudentsExams
--StudentID		Name	 |   	ExamID		Name			|	StudentID		ExamID
--1  			Mila     |      101			SpringMVC		|		1			101
--2				Toni	 |   	102			Neo4j			|		1			102
--3				Ron		 |   	103			Oracle 11g		|		2			101
--						 |   								|		3			103
--						 |  								|		2			102
--						 |  								|		2			103

CREATE TABLE Students
(StudentID INT IDENTITY NOT NULL, 
 [Name]    NVARCHAR(50) NOT NULL, 
 CONSTRAINT PK_StudentsID PRIMARY KEY(StudentID)
);
CREATE TABLE Exams
(ExamID INT IDENTITY(101, 1) NOT NULL, 
 [Name] NVARCHAR(50) NOT NULL, 
 CONSTRAINT PK_ExamID PRIMARY KEY(ExamID)
);
CREATE TABLE StudentsExams
(StudentID INT NOT NULL, 
 ExamID    INT NOT NULL, 
 CONSTRAINT PK_StudentID_ExamID PRIMARY KEY(StudentID, ExamID), 
 CONSTRAINT FK_StudentsExams_Students FOREIGN KEY(StudentID) REFERENCES Students(StudentID), 
 CONSTRAINT FK_StudentsExams_ExamID FOREIGN KEY(ExamID) REFERENCES Exams(ExamID)
);
INSERT INTO Students
VALUES('Mila'), ('Toni'), ('Ron');
INSERT INTO Exams
VALUES('SpringMVC'), ('Neo4j'), ('Oracle 11g');
INSERT INTO StudentsExams
VALUES
(1, 
 101
),
(1, 
 102
),
(2, 
 101
),
(3, 
 103
),
(2, 
 102
),
(2, 
 103
);

--------------------------------------------------------------------------------------
--Problem 4.	Self-Referencing 
--Teachers
--TeacherID		Name	ManagerID
--101			John	NULL
--102			Maya	106
--103			Silvia	106
--104			Ted		105
--105			Mark	101
--106			Greta	101
--Insert the data from the example above. Add primary keys and foreign keys. The foreign key should be between ManagerId and TeacherId.

CREATE TABLE Teachers
(TeacherID INT IDENTITY(101, 1) NOT NULL, 
 [Name]    NVARCHAR(50) NOT NULL, 
 ManagerID INT, 
 CONSTRAINT PK_TeacherID PRIMARY KEY(TeacherID), 
 CONSTRAINT FK_ManagerID_TeacherID FOREIGN KEY(ManagerID) REFERENCES Teachers(TeacherID)
);
INSERT INTO Teachers
VALUES
('John', 
 NULL
),
('Maya', 
 106
),
('Silvia', 
 106
),
('Ted', 
 105
),
('Mark', 
 101
),
('Greta', 
 101
);

--------------------------------------------------------------------------------------
--Problem 5.	Online Store Database
--Create a new database and design the following structure:
--https://i.imgur.com/a09ItSG.png - E/R Diagram

CREATE DATABASE OnlineStoreDb;
USE OnlineStoreDb;
CREATE TABLE Cities
(CityID INT IDENTITY NOT NULL, 
 [Name] NVARCHAR(50) NOT NULL, 
 CONSTRAINT PK_CityID PRIMARY KEY(CityID)
);
CREATE TABLE Customers
(CustomerID INT IDENTITY NOT NULL, 
 [Name]     NVARCHAR(50) NOT NULL, 
 Birthday   DATE, 
 CityID     INT NOT NULL, 
 CONSTRAINT PK_CustomerID PRIMARY KEY(CustomerID), 
 CONSTRAINT FK_Customers_Cities FOREIGN KEY(CityID) REFERENCES Cities(CityID),
);
CREATE TABLE ItemTypes
(ItemTypeID INT IDENTITY NOT NULL, 
 [Name]     NVARCHAR(50) NOT NULL, 
 CONSTRAINT PK_ItemTypeID PRIMARY KEY(ItemTypeID)
);
CREATE TABLE Items
(ItemID     INT IDENTITY NOT NULL, 
 [Name]     NVARCHAR(50) NOT NULL, 
 ItemTypeID INT NOT NULL, 
 CONSTRAINT PK_ItemID PRIMARY KEY(ItemID), 
 CONSTRAINT FK_Items_ItemTypes FOREIGN KEY(ItemTypeID) REFERENCES ItemTypes(ItemTypeID)
);
CREATE TABLE Orders
(OrderID    INT IDENTITY NOT NULL, 
 CustomerID INT NOT NULL, 
 CONSTRAINT PK_OrderID PRIMARY KEY(OrderID), 
 CONSTRAINT FK_OrderID_Customers FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID)
);
CREATE TABLE OrderItems
(OrderID INT NOT NULL, 
 ItemID  INT NOT NULL, 
 CONSTRAINT PK_OrderID_ItemID PRIMARY KEY(OrderID, ItemID), 
 CONSTRAINT FK_OrderItems_Orders FOREIGN KEY(OrderID) REFERENCES Orders(OrderID), 
 CONSTRAINT FK_OrderItems_Items FOREIGN KEY(ItemID) REFERENCES Items(ItemID)
);

--------------------------------------------------------------------------------------
--Problem 6.	University Database
--Create a new database and design the following structure:
--http://prntscr.com/m9zr8v - E/R Diagram

CREATE DATABASE University;
USE University;
CREATE TABLE Majors
(MajorID INT IDENTITY NOT NULL, 
 [Name]  NVARCHAR(50) NOT NULL, 
 CONSTRAINT PK_MajorID PRIMARY KEY(MajorID)
);
CREATE TABLE Students
(StudentID     INT IDENTITY NOT NULL, 
 StudentNumber NVARCHAR(MAX) NOT NULL, 
 [Name]        NVARCHAR(50) NOT NULL, 
 MajorID       INT NOT NULL, 
 CONSTRAINT PK_StudentID PRIMARY KEY(StudentID), 
 CONSTRAINT FK_Students_Majors FOREIGN KEY(MajorID) REFERENCES Majors(MajorID)
);
CREATE TABLE Subjects
(SubjectID   INT IDENTITY NOT NULL, 
 SubjectName NVARCHAR(50) NOT NULL, 
 CONSTRAINT PK_SubjectID PRIMARY KEY(SubjectID)
);
CREATE TABLE Agenda
(StudentID INT NOT NULL, 
 SubjectID INT NOT NULL, 
 CONSTRAINT PK_StudentID_Students PRIMARY KEY(StudentID, SubjectID), 
 CONSTRAINT FK_Agenda_Students FOREIGN KEY(StudentID) REFERENCES Students(StudentID), 
 CONSTRAINT FK_Agenda_Subjects FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID)
);
CREATE TABLE Payments
(PaymentID      INT IDENTITY NOT NULL, 
 PaymentDate    DATE NOT NULL, 
 PaymentAmmount DECIMAL(5, 2) NOT NULL, 
 StudentID      INT NOT NULL, 
 CONSTRAINT PK_CustomerID PRIMARY KEY(PaymentID), 
 CONSTRAINT FK_Payments_Students FOREIGN KEY(StudentID) REFERENCES Students(StudentID)
);

qkov kraikov 17 

--------------------------------------------------------------------------------------
--Problem 9*.	Peaks in Rila
--Display all peaks for "Rila" mountain. Include:
--•	MountainRange
--•	PeakName
--•	Elevation
--Peaks should be sorted by elevation descending

USE Geography;
SELECT m.MountainRange, 
       p.PeakName, 
       p.Elevation
FROM Mountains AS m
     INNER JOIN Peaks AS p ON p.MountainId = m.Id
WHERE m.Id = 17
ORDER BY Elevation DESC;
