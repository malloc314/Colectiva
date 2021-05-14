![](https://raw.githubusercontent.com/malloc314/Colectiva/56233d5fa8c1497a04aa937fd4e64e13659ba75b/Docs/Colectiva-logo-v4.svg)

****

**Table of Contents**
- [Description](#description "Description")
- [Work environment](#work-environment "Work environment")
- [Project structure](#project-structure "Project structure")
- [Available endpoints](#available-endpoints "Available endpoints")

# Description
The colectiva mathematical engine allows you to generate **pseudo-probable** number sequences for games of chance based on **statistics** and **probability**. The current version of the application focuses on the draw of sequences for the Eurojackpot game.

# Work environment
The environment used to create the project.
                    
Tool | Version
------------- | :-------------:
C#  | `9.0`
ASP.NET Core | `5.0`
MS SQL Server | `18`

# Project structure
The backend application project created in the **REST API** standard with high responsiveness and security in mind has been divided into layers according to the principles of **Clean Architecture**.

Layer | Description
------------- | -------------
Application  | Business logic
Domain | Database entities
Infrastructure | Frameworks
WebAPI | Controllers

# Available endpoints
Currently available endpoints.

> Get the entire history of eurojackpot draws

- [x] **`GET` /api/HistoricalSequence/all** 

> Get historical sequence by serial number

- [x]  **`GET` /api/HistoricalSequence/sn/{sn}** 

****

> Draw pseudo-probable sequences from 1 to 16

- [x]  **`GET` /api/PseudoProbableSequence/qty/{Qty}**

> Get the entire pseudo-probable sequences

- [x]  **`GET` /api/PseudoProbableSequence/all**

> Add pseudo-probable sequences to database

- [x]  **`POST` /api/PseudoProbableSequence/add** 

> Get pseudo-probable sequences to database

- [x]  **`GET` /api/PseudoProbableSequence/id/{id}** 

> Delete pseudo-probable sequence by id

- [x]  **`DELETE` /api/PseudoProbableSequence/id/{id}** 

****

> User identification

- [x]  **`POST` api/Identity/Register** 

> User authentication

- [x]  **`POST` api/Identity/Login**  