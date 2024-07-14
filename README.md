# NBA Athlete Management App

## Description
This is a simple web application built using ASP.NET Core that allows users to manage athlete information. The application includes user authentication and authorization features provided by ASP.NET Core Identity.

## Features
- Add new NBA athletes
- Update existing athlete information
- Delete athletes
- View all athletes in the database

## Technologies Used
- ASP.NET Core
- Entity Framework Core
- SQL Server Express
- Bootstrap for styling

## Getting Started

### Prerequisites
- .NET Core SDK
- SQL Server Express

### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/nba-athlete-management.git
    cd nba-athlete-management
    ```

2. Configure the database connection in `appsettings.json`:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Your SQL Server connection string here"
      }
    }
    ```

3. Apply migrations to set up the database:
    ```bash
    dotnet ef database update
    ```

4. Run the application:
    ```bash
    dotnet run
    ```
