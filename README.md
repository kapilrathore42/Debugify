# Debugify

Debugify is a .NET 9.0 application designed to assist with debugging steps and issue tracking. It leverages various technologies including MediatR, Entity Framework Core, Serilog, and more.

## Table of Contents

- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [License](#license)

## Getting Started

These instructions will help you set up and run the project on your local machine for development and testing purposes.

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. Clone the repository:
git clone https://github.com/yourusername/Debugify.git
cd Debugify
    
2. Open the solution in Visual Studio 2022:
    
start Debugify.sln

3. Restore the NuGet packages:
dotnet restore
4. Update the database connection string in `appsettings.json` in the `Debugify.API` project.

5. Apply migrations to the database:

## Project Structure

The solution is divided into several projects:

- **Debugify.API**: The main entry point of the application, containing the API controllers and startup configuration.
- **Debugify.Application**: Contains the application logic, including commands, queries, and handlers.
- **Debugify.Domain**: Defines the domain entities and business logic.
- **Debugify.Infrastructure**: Contains the data access logic, including Entity Framework Core configurations and repositories.

## Contributing

Contributions are welcome! Please fork the repository and create a pull request with your changes.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
