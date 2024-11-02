# Day 10 Project

This project is a .NET application built using ASP.NET Core and Entity Framework Core. It is designed to demonstrate various features of a web application, including MVC architecture, database migrations, and logging.

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

   Run the following command to restore the NuGet packages:

   ```bash
   dotnet restore
   ```

3. **Build the project:**

   Build the project using the following command:

   ```bash
   dotnet build
   ```

4. **Run the application:**

   Start the application with:

   ```bash
   dotnet run
   ```

   The application will be available at `http://localhost:5000`.

## Configuration

The application uses `appsettings.json` and `appsettings.Development.json` for configuration. The logging configuration is set to log information level messages by default and warnings for `Microsoft.AspNetCore`.

json:appsettings.Development.json
startLine: 1
endLine: 8


## Database Migrations

Entity Framework Core is used for database migrations. To apply migrations, use the following command:


```bash
dotnet ef database update
```


To add a new migration, use:

```bash
dotnet ef migrations add <MigrationName>
```


## Project Structure

- **Controllers**: Contains the MVC controllers for handling HTTP requests.
- **Models**: Contains the data models used in the application.
- **Migrations**: Contains the Entity Framework Core migrations.
- **Views**: Contains the Razor views for the application.
- **wwwroot**: Contains static files like CSS, JavaScript, and images.

## Logging

The application uses ASP.NET Core's built-in logging framework. The logging configuration can be adjusted in the `appsettings.json` files.

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments

- ASP.NET Core Documentation
- Entity Framework Core Documentation
