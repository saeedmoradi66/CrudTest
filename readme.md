# Customer Management System

A production-ready CRUD application built with **Clean Architecture**, **DDD**, **TDD**, and **CQRS** patterns in ASP.NET Core.

## 🏗️ Architecture

This project demonstrates enterprise-level software design:

- **Clean Architecture** — strict separation of concerns across layers
- **Domain-Driven Design (DDD)** — rich domain model with aggregates and value objects
- **CQRS** — separate read/write models via MediatR
- **TDD + BDD** — full test coverage with xUnit and SpecFlow

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Backend | ASP.NET Core 8, C# |
| ORM | Entity Framework Core |
| Database | SQL Server  |
| Frontend | Blazor WebAssembly |
| Testing | xUnit, SpecFlow (BDD), FluentAssertions |
| Patterns | MediatR (CQRS), AutoMapper |

## 📁 Project Structure
Mc2.CrudTest/

├── Mc2.CrudTest.Domain/ # Entities, Value Objects, Domain Events

├── Mc2.CrudTest.Application/ # CQRS Commands/Queries, DTOs

├── Mc2.CrudTest.Infrastructure/ # EF Core, Repositories

├── Mc2.CrudTest.Presentation/ # Blazor WebAssembly

└── Mc2.CrudTest.AcceptanceTests/ # BDD Tests with SpecFlow

✅ Key Features
Create, Read, Update, Delete customers
Domain validation (unique email, valid phone number, IBAN validation)
Full test suite: Unit Tests + Acceptance Tests
Clean separation between domain logic and infrastructure
🚀 Getting Started
bash

git clone https://github.com/saeedmoradi66/CrudTest.git

cd CrudTest

dotnet restore

dotnet ef database update --project Mc2.CrudTest.Infrastructure

dotnet run --project Mc2.CrudTest.Presentation

🧪 Running Tests
bash

dotnet test

📐 Design Decisions
Value Objects for Email, PhoneNumber, and BankAccountNumber to enforce domain invariants
MediatR pipeline for cross-cutting concerns (validation, logging)
Repository pattern abstracted behind interfaces for testability
