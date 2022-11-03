--V1.0 CreateScripts
--1. Create Database for project.
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'ProjectDatabase')
	BEGIN
	CREATE DATABASE ProjectDatabase
	RAISERROR('1. Creating Database ProjectDatabase', 0, 1) WITH NOWAIT
END

GO
	USE ProjectDatabase
GO

--2. Create Table Koszty
IF NOT EXISTS(SELECT * FROM sysobjects where name = 'Koszty')
	BEGIN
	RAISERROR('2. Creating Table Koszty', 0, 1) WITH NOWAIT
	CREATE TABLE Koszty 
	(
	Id int IDENTITY(1,1) PRIMARY KEY,
	DataWystawieniaFaktury DATETIME,
	NumerFaktury VARCHAR(50),
	NipFirmy VARCHAR(50),
	OpisKosztu VARCHAR(100),
	RodzajKosztu VARCHAR(50),
	WartoscNetto DECIMAL(18,2),
	WartoscVat DECIMAL(18,2),
	WartoscBrutto DECIMAL(18,2)
	)
	END	

--3. Create Table Przychody
IF NOT EXISTS(SELECT * FROM sysobjects where name = 'Przychody')
	BEGIN
	RAISERROR('3. Creating Table Przychody', 0, 1) WITH NOWAIT
	CREATE TABLE Przychody 
	(
	Id int IDENTITY(1,1) PRIMARY KEY,
	DataWystawieniaFaktury DATETIME,
	NumerFaktury VARCHAR(50),
	NipFirmy VARCHAR(50),
	Projekt VARCHAR(50),
	OpisFaktury VARCHAR(100),
	WartoscNetto DECIMAL(18,2),
	WartoscVat DECIMAL(18,2),
	WartoscBrutto DECIMAL(18,2)
	)
	END

--4. Create Table ZestawienieMiesieczne
IF NOT EXISTS(SELECT * FROM sysobjects where name = 'ZestawienieMiesieczne')
	BEGIN
	RAISERROR('4. Creating Table ZestawienieMiesieczne', 0, 1) WITH NOWAIT
	CREATE TABLE ZestawienieMiesieczne 
	(
	Id int IDENTITY(1,1) PRIMARY KEY,
	DataWpisu DATETIME,
	Rok INT, 
	Miesiac INT,
	KosztyBiuro DECIMAL(18,2),
	KosztyAuto DECIMAL(18,2),
	KosztyLacznie DECIMAL(18,2),
	PrzychodyLacznie DECIMAL(18,2),
	VatLacznie DECIMAL(18,2)
	)
	END

--5. Create Table Podatek
IF NOT EXISTS(SELECT * FROM sysobjects where name = 'Podatek')
	BEGIN
	RAISERROR('5. Creating Table Podatek', 0, 1) WITH NOWAIT
	CREATE TABLE Podatek 
	(
	Id int IDENTITY(1,1) PRIMARY KEY,
	DataWpisu DATETIME,
	Rok INT, 
	Miesiac INT, 
	VatDoOdliczenia DECIMAL(18,2),
	PitDoZaplaty DECIMAL(18,2),
	VatDoZaplaty DECIMAL(18,2),
	ZusDoZaplaty DECIMAL(18,2)
	)
	END

--6. Create Table Godziny
IF NOT EXISTS(SELECT * FROM sysobjects where name = 'Godziny')
	BEGIN
	RAISERROR('6. Creating Table Godziny', 0, 1) WITH NOWAIT
	CREATE TABLE Godziny
	(
	Id int IDENTITY(1,1) PRIMARY KEY,
	DataWpisu DATETIME,
	NazwaProjektu VARCHAR(50),
	IleGodzin INT
	)
	END

--7. Create Table ZestawienieGodzin
IF NOT EXISTS(SELECT * FROM sysobjects where name = 'ZestawienieGodzin')
	BEGIN
	RAISERROR('7. Creating Table ZestawienieGodzin', 0, 1) WITH NOWAIT
	CREATE TABLE ZestawienieGodzin
	(
	Id int IDENTITY(1,1) PRIMARY KEY,
	DataWpisu DATETIME,
	Rok INT, 
	Miesiac INT, 
	NazwaProjektu VARCHAR(50),
	IleGodzin INT
	)
	END

--8. Create Table Kontrakt
IF NOT EXISTS(SELECT * FROM sysobjects where name = 'Kontrakt')
	BEGIN
	RAISERROR('8. Creating Table Kontrakt', 0, 1) WITH NOWAIT
	CREATE TABLE Kontrakt
	(
	Id int IDENTITY(1,1) PRIMARY KEY,
	DataWpisu DATETIME,
	StartKontraktu DATETIME,
	CzyTerminowy BIT,
	KoniecKontraktu DATETIME,
	NazwaProjektu VARCHAR(50),
	StawkaGodzinowa DECIMAL(18,2),
	StawkaMiesieczna DECIMAL(18,2),
	Stanowisko VARCHAR(100),
	OpisStanowiska VARCHAR(250),
	CzyOutsourcing BIT,
	NazwaZleceniodawcy VARCHAR(100),
	NipZleceniodawcy VARCHAR(50),
	AdresZleceniodawcy VARCHAR(100),
	KodPocztowyZleceniodawcy VARCHAR(10),
	MiastoZleceniodawcy VARCHAR(50),
	KrajZleceniodawcy VARCHAR(50)
	)
	END