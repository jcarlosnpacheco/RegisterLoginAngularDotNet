# RegisterLoginAngularDotNet

## Overview

**RegisterLoginAngularDotNet** is a full-stack web application that demonstrates user registration and login functionality using Angular for the frontend and ASP.NET Core for the backend. The project showcases how to implement authentication, authorization, and secure communication between a modern SPA and a RESTful API.

---

## Features

- User registration and login
- JWT-based authentication
- Role-based authorization
- Secure password hashing
- Angular SPA frontend
- ASP.NET Core Web API backend
- CORS configuration for cross-origin requests

---

## Technologies Used

- **Frontend:** Angular (TypeScript)
- **Backend:** ASP.NET Core (.NET 8)
- **Authentication:** JWT (JSON Web Tokens)
- **Database:** (Typically SQL Server or SQLite; check the project for details)

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Node.js & npm](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)

### Backend Setup

1. Navigate to the backend project directory.
2. Restore dependencies: dotnet restore
3. Update the database connection string in `appsettings.json` if needed.
4. Run database migrations (if applicable): dotnet ef database update
5. Start the API: dotnet run (f5)

### Frontend Setup

1. Navigate to the Angular project directory.
2. Install dependencies: npm install
3. Start the development server: ng serve
4. Access the app at [http://localhost:4200](http://localhost:4200).

---

## Usage

- Register a new user via the registration form.
- Log in with your credentials.
- Access protected routes based on your authentication status.
