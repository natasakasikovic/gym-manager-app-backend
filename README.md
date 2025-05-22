<a id="readme-top"/>

[![Build Status](https://img.shields.io/github/actions/workflow/status/natasakasikovic/gym-manager-app-backend/build.yml?branch=master&style=for-the-badge)](https://github.com/natasakasikovic/gym-manager-app-backend/actions/workflows/build.yml)
[![Last Commit](https://img.shields.io/github/last-commit/natasakasikovic/gym-manager-app-backend?branch=main&style=for-the-badge)](https://github.com/natasakasikovic/gym-manager-app-backend/commits/main)

<div align="center">
  <h1 align="center">GymManagerApp API</h1>
  <p align="center">
    <i>GymManagerApp is an API designed for managing gym training sessions, training types, and users!</i>
    <br />
    <br />
    <a href="https://github.com/natasakasikovic/gym-manager-app-backend/issues/new?labels=bug&template=bug-report---.md">Report Bug</a>
  </p>
</div>

<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#architecture">Architecture</a></li>
    <li><a href="#features">Features</a></li>
  </ol>
</details>

## 🧠 About The Project

This is a small-scale project demonstrating **Clean Architecture**, adhering to **SOLID principles**, and drawing inspiration from **Domain-Driven Design (DDD)**. It also incorporates the **CQRS pattern** with **MediatR** to showcase a *structured*, *testable*, and *maintainable* approach to modern software development.

### 🛠️ Built With 

- [![.NET][DotNetBadge]][DotNet-url]
- [![Entity Framework][EFCoreBadge]][EFCore-url]
- [![MediatR][MediatRBadge]][MediatR-url]
- [![FluentValidation][FluentValidationBadge]][FluentValidation-url]

## 🚀 Getting Started

###  🧰 Prerequisites

This project requires the following tools installed on your machine:

    .NET 9 SDK

    PostgreSQL

###  ⚙️ Installation

1. Clone the repository
   ```sh
   git clone https://github.com/natasakasikovic/gym-manager-app-backend.git
   cd gym-manager-app-backend
   ```
   
2. Set up database credentials.
  Edit the appsettings.json file in the Presentation project:

   ```sh
   "ConnectionStrings": {
    "DefaultConnection": "Host=HOST;Database=DATABASE;Username=USERNAME;Password=PASSWORD"
   }
      ```

3. Apply migrations and create the database

    ```sh
    dotnet ef database update --project Infrastructure --startup-project Presentation
    ```

4. Run the application

    ```sh
      dotnet run --project Presentation
    ```

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## 🧱 Architecture

![Architecture Diagram](https://www.milanjovanovic.tech/blogs/mnw_004/clean_architecture.png?imwidth=3840)

- **Domain**

  This layer contains entities and enums. Business logic is encapsulated within the entities themselves. It is entirely independent of any frameworks, which ensures maximum flexibility, maintainability, and reusability.

- **Application**

  Like the domain layer, this one is also independent of the UI and database. It communicates with the infrastructure through **interfaces**, making it easily testable and adaptable.
  It follows the **CQRS** pattern using **MediatR**, allowing separation of read and write logic, and simplifying the handling of **cross-cutting concerns**.
  Two important MediatR behaviors are implemented in this layer:
  
     - **Logging behavior** – used to track and log request execution for better monitoring and debugging.
  
     - **Validation behavior** – used to enforce validation rules before the handler logic is executed, based on **FluentValidation**.
  
  The IDateTime interface is introduced to **avoid direct dependency on system DateTime**, and also to allow easy mocking during unit testing, which significantly improves testability.

- **Infrastructure**

  This layer handles external concerns such as **persistence**, **identity**, and other integrations. It provides the concrete implementations for the interfaces defined in the application layer. If there is a need to switch to a different database or identity provider, only this layer needs to change, while **Domain** and **Application** layers remain untouched.

- **Presentation**

  This is the entry point of the application. It contains **API controllers**, **endpoints**, and **handles centralized error management** via *BaseApiController*. It interacts with the application layer to execute commands and queries, serving as the interface between the user and the core logic.

## ✨ Features

- **User Authentication**
  - User registration and login functionality.
  - Secured with JWT tokens.
  
- **Training Management**
  - Create, update, fetch training sessions
  - Sign up for trainings
  
- **Training Type Management**
  - Create, update, fetch training types
    
<p align="right">(<a href="#readme-top">back to top</a>)</p>

[DotNetBadge]: https://img.shields.io/badge/.NET%209-512BD4?style=for-the-badge&logo=dotnet&logoColor=white
[DotNet-url]: https://dotnet.microsoft.com/
[EFCoreBadge]: https://img.shields.io/badge/Entity%20Framework%20Core-6DB33F?style=for-the-badge&logo=dotnet&logoColor=white
[EFCore-url]: https://learn.microsoft.com/en-us/ef/core/
[MediatRBadge]: https://img.shields.io/badge/MediatR-000000?style=for-the-badge&logo=mediatr&logoColor=white
[MediatR-url]: https://github.com/jbogard/MediatR
[FluentValidationBadge]: https://img.shields.io/badge/FluentValidation-000000?style=for-the-badge&logo=checkmarx&logoColor=white
[FluentValidation-url]: https://fluentvalidation.net/
