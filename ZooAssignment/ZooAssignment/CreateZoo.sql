CREATE DATABASE ZooAssignment
GO
USE ZooAssignment

CREATE TABLE Parks
(
	Id INT PRIMARY KEY IDENTITY not null,
	TicketPrize MONEY not null,
	MaxVisitors INT not null
)

CREATE TABLE Animals
(
	Id INT PRIMARY KEY IDENTITY not null,
	Name VARCHAR(32) not null,
	Species INT not null,
	Sex INT not null,
	HabitatId INT,
	Status INT
)

CREATE TABLE Habitats
(
	Id INT PRIMARY KEY IDENTITY not null,
	Name INT not null,
	GrowthDensity INT not null,
	Climate INT not null
)

CREATE TABLE Persons
(
	Id INT PRIMARY KEY IDENTITY not null,
	Name VARCHAR(32) not null,
	Age INT not null,
	Email VARCHAR(32),
	Phone VARCHAR(32)
)

CREATE TABLE Visits
(
	Id INT PRIMARY KEY IDENTITY not null,
	VisitorId INT FOREIGN KEY REFERENCES Persons(Id) ON DELETE CASCADE not null,
	VisitDate DATETIME not null,
	TicketPaid TINYINT(1) not null
)