# TE_assignment_2025

TE Assignment – Project & Skill Management System

This is an ASP.NET Core MVC web application developed as part of a Technical Evaluation (TE) assignment.
The application manages projects and their associated skills using a many-to-many relationship, built with Entity Framework Core and MySQL.

🔹 Key Features

Create, view, update, and delete projects

Assign multiple skills to a project

Manage project status (active/inactive)

Search projects by name or description

Display assigned skills for each project

Server-side validation using Data Annotations

Clean MVC architecture (Controllers, Views, Models)

EF Core migrations for database schema management

🔹 Tech Stack

ASP.NET Core MVC (.NET 8)

Entity Framework Core

MySQL (Pomelo Provider)

Bootstrap (UI styling)

LINQ

Code-First Migrations

🔹 Database Design

Projects table

Skills table

ProjectSkill join table (many-to-many mapping)

**********How to Run**********

Configure the MySQL connection string in appsettings.json

Run EF Core migrations:

Add-Migration InitialCreate
Update-Database


Run the project using Visual Studio or dotnet run

Open:

https://localhost:<port>/Projects
