# ExpenseTracker

A simple ASP.NET Core Web API for tracking personal expenses. The app stores data in memory while the server is running, so the data is lost if the application is stopped.

## Features
- Create, list, get, and delete expenses
- Validation for required title and positive amount values
- Summary endpoint with totals and category breakdown
- Swagger UI for testing the API in a browser

## Prerequisites
Before running the project, make sure .NET 8 SDK is installed on your computer.

Check it with this command in PowerShell:
```powershell
dotnet --version
```

If this command does not work, install the .NET 8 SDK from the official Microsoft website.

## Open the project folder
Open PowerShell and go to the folder that contains the project.

Example:
```powershell
cd C:\path\to\ExpenseTracker
```

Replace the path above with the actual folder where you saved the project.

## Restore dependencies
Run this command:
```powershell
dotnet restore
```

## Build the project
Run this command:
```powershell
dotnet build
```

## Start the API
Run this command:
```powershell
dotnet run --project .\ExpenseTracker.csproj --urls http://localhost:5005
```

This starts the application. After it starts, open this address in your browser:
```text
http://localhost:5005/swagger
```

You can also open:
```text
http://localhost:5005/
```

## Test the API
Open Swagger in your browser and try the endpoints.

### Example request to create an expense
Use this JSON body in the POST request:
```json
{
  "title": "Lunch",
  "amount": 250,
  "category": "Food"
}
```

## API endpoints
- GET /api/expenses
- GET /api/expenses/{id}
- POST /api/expenses
- DELETE /api/expenses/{id}
- GET /api/expenses/summary

## Project files
- Controllers/
- Models/
- Services/
- Program.cs
- queries.sql
- ExpenseTracker.postman_collection.json