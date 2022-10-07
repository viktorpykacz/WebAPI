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
OpisFaktury VARCHAR(100),
WartoscNetto DECIMAL(18,2),
WartoscVat DECIMAL(18,2),
WartoscBrutto DECIMAL(18,2)
)

select * from koszty