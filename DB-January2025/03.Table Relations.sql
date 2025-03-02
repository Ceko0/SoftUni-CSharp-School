--1.One-To-One Relationship
CREATE TABLE [Passports](
		     [PassportID] INT PRIMARY KEY IDENTITY(101,1),
			 [PassportNumber] CHAR(8) NOT NULL
)

CREATE TABLE [Persons](
			 [PersonId] INT PRIMARY KEY IDENTITY(1,1),
			 [FirstName] VARCHAR(20) NOT NULL,
			 [Salary] DECIMAL(8,2) NOT NULL,
			 [PassportID] INT UNIQUE,
			 CONSTRAINT FK_PassportID FOREIGN KEY (PassportID) REFERENCES Passports(PassportID)
)

INSERT INTO Passports (PassportNumber) VALUES
('N34FG21B'), 
('K65LO4R7'), 
('ZE657QP2');

INSERT INTO Persons (FirstName, Salary, PassportID) VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101);

SELECT * FROM Passports;
SELECT * FROM Persons;

--2.One-To-Many Relationship

CREATE TABLE [Manufacturers](
			 [ManufacturersID] INT PRIMARY KEY IDENTITY(1,1),
			 [Name] VARCHAR(50) NOT NULL,
			 [EstablishedOn] DATETIME2 NOT NULL
)

CREATE TABLE [Models](
			 [ModelId] INT PRIMARY KEY IDENTITY(101,1),
			 [Name] VARCHAR(50),
			 [ManufacturerID] INT,
			 CONSTRAINT FK_ManufacturerID FOREIGN KEY (ManufacturerID) REFERENCES Manufacturers(ManufacturersID)
)

INSERT INTO Manufacturers (Name, EstablishedOn)
VALUES
('BMW', '1916-03-07'),
('Tesla', '2003-01-01'),
('Lada', '1966-05-01');

INSERT INTO Models (Name, ManufacturerID)
VALUES
('X1', 1),
('i6', 1),
('Model S', 2),
('Model X', 2),
('Model 3', 2),
('Nova', 3);

SELECT * FROM Manufacturers;
SELECT * FROM Models;

--3.Many-To-Many Relationship

CREATE TABLE [Students](
			 [StudentID] INT PRIMARY KEY IDENTITY(1,1),
			 [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Exams](
			 [ExamId] INT PRIMARY KEY IDENTITY(101,1),
			 [Name] VARCHAR(50)
)

CREATE TABLE [StudentsExams](
			 [StudentID] INT NOT NULL,
			 [ExamID] INT NOT NULL,
			 CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentID, ExamID),
    CONSTRAINT FK_StudentID FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    CONSTRAINT FK_ExamID FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
)

INSERT INTO Students (Name)
VALUES
('Mila'),
('Toni'),
('Ron');

INSERT INTO Exams (Name)
VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g');

INSERT INTO StudentsExams (StudentID, ExamID)
VALUES
(1, 101),
(1, 102),
(2, 101),
(2, 102),
(2, 103),
(3, 103);

SELECT * FROM Students;
SELECT * FROM Exams;
SELECT * FROM StudentsExams;

--4.Self-Referencing 

CREATE TABLE Teachers (
    TeacherID INT PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    ManagerID INT,
    CONSTRAINT FK_ManagerID FOREIGN KEY (ManagerID) REFERENCES Teachers(TeacherID)
);

INSERT INTO Teachers (TeacherID, Name, ManagerID)
VALUES
(101, 'John', NULL),
(102, 'Maya', 106),
(103, 'Silvia', 106),
(104, 'Ted', 105),
(105, 'Mark', 101),
(106, 'Greta', 101);

SELECT * FROM Teachers;

--5.Online Store Database

CREATE TABLE [ItemTypes](
    [ItemTypeID] INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(150) NOT NULL
)

CREATE TABLE [Cities](
    [CityID] INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(150) NOT NULL
)

CREATE TABLE [Items](
    [ItemID] INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(150) NOT NULL,
    [ItemTypeID] INT NOT NULL,
    CONSTRAINT FK_ItemTypeID FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE [Customers](
    [CustomerID] INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(150) NOT NULL,
    [Birthday] DATE NOT NULL,
    [CityID] INT NOT NULL,
    CONSTRAINT FK_CityID FOREIGN KEY (CityID) REFERENCES Cities(CityID)
)

CREATE TABLE [Orders](
    [OrderID] INT PRIMARY KEY IDENTITY(1,1),
    [CustomerID] INT NOT NULL,
    CONSTRAINT FK_CustomerID FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)

CREATE TABLE [OrderItems](
    [OrderID] INT NOT NULL,
    [ItemID] INT NOT NULL,
    CONSTRAINT PK_OrderItems PRIMARY KEY (OrderID, ItemID),
    CONSTRAINT FK_OrderID FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    CONSTRAINT FK_ItemID FOREIGN KEY (ItemID) REFERENCES Items(ItemID)
)


--6.University Database

CREATE TABLE [Majors](
    [MajorID] INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(150) NOT NULL
)

CREATE TABLE [Students](
    [StudentID] INT PRIMARY KEY IDENTITY(1,1),
    [StudentNumber] NVARCHAR(50) NOT NULL UNIQUE,
    [StudentName] NVARCHAR(150) NOT NULL,
    [MajorID] INT NOT NULL,
    CONSTRAINT FK_MajorID FOREIGN KEY (MajorID) REFERENCES Majors(MajorID)
)

CREATE TABLE [Subjects](
    [SubjectID] INT PRIMARY KEY IDENTITY(1,1),
    [SubjectName] NVARCHAR(150) NOT NULL
)

CREATE TABLE [Agenda](
    [StudentID] INT NOT NULL,
    [SubjectID] INT NOT NULL,
    CONSTRAINT PK_Agenda PRIMARY KEY (StudentID, SubjectID),
    CONSTRAINT FK_StudentID_Agenda FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    CONSTRAINT FK_SubjectID_Agenda FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
)

CREATE TABLE [Payments](
    [PaymentID] INT PRIMARY KEY IDENTITY(1,1),
    [PaymentDate] DATETIME2 NOT NULL,
    [PaymentAmount] DECIMAL(10,2) NOT NULL,
    [StudentID] INT NOT NULL,
    CONSTRAINT FK_StudentID_Payments FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
)

--7.SoftUni Design

--8.Geography Design

--9.*Peaks in Rila

USE [Geography]

GO

SELECT 
    m.MountainRange,
    p.PeakName,
    p.Elevation
FROM 
    Peaks p
JOIN 
    Mountains m ON p.MountainID = m.ID
WHERE 
    m.MountainRange = 'Rila'
ORDER BY 
    p.Elevation DESC