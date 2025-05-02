JobTracker

JobTracker is a simple ASP.NET Core application designed to help users track their job applications. Built with Entity Framework Core and SQLite, this backend-focused project provides basic functionality for managing users and job submissions.

Features

User authentication with seeded applicant and admin accounts
CRUD operations for job applications
Entity Framework Core with SQLite for data persistence
Modular architecture with Controllers, Services, Repositories, and DTOs
Seeded data for initial testing and development
Getting Started

Prerequisites
.NET 9.0 SDK
SQLite
Installation
Clone the repository:
git clone https://github.com/KennyBDykes/JobTracker.git
cd JobTracker
Restore dependencies:
dotnet restore
Apply migrations and update the database:
dotnet ef database update
Run the application:
dotnet run
The application will start and listen on http://localhost:5047.

Usage

Access the application via the browser at http://localhost:5047.
Use the seeded credentials to log in as an applicant or admin.
Perform CRUD operations on job applications.
Project Structure

Controllers/ – Handles HTTP requests and responses.
DTO/ – Data Transfer Objects for request and response models.
DbContext/ – Entity Framework Core database context.
Enums/ – Enumeration types used across the application.
Migrations/ – Database migration files.
Models/ – Entity models representing database tables.
Repositories/ – Data access logic.
Services/ – Business logic and service layer.
Program.cs – Application entry point and configuration.
