USE ProjectDatabase
GO

--insert dummy values to the Koszty table
insert into Koszty
(DataWystawieniaFaktury, NumerFaktury, NipFirmy, OpisKosztu, RodzajKosztu, WartoscNetto, WartoscVat, WartoscBrutto)
values
(GETDATE(), '01_06_2023', '1132800726', 'Zakup drukarki', 'BIURO', 1000.00, 0.23*1000.00, 1.23*1000),
(GETDATE(), '55/FS/2023', '5152233231', 'Rata leasingowa auta', 'AUTO', 5000.00, 0.23*1000.00, 1.23*1000)

--insert dummy values to the Przychody table
insert into Przychody
(DataWystawieniaFaktury, NumerFaktury, NipFirmy, Projekt, OpisFaktury, WartoscNetto, WartoscVat, WartoscBrutto)
values
(GETDATE(), '01_06_2023', '1132800726', 'TEST PROJEKT', 'Faktura za us³ugi informatyczne', 16000.00, 0.23*16000.00, 1.23*16000.00)

--insert dummy values to the ZestawienieMiesieczne table
insert into ZestawienieMiesieczne
(DataWpisu, Rok, Miesiac, KosztyBiuro, KosztyAuto, KosztyLacznie, PrzychodyLacznie, VatLacznie)
values
(GETDATE(), 2023, 6, 100.55, 2500.00, 100.55+2500.00, 30000.15, 0.23*30000.15)

--insert dummy values to the Podatek table
insert into Podatek
(DataWpisu, Rok, Miesiac, VatDoOdliczenia, PitDoZaplaty, VatDoZaplaty, ZusDoZaplaty)
values
(GETDATE(), 2023, 6, 100.15, 355.12, 3500.12, 1453.17)

--insert dummy values to the Godziny table
insert into Godziny
(DataWpisu, DataPracy, NazwaProjektu, IleGodzin)
values
(GETDATE(), '2023-06-12','TEST PROJEKT', 8),
(GETDATE(), '2023-06-12','TEST PROJEKT 2', 8)

--insert dummy values to the ZestawienieGodzin table
insert into ZestawienieGodzin
(DataWpisu, Rok, Miesiac, NazwaProjektu, IleGodzin)
values
(GETDATE(), 2023, 6, 'TEST PROJEKT', 100),
(GETDATE(), 2023, 6, 'TEST PROJEKT 2', 100)

--insert dummy values to the Kontrakt table
insert into Kontrakt
(DataWpisu, StartKontraktu, CzyTerminowy, KoniecKontraktu, NazwaProjektu, StawkaGodzinowa, StawkaMiesieczna, Stanowisko, OpisStanowiska, CzyOutsourcing, NazwaZleceniodawcy, NipZleceniodawcy, AdresZleceniodawcy, KodPocztowyZleceniodawcy, MiastoZleceniodawcy, KrajZleceniodawcy)
values
(GETDATE(), '2023-01-01', 1, '2023-12-31', 'TEST PROJEKT', 100.00, 160*100.00, 'Tester automatyczny', 'Testowanie oprogramowania', 1, 'Fajna firma', '1159202311', 'Fajny Adres 15', '05-110', 'Fajne Miasto', 'Polska')
