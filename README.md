# RPDemoApp — ASP.NET Core Razor Pages Demo

A portfolio project built while working through Tim Corey's Razor Pages course as part of a structured .NET skills refresh.

## Overview

Front-end UI layer for **Gary's Diner**, a fictional restaurant management system. Consumes a shared `DataLibrary` class library to read and write data against a SQL Server database (`GarysDinerDB`) via Dapper.

## Tech Stack

- **Framework:** ASP.NET Core (.NET 10)
- **UI Pattern:** Razor Pages
- **Data Access:** Dapper (via DataLibrary)
- **Database:** SQL Server — `GarysDinerDB`

## Concepts Demonstrated

- Razor Pages model binding (`[BindProperty]`, `OnGet`, `OnPost`)
- Dependency injection and service lifetimes
- Async/await data access patterns
- Separation of concerns — UI delegates all data access to `DataLibrary`
- SQL Server stored procedure conventions

## Getting Started

1. Clone the repo and update the connection string in `appsettings.json`:
```json
   { "ConnectionStrings": { "Default": "Server=.;Database=GarysDinerDB;Trusted_Connection=True;" } }
```
2. Run with `dotnet run --project RPDemo`

## Related

- **[MVCDemo](https://github.com/garyturna/MVCDemo)** — companion project demonstrating the same stack using the MVC pattern.
