--V1.0 CreateScripts
--1. Create Database for project.
CREATE DATABASE ProjectDatabase

--2. Create Table Koszty
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

--3. Create Table Przychody
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

--4. Create Table ZestawienieMiesieczne
CREATE TABLE ZestawienieMiesieczne 
(
Id int IDENTITY(1,1) PRIMARY KEY,
DataWpisu DATETIME,
KosztyBiuro DECIMAL(18,2),
KosztyAuto DECIMAL(18,2),
KosztyLacznie DECIMAL(18,2),
PrzychodyLacznie DECIMAL(18,2),
VatLacznie DECIMAL(18,2)
)

--5. Create Table Podatek
CREATE TABLE Podatek 
(
Id int IDENTITY(1,1) PRIMARY KEY,
DataWpisu DATETIME,
VatDoOdliczenia DECIMAL(18,2),
PitDoZaplaty DECIMAL(18,2),
VatDoZaplaty DECIMAL(18,2),
ZusDoZaplaty DECIMAL(18,2)
)

--6. Create Table Godziny
CREATE TABLE Godziny
(
Id int IDENTITY(1,1) PRIMARY KEY,
DataWpisu DATETIME,
NazwaProjektu VARCHAR(50),
IleGodzin INT
)

--7. Create Table ZestawienieGodzin
CREATE TABLE ZestawienieGodzin
(
Id int IDENTITY(1,1) PRIMARY KEY,
DataWpisu DATETIME,
Rok INT, 
Miesiac INT, 
NazwaProjektu VARCHAR(50),
IleGodzin INT
)

--8. Create Table Kontrakt
CREATE TABLE Kontrakt
(
Id int IDENTITY(1,1) PRIMARY KEY,
DataWpisu DATETIME,
StartKontraktu DATETIME,
CzyTerminowy BOOL,
KoniecKontraktu DATETIME,
NazwaProjektu VARCHAR(50),
StawkaGodzinowa DECIMAL(18,2),
StawkaMiesieczna DECIMAL(18,2),
Stanowisko VARCHAR(100),
CzyOutsourcing BOOL,
NazwaZleceniodawcy VARCHAR(100),
NipZleceniodawcy VARCHAR(50),
AdresZleceniodawcy VARCHAR(100),
KodPocztowyZleceniodawcy VARCHAR(10),
MiastoZleceniodawcy VARCHAR(50),
KrajZleceniodawcy VARCHAR(50)
)