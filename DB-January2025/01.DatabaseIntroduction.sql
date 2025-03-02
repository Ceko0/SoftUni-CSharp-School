--1.Create Datavase
CREATE DATABASE [Minions]

GO

USE [Minions]

GO

--2.Create Tables
CREATE TABLE [Minions](
	[Id] INT PRIMARY KEY NOT NULL 
	,[Name] NVARCHAR(50) NOT NULL 
	,[Age] INT NULL
)

CREATE TABLE [Towns](
	[Id] INT PRIMARY KEY NOT NULL
	,[Name] NVARCHAR(85) NOT NULL
)

--3.Alter Minions Table
ALTER TABLE [Minions] 
ADD [TownId] INT 

ALTER TABLE [Minions]
ADD CONSTRAINT [FK_Minions_Towdn_Id]
FOREIGN KEY ([TownId]) REFERENCES [Towns] ([Id])

--4.Insert Records in Both Tables
INSERT INTO [Towns]([Id],[Name])
VALUES 
(1, 'Sofia')
,(2, 'Plovdiv')
,(3, 'Varna')

INSERT INTO [Minions]([Id] , [Name] , [Age] , [TownId])
VALUES 
(1,'Kevin',22,1)
,(2,'Bob',15,3)
,(3,'Steward',null,2)

-- 5.Trucate Table Minions
TRUNCATE TABLE [Minions]

--6.Drop All Tables
DROP TABLE [Minions]
DROP TABLE [Towns]

--7.Create Table People
CREATE TABLE [People](
	[Id] INT UNIQUE IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(2048),
	[Height] DECIMAL(5,2),
	[Weight] DECIMAL(5,2),
	[Gender] CHAR(1),
	[Birthdate] DATE NOT NULL,
	[Biography] VARCHAR(MAX)
)
ALTER TABLE [People]
ADD CONSTRAINT PK_People_Id PRIMARY KEY ([Id])
INSERT INTO People (Name, Picture, Height, Weight, Gender, Birthdate, Biography)
VALUES
('Петър Петров', NULL, 1.80, 75.50, 'm', '1999-11-11', 'Инженер, обича туризъм.'),
('Мария Иванова', NULL, 1.65, 60.30, 'f', '1990-06-15', 'Учител по математика.'),
('Иван Стоянов', NULL, 1.75, 80.20, 'm', '1985-02-20', 'Спортист, занимава се с футбол.'),
('Елена Георгиева', NULL, 1.70, 65.00, 'f', '1992-09-01', 'Лекар, специализира хирургия.'),
('Георги Димитров', NULL, 1.85, 90.00, 'm', '1988-12-05', 'Архитект с интерес към дизайна.');

--08. Create Table Users
CREATE TABLE [Users](
	[Id] BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX) NULL,
	[LastLoginTime] DATETIME2 NULL,
	[IsDeleted] BIT NOT NULL,
)
INSERT INTO [Users] ([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
VALUES
('user1', 'password1', NULL, '2025-01-10 15:30:00', 0),
('user2', 'password2', NULL, '2025-01-11 12:00:00', 0),
('user3', 'password3', NULL, '2025-01-09 09:15:00', 1),
('user4', 'password4', NULL, '2025-01-12 18:45:00', 0),
('user5', 'password5', NULL, '2025-01-08 07:00:00', 1);

--9.Change Primary Key
ALTER TABLE [Users] DROP CONSTRAINT PK__Users__3214EC077D4DB79C
ALTER TABLE [Users] ADD CONSTRAINT PK_Users_Id_Username PRIMARY KEY ([Id], [Username])

--10.Add Check Constraint
ALTER TABLE [Users]
ADD CONSTRAINT CK_Users_Password_Length
CHECK (LEN([Password]) >= 5)

--11.Set Default Value of a Field
ALTER TABLE [Users]
ADD CONSTRAINT DF_Users_LastLoginTime
DEFAULT GETDATE() FOR [LastLoginTime]

--12.Set Unique Field
ALTER TABLE [Users] DROP CONSTRAINT PK_Users_Id_Username
GO
ALTER TABLE [Users] ADD CONSTRAINT PK_Users_Id PRIMARY KEY ([Id])
GO
ALTER TABLE [Users]
ADD CONSTRAINT UQ_Users_Username UNIQUE ([Username])
ALTER TABLE [Users]
ADD CONSTRAINT CK_Users_Username_Length CHECK (LEN([Username]) >= 3)

--13.Movies Database
CREATE DATABASE [Movies]
GO

USE [Movies]
GO
CREATE TABLE [Directors](
	[Id] INT IDENTITY(1,1) PRIMARY KEY
	,[DirectorName] NVARCHAR(50) NOT NULL
	,[Notes] NVARCHAR(MAX) 
)
CREATE TABLE [Genres](
	[Id] INT IDENTITY(1,1) PRIMARY KEY
	,[GenreName] NVARCHAR(50) NOT NULL
	,[Notes] NVARCHAR(MAX)
)
CREATE TABLE [Categories](
	[Id] INT IDENTITY(1,1) PRIMARY KEY
	,[CategoryName] NVARCHAR(50) NOT NULL
	,[Notes] NVARCHAR(MAX)
)
CREATE TABLE [Movies](
	[Id] INT IDENTITY(1,1) PRIMARY KEY
	,[Title] NVARCHAR(50) NOT NULL
	,[DirectorId] INT NOT NULL
	,[CopyrightYear] INT CHECK (CopyrightYear >= 1900 AND CopyrightYear <= YEAR(GETDATE()))
	,[Length] DECIMAL(5,2) NULL
	,[GenreId] INT NOT NULL
	,[CategoryId] INT NOT NULL
	,[Rating] DECIMAL(2,1) CHECK (Rating BETWEEN 0 AND 10)
	,[Notes] NVARCHAR(MAX) NULL
	,FOREIGN KEY (DirectorId) REFERENCES Directors(Id)
	,FOREIGN KEY (GenreId) REFERENCES Genres(Id)
	,FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
)
INSERT INTO [Directors] ([DirectorName], [Notes])
VALUES
('Steven Spielberg', 'Famous for movies like Jaws, E.T., and Jurassic Park.'),
('Christopher Nolan', 'Known for Inception, The Dark Knight trilogy.'),
('Quentin Tarantino', 'Famous for Pulp Fiction and Kill Bill series.'),
('Martin Scorsese', 'Known for movies like Taxi Driver and Goodfellas.'),
('James Cameron', 'Director of Titanic and Avatar.')
INSERT INTO [Genres] ([GenreName], [Notes])
VALUES
('Action', 'Movies with high-energy sequences.'),
('Drama', 'Movies with a strong focus on emotional narratives.'),
('Comedy', 'Light-hearted movies designed to entertain.'),
('Horror', 'Movies meant to scare or thrill the audience.'),
('Sci-Fi', 'Movies about science and futuristic concepts.')
INSERT INTO [Categories] ([CategoryName], [Notes])
VALUES
('Blockbuster', 'High-budget movies targeting mass audiences.'),
('Indie', 'Low-budget independent films.'),
('Documentary', 'Non-fictional films focusing on real events.'),
('Animated', 'Movies created through animation techniques.'),
('Classic', 'Timeless movies from the past.')
INSERT INTO [Movies] ([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId], [Rating], [Notes])
VALUES
('Jurassic Park', 1, 1993, 127.00, 1, 1, 8.1, 'A sci-fi action movie about dinosaurs.'),
('Inception', 2, 2010, 148.00, 5, 1, 8.8, 'A sci-fi thriller about dreams within dreams.'),
('Pulp Fiction', 3, 1994, 154.00, 2, 1, 8.9, 'A drama with interconnected storylines.'),
('Goodfellas', 4, 1990, 146.00, 2, 5, 8.7, 'A classic crime drama.'),
('Avatar', 5, 2009, 162.00, 5, 1, 7.8, 'A sci-fi movie set on a distant planet.')

--14.Car Rental Database

CREATE DATABASE [CarRental]
GO

USE [CarRental]
GO

CREATE TABLE [Categories](
	[Id] INT IDENTITY(1,1) PRIMARY KEY
	,[CategoryName] NVARCHAR(50) NOT NULL
    ,[DailyRate] DECIMAL(10,2) NOT NULL
    ,[WeeklyRate] DECIMAL(10,2) NOT NULL
    ,[MonthlyRate] DECIMAL(10,2) NOT NULL
    ,[WeekendRate] DECIMAL(10,2) NOT NULL
)
CREATE TABLE [Cars] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY
    ,[PlateNumber] NVARCHAR(20) NOT NULL
    ,[Manufacturer] NVARCHAR(50) NOT NULL
    ,[Model] NVARCHAR(50) NOT NULL
    ,[CarYear] INT CHECK (CarYear >= 1900 AND CarYear <= YEAR(GETDATE())) NOT NULL
    ,[CategoryId] INT NOT NULL
    ,[Doors] INT NOT NULL
    ,[Picture] VARBINARY(MAX) NULL
    ,[Condition] NVARCHAR(50) NOT NULL
    ,[Available] BIT NOT NULL
    ,FOREIGN KEY ([CategoryId]) REFERENCES [Categories]([Id])
)
CREATE TABLE [Employees] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY
    ,[FirstName] NVARCHAR(50) NOT NULL
    ,[LastName] NVARCHAR(50) NOT NULL
    ,[Title] NVARCHAR(50) NOT NULL
    ,[Notes] NVARCHAR(MAX) NULL
)
CREATE TABLE [Customers] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY
    ,[DriverLicenceNumber] NVARCHAR(50) NOT NULL
    ,[FullName] NVARCHAR(100) NOT NULL
    ,[Address] NVARCHAR(100) NOT NULL
    ,[City] NVARCHAR(50) NOT NULL
    ,[ZIPCode] NVARCHAR(20) NOT NULL
    ,[Notes] NVARCHAR(MAX) NULL
)
CREATE TABLE [RentalOrders] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY
    ,[EmployeeId] INT NOT NULL
    ,[CustomerId] INT NOT NULL
    ,[CarId] INT NOT NULL
    ,[TankLevel] DECIMAL(5,2) CHECK (TankLevel BETWEEN 0 AND 100) NOT NULL
    ,[KilometrageStart] INT NOT NULL
    ,[KilometrageEnd] INT NOT NULL
    ,[TotalKilometrage] AS ([KilometrageEnd] - [KilometrageStart]) PERSISTED
    ,[StartDate] DATE NOT NULL
    ,[EndDate] DATE NOT NULL
    ,[TotalDays] AS (DATEDIFF(DAY, [StartDate], [EndDate]) + 1) PERSISTED
    ,[RateApplied] DECIMAL(10,2) NOT NULL
    ,[TaxRate] DECIMAL(5,2) NOT NULL
    ,[OrderStatus] NVARCHAR(50) NOT NULL
    ,[Notes] NVARCHAR(MAX) NULL
    FOREIGN KEY ([EmployeeId]) REFERENCES [Employees]([Id]),
    FOREIGN KEY ([CustomerId]) REFERENCES [Customers]([Id]),
    FOREIGN KEY ([CarId]) REFERENCES [Cars]([Id])
)

INSERT INTO [Categories] ([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate])
VALUES
('Economy', 30.00, 200.00, 700.00, 60.00),
('Luxury', 100.00, 600.00, 2000.00, 200.00),
('SUV', 70.00, 450.00, 1500.00, 140.00)

INSERT INTO [Cars] ([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Picture], [Condition], [Available])
VALUES
('ABC123', 'Toyota', 'Corolla', 2020, 1, 4, NULL, 'Good', 1),
('DEF456', 'BMW', 'X5', 2022, 2, 5, NULL, 'Excellent', 1),
('GHI789', 'Ford', 'Escape', 2019, 3, 4, NULL, 'Good', 0)

INSERT INTO [Employees] ([FirstName], [LastName], [Title], [Notes])
VALUES
('John', 'Doe', 'Manager', 'Team leader of the rental department.'),
('Jane', 'Smith', 'Assistant Manager', 'Handles escalations and issues.'),
('Emily', 'Johnson', 'Rental Agent', 'Primary contact for customer rentals.')

INSERT INTO [Customers] ([DriverLicenceNumber], [FullName], [Address], [City], [ZIPCode], [Notes])
VALUES
('DL12345', 'Michael Brown', '123 Elm Street', 'New York', '10001', 'Preferred customer.'),
('DL67890', 'Sarah Connor', '456 Pine Avenue', 'Los Angeles', '90001', NULL),
('DL54321', 'John Wick', '789 Oak Boulevard', 'Chicago', '60601', 'Frequent renter.')

INSERT INTO [RentalOrders] ([EmployeeId], [CustomerId], [CarId], [TankLevel], [KilometrageStart], [KilometrageEnd], [StartDate], [EndDate], [RateApplied], [TaxRate], [OrderStatus], [Notes])
VALUES
(1, 1, 1, 100.00, 50000, 50200, '2025-01-01', '2025-01-03', 60.00, 15.00, 'Completed', 'No issues.'),
(2, 2, 2, 50.00, 30000, 30250, '2025-01-05', '2025-01-07', 200.00, 20.00, 'Pending', 'Customer requested early pickup.'),
(3, 3, 3, 75.00, 40000, 40400, '2025-01-10', '2025-01-14', 140.00, 18.00, 'Completed', 'Minor scratches noted.')

--15.Hotel Database
CREATE DATABASE [Hotel]
GO

USE [Hotel]
GO

CREATE TABLE [Employees](
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName] NVARCHAR(50) NOT NULL,
    [Title] NVARCHAR(50) NOT NULL,
    [Notes] NVARCHAR(MAX) NULL
)

CREATE TABLE [Customers](
    [AccountNumber] NVARCHAR(20) PRIMARY KEY,
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName] NVARCHAR(50) NOT NULL,
    [PhoneNumber] NVARCHAR(20) NOT NULL,
    [EmergencyName] NVARCHAR(50) NOT NULL,
    [EmergencyNumber] NVARCHAR(20) NOT NULL,
    [Notes] NVARCHAR(MAX) NULL
)

CREATE TABLE [RoomStatus](
    [RoomStatus] NVARCHAR(20) PRIMARY KEY,
    [Notes] NVARCHAR(MAX) NULL
)

CREATE TABLE [RoomTypes](
    [RoomType] NVARCHAR(20) PRIMARY KEY,
    [Notes] NVARCHAR(MAX) NULL
)

CREATE TABLE [BedTypes](
    [BedType] NVARCHAR(20) PRIMARY KEY,
    [Notes] NVARCHAR(MAX) NULL
)

CREATE TABLE [Rooms](
    [RoomNumber] INT PRIMARY KEY,
    [RoomType] NVARCHAR(20) NOT NULL,
    [BedType] NVARCHAR(20) NOT NULL,
    [Rate] DECIMAL(10,2) NOT NULL,
    [RoomStatus] NVARCHAR(20) NOT NULL,
    [Notes] NVARCHAR(MAX) NULL,
    FOREIGN KEY ([RoomType]) REFERENCES [RoomTypes]([RoomType]),
    FOREIGN KEY ([BedType]) REFERENCES [BedTypes]([BedType]),
    FOREIGN KEY ([RoomStatus]) REFERENCES [RoomStatus]([RoomStatus])
)

CREATE TABLE [Payments](
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [EmployeeId] INT NOT NULL,
    [PaymentDate] DATE NOT NULL,
    [AccountNumber] NVARCHAR(20) NOT NULL,
    [FirstDateOccupied] DATE NOT NULL,
    [LastDateOccupied] DATE NOT NULL,
    [TotalDays] AS (DATEDIFF(DAY, [FirstDateOccupied], [LastDateOccupied]) + 1) PERSISTED,
    [AmountCharged] DECIMAL(10,2) NOT NULL,
    [TaxRate] DECIMAL(5,2) NOT NULL,
    [TaxAmount] AS ([AmountCharged] * [TaxRate] / 100) PERSISTED,
    [PaymentTotal] AS ([AmountCharged] + ([AmountCharged] * [TaxRate] / 100)) PERSISTED,
    [Notes] NVARCHAR(MAX) NULL,
    FOREIGN KEY ([EmployeeId]) REFERENCES [Employees]([Id]),
    FOREIGN KEY ([AccountNumber]) REFERENCES [Customers]([AccountNumber])
)

CREATE TABLE [Occupancies](
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [EmployeeId] INT NOT NULL,
    [DateOccupied] DATE NOT NULL,
    [AccountNumber] NVARCHAR(20) NOT NULL,
    [RoomNumber] INT NOT NULL,
    [RateApplied] DECIMAL(10,2) NOT NULL,
    [PhoneCharge] DECIMAL(10,2) NULL,
    [Notes] NVARCHAR(MAX) NULL,
    FOREIGN KEY ([EmployeeId]) REFERENCES [Employees]([Id]),
    FOREIGN KEY ([AccountNumber]) REFERENCES [Customers]([AccountNumber]),
    FOREIGN KEY ([RoomNumber]) REFERENCES [Rooms]([RoomNumber])
)

INSERT INTO [Employees] ([FirstName], [LastName], [Title], [Notes])
VALUES
('John', 'Doe', 'Manager', 'Responsible for overall operations'),
('Jane', 'Smith', 'Receptionist', 'Handles guest check-ins and check-outs'),
('Emily', 'Johnson', 'Housekeeper', 'Ensures rooms are clean and tidy')

INSERT INTO [Customers] ([AccountNumber], [FirstName], [LastName], [PhoneNumber], [EmergencyName], [EmergencyNumber], [Notes])
VALUES
('ACC123', 'Michael', 'Brown', '123456789', 'Sarah Brown', '987654321', 'Preferred customer'),
('ACC456', 'Sarah', 'Connor', '555777888', 'John Connor', '666999000', NULL),
('ACC789', 'John', 'Wick', '444888555', 'Helen Wick', '333222111', 'Frequent traveler')

INSERT INTO [RoomStatus] ([RoomStatus], [Notes])
VALUES
('Available', 'Room is ready for occupancy'),
('Occupied', 'Room is currently occupied'),
('Maintenance', 'Room is under maintenance')

INSERT INTO [RoomTypes] ([RoomType], [Notes])
VALUES
('Single', 'Single bed for one person'),
('Double', 'Double bed for two people'),
('Suite', 'Luxury suite with additional amenities')

INSERT INTO [BedTypes] ([BedType], [Notes])
VALUES
('Twin', 'Two single beds'),
('Queen', 'One queen-sized bed'),
('King', 'One king-sized bed')

INSERT INTO [Rooms] ([RoomNumber], [RoomType], [BedType], [Rate], [RoomStatus], [Notes])
VALUES
(101, 'Single', 'Twin', 100.00, 'Available', 'Near the lobby'),
(202, 'Double', 'Queen', 150.00, 'Occupied', 'Balcony with sea view'),
(303, 'Suite', 'King', 300.00, 'Maintenance', 'Requires new carpeting')

INSERT INTO [Payments] ([EmployeeId], [PaymentDate], [AccountNumber], [FirstDateOccupied], [LastDateOccupied], [AmountCharged], [TaxRate], [Notes])
VALUES
(1, '2025-01-01', 'ACC123', '2025-01-01', '2025-01-03', 300.00, 15.00, 'Paid via credit card'),
(2, '2025-01-05', 'ACC456', '2025-01-05', '2025-01-07', 450.00, 10.00, 'Paid in cash'),
(3, '2025-01-10', 'ACC789', '2025-01-10', '2025-01-14', 1200.00, 18.00, 'Company invoice')

INSERT INTO [Occupancies] ([EmployeeId], [DateOccupied], [AccountNumber], [RoomNumber], [RateApplied], [PhoneCharge], [Notes])
VALUES
(1, '2025-01-01', 'ACC123', 101, 100.00, 0.00, 'No issues'),
(2, '2025-01-05', 'ACC456', 202, 150.00, 10.00, 'Extra towels requested'),
(3, '2025-01-10', 'ACC789', 303, 300.00, 20.00, 'Late check-out allowed')

--16.Create SoftUni Database
CREATE DATABASE [SoftUni]
GO

USE [SoftUni]
GO

CREATE TABLE [Towns] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE [Addresses] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [AddressText] NVARCHAR(255) NOT NULL,
    [TownId] INT NOT NULL,
    FOREIGN KEY ([TownId]) REFERENCES [Towns]([Id])
)

CREATE TABLE [Departments] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE [Employees] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [FirstName] NVARCHAR(50) NOT NULL,
    [MiddleName] NVARCHAR(50) NULL,
    [LastName] NVARCHAR(50) NOT NULL,
    [JobTitle] NVARCHAR(100) NOT NULL,
    [DepartmentId] INT NOT NULL,
    [HireDate] DATE NOT NULL,
    [Salary] DECIMAL(10,2) NOT NULL,
    [AddressId] INT NULL,
    FOREIGN KEY ([DepartmentId]) REFERENCES [Departments]([Id]),
    FOREIGN KEY ([AddressId]) REFERENCES [Addresses]([Id])
)

--17.Backup Database
BACKUP DATABASE [SoftUni] 
TO DISK = 'D:\ProgramsScool\DB on HDD\softuni-backup.bak'
WITH FORMAT, 
     MEDIANAME = 'SoftUni_Backup',
     NAME = 'Full Backup of SoftUni'

USE [master]
ALTER DATABASE [SoftUni] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
DROP DATABASE [SoftUni]

RESTORE FILELISTONLY 
FROM DISK = 'D:\ProgramsScool\DB on HDD\softuni-backup.bak'

RESTORE DATABASE [SoftUni]
FROM DISK = 'D:\ProgramsScool\DB on HDD\softuni-backup.bak'
WITH 
    MOVE 'SoftUni' TO 'D:\SQLData\SoftUni.mdf',
    MOVE 'SoftUni_log' TO 'D:\SQLData\SoftUni_log.ldf',
    REPLACE

--18.Basic Insert
USE [SoftUni]

INSERT INTO [Towns] ([Name])
VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO [Departments] ([Name])
VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO [Employees] ([FirstName], [MiddleName], [LastName], [JobTitle], [DepartmentId], [HireDate], [Salary], [AddressId])
VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', (SELECT Id FROM [Departments] WHERE [Name] = 'Software Development'), '2013-02-01', 3500.00, NULL),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', (SELECT Id FROM [Departments] WHERE [Name] = 'Engineering'), '2004-03-02', 4000.00, NULL),
('Maria', 'Petrova', 'Ivanova', 'Intern', (SELECT Id FROM [Departments] WHERE [Name] = 'Quality Assurance'), '2016-08-28', 525.25, NULL),
('Georgi', 'Teziev', 'Ivanov', 'CEO', (SELECT Id FROM [Departments] WHERE [Name] = 'Sales'), '2007-12-09', 3000.00, NULL),
('Peter', 'Pan', 'Pan', 'Intern', (SELECT Id FROM [Departments] WHERE [Name] = 'Marketing'), '2016-08-28', 599.88, NULL)

--19.Basic Select All Fields
SELECT * FROM [Towns]
SELECT * FROM [Departments]
SELECT * FROM [Employees]

--20.Basic Select All Fields and Order Them
SELECT * FROM [Towns] 
ORDER BY [Name] ASC

SELECT * FROM [Departments]
ORDER BY [Name] ASC

SELECT * FROM [Employees]
ORDER BY [Salary] DESC

--21.Basic Select Some Fields
SELECT [Name] FROM [Towns] 
ORDER BY [Name] ASC

SELECT [Name] FROM [Departments]
ORDER BY [Name] ASC

SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM [Employees]
ORDER BY [Salary] DESC

--22.Increase Employees Salary
UPDATE [Employees]
SET [Salary] = [Salary] * 1.10

SELECT [Salary] FROM [Employees]

--23.Decrease Tax Rate
USE [Hotel]

UPDATE [Payments]
SET [TaxRate] = [TaxRate] *0.97

SELECT [TaxRate] FROM [Payments]

--24.Delete All Records
DELETE FROM Occupancies
SELECT * FROM Occupancies