--V1.0 DeleteScripts
--1. Truncate and delete all tables
USE ProjectDatabase
GO

RAISERROR('Deleting Table Koszty', 0, 1) WITH NOWAIT
TRUNCATE TABLE Koszty;
DROP TABLE Koszty;

RAISERROR('Deleting Table Przychody', 0, 1) WITH NOWAIT
TRUNCATE TABLE Przychody;
DROP TABLE Przychody;

RAISERROR('Deleting Table ZestawienieMiesieczne', 0, 1) WITH NOWAIT
TRUNCATE TABLE ZestawienieMiesieczne;
DROP TABLE ZestawienieMiesieczne;

RAISERROR('Deleting Table Podatek', 0, 1) WITH NOWAIT
TRUNCATE TABLE Podatek;
DROP TABLE Podatek;

RAISERROR('Deleting Table Godziny', 0, 1) WITH NOWAIT
TRUNCATE TABLE Godziny;
DROP TABLE Godziny;

RAISERROR('Deleting Table ZestawienieGodzin', 0, 1) WITH NOWAIT
TRUNCATE TABLE ZestawienieGodzin;
DROP TABLE ZestawienieGodzin;

RAISERROR('Deleting Table Kontrakt', 0, 1) WITH NOWAIT
TRUNCATE TABLE Kontrakt;
DROP TABLE Kontrakt;