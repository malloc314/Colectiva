![](https://raw.githubusercontent.com/malloc314/Colectiva/555a79d9101038fff21ec8c0007544d171622d18/Docs/Colectiva-logo-v2.svg)

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

- [x] **`GET` /api/HistoricalSequence** 

> Get historical sequence by serial number

- [x]  **`GET` /api/HistoricalSequence/{sn}** 

> Get pseudo-probable sequences from 1 to 16

- [x]  **`GET` /api/PseudoProbableSequence/{Qty}** 

> Add pseudo-probable sequences to database [FromQuery]

- [x]  **`POST` /api/PseudoProbableSequence** 

> User identification

- [ ]  **`POST` api/** 

> User authentication

- [ ]  **`POST` api/**  