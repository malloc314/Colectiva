﻿![](https://raw.githubusercontent.com/malloc314/Colectiva/7cf40579acf6e195de5f3ca3a82678b738973af2/Docs/Colectiva-logo-v1.svg)

****

**Table of Contents**
- [Description](#description "Description")
- [Work environment](#work-environment "Work environment")
- [Project structure](#project-structure "Project structure")
- [Available endpoints](#available-endpoints "Available endpoints")
- [Available solutions](#available-solutions "Available solutions")

# Description
The colectiva mathematical engine allows you to generate **pseudo-probable** number sequences for games of chance based on **statistics** and **probability**. The current version of the application focuses on the draw of sequences for the Eurojackpot game.

# Work environment
The environment used to create the project:
                    
Tool | Version
------------- | :-------------:
C#  | `9.0`
ASP.NET Core | `5.0`
MS SQL Server | `18`

# Project structure
The backend application project created in the **REST API** standard with high responsiveness and security in mind has been divided into layers according to the principles of **Clean Architecture**:

Layer | Description
------------- | -------------
Application  | Business logic
Domain | Database entities
Infrastructure | Frameworks
WebAPI | Controllers

# Available endpoints
Currently implemented and available endpoints.

> Get the entire history of eurojackpot draws

- [x] **`GET` /api/HistoricalSequence** 

> Get historical sequence by serial number

- [x]  **`GET` /api/HistoricalSequence/{sn}** 

> Get pseudo-probable sequences from 1 to 16

- [x]  **`GET` /api/PseudoProbableSequence/{Qty}** 

> User identification

- [ ]  **`POST` api/** 

> User authentication

- [ ]  **`POST` api/**  


# Available solutions