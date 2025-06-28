Purpose and Scope

This document provides a high-level overview of the School Management System, an ASP.NET Core MVC web application designed to manage academic data for educational institutions. The system handles core academic entities including students, instructors, departments, courses, and course results through a web-based interface.

This overview covers the system's architecture, key components, and technology stack. For detailed information about specific subsystems, see Architecture for design patterns, Controllers for request handling logic, Database Schema for data persistence details, and Project Configuration for development setup.

System Architecture

The School Management System follows the Model-View-Controller (MVC) architectural pattern built on ASP.NET Core 8.0. The application uses Entity Framework Core for data access and SQL Server for data persistence.

High-Level Component Structure
Validation Layer
Data Access Layer
Domain Layer
Application Layer
Web Layer
Browser Client
Razor Views
(.cshtml files)
HomeController
StudentController
InstructorController
DepartmentController
CourseController
crsResultController
Student Model
Instructor Model
Department Model
Course Model
crsResult Model
SchoolContext
(DbContext)
Entity Framework Core
SQL Server Database
UniqueAttribute
(Custom Validator)
ModelState Validation
Sources: 
Day 10/Context/SchoolContext.cs
7-23
 
Day 10/Day 10.csproj
1-43

Core Components

The system consists of five main controllers that manage CRUD operations for their respective domain entities, all coordinated through a central SchoolContext class.

Controller and Model Mapping
Data Context
Models
Controllers
HomeController
(Navigation & Cookies)
StudentController
(Student CRUD)
InstructorController
(Instructor CRUD)
DepartmentController
(Department CRUD)
CourseController
(Course CRUD)
crsResultController
(Grade Management)
Student
(Id, name, age, parentNum, image, dept_id)
Instructor
(Id, name, address, salary, image, course_id, dept_id)
Department
(Id, name, Manager)
Course
(Id, name, minDegree, dept_id)
crsResult
(Id, degree, course_id, student_id)
SchoolContext
(DbContext)
Students DbSet
Instructors DbSet
Departments DbSet
Courses DbSet
crsResults DbSet
Sources: 
Day 10/Context/SchoolContext.cs
17-21

Technology Stack

Component	Technology	Version
Framework	ASP.NET Core	8.0
Language	C#	Latest
ORM	Entity Framework Core	8.0.8
Database	SQL Server	Local Instance
Frontend	Razor Views + jQuery	Built-in
Validation	Custom Attributes + ModelState	Built-in
Key Dependencies
The application relies on two primary NuGet packages for data access:

Microsoft.EntityFrameworkCore.SqlServer (8.0.8) - SQL Server provider for Entity Framework Core
Microsoft.EntityFrameworkCore.Tools (8.0.8) - Migration and scaffolding tools
Sources: 
Day 10/Day 10.csproj
32-36
 
Day 10/Day 10.csproj
4-7

Domain Model Overview

The system manages five core academic entities with well-defined relationships representing a typical educational institution structure.

Entity Relationships
enrolls
employs
offers
taught_by
generates
achieves
Department
int
Id
PK
Primary Key
string
name
Department Name
string
Manager
Department Manager
Student
int
Id
PK
Primary Key
string
name
Student Name (Max 23 chars)
int
age
Student Age
int
parentNum
Parent Phone Number
string
image
Profile Image Path (Nullable)
int
dept_id
FK
Foreign Key to Department
Instructor
int
Id
PK
Primary Key
string
name
Instructor Name
string
address
Instructor Address
int
salary
Instructor Salary
string
image
Profile Image Path (Nullable)
int
course_id
FK
Foreign Key to Course
int
dept_id
FK
Foreign Key to Department
Course
int
Id
PK
Primary Key
string
name
Course Name
double
minDegree
Minimum Passing Grade
int
dept_id
FK
Foreign Key to Department
crsResult
int
Id
PK
Primary Key
double
degree
Student Grade
int
course_id
FK
Foreign Key to Course
int
student_id
FK
Foreign Key to Student
Sources: 
Day 10/Context/SchoolContext.cs
17-21

Request Processing Flow

The application follows standard ASP.NET Core MVC request processing patterns with Entity Framework Core for data persistence.

Typical CRUD Request Flow
Razor View
SQL Server
Entity Framework Core
SchoolContext
MVC Controller
ASP.NET Core Router
Browser
Razor View
SQL Server
Entity Framework Core
SchoolContext
MVC Controller
ASP.NET Core Router
Browser
"HTTP Request (e.g., GET /Student/GetAll)"
"Route to StudentController.GetAll()"
"context.Students.Include(s => s.dept)"
"LINQ to SQL Translation"
"SELECT * FROM Students JOIN Departments..."
"Result Set"
"List<Student> with Department data"
"Student entities"
"Model data passed to GetAll.cshtml"
"Rendered HTML"
"HTTP Response"
"HTML Page"
Sources: 
Day 10/Context/SchoolContext.cs
9-12

Key Features

The School Management System provides the following core functionality:

Student Management: Complete CRUD operations for student records including profile images and department assignment
Instructor Management: Instructor profiles with course assignments and department affiliations
Department Management: Organizational structure with department managers
Course Management: Course catalog with minimum grade requirements and department associations
Grade Management: Course result tracking linking students to courses with grades
Data Validation: Custom validation attributes including uniqueness constraints
Image Upload: Profile image support for students and instructors
The system uses a single SchoolContext class inheriting from DbContext to manage all database operations, with connection string configured for local SQL Server instance.
