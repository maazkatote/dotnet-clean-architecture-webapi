# Employee Management System API


A sample **enterprise-grade Employee Management System Web API** built using **.NET Core**, **Clean Architecture**, and **SQL Server stored procedures**. This project demonstrates best practices in backend development, architecture design, and database performance optimization.


---


## 🔹 Key Highlights


- Clean Architecture implementation
- RESTful Web API using ASP.NET Core
- SQL Server stored procedures–based data access
- Dapper for lightweight ORM
- Pagination and performance-focused queries
- Scalable, maintainable, and testable design


This repository is intended as a **portfolio-quality reference project** for senior-level .NET development.


---


## 🛠 Tech Stack


- **.NET Core Web API**
- **C#**
- **ASP.NET Core MVC**
- **SQL Server**
- **Dapper**
- **Clean Architecture**


---


## 📐 Architecture Overview


The solution follows **Clean Architecture principles**, ensuring separation of concerns and long-term maintainability.

### Layer Responsibilities


- **Domain**: Core business entities and repository contracts
- **Application**: Business logic, DTOs, and service abstractions
- **Infrastructure**: SQL Server access, Dapper implementation, stored procedures
- **API**: Controllers, request handling, dependency injection


---

## 🏗️ Clean Architecture Overview

```mermaid
flowchart TB

Client["Client / Frontend"]
API["API Layer\nControllers, Middleware"]
Application["Application Layer\nUse Cases, DTOs, Interfaces"]
Domain["Domain Layer\nEntities, Value Objects, Business Rules"]
Infrastructure["Infrastructure Layer\nEF Core, Repositories, Auth, External Services"]

Client --> API
API --> Application
Application --> Domain
Application --> Infrastructure
Infrastructure --> Application




## 📁 Project Structure

EmployeeManagementSystem │ ├── EmployeeManagement.API │ └── Controllers │ ├── EmployeeManagement.Application │ ├── DTOs │ ├── Interfaces │ └── Services │ ├── EmployeeManagement.Domain │ ├── Entities │ └── Interfaces │ ├── EmployeeManagement.Infrastructure │ └── Repositories │ └── database ├── tables ├── stored-procedures └
