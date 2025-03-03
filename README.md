# Employee Performance and Project Tracking System

This is a .NET Core console application that tracks employee performance, projects, and financial reports. It uses **Entity Framework Core** for database operations, **Dapper** for optimized queries, and **Redis** for caching frequently accessed data.

## Features

### Employee and Project Tracking
- Track employees, departments, and projects.
- Manage many-to-many relationships between employees and projects.

### Financial Reports
- Generate financial reports for total department salaries and project budgets.
- Compare performance of **EF Core** and **Dapper** for fetching reports.


### Bonus Calculation
- Calculate employee bonuses based on performance ratings and salaries.

## Prerequisites

Before running the project, ensure you have the following installed:

- **.NET Core SDK** (version 6.0 or later)
- **SQLite** (for the database)
- **Redis** (for caching)

## Setup

### Clone the Repository
```sh
git clone https://github.com/shahad-jeza/elm_training_Employee_Performance.git
cd elm_training_Employee_Performance
```

### Install Dependencies
Install the required NuGet packages:
```sh
dotnet restore
```

### Set Up the Database
- The application uses **SQLite** for the database.
- The database file (`EmployeePerformance.db`) will be created automatically when you run the application.
- If you want to reset the database, delete the `EmployeePerformance.db` file and re-run the application.



## Running the Application

### Build the Project
```sh
dotnet build
```

### Run the Application
```sh
dotnet run
```



## Contributing
Contributions are welcome! Feel free to fork the repository and submit pull requests.



