# OmniUpdate Project Detailed Documentation

## Prerequisites

Before proceeding, ensure you have the following tools installed on your machine:

- **.NET SDK**: Required for running the .NET backend.
- **Node.js**: Necessary for the Vue.js frontend.
- **Rust**: Required for Tauri, a framework for building desktop applications with web technologies.
- **Docker**: Used for running PostgreSQL in a containerized environment.
- **pnpm**: An efficient package manager for JavaScript.

## Backend - OmniUpdate API

The backend of OmniUpdate is a .NET 8 project, integrating Dapper for object mapping and Entity Framework Core for database migrations.

### Setting Up the API

1. **Navigate to the API Directory**: Open a terminal and change the directory to where the OmniUpdate API project is located.

2. **Install Dependencies**: The .NET SDK will handle dependency restoration automatically. Ensure all dependencies specified in the `OmniUpdate.Api.csproj` file are correctly installed.

### Running the API

- Execute the .NET API with the following command:
  ```sh
  dotnet run --project OmniUpdate.Api/OmniUpdate.Api.csproj
  ```
- This command compiles and runs the .NET application, starting the API server.

## Frontend - OmniUpdate Web

The frontend is a modern web application utilizing Vue.js for the user interface and Tauri for embedding it into a native desktop application.

### Preparing the Web Project

1. **Install Node.js and Rust**: These are prerequisites for Vue.js and Tauri, respectively.

2. **Navigate to the Web Project Directory**: Open a terminal and move to the OmniUpdate.Web directory.

3. **Install Project Dependencies**: Run the following command to install all necessary dependencies:
   ```sh
   cd OmniUpdate.Web
   pnpm install
   ```

### Running the Web Application

- Start the Vue.js development server with Tauri integration using:
  ```sh
  pnpm run dev
  ```
- This command serves the web application on a local server and wraps it with Tauri for desktop application capabilities.

## Docker Compose and PostgreSQL

The project uses Docker Compose to orchestrate the PostgreSQL database server.

### Using Docker Compose

1. **Ensure Docker is Running**: Verify that Docker is installed and running on your machine.

2. **Start PostgreSQL Server**: In the terminal, navigate to the root directory of the project where the `docker-compose.yml` file is located and run:
   ```sh
   docker-compose up
   ```
- This command starts the PostgreSQL server as specified in the `docker-compose.yml` file.

### Database Connection Setup

- To connect the application to the PostgreSQL server, configure the connection string as follows:
  ```powershell
  dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost; Database=OmniUpdate; Username=OmniUpdate; Password=OmniUpdate;"
  ```

## Entity Framework Core Migrations

Entity Framework Core is utilized for database migration management in the .NET backend.

### Managing Migrations

1. **Create a New Migration**: If you modify the data models, create a new migration using:
   ```sh
   dotnet ef migrations add [MigrationName]
   ```
   - Replace `[MigrationName]` with a meaningful name for the migration.

2. **Update Database**: Apply the new migrations to the database with:
   ```sh
   dotnet ef database update
   ```
- **Note**: You may need to install the `dotnet-ef` tool globally using `dotnet tool install --global dotnet-ef`.

### Additional Resources

- For more in-depth information on Entity Framework Core and its migration capabilities, refer to the [Entity Framework Core documentation](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/).
