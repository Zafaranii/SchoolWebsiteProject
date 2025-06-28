# School Management System

A comprehensive ASP.NET Core MVC web application designed to manage academic data for educational institutions. 

## Overview

The School Management System handles core academic entities including students, instructors, departments, courses, and course results through a web-based interface. [1](#0-0)  The system follows the Model-View-Controller (MVC) architectural pattern built on ASP.NET Core 8.0 with Entity Framework Core for data access and SQL Server for data persistence. 

## Technology Stack

| Component | Technology | Version |
|-----------|------------|---------|
| Framework | ASP.NET Core | 8.0 |
| Language | C# | Latest |
| ORM | Entity Framework Core | 8.0.8 |
| Database | SQL Server | Local Instance |
| Frontend | Razor Views + jQuery | Built-in |
| Validation | Custom Attributes + ModelState | Built-in |

### Key Dependencies

The application relies on two primary NuGet packages for data access: [2](#0-1) 

- `Microsoft.EntityFrameworkCore.SqlServer` (8.0.8) - SQL Server provider for Entity Framework Core
- `Microsoft.EntityFrameworkCore.Tools` (8.0.8) - Migration and scaffolding tools

## Prerequisites

- .NET SDK 8.0 or later
- A code editor like Visual Studio or Visual Studio Code

## Getting Started

1. **Clone the repository:**
   ```bash
   git clone <repository-url>
   cd Day-10
   ```

2. **Restore the dependencies:**
   ```bash
   dotnet restore
   ```

3. **Build the project:**
   ```bash
   dotnet build
   ```

4. **Run the application:**
   ```bash
   dotnet run
   ```
   The application will be available at `http://localhost:5000`.

## Database Setup

Entity Framework Core is used for database migrations. To apply migrations:

```bash
dotnet ef database update
```

To add a new migration:

```bash
dotnet ef migrations add <MigrationName>
```

## System Architecture

The system consists of six main controllers that manage CRUD operations for their respective domain entities: [3](#0-2) 

- **HomeController** - Navigation & Cookies
- **StudentController** - Student CRUD operations [4](#0-3) 
- **InstructorController** - Instructor CRUD operations [5](#0-4) 
- **DepartmentController** - Department CRUD operations [6](#0-5) 
- **CourseController** - Course CRUD operations [7](#0-6) 
- **crsResultController** - Grade Management [8](#0-7) 

## Domain Model

The system manages five core academic entities:

### Student
- Id (Primary Key)
- name (Student Name, Max 23 chars)
- age (Student Age)
- parentNum (Parent Phone Number)
- image (Profile Image Path, Nullable)
- dept_id (Foreign Key to Department)

### Instructor
- Id (Primary Key) [9](#0-8) 
- name (Instructor Name)
- address (Instructor Address)
- salary (Instructor Salary)
- image (Profile Image Path, Nullable)
- course_id (Foreign Key to Course)
- dept_id (Foreign Key to Department)

### Department
- Id (Primary Key)
- name (Department Name)
- Manager (Department Manager)

### Course
- Id (Primary Key)
- name (Course Name)
- minDegree (Minimum Passing Grade)
- dept_id (Foreign Key to Department)

### crsResult
- Id (Primary Key)
- degree (Student Grade)
- course_id (Foreign Key to Course)
- student_id (Foreign Key to Student)

## Key Features

- **Student Management**: Complete CRUD operations for student records including profile images and department assignment
- **Instructor Management**: Instructor profiles with course assignments and department affiliations
- **Department Management**: Organizational structure with department managers
- **Course Management**: Course catalog with minimum grade requirements and department associations
- **Grade Management**: Course result tracking linking students to courses with grades
- **Data Validation**: Custom validation attributes including uniqueness constraints [10](#0-9) 
- **Image Upload**: Profile image support for students and instructors

## Project Structure

- **Controllers**: Contains the MVC controllers for handling HTTP requests
- **Models**: Contains the data models used in the application
- **Context**: Contains the Entity Framework DbContext
- **Migrations**: Contains the Entity Framework Core migrations
- **Views**: Contains the Razor views for the application
- **Validators**: Contains custom validation attributes
- **wwwroot**: Contains static files like CSS, JavaScript, and images

## Configuration

The application uses `appsettings.json` and `appsettings.Development.json` for configuration.  The logging configuration is set to log information level messages by default and warnings for `Microsoft.AspNetCore`. 

## License

This project is licensed under the MIT License - see the LICENSE file for details. 

## Notes

The system uses a single `SchoolContext` class inheriting from `DbContext` to manage all database operations, with connection string configured for local SQL Server instance.  All controllers follow consistent patterns for CRUD operations, data validation, and error handling using Entity Framework Core methods. [11](#0-10) 
