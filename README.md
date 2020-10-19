# Eshop - Joachim

## Introduktion

Projekt Eshop er en opgave der bygger p� undervisning af Entity Framework core (Database OR/M) d�kker over:
1. Model Creating
2. Querying Data
3. Ordering-Filtering-Paging
4. Saving data
5. Arkitektur
6. Unit Test
7. Logging og Dokumentation
8. (Deployment)

### Opgave Beskrivelse

Kan l�ses [her](https://ilearn.eucsyd.dk/mod/page/view.php?id=231472) p� Ilearn.

## Arkitektur
Programmet er bygget op i flere dele indtil videre er den opbygget i fire dele.
- Datalayer: som st�r for komunikationen med databasen
- ServiceLayer: der st�r for overs�ttelse fra datalayer til frontend
- ConsoleApp: som er midlertidigt Fromntend
- UnitTest: Til test af de forskellige funktioner

## Foruds�tning og installation
Der forventes at der bruges Visual Studio.

Der skal installeres disse NuGet pakker til f�lgene projekter:
- Datalayer
  - Microsoft.EntityFrameworkCore.SqlServer (3.1.8)
  - Microsoft.EntityFrameworkCore.Tools (3.1.8)
  - Microsoft.EntityFrameworkCore.Logging (3.1.8)
  - Microsoft.EntityFrameworkCore.Logging.Console (3.1.8)
- ConsoleApp
  - Microsoft.EntityFrameworkCore.Design (3.1.8)
- UnitTest
  - Microsoft.EntityFrameworkCore (3.1.8)
  - Microsoft.EntityFrameworkCore.InMemory (3.1.8)

## Komponenter til Software l�sningen

- [x] Database der bliver h�ndterret af Entity Framework Core
- [x] At der bliver fulgt Data Layer -> Service Layer -> Frontend arkitektur
-  Entiteter:
   -  [x] Brand
      -  [ ] CRUD
      -  [ ] Billeder
   -  [X] Tag
      -  [ ] CRUD
   -  [x] Product
      -  [x] CRUD
      -  [ ] Billeder
   -  [ ] User
      -  [ ] CRUD
   -  [ ] Cart / Order
      -  [ ] CRUD
-  [x] Filtrer
-  [x] Sorter
-  [x] Paging
-  [x] UnitTest
-  [ ] Dokument database til Egenskaber p� produkter
-  [ ] Seeding med Json
-  [x] Cookie darkmode

## ER diagram
![EfDiagram](ERDiagram.PNG)